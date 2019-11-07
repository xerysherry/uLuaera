using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LuaMono : MonoBehaviour
{
    public static LuaMono Get(string name)
    {
        LuaMono t = null;
        _store.TryGetValue(name, out t);
        return t;
    }
    static void Register(LuaMono m)
    {
        if(m == null)
            return;
        var name = m.name;
        var index = name.IndexOf("(Clone)");
        if(index >= 0)
            name = name.Substring(0, index);
        _store.Add(name, m);
    }
    static void UnRegister(LuaMono m)
    {
        if(m == null)
            return;
        var name = m.name;
        var index = name.IndexOf("(Clone)");
        if(index >= 0)
            name = name.Substring(0, index);
        _store.Remove(name);
    }
    static Dictionary<string, LuaMono> _store = new Dictionary<string, LuaMono>();

    /// <summary>
    /// 检查数据是否存在
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static bool ExistStaticValue(string name, string valuename)
    {
        return _value_store.ContainsKey(name);
    }
    /// <summary>
    /// 设置注册数据（Lua状态机与C#关联）
    /// </summary>
    public static void SetValue(string valuename, object o)
    {
        if(o == null)
            _value_store.Remove(valuename);
        else
            _value_store[valuename] = o;
    }
    /// <summary>
    /// 获取注册的数据
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    /// <param name="valuename">参数名</param>
    /// <returns></returns>
    public static T GetValue<T>(string valuename)
    {
        object o = null;
        if(!_value_store.TryGetValue(valuename, out o))
            return default(T);
        return (T)o;
    }
    /// <summary>
    /// 获取注册数据
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static object GetValue(string valuename)
    {
        object o = null;
        _value_store.TryGetValue(valuename, out o);
        return o;
    }

    static Dictionary<string, object> _value_store = new Dictionary<string, object>();

    static void Log(object message)
    {
        Debug.Log(message);
    }
    static void Log(object message, Object context)
    {
        Debug.Log(message, context);
    }
    static void LogError(object message)
    {
        Debug.LogError(message);
    }
    static void LogError(object message, Object context)
    {
        Debug.LogError(message, context);
    }

    static readonly string[] kLuaScript = new string[]
    {
        " return function(...) ",
        " \xd\xa end ",
    };

    void Include(Lua.Param param)
    {
        var state = new Lua.State(param.state);
        if(param.GetCount() <= 0)
            return;

        var name = param.GetString(1);
        if(string.IsNullOrEmpty(name))
            return;

        var s = Lua.Resource.Load(name);
        if(string.IsNullOrEmpty(s))
            return;
        if(state.dostring(s, name) != Lua.Error.LUA_OK)
        {
            OnError(state_.last_error_string, false);
            Debug.LogError(state_.last_error_string);
        }
        param.state.Pop(-1);
        param.ReturnCount = 0;
    }
    void Prepare()
    {
        // 状态机检查
        if(state_ != null)
            return;

        var script = Lua.Resource.Load(
            string.Concat(Lua.Singleton.kStartLuaScript, gameObject.name));
        if(!string.IsNullOrEmpty(script))
        {
            state_ = Lua.Singleton.newthread();
            state_.register("require", param =>
            {
                var state = param.state;
                var top = state.GetTop();
                var name = param.GetString(1);
                var s = Lua.Resource.Load(name);
                if (string.IsNullOrEmpty(s))
                    return;
                if(state_.dostring(s, name) != Lua.Error.LUA_OK)
                {
                    OnError(state_.last_error_string, false);
                    Debug.LogError(state_.last_error_string);
                    return;
                }

                var d = state.GetTop() - top;
                List<Lua.Ref> refs = null;
                if (d > 0)
                {
                    refs = new List<Lua.Ref>();
                    for (var i = 0; i < d; ++i)
                    {
                        refs.Add(new Lua.Ref(state));
                    }
                }
                state.Pop(1);
                if (refs != null)
                {
                    for (var i = 0; i < refs.Count; ++i)
                    {
                        refs[i].Push();
                    }
                }
                param.ReturnCount = d;
            });
            state_.register("include", Include);
            state_.register("using", Include);

            state_.dostring(
                kLuaScript[0] +
                script +
                kLuaScript[1],
                gameObject.name + ".lua");

            if(!state_.state.IsNil(-1))
            {
                using(var func = new Lua.Function(state_.state))
                {
                    func.Start();
                    if(!func.Call())
                    {
                        LuaMono.LogError(func.last_error_string);
                        func.ClearCall();
                        enabled = false;
                        return;
                    }
                    if(func.GetReturnCount() == 0)
                        Debug.Log("LuaMono Not Return");
                    else
                        obj_ = func.GetRef(1);
                    func.ClearCall();
                    func.Dispose();
                }

                var dict = GetFunctionDict();
                dict.TryGetValue("Awake", out awake_);
                dict.TryGetValue("Start", out start_);
                dict.TryGetValue("Update", out update_);
                dict.TryGetValue("FixedUpdate", out fixed_update_);
                dict.TryGetValue("LateUpdate", out late_update_);
                dict.TryGetValue("OnGUI", out on_gui_);
                dict.TryGetValue("OnEnable", out on_enable_);
                dict.TryGetValue("OnDisable", out on_disable_);
                dict.TryGetValue("OnDestroy", out on_destroy_);

                dict.TryGetValue("UpdateCoroutine", out update_coroutine_);

                CallWithoutReturn("SetGameObject", gameObject);
                CallWithoutReturn("SetMonoBehaviour", this);
            }
        }
    }

    protected void Awake()
    {
        Register(this);
        Prepare();
        if(state_ == null || GetFunctionDict().Count == 0)
        {
            enabled = false;
            GameObject.Destroy(this);
        }
        else
            DoFunction(awake_);
    }
    protected void Start()
    {
        DoFunction(start_);
    }
    protected void Update()
    {
        DoFunction(update_);
        DoFunction(update_coroutine_);
    }
    protected void FixedUpdate()
    {
        DoFunction(fixed_update_);
    }
    protected void LateUpdate()
    {
        DoFunction(late_update_);
    }
    protected void OnGUI()
    {
        DoFunction(on_gui_);
    }
    protected void OnEnable()
    {
        DoFunction(on_enable_);
    }
    protected void OnDisable()
    {
        DoFunction(on_disable_);
    }
    protected void OnDestroy()
    {
        UnRegister(this);
        DoFunction(on_destroy_);
        ClearState();
    }
    protected void ClearState()
    {
        if(awake_ != null)
        {
            awake_.Dispose();
            awake_ = null;
        }
        if(start_ != null)
        {
            start_.Dispose();
            start_ = null;
        }
        if(update_ != null)
        {
            update_.Dispose();
            update_ = null;
        }
        if(fixed_update_ != null)
        {
            fixed_update_.Dispose();
            fixed_update_ = null;
        }
        if(late_update_ != null)
        {
            late_update_.Dispose();
            late_update_ = null;
        }
        if(on_gui_ != null)
        {
            on_gui_.Dispose();
            on_gui_ = null;
        }
        if(on_enable_ != null)
        {
            on_enable_.Dispose();
            on_enable_ = null;
        }
        if(on_disable_ != null)
        {
            on_disable_.Dispose();
            on_disable_ = null;
        }
        if(on_destroy_ != null)
        {
            on_destroy_.Dispose();
            on_destroy_ = null;
        }
        if(func_dict_ != null)
        {
            foreach(var func in func_dict_.Values)
                func.Dispose();
            func_dict_.Clear();
        }
        state_ = null;
    }

    public class DontCareReturn { };

    /// <summary>
    /// 调用Lua函数，参数说明参见Call<T>版本
    /// </summary>
    public void CallWithoutReturn(string methodname, params object[] ps)
    {
        Call<DontCareReturn>(methodname, ps);
    }
    /// <summary>
    /// 调用Lua函数
    /// </summary>
    /// <typeparam name="T">返回类型</typeparam>
    /// <param name="methodname">函数名</param>
    /// <param name="ps">参数数组</param>
    /// <returns>返回，函数异常时返回default(T)</returns>
    public T Call<T>(string methodname, params object[] ps)
    {
        var retn = default(T);
        var dict = GetFunctionDict();
        if(dict == null)
            return retn;

        Lua.Function func = null;
        dict.TryGetValue(methodname, out func);
        if(func == null)
        {
            LuaMono.Log("'" + methodname + "' is not found in '" + gameObject.name + "'");
            return retn;
        }

        func.Start();
        if(ps != null && ps.Length > 0)
        {
            int length = ps.Length;
            for(var i = 0; i < length; ++i)
                func.Push(ps[i]);
        }
        if(!func.Call())
        {
            LuaMono.LogError(func.last_error_string);
        }
        if(func.GetReturnCount() > 0 &&
            typeof(T) != typeof(DontCareReturn))
            retn = func.GetObject<T>(1);
        func.ClearCall();
        return retn;
    }
    /// <summary>
    /// 调用Lua函数，参数说明参见Call<T>版本
    /// </summary>
    public object Call(string methodname, params object[] ps)
    {
        object retn = null;
        var dict = GetFunctionDict();
        if(dict == null)
            return retn;

        Lua.Function func = null;
        dict.TryGetValue(methodname, out func);
        if(func == null)
        {
            LuaMono.Log("'" + methodname + "' is not found in '" + gameObject.name + "'");
            return retn;
        }

        func.Start();
        if(ps != null && ps.Length > 0)
        {
            int length = ps.Length;
            for(var i = 0; i < length; ++i)
                func.Push(ps[i]);
        }
        if(!func.Call())
        {
            LuaMono.LogError(func.last_error_string);
        }
        if(func.GetReturnCount() > 0)
            retn = func.GetOneobject(1);
        func.ClearCall();
        return retn;
    }
    ///// <summary>
    ///// 获取变量
    ///// </summary>
    ///// <typeparam name="T"></typeparam>
    ///// <param name="param"></param>
    ///// <returns></returns>
    //public T GetValue<T>(string param)
    //{
    //    var top = state_.state.GetTop();
    //    obj_.Push();
    //
    //    var L = state_.state;
    //    L.GetField(-1, param);
    //    top = state_.state.GetTop();
    //    if(L.IsNil(-1))
    //    {
    //        L.Pop(2);
    //        top = state_.state.GetTop();
    //        return default(T);
    //    }
    //    else
    //    {
    //        var retn = Lua.State.GetObject<T>(L, -1);
    //        L.Pop(2);
    //        top = state_.state.GetTop();
    //        return retn;
    //    }
    //}
    ///// <summary>
    ///// 获取变量
    ///// </summary>
    ///// <typeparam name="T"></typeparam>
    ///// <param name="param"></param>
    ///// <returns></returns>
    //public object GetValue(string param)
    //{
    //    var top = state_.state.GetTop();
    //    obj_.Push();
    //
    //    var L = state_.state;
    //    L.GetField(-1, param);
    //    top = state_.state.GetTop();
    //    if(L.IsNil(-1))
    //    {
    //        L.Pop(2);
    //        top = state_.state.GetTop();
    //        return null;
    //    }
    //    else
    //    {
    //        var retn = Lua.State.GetOneobject(L, -1);
    //        L.Pop(2);
    //        top = state_.state.GetTop();
    //        return retn;
    //    }
    //}

    private void DoFunction(Lua.Function func)
    {
        if(func == null || error_pause)
            return;
        try
        {
            func.Start();
            if(!func.Call())
            {
                LuaMono.LogError(func.last_error_string);
                OnError(func.last_error_string, false);
            }
            func.ClearCall();
        }
        catch(System.Exception e)
        {
            var err = e.ToString();
            OnError(err, true);
            Debug.LogError(err);
        }
    }

    public virtual void OnError(string error, bool critical)
    {
        error_pause = critical;
    }
    protected bool error_pause = false;

    private Dictionary<string, Lua.Function> GetFunctionDict()
    {
        if(func_dict_ != null)
            return func_dict_;
        func_dict_ = new Dictionary<string, Lua.Function>();

        obj_.Push();
        var state = state_.state;
        if(state.Type(1) != UniLua.LuaType.LUA_TTABLE)
        {
            state_.state.Pop(1);
            LuaMono.Log("the script of '" + gameObject.name + "' Return is not a table!");
            return null;
        }

        state.PushNil();
        while(state.Next(1))
        {
#if UNITY_EDITOR
            Debug.Log(Lua.State.GetString(state, -2));
#endif
            if(state.Type(-2) == UniLua.LuaType.LUA_TSTRING &&
                state.Type(-1) == UniLua.LuaType.LUA_TFUNCTION)
            {
                func_dict_[Lua.State.GetString(state, -2)] = Lua.State.GetFunction(state, -1);
            }
            state.Pop(1);
        }
        state.Pop(1);
        return func_dict_;
    }
    Dictionary<string, Lua.Function> func_dict_;

    Lua.State state_;
    Lua.Ref obj_;

    Lua.Function awake_;
    Lua.Function start_;
    Lua.Function update_;
    Lua.Function fixed_update_;
    Lua.Function late_update_;
    Lua.Function on_gui_;
    Lua.Function on_enable_;
    Lua.Function on_disable_;
    Lua.Function on_destroy_;

    Lua.Function update_coroutine_;
#if UNITY_EDITOR
    Lua.Function on_draw_gizmos_;
#endif
}
