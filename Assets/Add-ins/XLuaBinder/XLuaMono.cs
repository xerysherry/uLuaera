using System;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class XLuaMono : MonoBehaviour
{
    void Start()
    {
        Prepare();
        Lua.Resource.SetScriptPath(Config.GetProjectPath());
    }
    void Prepare()
    {
        var filename = string.Concat(Lua.Singleton.kStartLuaScript, gameObject.name, "X");
        var script = Lua.Resource.Load(filename);
        var objs = XLuaSingleton.DoString(script, filename);

        basetable = (LuaTable)objs[0];
        update_coroutine = basetable.Get<LuaFunction>("UpdateCoroutine");
    }
    void Update()
    {
        try
        {
            update_coroutine.Call();
        }
        catch(LuaException e)
        {
            OnError(e);
        }
    }
    void OnError(LuaException e)
    {
        Debug.LogError(e);

        var error = e.Message;
        Printer.PushAllConfig();
        Printer.DefaultAllConfig();
        Printer.SetFontSize(16);
        Printer.SetLineHeight(17);
        Printer.color = Color.red;
        var lines = error.Split('\n');
        foreach(var line in lines)
            Printer.PrintLn(line);
        Printer.PopAllConfig();
    }
    void OnDestroy()
    {
        Printer.LogClose();
    }
    LuaTable basetable;
    LuaFunction update_coroutine; 
}
