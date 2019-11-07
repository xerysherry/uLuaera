using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Lua
{
    public sealed class Constant
    {
        public static readonly string[] TypeName = new string[]
            {
                "none", "nil", "boolean",
                "lightuserdata", "number", "string",
                "table", "function", "userdata",
                "thread", "uint64",
            };

        /* option for multiple returns in `lua_pcall' and `lua_call' */
        public const int LUA_MULTRET = UniLua.LuaDef.LUA_MULTRET;
        public const int LUA_REGISTRYINDEX = UniLua.LuaDef.LUA_REGISTRYINDEX;

        //======================================================================
        //ref
        public const int LUA_NOREF = UniLua.LuaConstants.LUA_NOREF;
		public const int LUA_REFNIL = UniLua.LuaConstants.LUA_REFNIL;
        
        //======================================================================
        //type
        public const int LUA_TNONE = (int)UniLua.LuaType.LUA_TNONE;
        public const int LUA_TNIL = (int)UniLua.LuaType.LUA_TNIL;
        public const int LUA_TBOOLEAN = (int)UniLua.LuaType.LUA_TBOOLEAN;
        public const int LUA_TLIGHTUSERDATA = (int)UniLua.LuaType.LUA_TLIGHTUSERDATA;
        public const int LUA_TNUMBER = (int)UniLua.LuaType.LUA_TNUMBER;
        public const int LUA_TSTRING = (int)UniLua.LuaType.LUA_TSTRING;
        public const int LUA_TTABLE = (int)UniLua.LuaType.LUA_TTABLE;
        public const int LUA_TFUNCTION = (int)UniLua.LuaType.LUA_TFUNCTION;
        public const int LUA_TUSERDATA = (int)UniLua.LuaType.LUA_TUSERDATA;
        public const int LUA_TTHREAD = (int)UniLua.LuaType.LUA_TTHREAD;
        public const int LUA_TUINT64 = (int)UniLua.LuaType.LUA_TUINT64;
        public const int LUA_NUMTAGS = (int)UniLua.LuaType.LUA_NUMTAGS;

        public const int LUA_TPROTO = (int)UniLua.LuaType.LUA_TPROTO;
        public const int LUA_TUPVAL = (int)UniLua.LuaType.LUA_TUPVAL;
        public const int LUA_TDEADKEY = (int)UniLua.LuaType.LUA_TDEADKEY;

        //======================================================================
        //Error
        public const int LUA_RESUME_ERROR = (int)UniLua.ThreadStatus.LUA_RESUME_ERROR;
        public const int LUA_OK = (int)UniLua.ThreadStatus.LUA_OK;
        public const int LUA_YIELD = (int)UniLua.ThreadStatus.LUA_YIELD;
        public const int LUA_ERRRUN = (int)UniLua.ThreadStatus.LUA_ERRRUN;
        public const int LUA_ERRSYNTAX = (int)UniLua.ThreadStatus.LUA_ERRSYNTAX;
        public const int LUA_ERRMEM = (int)UniLua.ThreadStatus.LUA_ERRMEM;
        public const int LUA_ERRGCMM = (int)UniLua.ThreadStatus.LUA_ERRGCMM;
        public const int LUA_ERRERR = (int)UniLua.ThreadStatus.LUA_ERRERR;
        public const int LUA_ERRFILE = (int)UniLua.ThreadStatus.LUA_ERRFILE;
    }
    public enum Type
    {
        LUA_TNONE = Constant.LUA_TNONE,
        LUA_TNIL = Constant.LUA_TNIL,
        LUA_TBOOLEAN = Constant.LUA_TBOOLEAN,
        LUA_TLIGHTUSERDATA = Constant.LUA_TLIGHTUSERDATA,
        LUA_TNUMBER = Constant.LUA_TNUMBER,
        LUA_TSTRING = Constant.LUA_TSTRING,
        LUA_TTABLE = Constant.LUA_TTABLE,
        LUA_TFUNCTION = Constant.LUA_TFUNCTION,
        LUA_TUSERDATA = Constant.LUA_TUSERDATA,
        LUA_TTHREAD = Constant.LUA_TTHREAD,
        LUA_TUINT64 = Constant.LUA_TUINT64,
        LUA_NUMTAGS = Constant.LUA_NUMTAGS,

        /// <summary>
        /// 自适应类型（使用UserData类型）
        /// </summary>
        LUA_AUTOTYPE = 0xF,

        LUA_TPROTO = Constant.LUA_TPROTO,
        LUA_TUPVAL = Constant.LUA_TUPVAL,
        LUA_TDEADKEY = Constant.LUA_TDEADKEY,
    }
    public enum Error
    {
        LUA_RESUME_ERROR = Constant.LUA_RESUME_ERROR,
        LUA_OK = Constant.LUA_OK,
        LUA_YIELD = Constant.LUA_YIELD,
        LUA_ERRRUN = Constant.LUA_ERRRUN,
        LUA_ERRSYNTAX = Constant.LUA_ERRSYNTAX,
        LUA_ERRMEM = Constant.LUA_ERRMEM,
        LUA_ERRGCMM = Constant.LUA_ERRGCMM,
        LUA_ERRERR = Constant.LUA_ERRERR,
        LUA_ERRFILE = Constant.LUA_ERRFILE,
    }

    /// <summary>
    /// 引用
    /// </summary>
    public sealed class Ref : IDisposable
    {
        public Ref()
        { }
        public Ref(UniLua.ILuaState state)
        {
            Validate(state);
        }
        ~Ref()
        { }
        public void Dispose()
        {
            if(ref_ != Constant.LUA_NOREF)
            {
                state_.L_Unref(Constant.LUA_REGISTRYINDEX, ref_);
                ref_ = Constant.LUA_NOREF;
            }
            if(state_ != null)
                state_ = null;
            nil_flag_ = false;
        }

        /// <summary>
        /// 有效化（初始化）
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool Validate(UniLua.ILuaState state)
        {
            if(state == null)
                return false;

            Dispose();

            state_ = state;
            if(state_.IsNil(-1))
            {
                state_.Pop(1);
                nil_flag_ = true;
            }
            else
            {
                ref_ = state_.L_Ref(Constant.LUA_REGISTRYINDEX);
                if(ref_ == Constant.LUA_NOREF || ref_ == Constant.LUA_REFNIL)
                    return false;
                nil_flag_ = false;
            }
            return true;
        }
        /// <summary>
        /// 压入该引用对象
        /// </summary>
        public void Push()
        {
            if(valid)
                state_.RawGetI(Constant.LUA_REGISTRYINDEX, ref_);
            else
                state_.PushNil();
        }
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool valid { get { return ref_ != Constant.LUA_NOREF; } }
        /// <summary>
        /// 状态机
        /// </summary>
        public UniLua.ILuaState state { get { return state_; } }
        /// <summary>
        /// 状态机
        /// </summary>
        UniLua.ILuaState state_;
        /// <summary>
        /// 引用
        /// </summary>
        int ref_ = Constant.LUA_NOREF;
        /// <summary>
        /// NIL 标记
        /// </summary>
        public bool nil_flag { get { return nil_flag_; } }
        /// <summary>
        /// NIL 标记
        /// </summary>
        bool nil_flag_ = false;
    }

    public sealed class Exception : System.Exception
    {
        public Exception(string message)
            :base(message)
        { }
        public Exception(State state)
            : base(state.last_error_string)
        { }
        public Exception(Function function)
            : base(function.last_error_string)
        { }
    }

    public sealed class Function : IDisposable
    {
        public Function()
        { }
        public Function(UniLua.ILuaState state)
        {
            if(state.Type(-1) != UniLua.LuaType.LUA_TFUNCTION)
                return;
            @ref_ = new Ref(state);
        }
        public Function(Ref @ref)
        {
            if(!@ref.valid)
                return;
            @ref.Push();
            if(@ref.state.Type(-1) != UniLua.LuaType.LUA_TFUNCTION)
                return;
            @ref_ = new Ref(@ref.state);
        }
        public void Dispose()
        {
            if(@ref_ != null)
            {
                @ref_.Dispose();
                @ref_ = null;
            }
        }

        public bool valid { get { return @ref_ != null; } }

        public void Push(int value)
        {
            State.Push(state, value);
            ++param_count_;
        }
        public void Push(uint value)
        {
            State.Push(state, value);
            ++param_count_;
        }
        public void Push(short value)
        {
            State.Push(state, value);
            ++param_count_;
        }
        public void Push(ushort value)
        {
            State.Push(state, value);
            ++param_count_;
        }
        public void Push(char value)
        {
            State.Push(state, value);
            ++param_count_;
        }
        public void Push(byte value)
        {
            State.Push(state, value);
            ++param_count_;
        }
        public void Push(long value)
        {
            State.Push(state, value);
            ++param_count_;
        }
        public void Push(ulong value)
        {
            State.Push(state, value);
            ++param_count_;
        }
        public void Push(float value)
        {
            State.Push(state, value);
            ++param_count_;
        }
        public void Push(double value)
        {
            State.Push(state, value);
            ++param_count_;
        }
        public void Push(string value)
        {
            State.Push(state, value);
            ++param_count_;
        }
        public void Push(bool value)
        {
            State.Push(state, value);
            ++param_count_;
        }
        public void Push(object userdata)
        {
            State.Push(state, userdata);
            ++param_count_;
        }
        public void Push(Action<Param> userdata)
        {
            State.Push(state, userdata);
            ++param_count_;
        }
        public void Push()
        {
            State.Push(state);
            ++param_count_;
        }
        public void Push(object userdata, string metatable)
        {
            State.Push(state, userdata, metatable);
            ++param_count_;
        }
        public void Push(Array array)
        {
            State.Push(state, array);
            ++param_count_;
        }
        public void Push(IList list)
        {
            State.Push(state, list);
            ++param_count_;
        }
        public void Push(IDictionary dict)
        {
            State.Push(state, dict);
            ++param_count_;
        }
        public void Push(Dictionary<string, object> dict, string metatable)
        {
            State.Push(state, dict, metatable);
            ++param_count_;
        }
        public void Push(object value, System.Type type)
        {
            State.Push(state, value, type);
            ++param_count_;
        }
        public void Push(Ref @ref)
        {
            State.Push(state, @ref);
            ++param_count_;
        }

        public int GetReturnCount()
        {
            return return_count_;
        }
        //索引从1开始
        public int GetInteger(int i)
        {
            return State.GetInteger(state, top_ + i);
        }
        public uint GetUInteger(int i)
        {
            return State.GetUInteger(state, top_ + i);
        }
        public short GetShort(int i)
        {
            return State.GetShort(state, top_ + i);
        }
        public ushort GetUShort(int i)
        {
            return State.GetUShort(state, top_ + i);
        }
        public char GetChar(int i)
        {
            return State.GetChar(state, top_ + i);
        }
        public byte GetByte(int i)
        {
            return State.GetByte(state, top_ + i);
        }
        public long GetLong(int i)
        {
            return State.GetLong(state, top_ + i);
        }
        public ulong GetULong(int i)
        {
            return State.GetULong(state, top_ + i);
        }
        public float GetFloat(int i)
        {
            return State.GetFloat(state, top_ + i);
        }
        public double GetDouble(int i)
        {
            return State.GetDouble(state, top_ + i);
        }
        public string GetString(int i)
        {
            return State.GetString(state, top_ + i);
        }
        public bool GetBoolean(int i)
        {
            return State.GetBoolean(state, top_ + i);
        }
        public object GetUserdata(int i)
        {
            return State.GetUserdata(state, top_ + i);
        }
        public T GetUserdata<T>(int i)
        {
            return State.GetUserdata<T>(state, top_ + i);
        }
        public T[] GetArray<T>(int i)
        {
            return State.GetArray<T>(state, top_ + i);
        }
        public object GetArray(int i, System.Type t)
        {
            return State.GetArray(state, top_ + i, t);
        }
        public List<T> GetList<T>(int i)
        {
            return State.GetList<T>(state, top_ + i);
        }
        public object GetList(int i, System.Type t)
        {
            return State.GetList(state, top_ + i, t);
        }
        public Dictionary<T, K> GetDictionary<T, K>(int i)
        {
            return State.GetDictionary<T, K>(state, top_ + i);
        }
        public object GetDictionary(int i, System.Type t)
        {
            return State.GetDictionary(state, top_ + i, t);
        }
        public Function GetFunction(int i)
        {
            return State.GetFunction(state, top_ + i);
        }
        public Ref GetRef(int i)
        {
            return State.GetRef(state, top_ + i);
        }
        public object GetOneobject(int i)
        {
            return State.GetOneobject(state, top_ + i);
        }
        public object GetObject(int i, System.Type type)
        {
            return State.GetObject(state, top_ + i, type);
        }
        public T GetObject<T>(int i)
        {
            return State.GetObject<T>(state, top_ + i);
        }

        public void Start()
        {
            @ref.Push();
        }

        public bool Call()
        {
            top_ = state.GetTop()
                //减去函数所在栈
                - 1
                //减去压入参数数
                - param_count_;
            var error = (Error)state.PCall(param_count_, Lua.Constant.LUA_MULTRET, 0);

            var top = state.GetTop();
            param_count_ = 0;
            return_count_ = top - top_;

            if(error != Error.LUA_OK)
            {
                last_error_string_ = state.ToString(-1);
                return false;
            }
            else
            {
                last_error_string_ = null;
                return true;
            }
            
        }
        public void ClearCall()
        {
            if(return_count_ == 0)
                return;

            state.Pop(return_count_);
            return_count_ = 0;
            param_count_ = 0;
        }

        /// <summary>
        /// 状态机
        /// </summary>
        public UniLua.ILuaState state 
        { 
            get 
            {
                if(@ref_ == null)
                    return null;
                return @ref_.state; 
            }
        }
        /// <summary>
        /// 索引
        /// </summary>
        public Ref @ref { get { return @ref_; } }
        /// <summary>
        /// 引用
        /// </summary>
        Ref @ref_ = null;
        /// <summary>
        /// 最后一次错误
        /// </summary>
        public string last_error_string { get { return last_error_string_; } }
        string last_error_string_ = null;

        /// <summary>
        /// 栈顶
        /// </summary>
        int top_ = 0;
        int param_count_ = 0;
        int return_count_ = 0;
    }

    /// <summary>
    /// 参数相关类
    /// </summary>
    public sealed class Param : IDisposable
    {
        public static bool Equal(ulong typecode, ulong value)
        {
            if(typecode == value)
                return true;

            while(typecode != 0 && value != 0)
            {
                if((typecode & 0xFUL) != (value & 0xFUL))
                {
                    if((value & 0xF) != 0xF)
                        return false;
                }
                typecode = (typecode >> 4);
                value = (value >> 4);
            }
            return typecode == value;
        }

        public Param(UniLua.ILuaState lua_state)
        {
            state_ = lua_state;
        }
        ~Param()
        {
            Dispose();
        }
        public void Dispose()
        {
            state_ = null;
        }
        
        /// <summary>
        /// 获取参数数量
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            return state_.GetTop();
        }
        /// <summary>
        /// 获取参数类型
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Type Type(int i)
        {
            return (Type)state_.Type(i);
        }
        /// <summary>
        /// 获取typecode
        /// </summary>
        /// <returns></returns>
        public ulong GetTypecode()
        {
            if(_typecode == 0xFFFFFFFFFFFFFFFFL)
            {
                _typecode = 0;

                int count = GetCount();
                for(int i = 0; i < count; ++i)
                {
                    var t = (ulong)Type(i + 1);
                    if(t == 7)
                        //把LUA_TUSERDATA统一变为LUA_TLIGHTUSERDATA
                        t = 2;
                    else if(t < 0)
                        t = 0;
                    _typecode = t + _typecode * 0x10L;
                }
            }
            return _typecode;
        }
        ulong _typecode = 0xFFFFFFFFFFFFFFFFL;
        /// <summary>
        /// 获取参数类型名
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public string Typename(int i)
        {
            return Constant.TypeName[(int)state_.Type(i) + 1];
        }
        /// <summary>
        /// 获取整型参数
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public int GetInteger(int i)
        {
            return State.GetInteger(state_, i);
        }
        /// <summary>
        /// 获取无符号整型参数
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public uint GetUInteger(int i)
        {
            return State.GetUInteger(state_, i);
        }
        /// <summary>
        /// 获取短整型参数
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public short GetShort(int i)
        {
            return State.GetShort(state_, i);
        }
        /// <summary>
        /// 获取无符号短整型参数
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public ushort GetUShort(int i)
        {
            return State.GetUShort(state_, i);
        }
        /// <summary>
        /// 获取长整型参数
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public long GetLong(int i)
        {
            return State.GetLong(state_, i);
        }
        /// <summary>
        /// 获取无符号长整型参数
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public ulong GetULong(int i)
        {
            return State.GetULong(state_, i);
        }
        /// <summary>
        /// 获取单字节
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public char GetChar(int i)
        {
            return State.GetChar(state_, i);
        }
        /// <summary>
        /// 获取无符号单字节
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public byte GetByte(int i)
        {
            return State.GetByte(state_, i);
        }
        /// <summary>
        /// 获取浮动参数
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public float GetFloat(int i)
        {
            return State.GetFloat(state_, i);
        }
        /// <summary>
        /// 获取双精度参数
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public double GetDouble(int i)
        {
            return State.GetDouble(state_, i);
        }
        /// <summary>
        /// 获取字符串参数
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public string GetString(int i)
        {
            return State.GetString(state_, i);
        }
        /// <summary>
        /// 获取布尔型参数
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public bool GetBoolean(int i)
        {
            return State.GetBoolean(state_, i);
        }
        /// <summary>
        /// 获取用户数据参数
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public object GetUserdata(int i)
        {
            return State.GetUserdata(state_, i);
        }
        /// <summary>
        /// 获取用户数据参数
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="i"></param>
        /// <returns></returns>
        public T GetUserdata<T>(int i)
        {
            return State.GetUserdata<T>(state_, i);
        }
        /// <summary>
        /// 获取数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="i"></param>
        /// <returns></returns>
        public T[] GetArray<T>(int i)
        {
            return State.GetArray<T>(state_, i);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="i"></param>
        /// <returns></returns>
        public object GetArray(int i, System.Type t)
        {
            return State.GetArray(state_, i, t);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="i"></param>
        /// <returns></returns>
        public List<T> GetList<T>(int i)
        {
            return State.GetList<T>(state_, i);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="i"></param>
        /// <returns></returns>
        public object GetList(int i, System.Type t)
        {
            return State.GetList(state_, i, t);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="i"></param>
        /// <returns></returns>
        public Dictionary<T, K> GetDictionary<T, K>(int i)
        {
            return State.GetDictionary<T, K>(state_, i);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="i"></param>
        /// <returns></returns>
        public object GetDictionary(int i, System.Type t)
        {
            return State.GetDictionary(state_, i, t);
        }
        /// <summary>
        /// 返回函数
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Function GetFunction(int i)
        {
            return State.GetFunction(state_, i);
        }
        /// <summary>
        /// 返回引用
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Ref GetRef(int i)
        {
            return State.GetRef(state_, i);
        }

        public object GetOneobject(int i)
        {
            return State.GetOneobject(state_, i);
        }
        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="i"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public object GetObject(int i, System.Type type)
        {
            return State.GetObject(state_, i, type);
        }
        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="i"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public T GetObject<T>(int i)
        {
            return State.GetObject<T>(state_, i);
        }

        public int ReturnCount
        {
            get { return return_count_; }
            set { return_count_ = value; }
        }
 
        public void Return(object value, System.Type type)
        {
            State.Push(state_, value, type);
            ++return_count_;
        }
        public void Return(Ref @ref)
        {
            State.Push(state_, @ref);
            ++return_count_;
        }
        public void Return(Function function)
        {
            State.Push(state_, function);
            ++return_count_;
        }
        public void Return(int value)
        {
            State.Push(state_, value);
            ++return_count_;
        }
        public void Return(uint value)
        {
            State.Push(state_, value);
            ++return_count_;
        }
        public void Return(short value)
        {
            State.Push(state_, value);
            ++return_count_;
        }
        public void Return(ushort value)
        {
            State.Push(state_, value);
            ++return_count_;
        }
        public void Return(char value)
        {
            State.Push(state_, value);
            ++return_count_;
        }
        public void Return(byte value)
        {
            State.Push(state_, value);
            ++return_count_;
        }
        public void Return(long value)
        {
            State.Push(state_, value);
            ++return_count_;
        }
        public void Return(ulong value)
        {
            State.Push(state_, value);
            ++return_count_;
        }
        public void Return(float value)
        {
            State.Push(state_, value);
            ++return_count_;
        }
        public void Return(double value)
        {
            State.Push(state_, value);
            ++return_count_;
        }
        public void Return(string value)
        {
            State.Push(state_, value);
            ++return_count_;
        }
        public void Return(bool value)
        {
            State.Push(state_, value);
            ++return_count_;
        }
        public void Return(object value)
        {
            State.Push(state_, value);
            ++return_count_;
        }
        public void Return(Action<Param> value)
        {
            State.Push(state_, value);
            ++return_count_;
        }
        public void Return()
        {
            state_.PushNil();
            ++return_count_;
        }
        public void Return(object userdata, string metatable)
        {
            State.Push(state_, userdata, metatable);
            ++return_count_;
        }
        public void Return(Array array)
        {
            State.Push(state_, array);
            ++return_count_;
        }
        public void Return(IList list)
        {
            State.Push(state_, list);
            ++return_count_;
        }
        public void Return(IDictionary dict)
        {
            State.Push(state, dict);
            ++return_count_;
        }
        public void Return(Dictionary<string, object> dict, string metatable)
        {
            //UniLua metatable导致如此编写
            if(!string.IsNullOrEmpty(metatable))
                dict["__|type|__"] = metatable;
            State.Push(state, dict, metatable);
            ++return_count_;
        }

        public UniLua.ILuaState state { get { return state_; } }
        /// <summary>
        /// 状态机
        /// </summary>
        UniLua.ILuaState state_;
        /// <summary>
        /// 返回量
        /// </summary>
        int return_count_ = 0;

        int n { get { return state_.GetTop(); } }
    }

    public sealed class Module
    {
        public Module(string name, bool global)
        {
            name_ = name;
            global_ = true;
        }
        public void Add(string func_name, Action<Param> func)
        { 
            pairs_.Add(new UniLua.NameFuncPair(
                func_name, 
                L=>{
                    var param = new Param(L);
                    func(param);
                    return param.ReturnCount;
                })
            );
        }

        public string name { get { return name_; } }
        string name_;

        public List<UniLua.NameFuncPair> pairs { get { return pairs_; } }
        List<UniLua.NameFuncPair> pairs_ = new List<UniLua.NameFuncPair>();

        public bool global { get { return global_; } }
        bool global_ = false;
    }

    public sealed class Metatable
    {
        public Metatable(System.Type type,
                        Dictionary<string, Action<Param>> ref_list,
                        System.Type parent)
        {
            type_ = type;
            if(parent != null)
                parent_ = parent;
            ref_list_ = ref_list;
        }
        public Action<Param> Get(string name)
        {
            Action<Param> r = null;
            ref_list_.TryGetValue(name, out r);
            return r;
        }
        public System.Type type { get { return type_; } }
        public System.Type parent { get { return parent_; } }

        System.Type type_;
        System.Type parent_;
        Dictionary<string, Action<Param>> ref_list_;
    }

    public sealed class State
    {
        /// <summary>
        /// 压入数据
        /// </summary>
        /// <param name="state"></param>
        /// <param name="value"></param>
        /// <param name="type"></param>
        public static void Push(UniLua.ILuaState state, object value, System.Type type)
        {
            if(value == null)
                Push(state);
            else if(type == typeof(Ref))
                Push(state, (Ref)value);
            else if(type == typeof(Function))
                Push(state, (Function)value);
            else if(type == typeof(int) ||
                type == typeof(short) ||
                type == typeof(char))
                Push(state, (int)value);
            else if(type == typeof(uint) ||
                type == typeof(ushort) ||
                type == typeof(byte))
                Push(state, (uint)value);
            else if(type == typeof(long))
                Push(state, (long)value);
            else if(type == typeof(ulong))
                Push(state, (ulong)value);
            else if(type == typeof(string))
                Push(state, (string)value);
            else if(type == typeof(bool))
                Push(state, (bool)value);
            else if(type == typeof(float))
                Push(state, (float)value);
            else if(type == typeof(double))
                Push(state, (double)value);
            else if(type.BaseType == typeof(Array))
                Push(state, (Array)value);
            else if(type.GetInterface("System.Collections.IList") != null)
                Push(state, (IList)value);
            else if(type.GetInterface("System.Collections.IDictionary") != null)
                Push(state, (IDictionary)value);
            else
                Push(state, value);
        }
        /// <summary>
        /// 压入引用
        /// </summary>
        /// <param name="state"></param>
        /// <param name="ref"></param>
        public static void Push(UniLua.ILuaState state, Ref @ref)
        {
            if(@ref == null)
                Push(state);
            else
            {
                @ref.Push();
            }
        }
        /// <summary>
        /// 压入函数
        /// </summary>
        /// <param name="state"></param>
        /// <param name="function"></param>
        public static void Push(UniLua.ILuaState state, Function function)
        {
            if(function == null || !function.valid)
                Push(state);
            else
            {
                function.@ref.Push();
            }
        }
        /// <summary>
        /// 压入整型
        /// </summary>
        /// <param name="state"></param>
        /// <param name="value"></param>
        public static void Push(UniLua.ILuaState state, int value)
        {
            state.PushInteger(value);
        }
        /// <summary>
        /// 压入无符号整型
        /// </summary>
        /// <param name="state"></param>
        /// <param name="value"></param>
        public static void Push(UniLua.ILuaState state, uint value)
        {
            state.PushUnsigned(value);
        }
        /// <summary>
        /// 压入短整型
        /// </summary>
        /// <param name="state"></param>
        /// <param name="value"></param>
        public static void Push(UniLua.ILuaState state, short value)
        {
            state.PushInteger(value);
        }
        /// <summary>
        /// 压入无符号短整型
        /// </summary>
        /// <param name="state"></param>
        /// <param name="value"></param>
        public static void Push(UniLua.ILuaState state, ushort value)
        {
            state.PushUnsigned(value);
        }
        /// <summary>
        /// 压入单字节
        /// </summary>
        /// <param name="state"></param>
        /// <param name="value"></param>
        public static void Push(UniLua.ILuaState state, char value)
        {
            state.PushInteger(value);
        }
        /// <summary>
        /// 压入无符号单字节
        /// </summary>
        /// <param name="state"></param>
        /// <param name="value"></param>
        public static void Push(UniLua.ILuaState state, byte value)
        {
            state.PushUnsigned(value);
        }
        /// <summary>
        /// 压入长整型
        /// </summary>
        /// <param name="state"></param>
        /// <param name="value"></param>
        public static void Push(UniLua.ILuaState state, long value)
        {
            state.PushNumber((double)value);
        }
        /// <summary>
        /// 压入无符号长整型
        /// </summary>
        /// <param name="state"></param>
        /// <param name="value"></param>
        public static void Push(UniLua.ILuaState state, ulong value)
        {
            state.PushUInt64(value);
        }
        /// <summary>
        /// 压入浮点
        /// </summary>
        /// <param name="state"></param>
        /// <param name="value"></param>
        public static void Push(UniLua.ILuaState state, float value)
        {
            state.PushNumber(value);
        }
        /// <summary>
        /// 压入双精度浮点
        /// </summary>
        /// <param name="state"></param>
        /// <param name="value"></param>
        public static void Push(UniLua.ILuaState state, double value)
        {
            state.PushNumber(value);
        }
        /// <summary>
        /// 压入字符串
        /// </summary>
        /// <param name="state"></param>
        /// <param name="value"></param>
        public static void Push(UniLua.ILuaState state, string value)
        {
            state.PushString(value);
        }
        /// <summary>
        /// 压入布尔
        /// </summary>
        /// <param name="state"></param>
        /// <param name="value"></param>
        public static void Push(UniLua.ILuaState state, bool value)
        {
            state.PushBoolean(value);
        }
        /// <summary>
        /// 压入Userdata
        /// </summary>
        /// <param name="state"></param>
        /// <param name="userdata"></param>
        public static void Push(UniLua.ILuaState state, object userdata)
        {
            if(userdata == null)
            {
                Push(state);
                return;
            }
            state.PushLightUserData(userdata);
            state.GetField(Constant.LUA_REGISTRYINDEX, "__Wrap");
            if(state.IsNil(-1))
                state.Pop(1);
            else
                state.SetMetaTable(-2);
        }
        /// <summary>
        /// 压入函数
        /// </summary>
        /// <param name="state"></param>
        /// <param name="func"></param>
        public static void Push(UniLua.ILuaState state, Action<Param> func)
        {
            if(func == null)
            {
                Push(state);
                return;
            }
            state.PushCSharpFunction(L =>
            {
                var param = new Param(L);
                func(param);
                return param.ReturnCount;
            });
        }
        /// <summary>
        /// 压入Nil
        /// </summary>
        /// <param name="state"></param>
        public static void Push(UniLua.ILuaState state)
        {
            state.PushNil();
        }
        /// <summary>
        /// 压入Userdata，带metetable
        /// </summary>
        /// <param name="state"></param>
        /// <param name="userdata"></param>
        /// <param name="metatable"></param>
        public static void Push(UniLua.ILuaState state, object userdata, string metatable)
        {
            if(userdata == null)
            {
                State.Push(state);
                return;
            }
            else if(string.IsNullOrEmpty(metatable))
            {
                State.Push(state, userdata);
                return;
            }

            state.PushLightUserData(userdata);
            state.GetField(Constant.LUA_REGISTRYINDEX, metatable);
            if(state.IsNil(-1))
                state.Pop(1);
            else
                state.SetMetaTable(-2);
        }
        /// <summary>
        /// 压入数组
        /// </summary>
        /// <param name="state"></param>
        /// <param name="array"></param>
        public static void Push(UniLua.ILuaState state, Array array)
        {
            if(array == null)
            {
                State.Push(state);
                return;
            }

            var type = array.GetType();
            var etype = type.GetElementType();

            state.NewTable();
            int count = array.GetLength(0);
            for(int i = 0; i < count; ++i)
            {
                var o = array.GetValue(i);
                State.Push(state, o, etype);
                state.RawSetI(-2, i + 1);
            }
        }
        /// <summary>
        ///  压入列表
        /// </summary>
        /// <param name="state"></param>
        /// <param name="list"></param>
        public static void Push(UniLua.ILuaState state, IList list)
        {
            if(list == null)
            {
                State.Push(state);
                return;
            }
            state.NewTable();
            for(int i = 0; i < list.Count; ++i)
            {
                var o = list[i];
                if(o == null)
                    continue;
                State.Push(state, o, o.GetType());
                state.RawSetI(-2, i + 1);
            }
        }
        /// <summary>
        /// 压入字典
        /// </summary>
        /// <param name="state"></param>
        /// <param name="dict"></param>
        public static void Push(UniLua.ILuaState state, IDictionary dict)
        {
            if(dict == null)
            {
                State.Push(state);
                return;
            }
            state.NewTable();
            foreach(var key in dict.Keys)
            {
                if(key == null)
                    continue;
                var value = dict[key];
                if(value == null)
                    continue;
                State.Push(state, key, key.GetType());
                State.Push(state, value, value.GetType());
                state.SetTable(-3);
            }
        }
        /// <summary>
        /// 压入字典，带metatable
        /// </summary>
        /// <param name="state"></param>
        /// <param name="dict"></param>
        /// <param name="metatable"></param>
        public static void Push(UniLua.ILuaState state, Dictionary<string, object> dict, string metatable)
        {
            State.Push(state, dict);
            if(!string.IsNullOrEmpty(metatable))
            {
                //state.GetField(Constant.LUA_REGISTRYINDEX, metatable);
                state.GetField(Constant.LUA_REGISTRYINDEX, "__Wrap");
                if(state.IsNil(-1))
                    state.Pop(1);
                else
                    state.SetMetaTable(-2);
            }
        }
        /// <summary>
        /// 获取整型参数
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static int GetInteger(UniLua.ILuaState state, int i)
        {
            var type = state.Type(i);
            switch(type)
            {
                case UniLua.LuaType.LUA_TNUMBER:
                    return (int)state.ToNumber(i);
                case UniLua.LuaType.LUA_TSTRING:
                    try
                    {
                        return int.Parse(state.ToString(i));
                    }
                    catch(Exception e)
                    {
                        return 0;
                    }
                case UniLua.LuaType.LUA_TBOOLEAN:
                    return state.ToBoolean(i) ? 1 : 0;
                case UniLua.LuaType.LUA_TUINT64:
                    return (int)state.ToUInt64(i);
                default:
                    throw new NotImplementedException();
            }
            return 0;
        }
        /// <summary>
        /// 获取无符号整型参数
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static uint GetUInteger(UniLua.ILuaState state, int i)
        {
            var type = state.Type(i);
            switch(type)
            {
                case UniLua.LuaType.LUA_TNUMBER:
                    return (uint)(state.ToNumber(i));
                case UniLua.LuaType.LUA_TSTRING:
                    try
                    {
                        return uint.Parse(state.ToString(i));
                    }
                    catch(Exception e)
                    {
                        return 0;
                    }
                case UniLua.LuaType.LUA_TBOOLEAN:
                    return state.ToBoolean(i) ? 1u : 0u;
                case UniLua.LuaType.LUA_TUINT64:
                    return (uint)state.ToUInt64(i);
                default:
                    throw new NotImplementedException();
            }
            return 0;
        }
        /// <summary>
        /// 获取无符号整型参数
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static short GetShort(UniLua.ILuaState state, int i)
        {
            var type = state.Type(i);
            switch(type)
            {
            case UniLua.LuaType.LUA_TNUMBER:
                return (short)(state.ToNumber(i));
            case UniLua.LuaType.LUA_TSTRING:
                try
                {
                    return short.Parse(state.ToString(i));
                }
                catch(Exception e)
                {
                    return 0;
                }
            case UniLua.LuaType.LUA_TBOOLEAN:
                return (short)(state.ToBoolean(i) ? 1 : 0);
            case UniLua.LuaType.LUA_TUINT64:
                return (short)state.ToUInt64(i);
            default:
                throw new NotImplementedException();
            }
            return 0;
        }
        /// <summary>
        /// 获取无符号整型参数
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static ushort GetUShort(UniLua.ILuaState state, int i)
        {
            var type = state.Type(i);
            switch(type)
            {
            case UniLua.LuaType.LUA_TNUMBER:
                return (ushort)(state.ToNumber(i));
            case UniLua.LuaType.LUA_TSTRING:
                try
                {
                    return ushort.Parse(state.ToString(i));
                }
                catch(Exception e)
                {
                    return 0;
                }
            case UniLua.LuaType.LUA_TBOOLEAN:
                return (ushort)(state.ToBoolean(i) ? 1 : 0);
            case UniLua.LuaType.LUA_TUINT64:
                return (ushort)state.ToUInt64(i);
            default:
                throw new NotImplementedException();
            }
            return 0;
        }
        /// <summary>
        /// 获取单字节
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static char GetChar(UniLua.ILuaState state, int i)
        {
            var type = state.Type(i);
            switch(type)
            {
            case UniLua.LuaType.LUA_TNUMBER:
                return (char)(state.ToNumber(i));
            case UniLua.LuaType.LUA_TSTRING:
                try
                {
                    return char.Parse(state.ToString(i));
                }
                catch(Exception e)
                {
                    return '\x0';
                }
            case UniLua.LuaType.LUA_TBOOLEAN:
                return (char)(state.ToBoolean(i) ? 1 : 0);
            case UniLua.LuaType.LUA_TUINT64:
                return (char)state.ToUInt64(i);
            default:
                throw new NotImplementedException();
            }
            return '\x0';
        }
        /// <summary>
        /// 获取无符号单字节
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static byte GetByte(UniLua.ILuaState state, int i)
        {
            var type = state.Type(i);
            switch(type)
            {
            case UniLua.LuaType.LUA_TNUMBER:
                return (byte)(state.ToNumber(i));
            case UniLua.LuaType.LUA_TSTRING:
                try
                {
                    return byte.Parse(state.ToString(i));
                }
                catch(Exception e)
                {
                    return 0;
                }
            case UniLua.LuaType.LUA_TBOOLEAN:
                return (byte)(state.ToBoolean(i) ? 1 : 0);
            case UniLua.LuaType.LUA_TUINT64:
                return (byte)state.ToUInt64(i);
            default:
                throw new NotImplementedException();
            }
            return 0;
        }
        /// <summary>
        /// 获取长整型
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static long GetLong(UniLua.ILuaState state, int i)
        {
            var type = state.Type(i);
            switch(type)
            {
            case UniLua.LuaType.LUA_TNUMBER:
                return (long)(state.ToNumber(i));
            case UniLua.LuaType.LUA_TSTRING:
                try
                {
                    return long.Parse(state.ToString(i));
                }
                catch(Exception e)
                {
                    return 0L;
                }
            case UniLua.LuaType.LUA_TBOOLEAN:
                return (long)(state.ToBoolean(i) ? 1 : 0);
            case UniLua.LuaType.LUA_TUINT64:
                return (long)state.ToUInt64(i);
            default:
                throw new NotImplementedException();
            }
            return 0L;
        }
        /// <summary>
        /// 获取无符号单字节
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static ulong GetULong(UniLua.ILuaState state, int i)
        {
            var type = state.Type(i);
            switch(type)
            {
            case UniLua.LuaType.LUA_TNUMBER:
                return (ulong)(state.ToNumber(i));
            case UniLua.LuaType.LUA_TSTRING:
                try
                {
                    return ulong.Parse(state.ToString(i));
                }
                catch(Exception e)
                {
                    return 0UL;
                }
            case UniLua.LuaType.LUA_TBOOLEAN:
                return (ulong)(state.ToBoolean(i) ? 1 : 0);
            case UniLua.LuaType.LUA_TUINT64:
                return (ulong)state.ToUInt64(i);
            default:
                throw new NotImplementedException();
            }
            return 0UL;
        }
        /// <summary>
        /// 获取浮动参数
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static float GetFloat(UniLua.ILuaState state, int i)
        {
            var type = state.Type(i);
            switch(type)
            {
                case UniLua.LuaType.LUA_TNUMBER:
                    return (float)state.ToNumber(i);
                case UniLua.LuaType.LUA_TSTRING:
                    try
                    {
                        return float.Parse(state.ToString(i));
                    }
                    catch(Exception e)
                    {
                        return 0;
                    }
                case UniLua.LuaType.LUA_TBOOLEAN:
                    return state.ToBoolean(i) ? 1 : 0;
                case UniLua.LuaType.LUA_TUINT64:
                    return (float)state.ToUInt64(i);
                default:
                    throw new NotImplementedException();
            }
            return 0;
        }
        /// <summary>
        /// 获取双精度参数
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static double GetDouble(UniLua.ILuaState state, int i)
        {
            var type = state.Type(i);
            switch(type)
            {
                case UniLua.LuaType.LUA_TNUMBER:
                    return state.ToNumber(i);
                case UniLua.LuaType.LUA_TSTRING:
                    try
                    {
                        return double.Parse(state.ToString(i));
                    }
                    catch(Exception e)
                    {
                        return 0;
                    }
                case UniLua.LuaType.LUA_TBOOLEAN:
                    return state.ToBoolean(i) ? 1 : 0;
                case UniLua.LuaType.LUA_TUINT64:
                    return (double)state.ToUInt64(i);
                default:
                    throw new NotImplementedException();
            }
            return 0;
        }
        /// <summary>
        /// 获取字符串参数
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static string GetString(UniLua.ILuaState state, int i)
        {
            var type = state.Type(i);
            switch(type)
            {
                case UniLua.LuaType.LUA_TNUMBER:
                    return state.ToNumber(i).ToString();
                case UniLua.LuaType.LUA_TSTRING:
                    return state.ToString(i);
                case UniLua.LuaType.LUA_TBOOLEAN:
                    return state.ToBoolean(i) ? "true" : "false";
                case UniLua.LuaType.LUA_TUINT64:
                    return state.ToUInt64(i).ToString();
                case UniLua.LuaType.LUA_TTABLE:
                    return "table@lua";
                case UniLua.LuaType.LUA_TFUNCTION:
                    return "function@lua";
                case UniLua.LuaType.LUA_TLIGHTUSERDATA:
                case UniLua.LuaType.LUA_TUSERDATA:
                    return state.ToUserData(i).ToString();
                case UniLua.LuaType.LUA_TTHREAD:
                    return "thread@lua";
                case UniLua.LuaType.LUA_TNONE:
                case UniLua.LuaType.LUA_TNIL:
                    return null;
                default:
                    return null;
            }
            return null;
        }
        /// <summary>
        /// 获取布尔型参数
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool GetBoolean(UniLua.ILuaState state, int i)
        {
            var type = state.Type(i);
            switch(type)
            {
                case UniLua.LuaType.LUA_TNUMBER:
                    return ((int)state.ToNumber(i)) != 0;
                case UniLua.LuaType.LUA_TSTRING:
                    return true;
                case UniLua.LuaType.LUA_TBOOLEAN:
                    return state.ToBoolean(i);
                case UniLua.LuaType.LUA_TUINT64:
                    return state.ToUInt64(i) != 0;
                case UniLua.LuaType.LUA_TNONE:
                case UniLua.LuaType.LUA_TNIL:
                    return false;
                case UniLua.LuaType.LUA_TTABLE:
                case UniLua.LuaType.LUA_TFUNCTION:
                case UniLua.LuaType.LUA_TLIGHTUSERDATA:
                case UniLua.LuaType.LUA_TUSERDATA:
                case UniLua.LuaType.LUA_TTHREAD:
                default:
                    throw new NotImplementedException();
            }
            return false;
        }
        /// <summary>
        /// 获取用户数据参数
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static object GetUserdata(UniLua.ILuaState state, int i)
        {
            var type = state.Type(i);
            switch(type)
            {
                case UniLua.LuaType.LUA_TLIGHTUSERDATA:
                case UniLua.LuaType.LUA_TUSERDATA:
                    return state.ToUserData(i);
                case UniLua.LuaType.LUA_TTABLE:
                    return GetDictionary<string, object>(state, i);
                case UniLua.LuaType.LUA_TNONE:
                case UniLua.LuaType.LUA_TNIL:
                    return null;
                case UniLua.LuaType.LUA_TNUMBER:
                case UniLua.LuaType.LUA_TSTRING:
                case UniLua.LuaType.LUA_TBOOLEAN:
                case UniLua.LuaType.LUA_TUINT64:
                case UniLua.LuaType.LUA_TFUNCTION:
                case UniLua.LuaType.LUA_TTHREAD:
                default:
                    throw new NotImplementedException();
            }
            return null;
        }
        /// <summary>
        /// 获取用户数据参数
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="i"></param>
        /// <returns></returns>
        public static T GetUserdata<T>(UniLua.ILuaState state, int i)
        {
            //var a = State.GetUserdata(state, i);
            return (T)State.GetUserdata(state, i);
        }
        /// <summary>
        /// 获取数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="i"></param>
        /// <returns></returns>
        public static T[] GetArray<T>(UniLua.ILuaState state, int i)
        {
            var type = state.Type(i);
            switch(type)
            {
                case UniLua.LuaType.LUA_TTABLE:
                    {
                        int count = state.L_Len(i);
                        var array = new T[count];
                        for(int index = 0; index < count; ++index)
                        {
                            state.RawGetI(i, index + 1);
                            array[index] = State.GetObject<T>(state, -1);
                            state.Pop(1);
                        }
                        return array;
                    }
                case UniLua.LuaType.LUA_TNUMBER:
                case UniLua.LuaType.LUA_TSTRING:
                case UniLua.LuaType.LUA_TBOOLEAN:
                case UniLua.LuaType.LUA_TUINT64:
                case UniLua.LuaType.LUA_TNONE:
                case UniLua.LuaType.LUA_TNIL:
                case UniLua.LuaType.LUA_TFUNCTION:
                case UniLua.LuaType.LUA_TLIGHTUSERDATA:
                case UniLua.LuaType.LUA_TUSERDATA:
                case UniLua.LuaType.LUA_TTHREAD:
                default:
                    throw new NotImplementedException();
            }
            return null;
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="i"></param>
        /// <returns></returns>
        public static object GetArray(UniLua.ILuaState state, int i, System.Type t)
        {
            var type = state.Type(i);
            switch(type)
            {
                case UniLua.LuaType.LUA_TTABLE:
                    {
                        int count = state.L_Len(i);
                        var array = (Array)Activator.CreateInstance(t, count);
                        var etype = t.GetElementType();
                        for(int index = 0; index < count; ++index)
                        {
                            state.RawGetI(i, index + 1);
                            array.SetValue(State.GetObject(state, -1, etype), index);
                            state.Pop(1);
                        }
                        return array;
                    }
                case UniLua.LuaType.LUA_TNUMBER:
                case UniLua.LuaType.LUA_TSTRING:
                case UniLua.LuaType.LUA_TBOOLEAN:
                case UniLua.LuaType.LUA_TUINT64:
                case UniLua.LuaType.LUA_TNONE:
                case UniLua.LuaType.LUA_TNIL:
                case UniLua.LuaType.LUA_TFUNCTION:
                case UniLua.LuaType.LUA_TLIGHTUSERDATA:
                case UniLua.LuaType.LUA_TUSERDATA:
                case UniLua.LuaType.LUA_TTHREAD:
                default:
                    throw new NotImplementedException();
            }
            return null;
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="i"></param>
        /// <returns></returns>
        public static List<T> GetList<T>(UniLua.ILuaState state, int i)
        {
            var type = state.Type(i);
            switch(type)
            {
                case UniLua.LuaType.LUA_TTABLE:
                    {
                        List<T> list = new List<T>();
                        int count = state.L_Len(i);
                        for(int index = 0; index < count; ++index)
                        {
                            state.RawGetI(i, index + 1);
                            list.Add(State.GetObject<T>(state, -1));
                            state.Pop(1);
                        }
                        return list;
                    }
                case UniLua.LuaType.LUA_TNUMBER:
                case UniLua.LuaType.LUA_TSTRING:
                case UniLua.LuaType.LUA_TBOOLEAN:
                case UniLua.LuaType.LUA_TUINT64:
                case UniLua.LuaType.LUA_TNONE:
                case UniLua.LuaType.LUA_TNIL:
                case UniLua.LuaType.LUA_TFUNCTION:
                case UniLua.LuaType.LUA_TLIGHTUSERDATA:
                case UniLua.LuaType.LUA_TUSERDATA:
                case UniLua.LuaType.LUA_TTHREAD:
                default:
                    throw new NotImplementedException();
            }
            return null;
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="i"></param>
        /// <returns></returns>
        public static object GetList(UniLua.ILuaState state, int i, System.Type t)
        {
            var type = state.Type(i);
            switch(type)
            {
                case UniLua.LuaType.LUA_TTABLE:
                    {
                        var list = (System.Collections.IList)Activator.CreateInstance(t);
                        var atype = t.GetGenericArguments()[0];
                        int count = state.L_Len(i);
                        for(int index = 0; index < count; ++index)
                        {
                            state.RawGetI(i, index + 1);
                            list.Add(State.GetObject(state, -1, atype));
                            state.Pop(1);
                        }
                        return list;
                    }
                case UniLua.LuaType.LUA_TNUMBER:
                case UniLua.LuaType.LUA_TSTRING:
                case UniLua.LuaType.LUA_TBOOLEAN:
                case UniLua.LuaType.LUA_TUINT64:
                case UniLua.LuaType.LUA_TNONE:
                case UniLua.LuaType.LUA_TNIL:
                case UniLua.LuaType.LUA_TFUNCTION:
                case UniLua.LuaType.LUA_TLIGHTUSERDATA:
                case UniLua.LuaType.LUA_TUSERDATA:
                case UniLua.LuaType.LUA_TTHREAD:
                default:
                    throw new NotImplementedException();
            }
            return null;
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Dictionary<T, K> GetDictionary<T, K>(UniLua.ILuaState state, int i)
        {
            var type = state.Type(i);
            switch(type)
            {
                case UniLua.LuaType.LUA_TTABLE:
                    {
                        Dictionary<T, K> dict = new Dictionary<T, K>();
                        var typeK = typeof(K);
                        state.PushNil();
                        if(i < 0)
                            //跳过NIL
                            i -= 1;
                        while(state.Next(i))
                        {
                            dict[State.GetObject<T>(state, -2)] = 
                                (K)State.GetObject(state, -1, typeK);
                            state.Pop(1);
                        }
                        return dict;
                    }
                case UniLua.LuaType.LUA_TNUMBER:
                case UniLua.LuaType.LUA_TSTRING:
                case UniLua.LuaType.LUA_TBOOLEAN:
                case UniLua.LuaType.LUA_TUINT64:
                case UniLua.LuaType.LUA_TNONE:
                case UniLua.LuaType.LUA_TNIL:
                case UniLua.LuaType.LUA_TFUNCTION:
                case UniLua.LuaType.LUA_TLIGHTUSERDATA:
                case UniLua.LuaType.LUA_TUSERDATA:
                case UniLua.LuaType.LUA_TTHREAD:
                default:
                    throw new NotImplementedException();
            }
            return null;
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="i"></param>
        /// <returns></returns>
        public static object GetDictionary(UniLua.ILuaState state, int i, System.Type t)
        {
            var type = state.Type(i);
            switch(type)
            {
                case UniLua.LuaType.LUA_TTABLE:
                    {
                        var dict = (System.Collections.IDictionary)Activator.CreateInstance(t);
                        var args = t.GetGenericArguments();
                        var left = args[0];
                        var right = args[1];

                        state.PushNil();
                        if(i < 0)
                            //跳过NIL
                            i -= 1;
                        while(state.Next(i))
                        {
                            dict[State.GetObject(state, -2, left)] = State.GetObject(state, -1, right);
                            state.Pop(1);
                        }
                        return dict;
                    }
                case UniLua.LuaType.LUA_TNUMBER:
                case UniLua.LuaType.LUA_TSTRING:
                case UniLua.LuaType.LUA_TBOOLEAN:
                case UniLua.LuaType.LUA_TUINT64:
                case UniLua.LuaType.LUA_TNONE:
                case UniLua.LuaType.LUA_TNIL:
                case UniLua.LuaType.LUA_TFUNCTION:
                case UniLua.LuaType.LUA_TLIGHTUSERDATA:
                case UniLua.LuaType.LUA_TUSERDATA:
                case UniLua.LuaType.LUA_TTHREAD:
                default:
                    throw new NotImplementedException();
            }
            return null;
        }
        /// <summary>
        /// 返回函数
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Function GetFunction(UniLua.ILuaState state, int i)
        {
            var type = state.Type(i);
            switch(type)
            {
                case UniLua.LuaType.LUA_TFUNCTION:
                    state.PushValue(i);
                    return new Function(state);
                case UniLua.LuaType.LUA_TNUMBER:
                case UniLua.LuaType.LUA_TSTRING:
                case UniLua.LuaType.LUA_TBOOLEAN:
                case UniLua.LuaType.LUA_TUINT64:
                case UniLua.LuaType.LUA_TTABLE:
                case UniLua.LuaType.LUA_TLIGHTUSERDATA:
                case UniLua.LuaType.LUA_TUSERDATA:
                case UniLua.LuaType.LUA_TTHREAD:
                case UniLua.LuaType.LUA_TNONE:
                case UniLua.LuaType.LUA_TNIL:
                default:
                    throw new NotImplementedException();
            }
            return null;
        }
        /// <summary>
        /// 返回引用
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Ref GetRef(UniLua.ILuaState state, int i)
        {
            state.PushValue(i);
            return new Ref(state);
        }
        /// <summary>
        /// 获得值
        /// </summary>
        /// <param name="state"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static object GetOneobject(UniLua.ILuaState state, int i)
        {
            var type = state.Type(i);
            switch(type)
            {
                case UniLua.LuaType.LUA_TTABLE:
                    {
                        var dict = new Dictionary<object, object>();
                        state.PushNil();
                        if(i < 0)
                            //跳过NIL
                            i -= 1;

                        while(state.Next(i))
                        {
                            dict[State.GetOneobject(state, -2)] = State.GetOneobject(state, -1);
                            state.Pop(1);
                        }
                        return dict;
                    }
                case UniLua.LuaType.LUA_TNUMBER:
                    return state.ToNumber(i);
                case UniLua.LuaType.LUA_TSTRING:
                    return state.ToString(i);
                case UniLua.LuaType.LUA_TBOOLEAN:
                    return state.ToBoolean(i);
                case UniLua.LuaType.LUA_TUINT64:
                    return state.ToUInt64(i);
                case UniLua.LuaType.LUA_TNONE:
                case UniLua.LuaType.LUA_TNIL:
                    return null;
                case UniLua.LuaType.LUA_TLIGHTUSERDATA:
                case UniLua.LuaType.LUA_TUSERDATA:
                    return state.ToUserData(i);
                case UniLua.LuaType.LUA_TFUNCTION:
                    state.PushValue(i);
                    return new Lua.Ref(state);
                case UniLua.LuaType.LUA_TTHREAD:
                    return state.ToThread(i);
                default:
                    throw new NotImplementedException();
            }
            return null;
        }
        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="i"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object GetObject(UniLua.ILuaState state, int i, System.Type type)
        {
            if(type == typeof(Ref))
                return State.GetRef(state, i);
            else if(type == typeof(Function))
                return State.GetFunction(state, i);
            else if(type == typeof(System.Object))
                return State.GetOneobject(state, i);
            else if(type == typeof(int))
                return State.GetInteger(state, i);
            else if(type == typeof(uint))
                return State.GetUInteger(state, i);
            else if(type == typeof(short))
                return State.GetShort(state, i);
            else if(type == typeof(ushort))
                return State.GetUShort(state, i);
            else if(type == typeof(char))
                return State.GetChar(state, i);
            else if(type == typeof(byte))
                return State.GetByte(state, i);
            else if(type == typeof(long))
                return State.GetLong(state, i);
            else if(type == typeof(ulong))
                return State.GetULong(state, i);
            else if(type == typeof(string))
                return State.GetString(state, i);
            else if(type == typeof(bool))
                return State.GetBoolean(state, i);
            else if(type == typeof(float))
                return State.GetFloat(state, i);
            else if(type == typeof(double))
                return State.GetDouble(state, i);
            else if(type.BaseType == typeof(Array))
                return State.GetArray(state, i, type);
            else if(type.GetInterface("System.Collections.IList") != null)
                return State.GetList(state, i, type);
            else if(type.GetInterface("System.Collections.IDictionary") != null)
                return State.GetDictionary(state, i, type);
            else
                return State.GetUserdata(state, i);
        }
        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="i"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static T GetObject<T>(UniLua.ILuaState state, int i)
        {
            return (T)State.GetObject(state, i, typeof(T));
        }
        /// <summary>
        /// 获取线程值
        /// </summary>
        /// <param name="state"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static UniLua.ILuaState GetThread(UniLua.ILuaState state, int i)
        {
            var type = state.Type(i);
            if(type == UniLua.LuaType.LUA_TTHREAD)
                return state.ToThread(i);
            throw new NotImplementedException();
            return null;
        }

        public static string GetTypeFullName(System.Type type)
        {
            if(type == typeof(int))
                return "int";
            else if(type == typeof(uint))
                return "uint";
            else if(type == typeof(short))
                return "short";
            else if(type == typeof(ushort))
                return "ushort";
            else if(type == typeof(char))
                return "char";
            else if(type == typeof(byte))
                return "byte";
            else if(type == typeof(long))
                return "long";
            else if(type == typeof(ulong))
                return "ulong";
            else if(type == typeof(float))
                return "float";
            else if(type == typeof(bool))
                return "bool";
            else if(type == typeof(double))
                return "double";
            else if(type == typeof(string))
                return "string";
            else if(type.IsGenericType)
                return GetGenericTypeName(type);
            else
                return GetReflectTypeName(type);
        }
        static string GetReflectTypeName(System.Type type)
        {
            string name = type.Name;
            var t = type.ReflectedType;
            while(t != null)
            {
                name = t.Name + "." + name;
                t = t.ReflectedType;
            }
            if(!string.IsNullOrEmpty(type.Namespace))
                name = type.Namespace + "." + name;
            return name;
        }
        static string GetGenericTypeName(System.Type type)
        {
            var types = type.GetGenericArguments();
            var str = "";
            for(int i = 0; i < types.Length; ++i)
            {
                str += GetTypeFullName(types[i]);
                if(i + 1 < types.Length)
                    str += ",";
            }
            var typename = GetReflectTypeName(type);// +"<" + str + ">";
            typename = typename.Split('`')[0];
            return typename + "<" + str + ">";
        }

        public static Metatable CreateMetatable(System.Type type,
                                                Dictionary<string, Action<Param>> ref_list,
                                                System.Type parent = null)
        {
            return new Metatable(type, ref_list, parent);
        }
        public State()
        {
            state_ = UniLua.LuaAPI.NewState();
            state_.L_OpenLibs();
        }
        public State(UniLua.ILuaState lua_state)
        {
            state_ = lua_state;
        }
        public State newthread()
        {
            var state = new State(state_.NewThread());
            state.parent_ = this;
            return state;
        }
        /// <summary>
        /// 执行文件
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public Error dofile(string filename)
        {
            var error = (Error)state_.L_DoFile(filename);
            if(error != Error.LUA_OK)
            {
                last_error_string_ = state_.ToString(-1);
                state_.Pop(1);
            }
            return error;
        }
        /// <summary>
        /// 执行字符串
        /// </summary>
        /// <param name="script"></param>
        /// <returns></returns>
        public Error dostring(string script, string name = null)
        {
            var error = (Error)state_.L_LoadBuffer(script, 
                (name == null ?  script : name + "\xd\xa"));
            if(error != Error.LUA_OK)
            {
                last_error_string_ = state_.ToString(-1);
                state_.Pop(1);
            }
            else
            {
                error = (Error)state_.PCall(0, Constant.LUA_MULTRET, 0);
                if(error != Error.LUA_OK)
                {
                    last_error_string_ = state_.ToString(-1);
                    state_.Pop(1);
                }
            }
            return error;
        }
        /// <summary>
        /// 注册函数
        /// </summary>
        /// <param name="name"></param>
        /// <param name="func"></param>
        public void register(string name, Action<Param> func)
        {
            if(string.IsNullOrEmpty(name) || func == null)
                return;

            PushFunction(func);
            state_.SetGlobal(name);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="module"></param>
        public void require(Module module)
        {
            if(module == null || module.pairs.Count == 0)
                return;

            var m = module;
            //var pairs = module.pairs.ToArray();
            state_.L_RequireF(m.name, L =>
            {
                var pairs = module.pairs.ToArray();
                L.L_NewLib(pairs);
                return 1;
            }, m.global);
            state_.Pop(1);
        }

        /// <summary>
        /// 整型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Ref newref(int value)
        {
            state_.PushInteger(value);
            return new Ref(state_);
        }
        /// <summary>
        /// 浮点
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Ref newref(float value)
        {
            state_.PushNumber(value);
            return new Ref(state_);
        }
        /// <summary>
        /// 双精度
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Ref newref(double value)
        {
            state_.PushNumber(value);
            return new Ref(state_);
        }
        /// <summary>
        /// 字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Ref newref(string value)
        {
            state_.PushString(value);
            return new Ref(state_);
        }
        /// <summary>
        /// 函数
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public Ref newref(Action<Param> func)
        {
            PushFunction(func);
            return new Ref(state_);
        }
        /// <summary>
        /// Light Userdata
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Ref newref(object obj)
        {
            state_.PushLightUserData(obj);
            return new Ref(state_);
        }
        /// <summary>
        /// 表
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public Ref newref(Dictionary<string, Ref> list)
        {
            state_.NewTable();
            _set_table(list);
            return new Ref(state_);
        }
        public Ref newreftable()
        {
            state_.NewTable();
            return new Ref(state_);
        }
        
        public void set_global(string name, int value)
        {
            if(string.IsNullOrEmpty(name))
                return;
            state_.PushInteger(value);
            state_.SetGlobal(name);
        }
        public void set_global(string name, float value)
        {
            if(string.IsNullOrEmpty(name))
                return;
            state_.PushNumber(value);
            state_.SetGlobal(name);
        }
        public void set_global(string name, double value)
        {
            if(string.IsNullOrEmpty(name))
                return;
            state_.PushNumber(value);
            state_.SetGlobal(name);
        }
        public void set_global(string name, string value)
        {
            if(string.IsNullOrEmpty(name))
                return;
            state_.PushString(value);
            state_.SetGlobal(name);
        }
        public void set_global(string name, object o)
        {
            if(string.IsNullOrEmpty(name))
                return;
            state_.PushLightUserData(o);
            state_.SetGlobal(name);
        }
        public void set_global(string name, Action<Param> func)
        {
            register(name, func);
        }
        public void set_global(string name, Dictionary<string, Ref> tables)
        {
            state_.NewTable();
            state_.SetGlobal(name);

            state_.GetGlobal(name);
            _set_table(tables);
            state_.Pop(1);
            return;
        }
        public void set_global(string name, Ref r)
        {
            if(string.IsNullOrEmpty(name) || !r.valid)
                return;
            r.Push();
            state_.SetGlobal(name);
        }

        void PushFunction(Action<Param> func)
        {
            state_.PushCSharpFunction(L =>
            {
                var param = new Param(L);
                func(param);
                return param.ReturnCount;
            });
        }
        void PushClosure(Action<Param> func, int n)
        {
            state_.PushCSharpClosure(L =>
            {
                var param = new Param(L);
                func(param);
                return param.ReturnCount;
            }, n);
        }
        public void set_table(Ref table, Dictionary<string, Ref> tables)
        {
            table.Push();
            _set_table(tables);
            state_.Pop(1);
        }
        void _set_table(Dictionary<string, Ref> list)
        {
            if(list == null || list.Count == 0)
                return;
            foreach(var dv in list)
            {
                if(dv.Value == null || !dv.Value.valid)
                    continue;
                state_.PushString(dv.Key);
                dv.Value.Push();
                state_.SetTable(-3);
            }
        }

        public Ref get_global(string name)
        {
            state_.GetGlobal(name);
            if(state_.IsNil(-1))
                return null;
            return new Ref(state_);
        }

        public Ref get_table_ref_with_path(string path)
        {
            if(string.IsNullOrEmpty(path))
                return null;

            Ref r = null;
            var ps = path.Split('.');
            
            var first = ps[0];
            state_.GetGlobal(first);
            if(state_.IsNil(-1))
            {
                state_.Pop(1);
                r = newreftable();
                set_global(first, r);
            }
            else
                r = new Ref(state_);

            Ref next = null;
            for(int i = 1; i < ps.Length; ++i)
            {
                r.Push();
                state_.GetField(-1, ps[i]);
                if(state_.IsNil(-1))
                {
                    state_.Pop(1);
                    next = newreftable();
                    state_.PushString(ps[i]);
                    next.Push();
                    state_.SetTable(-3);
                }
                else
                    next = new Lua.Ref(state_);
                state_.Pop(1);

                r.Dispose();
                r = next;
            }
            return r;
        }

        // UniLua没有完善的metatable机制，以下代码调用会导致__index索引异常
        //void newmetatable(string name)
        //{
        //    state_.NewTable();
        //    state_.PushValue(-1);
        //    state_.SetField(Constant.LUA_REGISTRYINDEX, name);
        //}
        //
        ///// <summary>
        ///// 注册metatable
        ///// </summary>
        ///// <param name="type">metatable相关类型</param>
        ///// <param name="tables">相关表</param>
        ///// <param name="parent">metatable继承表</param>
        //public void register(System.Type type, 
        //                    Dictionary<string, Ref> tables, 
        //                    System.Type parent = null)
        //{
        //    if(metatables_.Contains(type))
        //        return;
        //
        //    var typename = GetTypeFullName(type);
        //    string parentname = null;
        //    if(parent != null && metatables_.Contains(parent))
        //        parentname = GetTypeFullName(parent);
        //
        //    metatables_.Add(type);
        //    register(typename, tables, parentname);
        //}
        /// <summary>
        /// 注册metatable，由于UniLua无完善metatable，请勿擅自调用
        /// </summary>
        public void register(string name,
                            Dictionary<string, Ref> tables,
                            string parent = null)
        {
            state_.NewTable();
            if(!string.IsNullOrEmpty(parent))
            {
                state_.GetField(Constant.LUA_REGISTRYINDEX, parent);
                if(state_.IsNil(-1))
                    state_.Pop(1);
                else
                    state_.SetMetaTable(-2);
            }

            state_.PushValue(-1);
            state_.SetField(Constant.LUA_REGISTRYINDEX, name);

            state_.PushValue(-1);
            state_.SetField(-2, "__index");

            state_.PushString(name);
            state_.PushCSharpClosure(state =>
            {
                state.PushValue(state.UpvalueIndex(1));
                return 1;
            }, 1);
            state_.SetField(-2, "__tostring");

            if(tables != null || tables.Count == 0)
            {
                foreach(var dv in tables)
                {
                    dv.Value.Push();
                    state_.SetField(-2, dv.Key);
                }
            }
            state_.Pop(1);
        }

        public Ref newrefmetatable(Dictionary<string, Ref> tables)
        {
            state_.NewTable();
            state_.PushValue(-1);
            state_.SetField(-2, "__index");

            //if(tables != null | tables.Count == 0)
            //{
            //    foreach(var dv in tables)
            //    {
            //        dv.Value.Push();
            //        state_.SetField(-2, dv.Key);
            //    }
            //}
            _set_table(tables);
            return new Ref(state);
        }

        public void set_metatable(Ref r, Ref metatable)
        {
            r.Push();
            metatable.Push();
            state_.SetMetaTable(-2);
            state_.Pop(1);
        }

        int n { get { return state_.GetTop(); } }

        /// <summary>
        /// 父状态机
        /// </summary>
        State parent_ = null;
        /// <summary>
        /// 状态机
        /// </summary>
        public UniLua.ILuaState state { get { return state_; } }
        /// <summary>
        /// 状态机
        /// </summary>
        UniLua.ILuaState state_;
        /// <summary>
        /// 最后一次错误
        /// </summary>
        public string last_error_string { get { return last_error_string_; } }
        /// <summary>
        /// 最后一次错误
        /// </summary>
        string last_error_string_;

        /// <summary>
        /// 模块
        /// </summary>
        HashSet<Module> modules_ = new HashSet<Module>();
        ///// <summary>
        ///// 源表
        ///// </summary>
        //HashSet<System.Type> metatables_ = new HashSet<System.Type>();

        //=====================================================================
        //UniLua没有完善的metatable机制，将有如下代码完成类metatable功能

        public delegate Metatable OpenLibFunc(State state);
        public void register(OpenLibFunc openlib)
        {
            var metatable = openlib(this);
            if(metatable == null)
                return;
            register(metatable.type, metatable);
        }
        void register(System.Type type, Metatable metatable)
        {
            if(metatable == null)
                return;
            if(metatables_ == null)
            {
                register("__Wrap", new Dictionary<string, Lua.Ref> {
                    {"__index", newref(Index)},
                });
                metatables_ = new Dictionary<System.Type, Metatable>();
                type_dict_ = new Dictionary<string, System.Type>();
            }
            metatables_[type] = metatable;
            type_dict_[type.FullName] = type;
        }
        Metatable IndexMetatable(System.Type type)
        {
            Metatable metatable = null;
            metatables_.TryGetValue(type, out metatable);
            if(metatable == null)
            {
                if(parent_ != null)
                    metatable = parent_.IndexMetatable(type);
            }
            return metatable;
        }

        /// <summary>
        /// 索引函数，替换应该在lua的索引
        /// </summary>
        /// <param name="param"></param>
        void Index(Lua.Param param)
        {
            var userdata = param.GetUserdata(1);
            var index = param.GetString(2);
            var type = userdata.GetType();
            if(type == typeof(Dictionary<string, object>))
            {
                object typename;
                var dict = (Dictionary<string, object>)userdata;
                dict.TryGetValue("__|type|__", out typename);
                if(typename == null)
                {
                    param.Return();
                    return;
                }
                System.Type other_type;
                type_dict_.TryGetValue((string)typename, out other_type);
                if(other_type == null)
                {
                    if(typename == null)
                    {
                        param.Return();
                        return;
                    }
                }
                type = other_type;
            }

            Metatable m = null;
            while((m = IndexMetatable(type)) != null)
            {
                var r = m.Get(index);
                if(r != null)
                {
                    param.Return(r);
                    return;
                }
                type = m.parent;
            }
            param.Return();
        }
        /// <summary>
        /// 各个Type绑定的对象metatable（伪）表
        /// </summary>
        Dictionary<System.Type, Metatable> metatables_;
        /// <summary>
        /// 类型字典表
        /// </summary>
        Dictionary<string, System.Type> type_dict_;
    }
}
