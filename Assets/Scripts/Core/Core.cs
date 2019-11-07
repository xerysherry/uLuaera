using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Core : LuaMono
{
    new void Awake()
    {
        Application.targetFrameRate = 60;
        SpriteManager.Init();
        Config.SetResourcePath("", Config.Location.PACKAGE);
        foreach(var sr in sprites)
        {
            SpriteManager.SetSpriteImage(sr.name, sr.resouce, 
                                        sr.rect, sr.border);
        }

        Printer.SelectConsole(console);

        Lua.Resource.SetScriptPath(Config.GetProjectPath());
        base.Awake();    
    }
    new void OnDestroy()
    {
        base.OnDestroy();
        Printer.LogClose();
    }
    public override void OnError(string error, bool critical)
    {
        base.OnError(error, critical);

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
    //new void LateUpdate()
    //{
    //    base.LateUpdate();

    //}
    public ConsoleContent console;

    //void UpdateOrientation()
    //{
    //    if(last_orientation_ != Input.deviceOrientation)
    //    {
    //        last_orientation_ = Input.deviceOrientation;
    //    }
    //}
    //DeviceOrientation last_orientation_ = DeviceOrientation.Unknown;
    [Serializable]
    public class SpriteRegister 
    {
        public string name;
        public string resouce;
        public Config.Location loc = Config.Location.PACKAGE;
        public Rect rect;
        public Vector4 border;
    }
    public List<SpriteRegister> sprites;
}
