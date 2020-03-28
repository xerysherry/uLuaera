using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using XLua;

public class XLuaSingleton : MonoBehaviour
{
    public static XLuaSingleton Instance { get { return _; } }
    static XLuaSingleton _;

    public static T LoadString<T>(byte[] chunk, string chunkName = "chunk", LuaTable env = null)
    {
        return _.L.LoadString<T>(chunk, chunkName, env);
    }
    public T LoadString<T>(string chunk, string chunkName = "chunk", LuaTable env = null)
    {
        return _.L.LoadString<T>(chunk, chunkName, env);
    }
    public LuaFunction LoadString(string chunk, string chunkName = "chunk", LuaTable env = null)
    {
        return _.L.LoadString(chunk, chunkName, env);
    }
    public static object[] DoString(string chunk, string chunkName = "chunk", LuaTable env = null)
    {
        return _.L.DoString(chunk, chunkName, env);
    }
    public static object[] DoString(byte[] chunk, string chunkName = "chunk", LuaTable env = null)
    {
        return _.L.DoString(chunk, chunkName, env);
    }

    void Awake()
    {
        _ = this;
        _L.AddLoader(Loader);

        var script = Lua.Resource.Load("(-_-b)X");
        _L.DoString(script, "(-_-b)X");

        //if(use_thread)
        //    StartThread();
    }
    void Update()
    {
        //if(!use_thread)
            _L.Tick();
    }
    void OnDestroy()
    {
        _ = null;
    }

    //void StartThread()
    //{
    //    ThreadPool.QueueUserWorkItem(new WaitCallback(p =>
    //    {
    //        ThreadWork();
    //    }));
    //}
    //void ThreadWork()
    //{
    //    try
    //    {
    //        while(!thread_exit)
    //        {
    //            if(Work != null)
    //                Work();
    //            _L.Tick();
    //            Thread.Sleep(sleep_time);
    //        }
    //    }
    //    catch(System.Exception e)
    //    {
    //        Debug.LogError(e);
    //    }
    //}

    byte[] Loader(ref string filename)
    {
        var script = Lua.Resource.Load(filename);
#if UNITY_EDITOR
        if(string.Compare(filename, "Entry") == 0)
            script = debug ?
                string.Concat("require\"LuaPanda\".start(\"127.0.0.1\",8818); ", script) :
                script;
#endif
        if(script != null)
            return System.Text.Encoding.UTF8.GetBytes(script);
        return null;
    }

    public LuaEnv L { get { return _L; } }
    LuaEnv _L = new LuaEnv();

#if UNITY_EDITOR
    public bool debug = false;
#endif
    //public bool use_thread = false;
    //bool thread_exit = false;
    //public System.Action Work = null;
    //int sleep_time = 1000 / 30;
}
