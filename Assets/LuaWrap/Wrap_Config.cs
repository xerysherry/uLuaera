// THIS IS A GENERATED FILE. PLEASE DO NOT MODIFY IT!
using System;
using System.Collections;
using System.Collections.Generic;
using Lua;

namespace Lua
{
public static class Wrap_Config 
{
    /// <summary>
    /// function GetProjectPath()
    /// ex. Config.GetProjectPath()
    /// </summary>
    private static void _s_method_GetProjectPath_F7595740_0(Lua.Param pa)
    {
        var ra=Config.GetProjectPath();
        pa.Return(ra);
    }
    /// <summary>
    /// function GetSavePath()
    /// ex. Config.GetSavePath()
    /// </summary>
    private static void _s_method_GetSavePath_3213A0_0(Lua.Param pa)
    {
        var ra=Config.GetSavePath();
        pa.Return(ra);
    }
    /// <summary>
    /// function SetSavePath(string)
    /// ex. Config.SetSavePath(string1)
    /// </summary>
    private static void _s_method_SetSavePath_6CA91CC0_4(Lua.Param pa)
    {
        var a=pa.GetString(1);
        Config.SetSavePath(a);
    }
    /// <summary>
    /// function GetCsvPath()
    /// ex. Config.GetCsvPath()
    /// </summary>
    private static void _s_method_GetCsvPath_A750FF80_0(Lua.Param pa)
    {
        var ra=Config.GetCsvPath();
        pa.Return(ra);
    }
    /// <summary>
    /// function SetCsvPath(string)
    /// ex. Config.SetCsvPath(string1)
    /// </summary>
    private static void _s_method_SetCsvPath_E1F8E240_4(Lua.Param pa)
    {
        var a=pa.GetString(1);
        Config.SetCsvPath(a);
    }
    /// <summary>
    /// function SetResourcePath(string, number)
    /// ex. Config.SetResourcePath(string1, number2)
    /// </summary>
    private static void _s_method_SetResourcePath_1CA0C50_43(Lua.Param pa)
    {
        var a=pa.GetString(1);
        var b=pa.GetInteger(2);
        Config.SetResourcePath(a,(Config.Location)b);
    }
    private static void _s_get_property_Flags(Lua.Param pa)
    {
        pa.Return(Config.Flags);
    }
    private static void _s_set_property_Flags(Lua.Param pa)
    {
        var a=pa.GetUInteger(1);
        Config.Flags = a;
    }
    private static void _s_get_field_FlagBit(Lua.Param pa)
    {
        pa.Return(new Dictionary<string, object>{
                {"flags", Config.FlagBit.flags},
                {"isbutton", Config.FlagBit.isbutton},
                {"underline", Config.FlagBit.underline},
                {"strickout", Config.FlagBit.strickout},
                {"empty", Config.FlagBit.empty},
                {"richedit", Config.FlagBit.richedit},
                {"monospaced", Config.FlagBit.monospaced},
                {"gradient", Config.FlagBit.gradient},
                {"outline", Config.FlagBit.outline},
                {"shadow", Config.FlagBit.shadow},
                {"bold", Config.FlagBit.bold},
                {"italic", Config.FlagBit.italic},
        }, "FlagBit");
    }
    private static void _s_set_field_FlagBit(Lua.Param pa)
    {
        var s1=pa.GetDictionary<string, object>(1);
        var a = new FlagBit();
        object a_isbutton = null;
        if(s1.TryGetValue("isbutton", out a_isbutton))
            a.isbutton = (bool)a_isbutton;
        object a_underline = null;
        if(s1.TryGetValue("underline", out a_underline))
            a.underline = (bool)a_underline;
        object a_strickout = null;
        if(s1.TryGetValue("strickout", out a_strickout))
            a.strickout = (bool)a_strickout;
        object a_empty = null;
        if(s1.TryGetValue("empty", out a_empty))
            a.empty = (bool)a_empty;
        object a_richedit = null;
        if(s1.TryGetValue("richedit", out a_richedit))
            a.richedit = (bool)a_richedit;
        object a_monospaced = null;
        if(s1.TryGetValue("monospaced", out a_monospaced))
            a.monospaced = (bool)a_monospaced;
        object a_gradient = null;
        if(s1.TryGetValue("gradient", out a_gradient))
            a.gradient = (bool)a_gradient;
        object a_outline = null;
        if(s1.TryGetValue("outline", out a_outline))
            a.outline = (bool)a_outline;
        object a_shadow = null;
        if(s1.TryGetValue("shadow", out a_shadow))
            a.shadow = (bool)a_shadow;
        object a_bold = null;
        if(s1.TryGetValue("bold", out a_bold))
            a.bold = (bool)a_bold;
        object a_italic = null;
        if(s1.TryGetValue("italic", out a_italic))
            a.italic = (bool)a_italic;
        Config.FlagBit = a;
    }
    private static void _s_get_field_FontColor(Lua.Param pa)
    {
        pa.Return(new Dictionary<string, object>{
                {"r", Config.FontColor.r},
                {"g", Config.FontColor.g},
                {"b", Config.FontColor.b},
                {"a", Config.FontColor.a},
        }, "UnityEngine.Color32");
    }
    private static void _s_set_field_FontColor(Lua.Param pa)
    {
        var s1=pa.GetDictionary<string, object>(1);
        var a = new UnityEngine.Color32();
        object a_r = null;
        if(s1.TryGetValue("r", out a_r))
            a.r = (byte)(double)a_r;
        object a_g = null;
        if(s1.TryGetValue("g", out a_g))
            a.g = (byte)(double)a_g;
        object a_b = null;
        if(s1.TryGetValue("b", out a_b))
            a.b = (byte)(double)a_b;
        object a_a = null;
        if(s1.TryGetValue("a", out a_a))
            a.a = (byte)(double)a_a;
        Config.FontColor = a;
    }
    private static void _s_get_field_FontGradientColor(Lua.Param pa)
    {
        pa.Return(new Dictionary<string, object>{
                {"r", Config.FontGradientColor.r},
                {"g", Config.FontGradientColor.g},
                {"b", Config.FontGradientColor.b},
                {"a", Config.FontGradientColor.a},
        }, "UnityEngine.Color32");
    }
    private static void _s_set_field_FontGradientColor(Lua.Param pa)
    {
        var s1=pa.GetDictionary<string, object>(1);
        var a = new UnityEngine.Color32();
        object a_r = null;
        if(s1.TryGetValue("r", out a_r))
            a.r = (byte)(double)a_r;
        object a_g = null;
        if(s1.TryGetValue("g", out a_g))
            a.g = (byte)(double)a_g;
        object a_b = null;
        if(s1.TryGetValue("b", out a_b))
            a.b = (byte)(double)a_b;
        object a_a = null;
        if(s1.TryGetValue("a", out a_a))
            a.a = (byte)(double)a_a;
        Config.FontGradientColor = a;
    }
    private static void _s_get_field_FontShadowColor(Lua.Param pa)
    {
        pa.Return(new Dictionary<string, object>{
                {"r", Config.FontShadowColor.r},
                {"g", Config.FontShadowColor.g},
                {"b", Config.FontShadowColor.b},
                {"a", Config.FontShadowColor.a},
        }, "UnityEngine.Color32");
    }
    private static void _s_set_field_FontShadowColor(Lua.Param pa)
    {
        var s1=pa.GetDictionary<string, object>(1);
        var a = new UnityEngine.Color32();
        object a_r = null;
        if(s1.TryGetValue("r", out a_r))
            a.r = (byte)(double)a_r;
        object a_g = null;
        if(s1.TryGetValue("g", out a_g))
            a.g = (byte)(double)a_g;
        object a_b = null;
        if(s1.TryGetValue("b", out a_b))
            a.b = (byte)(double)a_b;
        object a_a = null;
        if(s1.TryGetValue("a", out a_a))
            a.a = (byte)(double)a_a;
        Config.FontShadowColor = a;
    }
    private static void _s_get_field_FontOutlineColor(Lua.Param pa)
    {
        pa.Return(new Dictionary<string, object>{
                {"r", Config.FontOutlineColor.r},
                {"g", Config.FontOutlineColor.g},
                {"b", Config.FontOutlineColor.b},
                {"a", Config.FontOutlineColor.a},
        }, "UnityEngine.Color32");
    }
    private static void _s_set_field_FontOutlineColor(Lua.Param pa)
    {
        var s1=pa.GetDictionary<string, object>(1);
        var a = new UnityEngine.Color32();
        object a_r = null;
        if(s1.TryGetValue("r", out a_r))
            a.r = (byte)(double)a_r;
        object a_g = null;
        if(s1.TryGetValue("g", out a_g))
            a.g = (byte)(double)a_g;
        object a_b = null;
        if(s1.TryGetValue("b", out a_b))
            a.b = (byte)(double)a_b;
        object a_a = null;
        if(s1.TryGetValue("a", out a_a))
            a.a = (byte)(double)a_a;
        Config.FontOutlineColor = a;
    }
    private static void _s_get_field_FontSize(Lua.Param pa)
    {
        pa.Return(Config.FontSize);
    }
    private static void _s_set_field_FontSize(Lua.Param pa)
    {
        var a=pa.GetInteger(1);
        Config.FontSize = a;
    }
    private static void _s_get_field_ImageColor(Lua.Param pa)
    {
        pa.Return(new Dictionary<string, object>{
                {"r", Config.ImageColor.r},
                {"g", Config.ImageColor.g},
                {"b", Config.ImageColor.b},
                {"a", Config.ImageColor.a},
        }, "UnityEngine.Color32");
    }
    private static void _s_set_field_ImageColor(Lua.Param pa)
    {
        var s1=pa.GetDictionary<string, object>(1);
        var a = new UnityEngine.Color32();
        object a_r = null;
        if(s1.TryGetValue("r", out a_r))
            a.r = (byte)(double)a_r;
        object a_g = null;
        if(s1.TryGetValue("g", out a_g))
            a.g = (byte)(double)a_g;
        object a_b = null;
        if(s1.TryGetValue("b", out a_b))
            a.b = (byte)(double)a_b;
        object a_a = null;
        if(s1.TryGetValue("a", out a_a))
            a.a = (byte)(double)a_a;
        Config.ImageColor = a;
    }
    private static void _s_get_field_BackgroundColor(Lua.Param pa)
    {
        pa.Return(new Dictionary<string, object>{
                {"r", Config.BackgroundColor.r},
                {"g", Config.BackgroundColor.g},
                {"b", Config.BackgroundColor.b},
                {"a", Config.BackgroundColor.a},
                {"grayscale", Config.BackgroundColor.grayscale},
                {"linear", Config.BackgroundColor.linear},
                {"gamma", Config.BackgroundColor.gamma},
                {"maxColorComponent", Config.BackgroundColor.maxColorComponent},
        }, "UnityEngine.Color");
    }
    private static void _s_set_field_BackgroundColor(Lua.Param pa)
    {
        var s1=pa.GetDictionary<string, object>(1);
        var a = new UnityEngine.Color();
        object a_r = null;
        if(s1.TryGetValue("r", out a_r))
            a.r = (float)(double)a_r;
        object a_g = null;
        if(s1.TryGetValue("g", out a_g))
            a.g = (float)(double)a_g;
        object a_b = null;
        if(s1.TryGetValue("b", out a_b))
            a.b = (float)(double)a_b;
        object a_a = null;
        if(s1.TryGetValue("a", out a_a))
            a.a = (float)(double)a_a;
        Config.BackgroundColor = a;
    }
    private static void _s_get_field_ResourcePath(Lua.Param pa)
    {
        pa.Return(Config.ResourcePath);
    }
    private static void _s_set_field_ResourcePath(Lua.Param pa)
    {
        var a=pa.GetString(1);
        Config.ResourcePath = a;
    }
    private static void _s_get_field_location(Lua.Param pa)
    {
        pa.Return((int)Config.location);
    }
    private static void _s_set_field_location(Lua.Param pa)
    {
        var a=pa.GetInteger(1);
        Config.location = (Config.Location)a;
    }
    private static void _s_get_field_FontName(Lua.Param pa)
    {
        pa.Return(Config.FontName);
    }
    private static void _s_set_field_FontName(Lua.Param pa)
    {
        var a=pa.GetString(1);
        Config.FontName = a;
    }
    private static void _s_get_field_MaxLog(Lua.Param pa)
    {
        pa.Return(Config.MaxLog);
    }
    private static void _s_set_field_MaxLog(Lua.Param pa)
    {
        var a=pa.GetInteger(1);
        Config.MaxLog = a;
    }
    private static void _s_get_field_LineHeight(Lua.Param pa)
    {
        pa.Return(Config.LineHeight);
    }
    private static void _s_set_field_LineHeight(Lua.Param pa)
    {
        var a=pa.GetInteger(1);
        Config.LineHeight = a;
    }
    public static Lua.Metatable OpenLib(Lua.State state)
    {
        Lua.Metatable metatable = null;
        var _Location = state.newrefmetatable(new Dictionary<string, Lua.Ref>
        {
            {"__newindex", state.newref(param=>{})},
            {"FILE_SYSTEM", state.newref((int)Config.Location.FILE_SYSTEM)},
            {"PACKAGE", state.newref((int)Config.Location.PACKAGE)},
        });
        var Location = state.newreftable();
        state.set_metatable(Location, _Location);
        var rt = state.get_table_ref_with_path("Config");
        var _rt = state.newrefmetatable(new Dictionary<string, Lua.Ref>
        {
            {"__newindex", state.newref(param=>{})},
            {"Location", Location},
            {"GetFlags", state.newref(_s_get_property_Flags)},
            {"SetFlags", state.newref(_s_set_property_Flags)},
            {"get_FlagBit", state.newref(_s_get_field_FlagBit)},
            {"set_FlagBit", state.newref(_s_set_field_FlagBit)},
            {"get_FontColor", state.newref(_s_get_field_FontColor)},
            {"set_FontColor", state.newref(_s_set_field_FontColor)},
            {"get_FontGradientColor", state.newref(_s_get_field_FontGradientColor)},
            {"set_FontGradientColor", state.newref(_s_set_field_FontGradientColor)},
            {"get_FontShadowColor", state.newref(_s_get_field_FontShadowColor)},
            {"set_FontShadowColor", state.newref(_s_set_field_FontShadowColor)},
            {"get_FontOutlineColor", state.newref(_s_get_field_FontOutlineColor)},
            {"set_FontOutlineColor", state.newref(_s_set_field_FontOutlineColor)},
            {"get_FontSize", state.newref(_s_get_field_FontSize)},
            {"set_FontSize", state.newref(_s_set_field_FontSize)},
            {"get_ImageColor", state.newref(_s_get_field_ImageColor)},
            {"set_ImageColor", state.newref(_s_set_field_ImageColor)},
            {"get_BackgroundColor", state.newref(_s_get_field_BackgroundColor)},
            {"set_BackgroundColor", state.newref(_s_set_field_BackgroundColor)},
            {"get_ResourcePath", state.newref(_s_get_field_ResourcePath)},
            {"set_ResourcePath", state.newref(_s_set_field_ResourcePath)},
            {"get_location", state.newref(_s_get_field_location)},
            {"set_location", state.newref(_s_set_field_location)},
            {"get_FontName", state.newref(_s_get_field_FontName)},
            {"set_FontName", state.newref(_s_set_field_FontName)},
            {"get_MaxLog", state.newref(_s_get_field_MaxLog)},
            {"set_MaxLog", state.newref(_s_set_field_MaxLog)},
            {"get_LineHeight", state.newref(_s_get_field_LineHeight)},
            {"set_LineHeight", state.newref(_s_set_field_LineHeight)},
            {"GetProjectPath", state.newref(_s_method_GetProjectPath_F7595740_0)},
            {"GetSavePath", state.newref(_s_method_GetSavePath_3213A0_0)},
            {"SetSavePath", state.newref(_s_method_SetSavePath_6CA91CC0_4)},
            {"GetCsvPath", state.newref(_s_method_GetCsvPath_A750FF80_0)},
            {"SetCsvPath", state.newref(_s_method_SetCsvPath_E1F8E240_4)},
            {"SetResourcePath", state.newref(_s_method_SetResourcePath_1CA0C50_43)},
        });
        state.set_metatable(rt, _rt);
        return metatable;  
    }

}
}
