// THIS IS A GENERATED FILE. PLEASE DO NOT MODIFY IT!
using System;
using System.Collections;
using System.Collections.Generic;
using Lua;

namespace Lua
{
public static class Wrap_UnityEngine_Color 
{
    /// <summary>
    /// function Lerp(table, table, number)
    /// ex. UnityEngine.Color.Lerp(table1, table2, number3)
    /// </summary>
    private static void _s_method_Lerp_FED05F0_553(Lua.Param pa)
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
        var c=pa.GetFloat(3);
        var ra=UnityEngine.Color.Lerp(a,b,c);
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
    /// function LerpUnclamped(table, table, number)
    /// ex. UnityEngine.Color.LerpUnclamped(table1, table2, number3)
    /// </summary>
    private static void _s_method_LerpUnclamped_397841C0_553(Lua.Param pa)
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
        var c=pa.GetFloat(3);
        var ra=UnityEngine.Color.LerpUnclamped(a,b,c);
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
    /// function RGBToHSV(table)
    /// ex. UnityEngine.Color.RGBToHSV(table1)
    /// </summary>
    private static void _s_method_RGBToHSV_DD4A4FC0_5(Lua.Param pa)
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
        var rb=default(float);
        var rc=default(float);
        var rd=default(float);
        UnityEngine.Color.RGBToHSV(a,out rb,out rc,out rd);
        pa.Return(rb);
        pa.Return(rc);
        pa.Return(rd);
    }
    /// <summary>
    /// function HSVToRGB(number, number, number)
    /// ex. UnityEngine.Color.HSVToRGB(number1, number2, number3)
    /// </summary>
    private static void _s_method_HSVToRGB_17F23280_333(Lua.Param pa)
    {
        var a=pa.GetFloat(1);
        var b=pa.GetFloat(2);
        var c=pa.GetFloat(3);
        var ra=UnityEngine.Color.HSVToRGB(a,b,c);
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
    /// function HSVToRGB(number, number, number, boolean)
    /// ex. UnityEngine.Color.HSVToRGB(number1, number2, number3, boolean4)
    /// </summary>
    private static void _s_method_HSVToRGB_529A1540_3331(Lua.Param pa)
    {
        var a=pa.GetFloat(1);
        var b=pa.GetFloat(2);
        var c=pa.GetFloat(3);
        var d=pa.GetBoolean(4);
        var ra=UnityEngine.Color.HSVToRGB(a,b,c,d);
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
    private static void _s_get_property_red(Lua.Param pa)
    {
        pa.Return(new Dictionary<string, object>{
                {"r", UnityEngine.Color.red.r},
                {"g", UnityEngine.Color.red.g},
                {"b", UnityEngine.Color.red.b},
                {"a", UnityEngine.Color.red.a},
                {"grayscale", UnityEngine.Color.red.grayscale},
                {"linear", UnityEngine.Color.red.linear},
                {"gamma", UnityEngine.Color.red.gamma},
                {"maxColorComponent", UnityEngine.Color.red.maxColorComponent},
        }, "UnityEngine.Color");
    }
    private static void _s_get_property_green(Lua.Param pa)
    {
        pa.Return(new Dictionary<string, object>{
                {"r", UnityEngine.Color.green.r},
                {"g", UnityEngine.Color.green.g},
                {"b", UnityEngine.Color.green.b},
                {"a", UnityEngine.Color.green.a},
                {"grayscale", UnityEngine.Color.green.grayscale},
                {"linear", UnityEngine.Color.green.linear},
                {"gamma", UnityEngine.Color.green.gamma},
                {"maxColorComponent", UnityEngine.Color.green.maxColorComponent},
        }, "UnityEngine.Color");
    }
    private static void _s_get_property_blue(Lua.Param pa)
    {
        pa.Return(new Dictionary<string, object>{
                {"r", UnityEngine.Color.blue.r},
                {"g", UnityEngine.Color.blue.g},
                {"b", UnityEngine.Color.blue.b},
                {"a", UnityEngine.Color.blue.a},
                {"grayscale", UnityEngine.Color.blue.grayscale},
                {"linear", UnityEngine.Color.blue.linear},
                {"gamma", UnityEngine.Color.blue.gamma},
                {"maxColorComponent", UnityEngine.Color.blue.maxColorComponent},
        }, "UnityEngine.Color");
    }
    private static void _s_get_property_white(Lua.Param pa)
    {
        pa.Return(new Dictionary<string, object>{
                {"r", UnityEngine.Color.white.r},
                {"g", UnityEngine.Color.white.g},
                {"b", UnityEngine.Color.white.b},
                {"a", UnityEngine.Color.white.a},
                {"grayscale", UnityEngine.Color.white.grayscale},
                {"linear", UnityEngine.Color.white.linear},
                {"gamma", UnityEngine.Color.white.gamma},
                {"maxColorComponent", UnityEngine.Color.white.maxColorComponent},
        }, "UnityEngine.Color");
    }
    private static void _s_get_property_black(Lua.Param pa)
    {
        pa.Return(new Dictionary<string, object>{
                {"r", UnityEngine.Color.black.r},
                {"g", UnityEngine.Color.black.g},
                {"b", UnityEngine.Color.black.b},
                {"a", UnityEngine.Color.black.a},
                {"grayscale", UnityEngine.Color.black.grayscale},
                {"linear", UnityEngine.Color.black.linear},
                {"gamma", UnityEngine.Color.black.gamma},
                {"maxColorComponent", UnityEngine.Color.black.maxColorComponent},
        }, "UnityEngine.Color");
    }
    private static void _s_get_property_yellow(Lua.Param pa)
    {
        pa.Return(new Dictionary<string, object>{
                {"r", UnityEngine.Color.yellow.r},
                {"g", UnityEngine.Color.yellow.g},
                {"b", UnityEngine.Color.yellow.b},
                {"a", UnityEngine.Color.yellow.a},
                {"grayscale", UnityEngine.Color.yellow.grayscale},
                {"linear", UnityEngine.Color.yellow.linear},
                {"gamma", UnityEngine.Color.yellow.gamma},
                {"maxColorComponent", UnityEngine.Color.yellow.maxColorComponent},
        }, "UnityEngine.Color");
    }
    private static void _s_get_property_cyan(Lua.Param pa)
    {
        pa.Return(new Dictionary<string, object>{
                {"r", UnityEngine.Color.cyan.r},
                {"g", UnityEngine.Color.cyan.g},
                {"b", UnityEngine.Color.cyan.b},
                {"a", UnityEngine.Color.cyan.a},
                {"grayscale", UnityEngine.Color.cyan.grayscale},
                {"linear", UnityEngine.Color.cyan.linear},
                {"gamma", UnityEngine.Color.cyan.gamma},
                {"maxColorComponent", UnityEngine.Color.cyan.maxColorComponent},
        }, "UnityEngine.Color");
    }
    private static void _s_get_property_magenta(Lua.Param pa)
    {
        pa.Return(new Dictionary<string, object>{
                {"r", UnityEngine.Color.magenta.r},
                {"g", UnityEngine.Color.magenta.g},
                {"b", UnityEngine.Color.magenta.b},
                {"a", UnityEngine.Color.magenta.a},
                {"grayscale", UnityEngine.Color.magenta.grayscale},
                {"linear", UnityEngine.Color.magenta.linear},
                {"gamma", UnityEngine.Color.magenta.gamma},
                {"maxColorComponent", UnityEngine.Color.magenta.maxColorComponent},
        }, "UnityEngine.Color");
    }
    private static void _s_get_property_gray(Lua.Param pa)
    {
        pa.Return(new Dictionary<string, object>{
                {"r", UnityEngine.Color.gray.r},
                {"g", UnityEngine.Color.gray.g},
                {"b", UnityEngine.Color.gray.b},
                {"a", UnityEngine.Color.gray.a},
                {"grayscale", UnityEngine.Color.gray.grayscale},
                {"linear", UnityEngine.Color.gray.linear},
                {"gamma", UnityEngine.Color.gray.gamma},
                {"maxColorComponent", UnityEngine.Color.gray.maxColorComponent},
        }, "UnityEngine.Color");
    }
    private static void _s_get_property_grey(Lua.Param pa)
    {
        pa.Return(new Dictionary<string, object>{
                {"r", UnityEngine.Color.grey.r},
                {"g", UnityEngine.Color.grey.g},
                {"b", UnityEngine.Color.grey.b},
                {"a", UnityEngine.Color.grey.a},
                {"grayscale", UnityEngine.Color.grey.grayscale},
                {"linear", UnityEngine.Color.grey.linear},
                {"gamma", UnityEngine.Color.grey.gamma},
                {"maxColorComponent", UnityEngine.Color.grey.maxColorComponent},
        }, "UnityEngine.Color");
    }
    private static void _s_get_property_clear(Lua.Param pa)
    {
        pa.Return(new Dictionary<string, object>{
                {"r", UnityEngine.Color.clear.r},
                {"g", UnityEngine.Color.clear.g},
                {"b", UnityEngine.Color.clear.b},
                {"a", UnityEngine.Color.clear.a},
                {"grayscale", UnityEngine.Color.clear.grayscale},
                {"linear", UnityEngine.Color.clear.linear},
                {"gamma", UnityEngine.Color.clear.gamma},
                {"maxColorComponent", UnityEngine.Color.clear.maxColorComponent},
        }, "UnityEngine.Color");
    }
    private static void _s_method_HSVToRGB(Lua.Param pa)
    {
        var typecode = pa.GetTypecode();
        // function HSVToRGB(number, number, number)
        if(typecode == 0x333UL)
            _s_method_HSVToRGB_17F23280_333(pa);
        else
        // function HSVToRGB(number, number, number, boolean)
        if(typecode == 0x3331UL)
            _s_method_HSVToRGB_529A1540_3331(pa);
        else
        {
#if UNITY_EDITOR
            throw new NotImplementedException(string.Format("typecode=0x{0:X}", typecode));
#endif
        }
    }
    /// <summary>
    /// function Constructor(number, number, number, number)
    /// ex. UnityEngine.Color.Constructor(number1, number2, number3, number4)
    /// ex. UnityEngine.Color(number1, number2, number3, number4)
    /// </summary>
    private static void Constructor_8C7B8340_3333(Lua.Param pa)
    {
        var a=pa.GetFloat(1);
        var b=pa.GetFloat(2);
        var c=pa.GetFloat(3);
        var d=pa.GetFloat(4);
        var inst=new UnityEngine.Color(a,b,c,d);
        pa.Return(new Dictionary<string, object>{
                {"r", inst.r},
                {"g", inst.g},
                {"b", inst.b},
                {"a", inst.a},
                {"grayscale", inst.grayscale},
                {"linear", inst.linear},
                {"gamma", inst.gamma},
                {"maxColorComponent", inst.maxColorComponent},
        }, "UnityEngine.Color");
    }
    /// <summary>
    /// function Constructor(number, number, number, number)
    /// ex. UnityEngine.Color.Constructor(number1, number2, number3, number4)
    /// ex. UnityEngine.Color(number1, number2, number3, number4)
    /// </summary>
    private static void ConstructorRef_8C7B8340_53333(Lua.Param pa)
    {
        var a=pa.GetFloat(2);
        var b=pa.GetFloat(3);
        var c=pa.GetFloat(4);
        var d=pa.GetFloat(5);
        var inst=new UnityEngine.Color(a,b,c,d);
        pa.Return(new Dictionary<string, object>{
                {"r", inst.r},
                {"g", inst.g},
                {"b", inst.b},
                {"a", inst.a},
                {"grayscale", inst.grayscale},
                {"linear", inst.linear},
                {"gamma", inst.gamma},
                {"maxColorComponent", inst.maxColorComponent},
        }, "UnityEngine.Color");
    }
    /// <summary>
    /// function Constructor(number, number, number)
    /// ex. UnityEngine.Color.Constructor(number1, number2, number3)
    /// ex. UnityEngine.Color(number1, number2, number3)
    /// </summary>
    private static void Constructor_C723660_333(Lua.Param pa)
    {
        var a=pa.GetFloat(1);
        var b=pa.GetFloat(2);
        var c=pa.GetFloat(3);
        var inst=new UnityEngine.Color(a,b,c);
        pa.Return(new Dictionary<string, object>{
                {"r", inst.r},
                {"g", inst.g},
                {"b", inst.b},
                {"a", inst.a},
                {"grayscale", inst.grayscale},
                {"linear", inst.linear},
                {"gamma", inst.gamma},
                {"maxColorComponent", inst.maxColorComponent},
        }, "UnityEngine.Color");
    }
    /// <summary>
    /// function Constructor(number, number, number)
    /// ex. UnityEngine.Color.Constructor(number1, number2, number3)
    /// ex. UnityEngine.Color(number1, number2, number3)
    /// </summary>
    private static void ConstructorRef_C723660_5333(Lua.Param pa)
    {
        var a=pa.GetFloat(2);
        var b=pa.GetFloat(3);
        var c=pa.GetFloat(4);
        var inst=new UnityEngine.Color(a,b,c);
        pa.Return(new Dictionary<string, object>{
                {"r", inst.r},
                {"g", inst.g},
                {"b", inst.b},
                {"a", inst.a},
                {"grayscale", inst.grayscale},
                {"linear", inst.linear},
                {"gamma", inst.gamma},
                {"maxColorComponent", inst.maxColorComponent},
        }, "UnityEngine.Color");
    }
    /// <summary>
    /// function Constructor()
    /// ex. UnityEngine.Color.Constructor()
    /// ex. UnityEngine.Color()
    /// </summary>
    private static void Constructor_3D2611E8_0(Lua.Param pa)
    {
        var inst=new UnityEngine.Color();
        pa.Return(new Dictionary<string, object>{
                {"r", inst.r},
                {"g", inst.g},
                {"b", inst.b},
                {"a", inst.a},
                {"grayscale", inst.grayscale},
                {"linear", inst.linear},
                {"gamma", inst.gamma},
                {"maxColorComponent", inst.maxColorComponent},
        }, "UnityEngine.Color");
    }
    /// <summary>
    /// function Constructor()
    /// ex. UnityEngine.Color.Constructor()
    /// ex. UnityEngine.Color()
    /// </summary>
    private static void ConstructorRef_3D2611E8_5(Lua.Param pa)
    {
        var inst=new UnityEngine.Color();
        pa.Return(new Dictionary<string, object>{
                {"r", inst.r},
                {"g", inst.g},
                {"b", inst.b},
                {"a", inst.a},
                {"grayscale", inst.grayscale},
                {"linear", inst.linear},
                {"gamma", inst.gamma},
                {"maxColorComponent", inst.maxColorComponent},
        }, "UnityEngine.Color");
    }
    private static void Constructor(Lua.Param pa)
    {
        var typecode = pa.GetTypecode();
        // function Constructor(number, number, number, number)
        if(typecode == 0x3333UL)
            Constructor_8C7B8340_3333(pa);
        else
        // function Constructor(number, number, number)
        if(typecode == 0x333UL)
            Constructor_C723660_333(pa);
        else
        // function Constructor()
        if(typecode == 0x0UL)
            Constructor_3D2611E8_0(pa);
        else
        {
#if UNITY_EDITOR
            throw new NotImplementedException(string.Format("typecode=0x{0:X}", typecode));
#endif
        }
    }
    private static void ConstructorRef(Lua.Param pa)
    {
        var typecode = pa.GetTypecode();
        // function ConstructorRef(table, number, number, number, number)
        if(typecode == 0x53333UL)
            ConstructorRef_8C7B8340_53333(pa);
        else
        // function ConstructorRef(table, number, number, number)
        if(typecode == 0x5333UL)
            ConstructorRef_C723660_5333(pa);
        else
        // function ConstructorRef(table)
        if(typecode == 0x5UL)
            ConstructorRef_3D2611E8_5(pa);
        else
        {
#if UNITY_EDITOR
            throw new NotImplementedException(string.Format("typecode=0x{0:X}", typecode));
#endif
        }
    }
    /// <summary>
    /// function ToString(self)
    /// ex. self:ToString()
    /// </summary>
    private static void _inst_method_ToString_D06B8A80_0(Lua.Param pa)
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
        var ra=a.ToString();
        pa.Return(ra);
        var __state__=pa.state;
        Lua.State.Push(pa.state, "r");
        Lua.State.Push(pa.state, a.r); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "g");
        Lua.State.Push(pa.state, a.g); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "b");
        Lua.State.Push(pa.state, a.b); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "a");
        Lua.State.Push(pa.state, a.a); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "grayscale");
        Lua.State.Push(pa.state, a.grayscale); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "linear");
        Lua.State.Push(pa.state, a.linear, typeof(UnityEngine.Color));
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "gamma");
        Lua.State.Push(pa.state, a.gamma, typeof(UnityEngine.Color));
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "maxColorComponent");
        Lua.State.Push(pa.state, a.maxColorComponent); 
        __state__.SetTable(1);
    }
    /// <summary>
    /// function ToString(self, string)
    /// ex. self:ToString(string1)
    /// </summary>
    private static void _inst_method_ToString_B136D40_54(Lua.Param pa)
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
        var b=pa.GetString(2);
        var ra=a.ToString(b);
        pa.Return(ra);
        var __state__=pa.state;
        Lua.State.Push(pa.state, "r");
        Lua.State.Push(pa.state, a.r); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "g");
        Lua.State.Push(pa.state, a.g); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "b");
        Lua.State.Push(pa.state, a.b); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "a");
        Lua.State.Push(pa.state, a.a); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "grayscale");
        Lua.State.Push(pa.state, a.grayscale); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "linear");
        Lua.State.Push(pa.state, a.linear, typeof(UnityEngine.Color));
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "gamma");
        Lua.State.Push(pa.state, a.gamma, typeof(UnityEngine.Color));
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "maxColorComponent");
        Lua.State.Push(pa.state, a.maxColorComponent); 
        __state__.SetTable(1);
    }
    /// <summary>
    /// function GetHashCode(self)
    /// ex. self:GetHashCode()
    /// </summary>
    private static void _inst_method_GetHashCode_45BB500_0(Lua.Param pa)
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
        var ra=a.GetHashCode();
        pa.Return(ra);
        var __state__=pa.state;
        Lua.State.Push(pa.state, "r");
        Lua.State.Push(pa.state, a.r); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "g");
        Lua.State.Push(pa.state, a.g); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "b");
        Lua.State.Push(pa.state, a.b); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "a");
        Lua.State.Push(pa.state, a.a); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "grayscale");
        Lua.State.Push(pa.state, a.grayscale); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "linear");
        Lua.State.Push(pa.state, a.linear, typeof(UnityEngine.Color));
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "gamma");
        Lua.State.Push(pa.state, a.gamma, typeof(UnityEngine.Color));
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "maxColorComponent");
        Lua.State.Push(pa.state, a.maxColorComponent); 
        __state__.SetTable(1);
    }
    /// <summary>
    /// function Equals(self, autotype)
    /// ex. self:Equals(autotype1)
    /// </summary>
    private static void _inst_method_Equals_806332C0_5F(Lua.Param pa)
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
        var b=pa.GetOneobject(2);
        var ra=a.Equals(b);
        pa.Return(ra);
        var __state__=pa.state;
        Lua.State.Push(pa.state, "r");
        Lua.State.Push(pa.state, a.r); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "g");
        Lua.State.Push(pa.state, a.g); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "b");
        Lua.State.Push(pa.state, a.b); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "a");
        Lua.State.Push(pa.state, a.a); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "grayscale");
        Lua.State.Push(pa.state, a.grayscale); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "linear");
        Lua.State.Push(pa.state, a.linear, typeof(UnityEngine.Color));
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "gamma");
        Lua.State.Push(pa.state, a.gamma, typeof(UnityEngine.Color));
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "maxColorComponent");
        Lua.State.Push(pa.state, a.maxColorComponent); 
        __state__.SetTable(1);
    }
    private static void _inst_get_property_grayscale(Lua.Param pa)
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
        pa.Return(a.grayscale);
        var __state__=pa.state;
        Lua.State.Push(pa.state, "r");
        Lua.State.Push(pa.state, a.r); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "g");
        Lua.State.Push(pa.state, a.g); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "b");
        Lua.State.Push(pa.state, a.b); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "a");
        Lua.State.Push(pa.state, a.a); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "grayscale");
        Lua.State.Push(pa.state, a.grayscale); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "linear");
        Lua.State.Push(pa.state, a.linear, typeof(UnityEngine.Color));
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "gamma");
        Lua.State.Push(pa.state, a.gamma, typeof(UnityEngine.Color));
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "maxColorComponent");
        Lua.State.Push(pa.state, a.maxColorComponent); 
        __state__.SetTable(1);
    }
    private static void _inst_get_property_linear(Lua.Param pa)
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
        pa.Return(new Dictionary<string, object>{
                {"r", a.linear.r},
                {"g", a.linear.g},
                {"b", a.linear.b},
                {"a", a.linear.a},
                {"grayscale", a.linear.grayscale},
                {"linear", a.linear.linear},
                {"gamma", a.linear.gamma},
                {"maxColorComponent", a.linear.maxColorComponent},
        }, "UnityEngine.Color");
        var __state__=pa.state;
        Lua.State.Push(pa.state, "r");
        Lua.State.Push(pa.state, a.r); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "g");
        Lua.State.Push(pa.state, a.g); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "b");
        Lua.State.Push(pa.state, a.b); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "a");
        Lua.State.Push(pa.state, a.a); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "grayscale");
        Lua.State.Push(pa.state, a.grayscale); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "linear");
        Lua.State.Push(pa.state, a.linear, typeof(UnityEngine.Color));
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "gamma");
        Lua.State.Push(pa.state, a.gamma, typeof(UnityEngine.Color));
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "maxColorComponent");
        Lua.State.Push(pa.state, a.maxColorComponent); 
        __state__.SetTable(1);
    }
    private static void _inst_get_property_gamma(Lua.Param pa)
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
        pa.Return(new Dictionary<string, object>{
                {"r", a.gamma.r},
                {"g", a.gamma.g},
                {"b", a.gamma.b},
                {"a", a.gamma.a},
                {"grayscale", a.gamma.grayscale},
                {"linear", a.gamma.linear},
                {"gamma", a.gamma.gamma},
                {"maxColorComponent", a.gamma.maxColorComponent},
        }, "UnityEngine.Color");
        var __state__=pa.state;
        Lua.State.Push(pa.state, "r");
        Lua.State.Push(pa.state, a.r); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "g");
        Lua.State.Push(pa.state, a.g); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "b");
        Lua.State.Push(pa.state, a.b); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "a");
        Lua.State.Push(pa.state, a.a); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "grayscale");
        Lua.State.Push(pa.state, a.grayscale); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "linear");
        Lua.State.Push(pa.state, a.linear, typeof(UnityEngine.Color));
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "gamma");
        Lua.State.Push(pa.state, a.gamma, typeof(UnityEngine.Color));
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "maxColorComponent");
        Lua.State.Push(pa.state, a.maxColorComponent); 
        __state__.SetTable(1);
    }
    private static void _inst_get_property_maxColorComponent(Lua.Param pa)
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
        pa.Return(a.maxColorComponent);
        var __state__=pa.state;
        Lua.State.Push(pa.state, "r");
        Lua.State.Push(pa.state, a.r); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "g");
        Lua.State.Push(pa.state, a.g); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "b");
        Lua.State.Push(pa.state, a.b); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "a");
        Lua.State.Push(pa.state, a.a); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "grayscale");
        Lua.State.Push(pa.state, a.grayscale); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "linear");
        Lua.State.Push(pa.state, a.linear, typeof(UnityEngine.Color));
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "gamma");
        Lua.State.Push(pa.state, a.gamma, typeof(UnityEngine.Color));
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "maxColorComponent");
        Lua.State.Push(pa.state, a.maxColorComponent); 
        __state__.SetTable(1);
    }
    private static void _inst_get_property_Item_53(Lua.Param pa)
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
        var b=pa.GetInteger(2);
        pa.Return(a[b]);
        var __state__=pa.state;
        Lua.State.Push(pa.state, "r");
        Lua.State.Push(pa.state, a.r); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "g");
        Lua.State.Push(pa.state, a.g); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "b");
        Lua.State.Push(pa.state, a.b); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "a");
        Lua.State.Push(pa.state, a.a); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "grayscale");
        Lua.State.Push(pa.state, a.grayscale); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "linear");
        Lua.State.Push(pa.state, a.linear, typeof(UnityEngine.Color));
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "gamma");
        Lua.State.Push(pa.state, a.gamma, typeof(UnityEngine.Color));
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "maxColorComponent");
        Lua.State.Push(pa.state, a.maxColorComponent); 
        __state__.SetTable(1);
    }
    private static void _inst_set_property_Item_53(Lua.Param pa)
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
        var b=pa.GetInteger(2);
        pa.Return(a[b]);
        var __state__=pa.state;
        Lua.State.Push(pa.state, "r");
        Lua.State.Push(pa.state, a.r); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "g");
        Lua.State.Push(pa.state, a.g); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "b");
        Lua.State.Push(pa.state, a.b); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "a");
        Lua.State.Push(pa.state, a.a); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "grayscale");
        Lua.State.Push(pa.state, a.grayscale); 
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "linear");
        Lua.State.Push(pa.state, a.linear, typeof(UnityEngine.Color));
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "gamma");
        Lua.State.Push(pa.state, a.gamma, typeof(UnityEngine.Color));
        __state__.SetTable(1);
        Lua.State.Push(pa.state, "maxColorComponent");
        Lua.State.Push(pa.state, a.maxColorComponent); 
        __state__.SetTable(1);
    }
    private static void _inst_get_field_r(Lua.Param pa)
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
        pa.Return(a.r);
    }
    private static void _inst_set_field_r(Lua.Param pa)
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
        var b=pa.GetFloat(2);
        a.r = b;
        var __state__=pa.state;
        Lua.State.Push(pa.state, "r");
        Lua.State.Push(pa.state, a.r); 
        __state__.SetTable(1);
    }
    private static void _inst_get_field_g(Lua.Param pa)
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
        pa.Return(a.g);
    }
    private static void _inst_set_field_g(Lua.Param pa)
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
        var b=pa.GetFloat(2);
        a.g = b;
        var __state__=pa.state;
        Lua.State.Push(pa.state, "g");
        Lua.State.Push(pa.state, a.g); 
        __state__.SetTable(1);
    }
    private static void _inst_get_field_b(Lua.Param pa)
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
        pa.Return(a.b);
    }
    private static void _inst_set_field_b(Lua.Param pa)
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
        var b=pa.GetFloat(2);
        a.b = b;
        var __state__=pa.state;
        Lua.State.Push(pa.state, "b");
        Lua.State.Push(pa.state, a.b); 
        __state__.SetTable(1);
    }
    private static void _inst_get_field_a(Lua.Param pa)
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
        pa.Return(a.a);
    }
    private static void _inst_set_field_a(Lua.Param pa)
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
        var b=pa.GetFloat(2);
        a.a = b;
        var __state__=pa.state;
        Lua.State.Push(pa.state, "a");
        Lua.State.Push(pa.state, a.a); 
        __state__.SetTable(1);
    }
    private static void _inst_method_ToString(Lua.Param pa)
    {
        var typecode = pa.GetTypecode();
        // function ToString()
        if(typecode == 0x0UL)
            _inst_method_ToString_D06B8A80_0(pa);
        else
        // function ToString(table, string)
        if(typecode == 0x54UL)
            _inst_method_ToString_B136D40_54(pa);
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
        var constructor_ref = state.newref(ConstructorRef);
        var rt = state.get_table_ref_with_path("UnityEngine.Color");
        var _rt = state.newrefmetatable(new Dictionary<string, Lua.Ref>
        {
            {"__newindex", state.newref(param=>{})},
            {"__call", constructor_ref},
            {"GetRed", state.newref(_s_get_property_red)},
            {"GetGreen", state.newref(_s_get_property_green)},
            {"GetBlue", state.newref(_s_get_property_blue)},
            {"GetWhite", state.newref(_s_get_property_white)},
            {"GetBlack", state.newref(_s_get_property_black)},
            {"GetYellow", state.newref(_s_get_property_yellow)},
            {"GetCyan", state.newref(_s_get_property_cyan)},
            {"GetMagenta", state.newref(_s_get_property_magenta)},
            {"GetGray", state.newref(_s_get_property_gray)},
            {"GetGrey", state.newref(_s_get_property_grey)},
            {"GetClear", state.newref(_s_get_property_clear)},
            {"Lerp", state.newref(_s_method_Lerp_FED05F0_553)},
            {"LerpUnclamped", state.newref(_s_method_LerpUnclamped_397841C0_553)},
            {"RGBToHSV", state.newref(_s_method_RGBToHSV_DD4A4FC0_5)},
            {"HSVToRGB", state.newref(_s_method_HSVToRGB)},
            {"Constructor", state.newref(Constructor)},
        });
        state.set_metatable(rt, _rt);
        metatable = Lua.State.CreateMetatable(typeof(UnityEngine.Color), 
            new Dictionary<string, Action<Lua.Param>>
        {
            {"GetGrayscale", _inst_get_property_grayscale},
            {"GetLinear", _inst_get_property_linear},
            {"GetGamma", _inst_get_property_gamma},
            {"GetMaxColorComponent", _inst_get_property_maxColorComponent},
            {"get_r", _inst_get_field_r},
            {"set_r", _inst_set_field_r},
            {"get_g", _inst_get_field_g},
            {"set_g", _inst_set_field_g},
            {"get_b", _inst_get_field_b},
            {"set_b", _inst_set_field_b},
            {"get_a", _inst_get_field_a},
            {"set_a", _inst_set_field_a},
            {"ToString", _inst_method_ToString},
            {"GetHashCode", _inst_method_GetHashCode_45BB500_0},
            {"Equals", _inst_method_Equals_806332C0_5F},
            {"Get", _inst_get_property_Item_53},
            {"Set", _inst_set_property_Item_53},
        }, typeof(System.ValueType));
        return metatable;  
    }

}
}
