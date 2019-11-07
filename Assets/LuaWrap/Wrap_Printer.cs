// THIS IS A GENERATED FILE. PLEASE DO NOT MODIFY IT!
using System;
using System.Collections;
using System.Collections.Generic;
using Lua;

namespace Lua
{
public static class Wrap_Printer 
{
    /// <summary>
    /// function SelectConsole(userdata)
    /// ex. Printer.SelectConsole(userdata1)
    /// </summary>
    private static void _s_method_SelectConsole_4162B6C0_2(Lua.Param pa)
    {
        var a=pa.GetUserdata<ConsoleContent>(1);
        Printer.SelectConsole(a);
    }
    /// <summary>
    /// function SetTargetFrame(number)
    /// ex. Printer.SetTargetFrame(number1)
    /// </summary>
    private static void _s_method_SetTargetFrame_7CA9980_3(Lua.Param pa)
    {
        var a=pa.GetInteger(1);
        Printer.SetTargetFrame(a);
    }
    /// <summary>
    /// function TargetFrame()
    /// ex. Printer.TargetFrame()
    /// </summary>
    private static void _s_method_TargetFrame_B6B27C40_0(Lua.Param pa)
    {
        var ra=Printer.TargetFrame();
        pa.Return(ra);
    }
    /// <summary>
    /// function SetBackgroundColor(table)
    /// ex. Printer.SetBackgroundColor(table1)
    /// </summary>
    private static void _s_method_SetBackgroundColor_F15A5F0_5(Lua.Param pa)
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
        Printer.SetBackgroundColor(a);
    }
    /// <summary>
    /// function GetBackgroundColor()
    /// ex. Printer.GetBackgroundColor()
    /// </summary>
    private static void _s_method_GetBackgroundColor_2C241C0_0(Lua.Param pa)
    {
        var ra=Printer.GetBackgroundColor();
        pa.Return(new Dictionary<string, object>{
                {"r", ra.r},
                {"g", ra.g},
                {"b", ra.b},
                {"a", ra.a},
                {"grayscale", ra.grayscale},
                {"linear", ra.linear},
                {"gamma", ra.gamma},
                {"maxColorComponent", ra.maxColorComponent},
        }, "UnityEngine.Color");
    }
    /// <summary>
    /// function SetBackgroundImage(string, boolean, boolean)
    /// ex. Printer.SetBackgroundImage(string1, boolean2, boolean3)
    /// </summary>
    private static void _s_method_SetBackgroundImage_66AA2480_411(Lua.Param pa)
    {
        var a=pa.GetString(1);
        var b=pa.GetBoolean(2);
        var c=pa.GetBoolean(3);
        Printer.SetBackgroundImage(a,b,c);
    }
    /// <summary>
    /// function SetOrientation(number)
    /// ex. Printer.SetOrientation(number1)
    /// </summary>
    private static void _s_method_SetOrientation_A152740_3(Lua.Param pa)
    {
        var a=pa.GetInteger(1);
        Printer.SetOrientation((Printer.ScreenOrientation)a);
    }
    /// <summary>
    /// function PushFlags()
    /// ex. Printer.PushFlags()
    /// </summary>
    private static void _s_method_PushFlags_DBF9EA0_0(Lua.Param pa)
    {
        Printer.PushFlags();
    }
    /// <summary>
    /// function PopFlags()
    /// ex. Printer.PopFlags()
    /// </summary>
    private static void _s_method_PopFlags_16A1CCC0_0(Lua.Param pa)
    {
        Printer.PopFlags();
    }
    /// <summary>
    /// function DefaultFlags()
    /// ex. Printer.DefaultFlags()
    /// </summary>
    private static void _s_method_DefaultFlags_5149AF80_0(Lua.Param pa)
    {
        Printer.DefaultFlags();
    }
    /// <summary>
    /// function GetFlags()
    /// ex. Printer.GetFlags()
    /// </summary>
    private static void _s_method_GetFlags_8BF19240_0(Lua.Param pa)
    {
        var ra=Printer.GetFlags();
        pa.Return(ra);
    }
    /// <summary>
    /// function SetFlags(number)
    /// ex. Printer.SetFlags(number1)
    /// </summary>
    private static void _s_method_SetFlags_C699750_3(Lua.Param pa)
    {
        var a=pa.GetUInteger(1);
        Printer.SetFlags(a);
    }
    /// <summary>
    /// function PushColor()
    /// ex. Printer.PushColor()
    /// </summary>
    private static void _s_method_PushColor_14157C0_0(Lua.Param pa)
    {
        Printer.PushColor();
    }
    /// <summary>
    /// function PopColor()
    /// ex. Printer.PopColor()
    /// </summary>
    private static void _s_method_PopColor_3BE93A80_0(Lua.Param pa)
    {
        Printer.PopColor();
    }
    /// <summary>
    /// function DefaultColor()
    /// ex. Printer.DefaultColor()
    /// </summary>
    private static void _s_method_DefaultColor_76911D40_0(Lua.Param pa)
    {
        Printer.DefaultColor();
    }
    /// <summary>
    /// function PushGradientColor()
    /// ex. Printer.PushGradientColor()
    /// </summary>
    private static void _s_method_PushGradientColor_B13900_0(Lua.Param pa)
    {
        Printer.PushGradientColor();
    }
    /// <summary>
    /// function PopGradientColor()
    /// ex. Printer.PopGradientColor()
    /// </summary>
    private static void _s_method_PopGradientColor_49D5A40_0(Lua.Param pa)
    {
        Printer.PopGradientColor();
    }
    /// <summary>
    /// function DefaultGradientColor()
    /// ex. Printer.DefaultGradientColor()
    /// </summary>
    private static void _s_method_DefaultGradientColor_847CED0_0(Lua.Param pa)
    {
        Printer.DefaultGradientColor();
    }
    /// <summary>
    /// function PushShadowColor()
    /// ex. Printer.PushShadowColor()
    /// </summary>
    private static void _s_method_PushShadowColor_BF24CFC0_0(Lua.Param pa)
    {
        Printer.PushShadowColor();
    }
    /// <summary>
    /// function PopShadowColor()
    /// ex. Printer.PopShadowColor()
    /// </summary>
    private static void _s_method_PopShadowColor_F9CCB280_0(Lua.Param pa)
    {
        Printer.PopShadowColor();
    }
    /// <summary>
    /// function DefaultShadowColor()
    /// ex. Printer.DefaultShadowColor()
    /// </summary>
    private static void _s_method_DefaultShadowColor_34749540_0(Lua.Param pa)
    {
        Printer.DefaultShadowColor();
    }
    /// <summary>
    /// function PushOutlineColor()
    /// ex. Printer.PushOutlineColor()
    /// </summary>
    private static void _s_method_PushOutlineColor_6F1C780_0(Lua.Param pa)
    {
        Printer.PushOutlineColor();
    }
    /// <summary>
    /// function PopOutlineColor()
    /// ex. Printer.PopOutlineColor()
    /// </summary>
    private static void _s_method_PopOutlineColor_A9C45AC0_0(Lua.Param pa)
    {
        Printer.PopOutlineColor();
    }
    /// <summary>
    /// function DefaultOutlineColor()
    /// ex. Printer.DefaultOutlineColor()
    /// </summary>
    private static void _s_method_DefaultOutlineColor_E46C3D80_0(Lua.Param pa)
    {
        Printer.DefaultOutlineColor();
    }
    /// <summary>
    /// function PushImageColor()
    /// ex. Printer.PushImageColor()
    /// </summary>
    private static void _s_method_PushImageColor_1F142040_0(Lua.Param pa)
    {
        Printer.PushImageColor();
    }
    /// <summary>
    /// function PopImageColor()
    /// ex. Printer.PopImageColor()
    /// </summary>
    private static void _s_method_PopImageColor_59BC30_0(Lua.Param pa)
    {
        Printer.PopImageColor();
    }
    /// <summary>
    /// function DefaultImageColor()
    /// ex. Printer.DefaultImageColor()
    /// </summary>
    private static void _s_method_DefaultImageColor_9463E5C0_0(Lua.Param pa)
    {
        Printer.DefaultImageColor();
    }
    /// <summary>
    /// function PushAllConfig()
    /// ex. Printer.PushAllConfig()
    /// </summary>
    private static void _s_method_PushAllConfig_CFBC880_0(Lua.Param pa)
    {
        Printer.PushAllConfig();
    }
    /// <summary>
    /// function PopAllConfig()
    /// ex. Printer.PopAllConfig()
    /// </summary>
    private static void _s_method_PopAllConfig_9B3AB40_0(Lua.Param pa)
    {
        Printer.PopAllConfig();
    }
    /// <summary>
    /// function DefaultAllConfig()
    /// ex. Printer.DefaultAllConfig()
    /// </summary>
    private static void _s_method_DefaultAllConfig_445B8E0_0(Lua.Param pa)
    {
        Printer.DefaultAllConfig();
    }
    /// <summary>
    /// function SetFontSize(number)
    /// ex. Printer.SetFontSize(number1)
    /// </summary>
    private static void _s_method_SetFontSize_7F370C0_3(Lua.Param pa)
    {
        var a=pa.GetInteger(1);
        Printer.SetFontSize(a);
    }
    /// <summary>
    /// function GetFontSize()
    /// ex. Printer.GetFontSize()
    /// </summary>
    private static void _s_method_GetFontSize_B9AB5380_0(Lua.Param pa)
    {
        var ra=Printer.GetFontSize();
        pa.Return(ra);
    }
    /// <summary>
    /// function SetLineHeight(number)
    /// ex. Printer.SetLineHeight(number1)
    /// </summary>
    private static void _s_method_SetLineHeight_2EFB190_3(Lua.Param pa)
    {
        var a=pa.GetInteger(1);
        Printer.SetLineHeight(a);
    }
    /// <summary>
    /// function GetLineHeight()
    /// ex. Printer.GetLineHeight()
    /// </summary>
    private static void _s_method_GetLineHeight_69A2FBC0_0(Lua.Param pa)
    {
        var ra=Printer.GetLineHeight();
        pa.Return(ra);
    }
    /// <summary>
    /// function SetButtonStyle(table, table, table, table)
    /// ex. Printer.SetButtonStyle(table1, table2, table3, table4)
    /// </summary>
    private static void _s_method_SetButtonStyle_DEF2C140_5555(Lua.Param pa)
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
        var s2=pa.GetDictionary<string, object>(2);
        var b = new UnityEngine.Color();
        object b_r = null;
        if(s2.TryGetValue("r", out b_r))
            b.r = (float)(double)b_r;
        object b_g = null;
        if(s2.TryGetValue("g", out b_g))
            b.g = (float)(double)b_g;
        object b_b = null;
        if(s2.TryGetValue("b", out b_b))
            b.b = (float)(double)b_b;
        object b_a = null;
        if(s2.TryGetValue("a", out b_a))
            b.a = (float)(double)b_a;
        var s3=pa.GetDictionary<string, object>(3);
        var c = new UnityEngine.Color();
        object c_r = null;
        if(s3.TryGetValue("r", out c_r))
            c.r = (float)(double)c_r;
        object c_g = null;
        if(s3.TryGetValue("g", out c_g))
            c.g = (float)(double)c_g;
        object c_b = null;
        if(s3.TryGetValue("b", out c_b))
            c.b = (float)(double)c_b;
        object c_a = null;
        if(s3.TryGetValue("a", out c_a))
            c.a = (float)(double)c_a;
        var s4=pa.GetDictionary<string, object>(4);
        var d = new UnityEngine.Color();
        object d_r = null;
        if(s4.TryGetValue("r", out d_r))
            d.r = (float)(double)d_r;
        object d_g = null;
        if(s4.TryGetValue("g", out d_g))
            d.g = (float)(double)d_g;
        object d_b = null;
        if(s4.TryGetValue("b", out d_b))
            d.b = (float)(double)d_b;
        object d_a = null;
        if(s4.TryGetValue("a", out d_a))
            d.a = (float)(double)d_a;
        Printer.SetButtonStyle(a,b,c,d);
    }
    /// <summary>
    /// function ClearButtonStyle()
    /// ex. Printer.ClearButtonStyle()
    /// </summary>
    private static void _s_method_ClearButtonStyle_199AA40_0(Lua.Param pa)
    {
        Printer.ClearButtonStyle();
    }
    /// <summary>
    /// function ShowFPS(boolean)
    /// ex. Printer.ShowFPS(boolean1)
    /// </summary>
    private static void _s_method_ShowFPS_544286C0_1(Lua.Param pa)
    {
        var a=pa.GetBoolean(1);
        Printer.ShowFPS(a);
    }
    /// <summary>
    /// function Quit()
    /// ex. Printer.Quit()
    /// </summary>
    private static void _s_method_Quit_8EEA6980_0(Lua.Param pa)
    {
        Printer.Quit();
    }
    /// <summary>
    /// function DataPath()
    /// ex. Printer.DataPath()
    /// </summary>
    private static void _s_method_DataPath_C9924C40_0(Lua.Param pa)
    {
        var ra=Printer.DataPath();
        pa.Return(ra);
    }
    /// <summary>
    /// function PersistentDataPath()
    /// ex. Printer.PersistentDataPath()
    /// </summary>
    private static void _s_method_PersistentDataPath_43A2F0_0(Lua.Param pa)
    {
        var ra=Printer.PersistentDataPath();
        pa.Return(ra);
    }
    /// <summary>
    /// function IsMobilePlatform()
    /// ex. Printer.IsMobilePlatform()
    /// </summary>
    private static void _s_method_IsMobilePlatform_3EE211C0_0(Lua.Param pa)
    {
        var ra=Printer.IsMobilePlatform();
        pa.Return(ra);
    }
    /// <summary>
    /// function Platform()
    /// ex. Printer.Platform()
    /// </summary>
    private static void _s_method_Platform_7989F480_0(Lua.Param pa)
    {
        var ra=Printer.Platform();
        pa.Return(ra);
    }
    /// <summary>
    /// function RunInBackground()
    /// ex. Printer.RunInBackground()
    /// </summary>
    private static void _s_method_RunInBackground_B431D740_0(Lua.Param pa)
    {
        var ra=Printer.RunInBackground();
        pa.Return(ra);
    }
    /// <summary>
    /// function SetRunInBackground(boolean)
    /// ex. Printer.SetRunInBackground(boolean1)
    /// </summary>
    private static void _s_method_SetRunInBackground_EED9BA0_1(Lua.Param pa)
    {
        var a=pa.GetBoolean(1);
        Printer.SetRunInBackground(a);
    }
    /// <summary>
    /// function OpenURL(string)
    /// ex. Printer.OpenURL(string1)
    /// </summary>
    private static void _s_method_OpenURL_29819CC0_4(Lua.Param pa)
    {
        var a=pa.GetString(1);
        Printer.OpenURL(a);
    }
    /// <summary>
    /// function SetResolution(number, number, boolean)
    /// ex. Printer.SetResolution(number1, number2, boolean3)
    /// </summary>
    private static void _s_method_SetResolution_64297F80_331(Lua.Param pa)
    {
        var a=pa.GetInteger(1);
        var b=pa.GetInteger(2);
        var c=pa.GetBoolean(3);
        Printer.SetResolution(a,b,c);
    }
    /// <summary>
    /// function GetResolution()
    /// ex. Printer.GetResolution()
    /// </summary>
    private static void _s_method_GetResolution_9ED16240_0(Lua.Param pa)
    {
        var rb=default(int);
        var rc=default(int);
        Printer.GetResolution(out rb,out rc);
        pa.Return(rb);
        pa.Return(rc);
    }
    /// <summary>
    /// function SetDragEnable(boolean)
    /// ex. Printer.SetDragEnable(boolean1)
    /// </summary>
    private static void _s_method_SetDragEnable_D979450_1(Lua.Param pa)
    {
        var a=pa.GetBoolean(1);
        Printer.SetDragEnable(a);
    }
    /// <summary>
    /// function SetConsoleBorder(number, number, number, number)
    /// ex. Printer.SetConsoleBorder(number1, number2, number3, number4)
    /// </summary>
    private static void _s_method_SetConsoleBorder_142127C0_3333(Lua.Param pa)
    {
        var a=pa.GetInteger(1);
        var b=pa.GetInteger(2);
        var c=pa.GetInteger(3);
        var d=pa.GetInteger(4);
        Printer.SetConsoleBorder(a,b,c,d);
    }
    /// <summary>
    /// function NowStamp()
    /// ex. Printer.NowStamp()
    /// </summary>
    private static void _s_method_NowStamp_4EC9A80_0(Lua.Param pa)
    {
        var ra=Printer.NowStamp();
        pa.Return(ra);
    }
    /// <summary>
    /// function DateToStamp(number, number, number, number, number, number)
    /// ex. Printer.DateToStamp(number1, number2, number3, number4, number5, number6)
    /// </summary>
    private static void _s_method_DateToStamp_8970ED40_333333(Lua.Param pa)
    {
        var a=pa.GetInteger(1);
        var b=pa.GetInteger(2);
        var c=pa.GetInteger(3);
        var d=pa.GetInteger(4);
        var e=pa.GetInteger(5);
        var f=pa.GetInteger(6);
        var ra=Printer.DateToStamp(a,b,c,d,e,f);
        pa.Return(ra);
    }
    /// <summary>
    /// function Now()
    /// ex. Printer.Now()
    /// </summary>
    private static void _s_method_Now_C418D00_0(Lua.Param pa)
    {
        var ra=Printer.Now();
        pa.Return(ra, typeof(System.Collections.Generic.Dictionary<string,int>));
    }
    /// <summary>
    /// function Date(number, number, number, number, number, number)
    /// ex. Printer.Date(number1, number2, number3, number4, number5, number6)
    /// </summary>
    private static void _s_method_Date_FEC0B2C0_333333(Lua.Param pa)
    {
        var a=pa.GetInteger(1);
        var b=pa.GetInteger(2);
        var c=pa.GetInteger(3);
        var d=pa.GetInteger(4);
        var e=pa.GetInteger(5);
        var f=pa.GetInteger(6);
        var ra=Printer.Date(a,b,c,d,e,f);
        pa.Return(ra, typeof(System.Collections.Generic.Dictionary<string,int>));
    }
    /// <summary>
    /// function StampToDate(number)
    /// ex. Printer.StampToDate(number1)
    /// </summary>
    private static void _s_method_StampToDate_39689580_3(Lua.Param pa)
    {
        var a=pa.GetInteger(1);
        var ra=Printer.StampToDate(a);
        pa.Return(ra, typeof(System.Collections.Generic.Dictionary<string,int>));
    }
    /// <summary>
    /// function SetLogFile(string, boolean)
    /// ex. Printer.SetLogFile(string1, boolean2)
    /// </summary>
    private static void _s_method_SetLogFile_AEB85B0_41(Lua.Param pa)
    {
        var a=pa.GetString(1);
        var b=pa.GetBoolean(2);
        Printer.SetLogFile(a,b);
    }
    /// <summary>
    /// function SetLogEnable(boolean)
    /// ex. Printer.SetLogEnable(boolean1)
    /// </summary>
    private static void _s_method_SetLogEnable_E9603DC0_1(Lua.Param pa)
    {
        var a=pa.GetBoolean(1);
        Printer.SetLogEnable(a);
    }
    /// <summary>
    /// function LogWrite(string)
    /// ex. Printer.LogWrite(string1)
    /// </summary>
    private static void _s_method_LogWrite_2482080_4(Lua.Param pa)
    {
        var a=pa.GetString(1);
        Printer.LogWrite(a);
    }
    /// <summary>
    /// function LogWriteLn(string)
    /// ex. Printer.LogWriteLn(string1)
    /// </summary>
    private static void _s_method_LogWriteLn_5EB0340_4(Lua.Param pa)
    {
        var a=pa.GetString(1);
        Printer.LogWriteLn(a);
    }
    /// <summary>
    /// function LogShiftLine()
    /// ex. Printer.LogShiftLine()
    /// </summary>
    private static void _s_method_LogShiftLine_9957E60_0(Lua.Param pa)
    {
        Printer.LogShiftLine();
    }
    /// <summary>
    /// function SetAutoLine(number)
    /// ex. Printer.SetAutoLine(number1)
    /// </summary>
    private static void _s_method_SetAutoLine_494F8E40_3(Lua.Param pa)
    {
        var a=pa.GetInteger(1);
        Printer.SetAutoLine(a);
    }
    /// <summary>
    /// function GetAutoLine()
    /// ex. Printer.GetAutoLine()
    /// </summary>
    private static void _s_method_GetAutoLine_83F7710_0(Lua.Param pa)
    {
        var ra=Printer.GetAutoLine();
        pa.Return(ra);
    }
    /// <summary>
    /// function GetStringLines(string, number)
    /// ex. Printer.GetStringLines(string1, number2)
    /// </summary>
    private static void _s_method_GetStringLines_BE9F53C0_43(Lua.Param pa)
    {
        var a=pa.GetString(1);
        var b=pa.GetInteger(2);
        var ra=Printer.GetStringLines(a,b);
        pa.Return(ra, typeof(System.Collections.Generic.List<string>));
    }
    /// <summary>
    /// function GetStringLines(string, boolean, number)
    /// ex. Printer.GetStringLines(string1, boolean2, number3)
    /// </summary>
    private static void _s_method_GetStringLines_F9473680_413(Lua.Param pa)
    {
        var a=pa.GetString(1);
        var b=pa.GetBoolean(2);
        var c=pa.GetInteger(3);
        var ra=Printer.GetStringLines(a,b,c);
        pa.Return(ra, typeof(System.Collections.Generic.List<string>));
    }
    /// <summary>
    /// function PrintT(number, number, string)
    /// ex. Printer.PrintT(number1, number2, string3)
    /// </summary>
    private static void _s_method_PrintT_33EF1940_334(Lua.Param pa)
    {
        var a=pa.GetInteger(1);
        var b=pa.GetInteger(2);
        var c=pa.GetString(3);
        Printer.PrintT(a,(Printer.Align)b,c);
    }
    /// <summary>
    /// function PrintTLn(number, number, string)
    /// ex. Printer.PrintTLn(number1, number2, string3)
    /// </summary>
    private static void _s_method_PrintTLn_6E96FC0_334(Lua.Param pa)
    {
        var a=pa.GetInteger(1);
        var b=pa.GetInteger(2);
        var c=pa.GetString(3);
        Printer.PrintTLn(a,(Printer.Align)b,c);
    }
    /// <summary>
    /// function PrintTF(number, number, string, table)
    /// ex. Printer.PrintTF(number1, number2, string3, table4)
    /// </summary>
    private static void _s_method_PrintTF_A93EDEC0_3345(Lua.Param pa)
    {
        var a=pa.GetInteger(1);
        var b=pa.GetInteger(2);
        var c=pa.GetString(3);
        var d=pa.GetArray<System.Object>(4);
        Printer.PrintTF(a,(Printer.Align)b,c,d);
    }
    /// <summary>
    /// function PrintTFLn(number, number, string, table)
    /// ex. Printer.PrintTFLn(number1, number2, string3, table4)
    /// </summary>
    private static void _s_method_PrintTFLn_E3E6C180_3345(Lua.Param pa)
    {
        var a=pa.GetInteger(1);
        var b=pa.GetInteger(2);
        var c=pa.GetString(3);
        var d=pa.GetArray<System.Object>(4);
        Printer.PrintTFLn(a,(Printer.Align)b,c,d);
    }
    /// <summary>
    /// function PrintF(string, table)
    /// ex. Printer.PrintF(string1, table2)
    /// </summary>
    private static void _s_method_PrintF_1E8EA440_45(Lua.Param pa)
    {
        var a=pa.GetString(1);
        var b=pa.GetArray<System.Object>(2);
        Printer.PrintF(a,b);
    }
    /// <summary>
    /// function PrintFLn(string, table)
    /// ex. Printer.PrintFLn(string1, table2)
    /// </summary>
    private static void _s_method_PrintFLn_5936870_45(Lua.Param pa)
    {
        var a=pa.GetString(1);
        var b=pa.GetArray<System.Object>(2);
        Printer.PrintFLn(a,b);
    }
    /// <summary>
    /// function Print(string)
    /// ex. Printer.Print(string1)
    /// </summary>
    private static void _s_method_Print_93DE69C0_4(Lua.Param pa)
    {
        var a=pa.GetString(1);
        Printer.Print(a);
    }
    /// <summary>
    /// function PrintLn(string)
    /// ex. Printer.PrintLn(string1)
    /// </summary>
    private static void _s_method_PrintLn_CE864C80_4(Lua.Param pa)
    {
        var a=pa.GetString(1);
        Printer.PrintLn(a);
    }
    /// <summary>
    /// function SetSpriteImage(string, string, table, table, boolean)
    /// ex. Printer.SetSpriteImage(string1, string2, table3, table4, boolean5)
    /// </summary>
    private static void _s_method_SetSpriteImage_92E2F40_44551(Lua.Param pa)
    {
        var a=pa.GetString(1);
        var b=pa.GetString(2);
        var c=pa.GetList<float>(3);
        var d=pa.GetList<float>(4);
        var e=pa.GetBoolean(5);
        Printer.SetSpriteImage(a,b,c,d,e);
    }
    /// <summary>
    /// function SetSpriteAnimation(string, number, table)
    /// ex. Printer.SetSpriteAnimation(string1, number2, table3)
    /// </summary>
    private static void _s_method_SetSpriteAnimation_7E7DF4C0_435(Lua.Param pa)
    {
        var a=pa.GetString(1);
        var b=pa.GetFloat(2);
        var c=pa.GetList<System.Collections.Generic.List<System.Object>>(3);
        Printer.SetSpriteAnimation(a,b,c);
    }
    /// <summary>
    /// function SetAnimationLoop(number)
    /// ex. Printer.SetAnimationLoop(number1)
    /// </summary>
    private static void _s_method_SetAnimationLoop_F3CDBA40_3(Lua.Param pa)
    {
        var a=pa.GetInteger(1);
        Printer.SetAnimationLoop(a);
    }
    /// <summary>
    /// function CheckSprite(string)
    /// ex. Printer.CheckSprite(string1)
    /// </summary>
    private static void _s_method_CheckSprite_2E759D0_4(Lua.Param pa)
    {
        var a=pa.GetString(1);
        var ra=Printer.CheckSprite(a);
        pa.Return(ra);
    }
    /// <summary>
    /// function SetErrorImage(string, table)
    /// ex. Printer.SetErrorImage(string1, table2)
    /// </summary>
    private static void _s_method_SetErrorImage_691D7FC0_45(Lua.Param pa)
    {
        var a=pa.GetString(1);
        var s2=pa.GetDictionary<string, object>(2);
        var b = new UnityEngine.Color();
        object b_r = null;
        if(s2.TryGetValue("r", out b_r))
            b.r = (float)(double)b_r;
        object b_g = null;
        if(s2.TryGetValue("g", out b_g))
            b.g = (float)(double)b_g;
        object b_b = null;
        if(s2.TryGetValue("b", out b_b))
            b.b = (float)(double)b_b;
        object b_a = null;
        if(s2.TryGetValue("a", out b_a))
            b.a = (float)(double)b_a;
        Printer.SetErrorImage(a,b);
    }
    /// <summary>
    /// function Image(string, number, number, number, number, boolean)
    /// ex. Printer.Image(string1, number2, number3, number4, number5, boolean6)
    /// </summary>
    private static void _s_method_Image_A3C56280_433331(Lua.Param pa)
    {
        var a=pa.GetString(1);
        var b=pa.GetFloat(2);
        var c=pa.GetFloat(3);
        var d=pa.GetFloat(4);
        var e=pa.GetFloat(5);
        var f=pa.GetBoolean(6);
        Printer.Image(a,b,c,d,e,f);
    }
    /// <summary>
    /// function ImageP(string, number, number, boolean)
    /// ex. Printer.ImageP(string1, number2, number3, boolean4)
    /// </summary>
    private static void _s_method_ImageP_DE6D4540_4331(Lua.Param pa)
    {
        var a=pa.GetString(1);
        var b=pa.GetInteger(2);
        var c=pa.GetInteger(3);
        var d=pa.GetBoolean(4);
        Printer.ImageP(a,b,c,d);
    }
    /// <summary>
    /// function ImageS(string, number, number, boolean)
    /// ex. Printer.ImageS(string1, number2, number3, boolean4)
    /// </summary>
    private static void _s_method_ImageS_1915280_4331(Lua.Param pa)
    {
        var a=pa.GetString(1);
        var b=pa.GetInteger(2);
        var c=pa.GetInteger(3);
        var d=pa.GetBoolean(4);
        Printer.ImageS(a,b,c,d);
    }
    /// <summary>
    /// function ImagePS(string, number, number, number, number, boolean)
    /// ex. Printer.ImagePS(string1, number2, number3, number4, number5, boolean6)
    /// </summary>
    private static void _s_method_ImagePS_53BDAC0_433331(Lua.Param pa)
    {
        var a=pa.GetString(1);
        var b=pa.GetInteger(2);
        var c=pa.GetInteger(3);
        var d=pa.GetInteger(4);
        var e=pa.GetInteger(5);
        var f=pa.GetBoolean(6);
        Printer.ImagePS(a,b,c,d,e,f);
    }
    /// <summary>
    /// function SetCode(string)
    /// ex. Printer.SetCode(string1)
    /// </summary>
    private static void _s_method_SetCode_8E64ED80_4(Lua.Param pa)
    {
        var a=pa.GetString(1);
        Printer.SetCode(a);
    }
    /// <summary>
    /// function RemoveLine(number)
    /// ex. Printer.RemoveLine(number1)
    /// </summary>
    private static void _s_method_RemoveLine_C9CD040_3(Lua.Param pa)
    {
        var a=pa.GetInteger(1);
        Printer.RemoveLine(a);
    }
    /// <summary>
    /// function Clear()
    /// ex. Printer.Clear()
    /// </summary>
    private static void _s_method_Clear_3B4B30_0(Lua.Param pa)
    {
        Printer.Clear();
    }
    /// <summary>
    /// function MovePosByPixel(number)
    /// ex. Printer.MovePosByPixel(number1)
    /// </summary>
    private static void _s_method_MovePosByPixel_3E5C95C0_3(Lua.Param pa)
    {
        var a=pa.GetInteger(1);
        Printer.MovePosByPixel(a);
    }
    /// <summary>
    /// function MovePosByWord(number)
    /// ex. Printer.MovePosByWord(number1)
    /// </summary>
    private static void _s_method_MovePosByWord_7947880_3(Lua.Param pa)
    {
        var a=pa.GetInteger(1);
        Printer.MovePosByWord(a);
    }
    /// <summary>
    /// function ResetPosByPixel(number)
    /// ex. Printer.ResetPosByPixel(number1)
    /// </summary>
    private static void _s_method_ResetPosByPixel_28FC20C0_3(Lua.Param pa)
    {
        var a=pa.GetInteger(1);
        Printer.ResetPosByPixel(a);
    }
    /// <summary>
    /// function ResetPosByWord(number)
    /// ex. Printer.ResetPosByWord(number1)
    /// </summary>
    private static void _s_method_ResetPosByWord_63A4380_3(Lua.Param pa)
    {
        var a=pa.GetInteger(1);
        Printer.ResetPosByWord(a);
    }
    /// <summary>
    /// function GetCurrentPos()
    /// ex. Printer.GetCurrentPos()
    /// </summary>
    private static void _s_method_GetCurrentPos_9E4BE640_0(Lua.Param pa)
    {
        var ra=Printer.GetCurrentPos();
        pa.Return(ra);
    }
    /// <summary>
    /// function NextTextPart(boolean)
    /// ex. Printer.NextTextPart(boolean1)
    /// </summary>
    private static void _s_method_NextTextPart_D8F3C90_1(Lua.Param pa)
    {
        var a=pa.GetBoolean(1);
        Printer.NextTextPart(a);
    }
    /// <summary>
    /// function NextImagePart(boolean)
    /// ex. Printer.NextImagePart(boolean1)
    /// </summary>
    private static void _s_method_NextImagePart_139BABC0_1(Lua.Param pa)
    {
        var a=pa.GetBoolean(1);
        Printer.NextImagePart(a);
    }
    /// <summary>
    /// function ShiftLine(number, boolean)
    /// ex. Printer.ShiftLine(number1, boolean2)
    /// </summary>
    private static void _s_method_ShiftLine_88EB7140_31(Lua.Param pa)
    {
        var a=pa.GetInteger(1);
        var b=pa.GetBoolean(2);
        Printer.ShiftLine(a,b);
    }
    /// <summary>
    /// function SetMsg(string)
    /// ex. Printer.SetMsg(string1)
    /// </summary>
    private static void _s_method_SetMsg_738AFC40_4(Lua.Param pa)
    {
        var a=pa.GetString(1);
        Printer.SetMsg(a);
    }
    /// <summary>
    /// function GetMsg()
    /// ex. Printer.GetMsg()
    /// </summary>
    private static void _s_method_GetMsg_AE32DF0_0(Lua.Param pa)
    {
        var ra=Printer.GetMsg();
        pa.Return(ra);
    }
    /// <summary>
    /// function EmptyMsg(boolean)
    /// ex. Printer.EmptyMsg(boolean1)
    /// </summary>
    private static void _s_method_EmptyMsg_E8DAC1C0_1(Lua.Param pa)
    {
        var a=pa.GetBoolean(1);
        var ra=Printer.EmptyMsg(a);
        pa.Return(ra);
    }
    /// <summary>
    /// function ClearMsg()
    /// ex. Printer.ClearMsg()
    /// </summary>
    private static void _s_method_ClearMsg_2382A480_0(Lua.Param pa)
    {
        Printer.ClearMsg();
    }
    /// <summary>
    /// function GetTextListCount(string)
    /// ex. Printer.GetTextListCount(string1)
    /// </summary>
    private static void _s_method_GetTextListCount_5E2A8740_4(Lua.Param pa)
    {
        var a=pa.GetString(1);
        var ra=Printer.GetTextListCount(a);
        pa.Return(ra);
    }
    /// <summary>
    /// function GetTextListWeight(string)
    /// ex. Printer.GetTextListWeight(string1)
    /// </summary>
    private static void _s_method_GetTextListWeight_98D26A0_4(Lua.Param pa)
    {
        var a=pa.GetString(1);
        var ra=Printer.GetTextListWeight(a);
        pa.Return(ra);
    }
    /// <summary>
    /// function SetTextList(string, table)
    /// ex. Printer.SetTextList(string1, table2)
    /// </summary>
    private static void _s_method_SetTextList_D37A4CC0_45(Lua.Param pa)
    {
        var a=pa.GetString(1);
        var b=pa.GetList<string>(2);
        Printer.SetTextList(a,b);
    }
    /// <summary>
    /// function SetTextWeightList(string, table)
    /// ex. Printer.SetTextWeightList(string1, table2)
    /// </summary>
    private static void _s_method_SetTextWeightList_E222F80_45(Lua.Param pa)
    {
        var a=pa.GetString(1);
        var b=pa.GetList<System.Collections.Generic.Dictionary<int,System.Object>>(2);
        Printer.SetTextWeightList(a,b);
    }
    /// <summary>
    /// function GetTextByIndex(string, number)
    /// ex. Printer.GetTextByIndex(string1, number2)
    /// </summary>
    private static void _s_method_GetTextByIndex_8371F50_43(Lua.Param pa)
    {
        var a=pa.GetString(1);
        var b=pa.GetInteger(2);
        var ra=Printer.GetTextByIndex(a,b);
        pa.Return(ra);
    }
    /// <summary>
    /// function GetTextByWeight(string, number)
    /// ex. Printer.GetTextByWeight(string1, number2)
    /// </summary>
    private static void _s_method_GetTextByWeight_BE19D7C0_43(Lua.Param pa)
    {
        var a=pa.GetString(1);
        var b=pa.GetInteger(2);
        var rb=default(int);
        var ra=Printer.GetTextByWeight(a,b,out rb);
        pa.Return(ra);
        pa.Return(rb);
    }
    /// <summary>
    /// function MessageBox(string, number, string, string, table, table, table, table, table, table, table)
    /// ex. Printer.MessageBox(string1, number2, string3, string4, table5, table6, table7, table8, table9, table10, table11)
    /// </summary>
    private static void _s_method_MessageBox_F8C1BA80_43445555555(Lua.Param pa)
    {
        var a=pa.GetString(1);
        var b=pa.GetInteger(2);
        var c=pa.GetString(3);
        var d=pa.GetString(4);
        var s5=pa.GetDictionary<string, object>(5);
        var e = new UnityEngine.Color();
        object e_r = null;
        if(s5.TryGetValue("r", out e_r))
            e.r = (float)(double)e_r;
        object e_g = null;
        if(s5.TryGetValue("g", out e_g))
            e.g = (float)(double)e_g;
        object e_b = null;
        if(s5.TryGetValue("b", out e_b))
            e.b = (float)(double)e_b;
        object e_a = null;
        if(s5.TryGetValue("a", out e_a))
            e.a = (float)(double)e_a;
        var s6=pa.GetDictionary<string, object>(6);
        var f = new UnityEngine.Color();
        object f_r = null;
        if(s6.TryGetValue("r", out f_r))
            f.r = (float)(double)f_r;
        object f_g = null;
        if(s6.TryGetValue("g", out f_g))
            f.g = (float)(double)f_g;
        object f_b = null;
        if(s6.TryGetValue("b", out f_b))
            f.b = (float)(double)f_b;
        object f_a = null;
        if(s6.TryGetValue("a", out f_a))
            f.a = (float)(double)f_a;
        var s7=pa.GetDictionary<string, object>(7);
        var g = new UnityEngine.Color();
        object g_r = null;
        if(s7.TryGetValue("r", out g_r))
            g.r = (float)(double)g_r;
        object g_g = null;
        if(s7.TryGetValue("g", out g_g))
            g.g = (float)(double)g_g;
        object g_b = null;
        if(s7.TryGetValue("b", out g_b))
            g.b = (float)(double)g_b;
        object g_a = null;
        if(s7.TryGetValue("a", out g_a))
            g.a = (float)(double)g_a;
        var s8=pa.GetDictionary<string, object>(8);
        var h = new UnityEngine.Color();
        object h_r = null;
        if(s8.TryGetValue("r", out h_r))
            h.r = (float)(double)h_r;
        object h_g = null;
        if(s8.TryGetValue("g", out h_g))
            h.g = (float)(double)h_g;
        object h_b = null;
        if(s8.TryGetValue("b", out h_b))
            h.b = (float)(double)h_b;
        object h_a = null;
        if(s8.TryGetValue("a", out h_a))
            h.a = (float)(double)h_a;
        var s9=pa.GetDictionary<string, object>(9);
        var i = new UnityEngine.Color();
        object i_r = null;
        if(s9.TryGetValue("r", out i_r))
            i.r = (float)(double)i_r;
        object i_g = null;
        if(s9.TryGetValue("g", out i_g))
            i.g = (float)(double)i_g;
        object i_b = null;
        if(s9.TryGetValue("b", out i_b))
            i.b = (float)(double)i_b;
        object i_a = null;
        if(s9.TryGetValue("a", out i_a))
            i.a = (float)(double)i_a;
        var s10=pa.GetDictionary<string, object>(10);
        var j = new UnityEngine.Color();
        object j_r = null;
        if(s10.TryGetValue("r", out j_r))
            j.r = (float)(double)j_r;
        object j_g = null;
        if(s10.TryGetValue("g", out j_g))
            j.g = (float)(double)j_g;
        object j_b = null;
        if(s10.TryGetValue("b", out j_b))
            j.b = (float)(double)j_b;
        object j_a = null;
        if(s10.TryGetValue("a", out j_a))
            j.a = (float)(double)j_a;
        var k=pa.GetList<float>(11);
        Printer.MessageBox(a,(Printer.MsgType)b,c,d,e,f,g,h,i,j,k);
    }
    /// <summary>
    /// function MessageBoxIsShow()
    /// ex. Printer.MessageBoxIsShow()
    /// </summary>
    private static void _s_method_MessageBoxIsShow_33699D40_0(Lua.Param pa)
    {
        var ra=Printer.MessageBoxIsShow();
        pa.Return(ra);
    }
    /// <summary>
    /// function MessageBoxResult()
    /// ex. Printer.MessageBoxResult()
    /// </summary>
    private static void _s_method_MessageBoxResult_6E11800_0(Lua.Param pa)
    {
        var ra=Printer.MessageBoxResult();
        pa.Return((int)ra);
    }
    /// <summary>
    /// function InputBoxShow(string, number, string, string, string, table, table, table, table, table, table, table)
    /// ex. Printer.InputBoxShow(string1, number2, string3, string4, string5, table6, table7, table8, table9, table10, table11, table12)
    /// </summary>
    private static void _s_method_InputBoxShow_C386A40_434445555555(Lua.Param pa)
    {
        var a=pa.GetString(1);
        var b=pa.GetInteger(2);
        var c=pa.GetString(3);
        var d=pa.GetString(4);
        var e=pa.GetString(5);
        var s6=pa.GetDictionary<string, object>(6);
        var f = new UnityEngine.Color();
        object f_r = null;
        if(s6.TryGetValue("r", out f_r))
            f.r = (float)(double)f_r;
        object f_g = null;
        if(s6.TryGetValue("g", out f_g))
            f.g = (float)(double)f_g;
        object f_b = null;
        if(s6.TryGetValue("b", out f_b))
            f.b = (float)(double)f_b;
        object f_a = null;
        if(s6.TryGetValue("a", out f_a))
            f.a = (float)(double)f_a;
        var s7=pa.GetDictionary<string, object>(7);
        var g = new UnityEngine.Color();
        object g_r = null;
        if(s7.TryGetValue("r", out g_r))
            g.r = (float)(double)g_r;
        object g_g = null;
        if(s7.TryGetValue("g", out g_g))
            g.g = (float)(double)g_g;
        object g_b = null;
        if(s7.TryGetValue("b", out g_b))
            g.b = (float)(double)g_b;
        object g_a = null;
        if(s7.TryGetValue("a", out g_a))
            g.a = (float)(double)g_a;
        var s8=pa.GetDictionary<string, object>(8);
        var h = new UnityEngine.Color();
        object h_r = null;
        if(s8.TryGetValue("r", out h_r))
            h.r = (float)(double)h_r;
        object h_g = null;
        if(s8.TryGetValue("g", out h_g))
            h.g = (float)(double)h_g;
        object h_b = null;
        if(s8.TryGetValue("b", out h_b))
            h.b = (float)(double)h_b;
        object h_a = null;
        if(s8.TryGetValue("a", out h_a))
            h.a = (float)(double)h_a;
        var s9=pa.GetDictionary<string, object>(9);
        var i = new UnityEngine.Color();
        object i_r = null;
        if(s9.TryGetValue("r", out i_r))
            i.r = (float)(double)i_r;
        object i_g = null;
        if(s9.TryGetValue("g", out i_g))
            i.g = (float)(double)i_g;
        object i_b = null;
        if(s9.TryGetValue("b", out i_b))
            i.b = (float)(double)i_b;
        object i_a = null;
        if(s9.TryGetValue("a", out i_a))
            i.a = (float)(double)i_a;
        var s10=pa.GetDictionary<string, object>(10);
        var j = new UnityEngine.Color();
        object j_r = null;
        if(s10.TryGetValue("r", out j_r))
            j.r = (float)(double)j_r;
        object j_g = null;
        if(s10.TryGetValue("g", out j_g))
            j.g = (float)(double)j_g;
        object j_b = null;
        if(s10.TryGetValue("b", out j_b))
            j.b = (float)(double)j_b;
        object j_a = null;
        if(s10.TryGetValue("a", out j_a))
            j.a = (float)(double)j_a;
        var s11=pa.GetDictionary<string, object>(11);
        var k = new UnityEngine.Color();
        object k_r = null;
        if(s11.TryGetValue("r", out k_r))
            k.r = (float)(double)k_r;
        object k_g = null;
        if(s11.TryGetValue("g", out k_g))
            k.g = (float)(double)k_g;
        object k_b = null;
        if(s11.TryGetValue("b", out k_b))
            k.b = (float)(double)k_b;
        object k_a = null;
        if(s11.TryGetValue("a", out k_a))
            k.a = (float)(double)k_a;
        var s12=pa.GetDictionary<string, object>(12);
        var l = new UnityEngine.Color();
        object l_r = null;
        if(s12.TryGetValue("r", out l_r))
            l.r = (float)(double)l_r;
        object l_g = null;
        if(s12.TryGetValue("g", out l_g))
            l.g = (float)(double)l_g;
        object l_b = null;
        if(s12.TryGetValue("b", out l_b))
            l.b = (float)(double)l_b;
        object l_a = null;
        if(s12.TryGetValue("a", out l_a))
            l.a = (float)(double)l_a;
        Printer.InputBoxShow(a,(Printer.InputType)b,c,d,e,f,g,h,i,j,k,l);
    }
    /// <summary>
    /// function InputBoxIsShow()
    /// ex. Printer.InputBoxIsShow()
    /// </summary>
    private static void _s_method_InputBoxIsShow_FE2DED0_0(Lua.Param pa)
    {
        var ra=Printer.InputBoxIsShow();
        pa.Return(ra);
    }
    /// <summary>
    /// function InputBoxResult()
    /// ex. Printer.InputBoxResult()
    /// </summary>
    private static void _s_method_InputBoxResult_38D5CFC0_0(Lua.Param pa)
    {
        var ra=Printer.InputBoxResult();
        pa.Return(ra);
    }
    /// <summary>
    /// function EnumScripts(string)
    /// ex. Printer.EnumScripts(string1)
    /// </summary>
    private static void _s_method_EnumScripts_737DB280_4(Lua.Param pa)
    {
        var a=pa.GetString(1);
        var ra=Printer.EnumScripts(a);
        pa.Return(ra, typeof(System.Collections.Generic.List<string>));
    }
    /// <summary>
    /// function LoadCsv(string)
    /// ex. Printer.LoadCsv(string1)
    /// </summary>
    private static void _s_method_LoadCsv_AE259540_4(Lua.Param pa)
    {
        var a=pa.GetString(1);
        var ra=Printer.LoadCsv(a);
        pa.Return(ra);
    }
    /// <summary>
    /// function Save(string, string, string)
    /// ex. Printer.Save(string1, string2, string3)
    /// </summary>
    private static void _s_method_Save_E8CD780_444(Lua.Param pa)
    {
        var a=pa.GetString(1);
        var b=pa.GetString(2);
        var c=pa.GetString(3);
        Printer.Save(a,b,c);
    }
    /// <summary>
    /// function Load(string, string)
    /// ex. Printer.Load(string1, string2)
    /// </summary>
    private static void _s_method_Load_23755AC0_44(Lua.Param pa)
    {
        var a=pa.GetString(1);
        var b=pa.GetString(2);
        var ra=Printer.Load(a,b);
        pa.Return(ra);
    }
    /// <summary>
    /// function Exist(string)
    /// ex. Printer.Exist(string1)
    /// </summary>
    private static void _s_method_Exist_5E1D3D80_4(Lua.Param pa)
    {
        var a=pa.GetString(1);
        var ra=Printer.Exist(a);
        pa.Return(ra);
    }
    /// <summary>
    /// function Delete(string)
    /// ex. Printer.Delete(string1)
    /// </summary>
    private static void _s_method_Delete_98C52040_4(Lua.Param pa)
    {
        var a=pa.GetString(1);
        Printer.Delete(a);
    }
    /// <summary>
    /// function EnumSaves()
    /// ex. Printer.EnumSaves()
    /// </summary>
    private static void _s_method_EnumSaves_D36D30_0(Lua.Param pa)
    {
        var ra=Printer.EnumSaves();
        pa.Return(ra, typeof(System.Collections.Generic.List<string>));
    }
    private static void _s_get_field_flags(Lua.Param pa)
    {
        pa.Return(new Dictionary<string, object>{
                {"flags", Printer.flags.flags},
                {"isbutton", Printer.flags.isbutton},
                {"underline", Printer.flags.underline},
                {"strickout", Printer.flags.strickout},
                {"empty", Printer.flags.empty},
                {"richedit", Printer.flags.richedit},
                {"monospaced", Printer.flags.monospaced},
                {"gradient", Printer.flags.gradient},
                {"outline", Printer.flags.outline},
                {"shadow", Printer.flags.shadow},
                {"bold", Printer.flags.bold},
                {"italic", Printer.flags.italic},
        }, "FlagBit");
    }
    private static void _s_set_field_flags(Lua.Param pa)
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
        Printer.flags = a;
    }
    private static void _s_get_field_color(Lua.Param pa)
    {
        pa.Return(new Dictionary<string, object>{
                {"r", Printer.color.r},
                {"g", Printer.color.g},
                {"b", Printer.color.b},
                {"a", Printer.color.a},
                {"grayscale", Printer.color.grayscale},
                {"linear", Printer.color.linear},
                {"gamma", Printer.color.gamma},
                {"maxColorComponent", Printer.color.maxColorComponent},
        }, "UnityEngine.Color");
    }
    private static void _s_set_field_color(Lua.Param pa)
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
        Printer.color = a;
    }
    private static void _s_get_field_gradient_color(Lua.Param pa)
    {
        pa.Return(new Dictionary<string, object>{
                {"r", Printer.gradient_color.r},
                {"g", Printer.gradient_color.g},
                {"b", Printer.gradient_color.b},
                {"a", Printer.gradient_color.a},
                {"grayscale", Printer.gradient_color.grayscale},
                {"linear", Printer.gradient_color.linear},
                {"gamma", Printer.gradient_color.gamma},
                {"maxColorComponent", Printer.gradient_color.maxColorComponent},
        }, "UnityEngine.Color");
    }
    private static void _s_set_field_gradient_color(Lua.Param pa)
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
        Printer.gradient_color = a;
    }
    private static void _s_get_field_shadow_color(Lua.Param pa)
    {
        pa.Return(new Dictionary<string, object>{
                {"r", Printer.shadow_color.r},
                {"g", Printer.shadow_color.g},
                {"b", Printer.shadow_color.b},
                {"a", Printer.shadow_color.a},
                {"grayscale", Printer.shadow_color.grayscale},
                {"linear", Printer.shadow_color.linear},
                {"gamma", Printer.shadow_color.gamma},
                {"maxColorComponent", Printer.shadow_color.maxColorComponent},
        }, "UnityEngine.Color");
    }
    private static void _s_set_field_shadow_color(Lua.Param pa)
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
        Printer.shadow_color = a;
    }
    private static void _s_get_field_outline_color(Lua.Param pa)
    {
        pa.Return(new Dictionary<string, object>{
                {"r", Printer.outline_color.r},
                {"g", Printer.outline_color.g},
                {"b", Printer.outline_color.b},
                {"a", Printer.outline_color.a},
                {"grayscale", Printer.outline_color.grayscale},
                {"linear", Printer.outline_color.linear},
                {"gamma", Printer.outline_color.gamma},
                {"maxColorComponent", Printer.outline_color.maxColorComponent},
        }, "UnityEngine.Color");
    }
    private static void _s_set_field_outline_color(Lua.Param pa)
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
        Printer.outline_color = a;
    }
    private static void _s_get_field_image_color(Lua.Param pa)
    {
        pa.Return(new Dictionary<string, object>{
                {"r", Printer.image_color.r},
                {"g", Printer.image_color.g},
                {"b", Printer.image_color.b},
                {"a", Printer.image_color.a},
                {"grayscale", Printer.image_color.grayscale},
                {"linear", Printer.image_color.linear},
                {"gamma", Printer.image_color.gamma},
                {"maxColorComponent", Printer.image_color.maxColorComponent},
        }, "UnityEngine.Color");
    }
    private static void _s_set_field_image_color(Lua.Param pa)
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
        Printer.image_color = a;
    }
    private static void _s_method_GetStringLines(Lua.Param pa)
    {
        var typecode = pa.GetTypecode();
        // function GetStringLines(string, number)
        if(typecode == 0x43UL)
            _s_method_GetStringLines_BE9F53C0_43(pa);
        else
        // function GetStringLines(string, boolean, number)
        if(typecode == 0x413UL)
            _s_method_GetStringLines_F9473680_413(pa);
        else
        {
#if UNITY_EDITOR
            throw new NotImplementedException(string.Format("typecode=0x{0:X}", typecode));
#endif
        }
    }
    public static Lua.Metatable OpenLib(Lua.State state)
    {
        Lua.Metatable metatable = null;
        var _InputType = state.newrefmetatable(new Dictionary<string, Lua.Ref>
        {
            {"__newindex", state.newref(param=>{})},
            {"STANDARD", state.newref((int)Printer.InputType.STANDARD)},
            {"INTEGER", state.newref((int)Printer.InputType.INTEGER)},
            {"DECIMAL", state.newref((int)Printer.InputType.DECIMAL)},
            {"ALPHANUMERIC", state.newref((int)Printer.InputType.ALPHANUMERIC)},
            {"PASSWORD", state.newref((int)Printer.InputType.PASSWORD)},
        });
        var InputType = state.newreftable();
        state.set_metatable(InputType, _InputType);
        var _MsgResult = state.newrefmetatable(new Dictionary<string, Lua.Ref>
        {
            {"__newindex", state.newref(param=>{})},
            {"LEFT", state.newref((int)Printer.MsgResult.LEFT)},
            {"RIGHT", state.newref((int)Printer.MsgResult.RIGHT)},
        });
        var MsgResult = state.newreftable();
        state.set_metatable(MsgResult, _MsgResult);
        var _MsgType = state.newrefmetatable(new Dictionary<string, Lua.Ref>
        {
            {"__newindex", state.newref(param=>{})},
            {"ONE_BUTTON", state.newref((int)Printer.MsgType.ONE_BUTTON)},
            {"TWO_BUTTON", state.newref((int)Printer.MsgType.TWO_BUTTON)},
        });
        var MsgType = state.newreftable();
        state.set_metatable(MsgType, _MsgType);
        var _ScreenOrientation = state.newrefmetatable(new Dictionary<string, Lua.Ref>
        {
            {"__newindex", state.newref(param=>{})},
            {"Unknown", state.newref((int)Printer.ScreenOrientation.Unknown)},
            {"Portrait", state.newref((int)Printer.ScreenOrientation.Portrait)},
            {"PortraitUpsideDown", state.newref((int)Printer.ScreenOrientation.PortraitUpsideDown)},
            {"LandscapeLeft", state.newref((int)Printer.ScreenOrientation.LandscapeLeft)},
            {"Landscape", state.newref((int)Printer.ScreenOrientation.Landscape)},
            {"LandscapeRight", state.newref((int)Printer.ScreenOrientation.LandscapeRight)},
            {"AutoRotation", state.newref((int)Printer.ScreenOrientation.AutoRotation)},
        });
        var ScreenOrientation = state.newreftable();
        state.set_metatable(ScreenOrientation, _ScreenOrientation);
        var _Align = state.newrefmetatable(new Dictionary<string, Lua.Ref>
        {
            {"__newindex", state.newref(param=>{})},
            {"kLeft", state.newref((int)Printer.Align.kLeft)},
            {"kCenter", state.newref((int)Printer.Align.kCenter)},
            {"kRight", state.newref((int)Printer.Align.kRight)},
        });
        var Align = state.newreftable();
        state.set_metatable(Align, _Align);
        var rt = state.get_table_ref_with_path("Printer");
        var _rt = state.newrefmetatable(new Dictionary<string, Lua.Ref>
        {
            {"__newindex", state.newref(param=>{})},
            {"InputType", InputType},
            {"MsgResult", MsgResult},
            {"MsgType", MsgType},
            {"ScreenOrientation", ScreenOrientation},
            {"Align", Align},
            {"get_flags", state.newref(_s_get_field_flags)},
            {"set_flags", state.newref(_s_set_field_flags)},
            {"get_color", state.newref(_s_get_field_color)},
            {"set_color", state.newref(_s_set_field_color)},
            {"get_gradient_color", state.newref(_s_get_field_gradient_color)},
            {"set_gradient_color", state.newref(_s_set_field_gradient_color)},
            {"get_shadow_color", state.newref(_s_get_field_shadow_color)},
            {"set_shadow_color", state.newref(_s_set_field_shadow_color)},
            {"get_outline_color", state.newref(_s_get_field_outline_color)},
            {"set_outline_color", state.newref(_s_set_field_outline_color)},
            {"get_image_color", state.newref(_s_get_field_image_color)},
            {"set_image_color", state.newref(_s_set_field_image_color)},
            {"SelectConsole", state.newref(_s_method_SelectConsole_4162B6C0_2)},
            {"SetTargetFrame", state.newref(_s_method_SetTargetFrame_7CA9980_3)},
            {"TargetFrame", state.newref(_s_method_TargetFrame_B6B27C40_0)},
            {"SetBackgroundColor", state.newref(_s_method_SetBackgroundColor_F15A5F0_5)},
            {"GetBackgroundColor", state.newref(_s_method_GetBackgroundColor_2C241C0_0)},
            {"SetBackgroundImage", state.newref(_s_method_SetBackgroundImage_66AA2480_411)},
            {"SetOrientation", state.newref(_s_method_SetOrientation_A152740_3)},
            {"PushFlags", state.newref(_s_method_PushFlags_DBF9EA0_0)},
            {"PopFlags", state.newref(_s_method_PopFlags_16A1CCC0_0)},
            {"DefaultFlags", state.newref(_s_method_DefaultFlags_5149AF80_0)},
            {"GetFlags", state.newref(_s_method_GetFlags_8BF19240_0)},
            {"SetFlags", state.newref(_s_method_SetFlags_C699750_3)},
            {"PushColor", state.newref(_s_method_PushColor_14157C0_0)},
            {"PopColor", state.newref(_s_method_PopColor_3BE93A80_0)},
            {"DefaultColor", state.newref(_s_method_DefaultColor_76911D40_0)},
            {"PushGradientColor", state.newref(_s_method_PushGradientColor_B13900_0)},
            {"PopGradientColor", state.newref(_s_method_PopGradientColor_49D5A40_0)},
            {"DefaultGradientColor", state.newref(_s_method_DefaultGradientColor_847CED0_0)},
            {"PushShadowColor", state.newref(_s_method_PushShadowColor_BF24CFC0_0)},
            {"PopShadowColor", state.newref(_s_method_PopShadowColor_F9CCB280_0)},
            {"DefaultShadowColor", state.newref(_s_method_DefaultShadowColor_34749540_0)},
            {"PushOutlineColor", state.newref(_s_method_PushOutlineColor_6F1C780_0)},
            {"PopOutlineColor", state.newref(_s_method_PopOutlineColor_A9C45AC0_0)},
            {"DefaultOutlineColor", state.newref(_s_method_DefaultOutlineColor_E46C3D80_0)},
            {"PushImageColor", state.newref(_s_method_PushImageColor_1F142040_0)},
            {"PopImageColor", state.newref(_s_method_PopImageColor_59BC30_0)},
            {"DefaultImageColor", state.newref(_s_method_DefaultImageColor_9463E5C0_0)},
            {"PushAllConfig", state.newref(_s_method_PushAllConfig_CFBC880_0)},
            {"PopAllConfig", state.newref(_s_method_PopAllConfig_9B3AB40_0)},
            {"DefaultAllConfig", state.newref(_s_method_DefaultAllConfig_445B8E0_0)},
            {"SetFontSize", state.newref(_s_method_SetFontSize_7F370C0_3)},
            {"GetFontSize", state.newref(_s_method_GetFontSize_B9AB5380_0)},
            {"SetLineHeight", state.newref(_s_method_SetLineHeight_2EFB190_3)},
            {"GetLineHeight", state.newref(_s_method_GetLineHeight_69A2FBC0_0)},
            {"SetButtonStyle", state.newref(_s_method_SetButtonStyle_DEF2C140_5555)},
            {"ClearButtonStyle", state.newref(_s_method_ClearButtonStyle_199AA40_0)},
            {"ShowFPS", state.newref(_s_method_ShowFPS_544286C0_1)},
            {"Quit", state.newref(_s_method_Quit_8EEA6980_0)},
            {"DataPath", state.newref(_s_method_DataPath_C9924C40_0)},
            {"PersistentDataPath", state.newref(_s_method_PersistentDataPath_43A2F0_0)},
            {"IsMobilePlatform", state.newref(_s_method_IsMobilePlatform_3EE211C0_0)},
            {"Platform", state.newref(_s_method_Platform_7989F480_0)},
            {"RunInBackground", state.newref(_s_method_RunInBackground_B431D740_0)},
            {"SetRunInBackground", state.newref(_s_method_SetRunInBackground_EED9BA0_1)},
            {"OpenURL", state.newref(_s_method_OpenURL_29819CC0_4)},
            {"SetResolution", state.newref(_s_method_SetResolution_64297F80_331)},
            {"GetResolution", state.newref(_s_method_GetResolution_9ED16240_0)},
            {"SetDragEnable", state.newref(_s_method_SetDragEnable_D979450_1)},
            {"SetConsoleBorder", state.newref(_s_method_SetConsoleBorder_142127C0_3333)},
            {"NowStamp", state.newref(_s_method_NowStamp_4EC9A80_0)},
            {"DateToStamp", state.newref(_s_method_DateToStamp_8970ED40_333333)},
            {"Now", state.newref(_s_method_Now_C418D00_0)},
            {"Date", state.newref(_s_method_Date_FEC0B2C0_333333)},
            {"StampToDate", state.newref(_s_method_StampToDate_39689580_3)},
            {"SetLogFile", state.newref(_s_method_SetLogFile_AEB85B0_41)},
            {"SetLogEnable", state.newref(_s_method_SetLogEnable_E9603DC0_1)},
            {"LogWrite", state.newref(_s_method_LogWrite_2482080_4)},
            {"LogWriteLn", state.newref(_s_method_LogWriteLn_5EB0340_4)},
            {"LogShiftLine", state.newref(_s_method_LogShiftLine_9957E60_0)},
            {"SetAutoLine", state.newref(_s_method_SetAutoLine_494F8E40_3)},
            {"GetAutoLine", state.newref(_s_method_GetAutoLine_83F7710_0)},
            {"GetStringLines", state.newref(_s_method_GetStringLines)},
            {"PrintT", state.newref(_s_method_PrintT_33EF1940_334)},
            {"PrintTLn", state.newref(_s_method_PrintTLn_6E96FC0_334)},
            {"PrintTF", state.newref(_s_method_PrintTF_A93EDEC0_3345)},
            {"PrintTFLn", state.newref(_s_method_PrintTFLn_E3E6C180_3345)},
            {"PrintF", state.newref(_s_method_PrintF_1E8EA440_45)},
            {"PrintFLn", state.newref(_s_method_PrintFLn_5936870_45)},
            {"Print", state.newref(_s_method_Print_93DE69C0_4)},
            {"PrintLn", state.newref(_s_method_PrintLn_CE864C80_4)},
            {"SetSpriteImage", state.newref(_s_method_SetSpriteImage_92E2F40_44551)},
            {"SetSpriteAnimation", state.newref(_s_method_SetSpriteAnimation_7E7DF4C0_435)},
            {"SetAnimationLoop", state.newref(_s_method_SetAnimationLoop_F3CDBA40_3)},
            {"CheckSprite", state.newref(_s_method_CheckSprite_2E759D0_4)},
            {"SetErrorImage", state.newref(_s_method_SetErrorImage_691D7FC0_45)},
            {"Image", state.newref(_s_method_Image_A3C56280_433331)},
            {"ImageP", state.newref(_s_method_ImageP_DE6D4540_4331)},
            {"ImageS", state.newref(_s_method_ImageS_1915280_4331)},
            {"ImagePS", state.newref(_s_method_ImagePS_53BDAC0_433331)},
            {"SetCode", state.newref(_s_method_SetCode_8E64ED80_4)},
            {"RemoveLine", state.newref(_s_method_RemoveLine_C9CD040_3)},
            {"Clear", state.newref(_s_method_Clear_3B4B30_0)},
            {"MovePosByPixel", state.newref(_s_method_MovePosByPixel_3E5C95C0_3)},
            {"MovePosByWord", state.newref(_s_method_MovePosByWord_7947880_3)},
            {"ResetPosByPixel", state.newref(_s_method_ResetPosByPixel_28FC20C0_3)},
            {"ResetPosByWord", state.newref(_s_method_ResetPosByWord_63A4380_3)},
            {"GetCurrentPos", state.newref(_s_method_GetCurrentPos_9E4BE640_0)},
            {"NextTextPart", state.newref(_s_method_NextTextPart_D8F3C90_1)},
            {"NextImagePart", state.newref(_s_method_NextImagePart_139BABC0_1)},
            {"ShiftLine", state.newref(_s_method_ShiftLine_88EB7140_31)},
            {"SetMsg", state.newref(_s_method_SetMsg_738AFC40_4)},
            {"GetMsg", state.newref(_s_method_GetMsg_AE32DF0_0)},
            {"EmptyMsg", state.newref(_s_method_EmptyMsg_E8DAC1C0_1)},
            {"ClearMsg", state.newref(_s_method_ClearMsg_2382A480_0)},
            {"GetTextListCount", state.newref(_s_method_GetTextListCount_5E2A8740_4)},
            {"GetTextListWeight", state.newref(_s_method_GetTextListWeight_98D26A0_4)},
            {"SetTextList", state.newref(_s_method_SetTextList_D37A4CC0_45)},
            {"SetTextWeightList", state.newref(_s_method_SetTextWeightList_E222F80_45)},
            {"GetTextByIndex", state.newref(_s_method_GetTextByIndex_8371F50_43)},
            {"GetTextByWeight", state.newref(_s_method_GetTextByWeight_BE19D7C0_43)},
            {"MessageBox", state.newref(_s_method_MessageBox_F8C1BA80_43445555555)},
            {"MessageBoxIsShow", state.newref(_s_method_MessageBoxIsShow_33699D40_0)},
            {"MessageBoxResult", state.newref(_s_method_MessageBoxResult_6E11800_0)},
            {"InputBoxShow", state.newref(_s_method_InputBoxShow_C386A40_434445555555)},
            {"InputBoxIsShow", state.newref(_s_method_InputBoxIsShow_FE2DED0_0)},
            {"InputBoxResult", state.newref(_s_method_InputBoxResult_38D5CFC0_0)},
            {"EnumScripts", state.newref(_s_method_EnumScripts_737DB280_4)},
            {"LoadCsv", state.newref(_s_method_LoadCsv_AE259540_4)},
            {"Save", state.newref(_s_method_Save_E8CD780_444)},
            {"Load", state.newref(_s_method_Load_23755AC0_44)},
            {"Exist", state.newref(_s_method_Exist_5E1D3D80_4)},
            {"Delete", state.newref(_s_method_Delete_98C52040_4)},
            {"EnumSaves", state.newref(_s_method_EnumSaves_D36D30_0)},
        });
        state.set_metatable(rt, _rt);
        return metatable;  
    }

}
}
