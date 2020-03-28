using System;
using System.Collections.Generic;

public static class LuaTypeDefineForXLua
{
    [XLua.LuaCallCSharp]
    public static List<System.Type> XLuaTypeList = new List<System.Type>
    {
        typeof(UnityEngine.Color),
        typeof(UnityEngine.Time),
        typeof(UnityEngine.Debug),
        typeof(LuaUtils),
        typeof(FlagBit),
        typeof(Printer),
        typeof(StringHelper),
        typeof(Config),
    };
}
