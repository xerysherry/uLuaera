// THIS IS A GENERATED FILE. PLEASE DO NOT MODIFY IT!
using System;
using System.Collections;
using System.Collections.Generic;
using Lua;

namespace Lua
{
public static class Wrap_UnityEngine_Debug 
{
    /// <summary>
    /// function DrawLine(table, table, table, number, boolean)
    /// ex. UnityEngine.Debug.DrawLine(table1, table2, table3, number4, boolean5)
    /// </summary>
    private static void _s_method_DrawLine_DE67750_55531(Lua.Param pa)
    {
        var s1=pa.GetDictionary<string, object>(1);
        var a = new UnityEngine.Vector3();
        object a_x = null;
        if(s1.TryGetValue("x", out a_x))
            a.x = (float)(double)a_x;
        object a_y = null;
        if(s1.TryGetValue("y", out a_y))
            a.y = (float)(double)a_y;
        object a_z = null;
        if(s1.TryGetValue("z", out a_z))
            a.z = (float)(double)a_z;
        var s2=pa.GetDictionary<string, object>(2);
        var b = new UnityEngine.Vector3();
        object b_x = null;
        if(s2.TryGetValue("x", out b_x))
            b.x = (float)(double)b_x;
        object b_y = null;
        if(s2.TryGetValue("y", out b_y))
            b.y = (float)(double)b_y;
        object b_z = null;
        if(s2.TryGetValue("z", out b_z))
            b.z = (float)(double)b_z;
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
        var d=pa.GetFloat(4);
        var e=pa.GetBoolean(5);
        UnityEngine.Debug.DrawLine(a,b,c,d,e);
    }
    /// <summary>
    /// function DrawLine(table, table, table, number)
    /// ex. UnityEngine.Debug.DrawLine(table1, table2, table3, number4)
    /// </summary>
    private static void _s_method_DrawLine_19F57C0_5553(Lua.Param pa)
    {
        var s1=pa.GetDictionary<string, object>(1);
        var a = new UnityEngine.Vector3();
        object a_x = null;
        if(s1.TryGetValue("x", out a_x))
            a.x = (float)(double)a_x;
        object a_y = null;
        if(s1.TryGetValue("y", out a_y))
            a.y = (float)(double)a_y;
        object a_z = null;
        if(s1.TryGetValue("z", out a_z))
            a.z = (float)(double)a_z;
        var s2=pa.GetDictionary<string, object>(2);
        var b = new UnityEngine.Vector3();
        object b_x = null;
        if(s2.TryGetValue("x", out b_x))
            b.x = (float)(double)b_x;
        object b_y = null;
        if(s2.TryGetValue("y", out b_y))
            b.y = (float)(double)b_y;
        object b_z = null;
        if(s2.TryGetValue("z", out b_z))
            b.z = (float)(double)b_z;
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
        var d=pa.GetFloat(4);
        UnityEngine.Debug.DrawLine(a,b,c,d);
    }
    /// <summary>
    /// function DrawLine(table, table, table)
    /// ex. UnityEngine.Debug.DrawLine(table1, table2, table3)
    /// </summary>
    private static void _s_method_DrawLine_53B73A80_555(Lua.Param pa)
    {
        var s1=pa.GetDictionary<string, object>(1);
        var a = new UnityEngine.Vector3();
        object a_x = null;
        if(s1.TryGetValue("x", out a_x))
            a.x = (float)(double)a_x;
        object a_y = null;
        if(s1.TryGetValue("y", out a_y))
            a.y = (float)(double)a_y;
        object a_z = null;
        if(s1.TryGetValue("z", out a_z))
            a.z = (float)(double)a_z;
        var s2=pa.GetDictionary<string, object>(2);
        var b = new UnityEngine.Vector3();
        object b_x = null;
        if(s2.TryGetValue("x", out b_x))
            b.x = (float)(double)b_x;
        object b_y = null;
        if(s2.TryGetValue("y", out b_y))
            b.y = (float)(double)b_y;
        object b_z = null;
        if(s2.TryGetValue("z", out b_z))
            b.z = (float)(double)b_z;
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
        UnityEngine.Debug.DrawLine(a,b,c);
    }
    /// <summary>
    /// function DrawLine(table, table)
    /// ex. UnityEngine.Debug.DrawLine(table1, table2)
    /// </summary>
    private static void _s_method_DrawLine_8E5F1D40_55(Lua.Param pa)
    {
        var s1=pa.GetDictionary<string, object>(1);
        var a = new UnityEngine.Vector3();
        object a_x = null;
        if(s1.TryGetValue("x", out a_x))
            a.x = (float)(double)a_x;
        object a_y = null;
        if(s1.TryGetValue("y", out a_y))
            a.y = (float)(double)a_y;
        object a_z = null;
        if(s1.TryGetValue("z", out a_z))
            a.z = (float)(double)a_z;
        var s2=pa.GetDictionary<string, object>(2);
        var b = new UnityEngine.Vector3();
        object b_x = null;
        if(s2.TryGetValue("x", out b_x))
            b.x = (float)(double)b_x;
        object b_y = null;
        if(s2.TryGetValue("y", out b_y))
            b.y = (float)(double)b_y;
        object b_z = null;
        if(s2.TryGetValue("z", out b_z))
            b.z = (float)(double)b_z;
        UnityEngine.Debug.DrawLine(a,b);
    }
    /// <summary>
    /// function DrawRay(table, table, table, number)
    /// ex. UnityEngine.Debug.DrawRay(table1, table2, table3, number4)
    /// </summary>
    private static void _s_method_DrawRay_C9700_5553(Lua.Param pa)
    {
        var s1=pa.GetDictionary<string, object>(1);
        var a = new UnityEngine.Vector3();
        object a_x = null;
        if(s1.TryGetValue("x", out a_x))
            a.x = (float)(double)a_x;
        object a_y = null;
        if(s1.TryGetValue("y", out a_y))
            a.y = (float)(double)a_y;
        object a_z = null;
        if(s1.TryGetValue("z", out a_z))
            a.z = (float)(double)a_z;
        var s2=pa.GetDictionary<string, object>(2);
        var b = new UnityEngine.Vector3();
        object b_x = null;
        if(s2.TryGetValue("x", out b_x))
            b.x = (float)(double)b_x;
        object b_y = null;
        if(s2.TryGetValue("y", out b_y))
            b.y = (float)(double)b_y;
        object b_z = null;
        if(s2.TryGetValue("z", out b_z))
            b.z = (float)(double)b_z;
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
        var d=pa.GetFloat(4);
        UnityEngine.Debug.DrawRay(a,b,c,d);
    }
    /// <summary>
    /// function DrawRay(table, table, table)
    /// ex. UnityEngine.Debug.DrawRay(table1, table2, table3)
    /// </summary>
    private static void _s_method_DrawRay_269E8A40_555(Lua.Param pa)
    {
        var s1=pa.GetDictionary<string, object>(1);
        var a = new UnityEngine.Vector3();
        object a_x = null;
        if(s1.TryGetValue("x", out a_x))
            a.x = (float)(double)a_x;
        object a_y = null;
        if(s1.TryGetValue("y", out a_y))
            a.y = (float)(double)a_y;
        object a_z = null;
        if(s1.TryGetValue("z", out a_z))
            a.z = (float)(double)a_z;
        var s2=pa.GetDictionary<string, object>(2);
        var b = new UnityEngine.Vector3();
        object b_x = null;
        if(s2.TryGetValue("x", out b_x))
            b.x = (float)(double)b_x;
        object b_y = null;
        if(s2.TryGetValue("y", out b_y))
            b.y = (float)(double)b_y;
        object b_z = null;
        if(s2.TryGetValue("z", out b_z))
            b.z = (float)(double)b_z;
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
        UnityEngine.Debug.DrawRay(a,b,c);
    }
    /// <summary>
    /// function DrawRay(table, table)
    /// ex. UnityEngine.Debug.DrawRay(table1, table2)
    /// </summary>
    private static void _s_method_DrawRay_61466D0_55(Lua.Param pa)
    {
        var s1=pa.GetDictionary<string, object>(1);
        var a = new UnityEngine.Vector3();
        object a_x = null;
        if(s1.TryGetValue("x", out a_x))
            a.x = (float)(double)a_x;
        object a_y = null;
        if(s1.TryGetValue("y", out a_y))
            a.y = (float)(double)a_y;
        object a_z = null;
        if(s1.TryGetValue("z", out a_z))
            a.z = (float)(double)a_z;
        var s2=pa.GetDictionary<string, object>(2);
        var b = new UnityEngine.Vector3();
        object b_x = null;
        if(s2.TryGetValue("x", out b_x))
            b.x = (float)(double)b_x;
        object b_y = null;
        if(s2.TryGetValue("y", out b_y))
            b.y = (float)(double)b_y;
        object b_z = null;
        if(s2.TryGetValue("z", out b_z))
            b.z = (float)(double)b_z;
        UnityEngine.Debug.DrawRay(a,b);
    }
    /// <summary>
    /// function DrawRay(table, table, table, number, boolean)
    /// ex. UnityEngine.Debug.DrawRay(table1, table2, table3, number4, boolean5)
    /// </summary>
    private static void _s_method_DrawRay_9BEE4FC0_55531(Lua.Param pa)
    {
        var s1=pa.GetDictionary<string, object>(1);
        var a = new UnityEngine.Vector3();
        object a_x = null;
        if(s1.TryGetValue("x", out a_x))
            a.x = (float)(double)a_x;
        object a_y = null;
        if(s1.TryGetValue("y", out a_y))
            a.y = (float)(double)a_y;
        object a_z = null;
        if(s1.TryGetValue("z", out a_z))
            a.z = (float)(double)a_z;
        var s2=pa.GetDictionary<string, object>(2);
        var b = new UnityEngine.Vector3();
        object b_x = null;
        if(s2.TryGetValue("x", out b_x))
            b.x = (float)(double)b_x;
        object b_y = null;
        if(s2.TryGetValue("y", out b_y))
            b.y = (float)(double)b_y;
        object b_z = null;
        if(s2.TryGetValue("z", out b_z))
            b.z = (float)(double)b_z;
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
        var d=pa.GetFloat(4);
        var e=pa.GetBoolean(5);
        UnityEngine.Debug.DrawRay(a,b,c,d,e);
    }
    /// <summary>
    /// function Break()
    /// ex. UnityEngine.Debug.Break()
    /// </summary>
    private static void _s_method_Break_D6963280_0(Lua.Param pa)
    {
        UnityEngine.Debug.Break();
    }
    /// <summary>
    /// function DebugBreak()
    /// ex. UnityEngine.Debug.DebugBreak()
    /// </summary>
    private static void _s_method_DebugBreak_113E1540_0(Lua.Param pa)
    {
        UnityEngine.Debug.DebugBreak();
    }
    /// <summary>
    /// function Log(autotype)
    /// ex. UnityEngine.Debug.Log(autotype1)
    /// </summary>
    private static void _s_method_Log_FB8732C0_F(Lua.Param pa)
    {
        var a=pa.GetOneobject(1);
        UnityEngine.Debug.Log(a);
    }
    /// <summary>
    /// function Log(autotype, userdata)
    /// ex. UnityEngine.Debug.Log(autotype1, userdata2)
    /// </summary>
    private static void _s_method_Log_4BE5F80_F2(Lua.Param pa)
    {
        var a=pa.GetOneobject(1);
        var b=pa.GetUserdata<UnityEngine.Object>(2);
        UnityEngine.Debug.Log(a,b);
    }
    /// <summary>
    /// function LogFormat(string, table)
    /// ex. UnityEngine.Debug.LogFormat(string1, table2)
    /// </summary>
    private static void _s_method_LogFormat_868DDAC0_45(Lua.Param pa)
    {
        var a=pa.GetString(1);
        var b=pa.GetArray<System.Object>(2);
        UnityEngine.Debug.LogFormat(a,b);
    }
    /// <summary>
    /// function LogFormat(userdata, string, table)
    /// ex. UnityEngine.Debug.LogFormat(userdata1, string2, table3)
    /// </summary>
    private static void _s_method_LogFormat_C135BD80_245(Lua.Param pa)
    {
        var a=pa.GetUserdata<UnityEngine.Object>(1);
        var b=pa.GetString(2);
        var c=pa.GetArray<System.Object>(3);
        UnityEngine.Debug.LogFormat(a,b,c);
    }
    /// <summary>
    /// function LogError(autotype)
    /// ex. UnityEngine.Debug.LogError(autotype1)
    /// </summary>
    private static void _s_method_LogError_FBDDA040_F(Lua.Param pa)
    {
        var a=pa.GetOneobject(1);
        UnityEngine.Debug.LogError(a);
    }
    /// <summary>
    /// function LogError(autotype, userdata)
    /// ex. UnityEngine.Debug.LogError(autotype1, userdata2)
    /// </summary>
    private static void _s_method_LogError_3685830_F2(Lua.Param pa)
    {
        var a=pa.GetOneobject(1);
        var b=pa.GetUserdata<UnityEngine.Object>(2);
        UnityEngine.Debug.LogError(a,b);
    }
    /// <summary>
    /// function LogErrorFormat(string, table)
    /// ex. UnityEngine.Debug.LogErrorFormat(string1, table2)
    /// </summary>
    private static void _s_method_LogErrorFormat_712D65C0_45(Lua.Param pa)
    {
        var a=pa.GetString(1);
        var b=pa.GetArray<System.Object>(2);
        UnityEngine.Debug.LogErrorFormat(a,b);
    }
    /// <summary>
    /// function LogErrorFormat(userdata, string, table)
    /// ex. UnityEngine.Debug.LogErrorFormat(userdata1, string2, table3)
    /// </summary>
    private static void _s_method_LogErrorFormat_ABD54880_245(Lua.Param pa)
    {
        var a=pa.GetUserdata<UnityEngine.Object>(1);
        var b=pa.GetString(2);
        var c=pa.GetArray<System.Object>(3);
        UnityEngine.Debug.LogErrorFormat(a,b,c);
    }
    /// <summary>
    /// function ClearDeveloperConsole()
    /// ex. UnityEngine.Debug.ClearDeveloperConsole()
    /// </summary>
    private static void _s_method_ClearDeveloperConsole_E67D2B40_0(Lua.Param pa)
    {
        UnityEngine.Debug.ClearDeveloperConsole();
    }
    /// <summary>
    /// function LogException(userdata)
    /// ex. UnityEngine.Debug.LogException(userdata1)
    /// </summary>
    private static void _s_method_LogException_9674D380_2(Lua.Param pa)
    {
        var a=pa.GetUserdata<System.Exception>(1);
        UnityEngine.Debug.LogException(a);
    }
    /// <summary>
    /// function LogException(userdata, userdata)
    /// ex. UnityEngine.Debug.LogException(userdata1, userdata2)
    /// </summary>
    private static void _s_method_LogException_D11CB640_22(Lua.Param pa)
    {
        var a=pa.GetUserdata<System.Exception>(1);
        var b=pa.GetUserdata<UnityEngine.Object>(2);
        UnityEngine.Debug.LogException(a,b);
    }
    /// <summary>
    /// function LogWarning(autotype)
    /// ex. UnityEngine.Debug.LogWarning(autotype1)
    /// </summary>
    private static void _s_method_LogWarning_BC4990_F(Lua.Param pa)
    {
        var a=pa.GetOneobject(1);
        UnityEngine.Debug.LogWarning(a);
    }
    /// <summary>
    /// function LogWarning(autotype, userdata)
    /// ex. UnityEngine.Debug.LogWarning(autotype1, userdata2)
    /// </summary>
    private static void _s_method_LogWarning_466C7BC0_F2(Lua.Param pa)
    {
        var a=pa.GetOneobject(1);
        var b=pa.GetUserdata<UnityEngine.Object>(2);
        UnityEngine.Debug.LogWarning(a,b);
    }
    /// <summary>
    /// function LogWarningFormat(string, table)
    /// ex. UnityEngine.Debug.LogWarningFormat(string1, table2)
    /// </summary>
    private static void _s_method_LogWarningFormat_81145E80_45(Lua.Param pa)
    {
        var a=pa.GetString(1);
        var b=pa.GetArray<System.Object>(2);
        UnityEngine.Debug.LogWarningFormat(a,b);
    }
    /// <summary>
    /// function LogWarningFormat(userdata, string, table)
    /// ex. UnityEngine.Debug.LogWarningFormat(userdata1, string2, table3)
    /// </summary>
    private static void _s_method_LogWarningFormat_BBBC4140_245(Lua.Param pa)
    {
        var a=pa.GetUserdata<UnityEngine.Object>(1);
        var b=pa.GetString(2);
        var c=pa.GetArray<System.Object>(3);
        UnityEngine.Debug.LogWarningFormat(a,b,c);
    }
    /// <summary>
    /// function Assert(boolean)
    /// ex. UnityEngine.Debug.Assert(boolean1)
    /// </summary>
    private static void _s_method_Assert_F664240_1(Lua.Param pa)
    {
        var a=pa.GetBoolean(1);
        UnityEngine.Debug.Assert(a);
    }
    /// <summary>
    /// function Assert(boolean, userdata)
    /// ex. UnityEngine.Debug.Assert(boolean1, userdata2)
    /// </summary>
    private static void _s_method_Assert_31C6C0_12(Lua.Param pa)
    {
        var a=pa.GetBoolean(1);
        var b=pa.GetUserdata<UnityEngine.Object>(2);
        UnityEngine.Debug.Assert(a,b);
    }
    /// <summary>
    /// function Assert(boolean, autotype)
    /// ex. UnityEngine.Debug.Assert(boolean1, autotype2)
    /// </summary>
    private static void _s_method_Assert_6BB3E980_1F(Lua.Param pa)
    {
        var a=pa.GetBoolean(1);
        var b=pa.GetOneobject(2);
        UnityEngine.Debug.Assert(a,b);
    }
    /// <summary>
    /// function Assert(boolean, string)
    /// ex. UnityEngine.Debug.Assert(boolean1, string2)
    /// </summary>
    private static void _s_method_Assert_A65BCC40_14(Lua.Param pa)
    {
        var a=pa.GetBoolean(1);
        var b=pa.GetString(2);
        UnityEngine.Debug.Assert(a,b);
    }
    /// <summary>
    /// function Assert(boolean, autotype, userdata)
    /// ex. UnityEngine.Debug.Assert(boolean1, autotype2, userdata3)
    /// </summary>
    private static void _s_method_Assert_E13AF0_1F2(Lua.Param pa)
    {
        var a=pa.GetBoolean(1);
        var b=pa.GetOneobject(2);
        var c=pa.GetUserdata<UnityEngine.Object>(3);
        UnityEngine.Debug.Assert(a,b,c);
    }
    /// <summary>
    /// function Assert(boolean, string, userdata)
    /// ex. UnityEngine.Debug.Assert(boolean1, string2, userdata3)
    /// </summary>
    private static void _s_method_Assert_1BAB91C0_142(Lua.Param pa)
    {
        var a=pa.GetBoolean(1);
        var b=pa.GetString(2);
        var c=pa.GetUserdata<UnityEngine.Object>(3);
        UnityEngine.Debug.Assert(a,b,c);
    }
    /// <summary>
    /// function AssertFormat(boolean, string, table)
    /// ex. UnityEngine.Debug.AssertFormat(boolean1, string2, table3)
    /// </summary>
    private static void _s_method_AssertFormat_56537480_145(Lua.Param pa)
    {
        var a=pa.GetBoolean(1);
        var b=pa.GetString(2);
        var c=pa.GetArray<System.Object>(3);
        UnityEngine.Debug.AssertFormat(a,b,c);
    }
    /// <summary>
    /// function AssertFormat(boolean, userdata, string, table)
    /// ex. UnityEngine.Debug.AssertFormat(boolean1, userdata2, string3, table4)
    /// </summary>
    private static void _s_method_AssertFormat_90FB5740_1245(Lua.Param pa)
    {
        var a=pa.GetBoolean(1);
        var b=pa.GetUserdata<UnityEngine.Object>(2);
        var c=pa.GetString(3);
        var d=pa.GetArray<System.Object>(4);
        UnityEngine.Debug.AssertFormat(a,b,c,d);
    }
    /// <summary>
    /// function LogAssertion(autotype)
    /// ex. UnityEngine.Debug.LogAssertion(autotype1)
    /// </summary>
    private static void _s_method_LogAssertion_CBA33A0_F(Lua.Param pa)
    {
        var a=pa.GetOneobject(1);
        UnityEngine.Debug.LogAssertion(a);
    }
    /// <summary>
    /// function LogAssertion(autotype, userdata)
    /// ex. UnityEngine.Debug.LogAssertion(autotype1, userdata2)
    /// </summary>
    private static void _s_method_LogAssertion_64B1CC0_F2(Lua.Param pa)
    {
        var a=pa.GetOneobject(1);
        var b=pa.GetUserdata<UnityEngine.Object>(2);
        UnityEngine.Debug.LogAssertion(a,b);
    }
    /// <summary>
    /// function LogAssertionFormat(string, table)
    /// ex. UnityEngine.Debug.LogAssertionFormat(string1, table2)
    /// </summary>
    private static void _s_method_LogAssertionFormat_40F2FF80_45(Lua.Param pa)
    {
        var a=pa.GetString(1);
        var b=pa.GetArray<System.Object>(2);
        UnityEngine.Debug.LogAssertionFormat(a,b);
    }
    /// <summary>
    /// function LogAssertionFormat(userdata, string, table)
    /// ex. UnityEngine.Debug.LogAssertionFormat(userdata1, string2, table3)
    /// </summary>
    private static void _s_method_LogAssertionFormat_7B9AE240_245(Lua.Param pa)
    {
        var a=pa.GetUserdata<UnityEngine.Object>(1);
        var b=pa.GetString(2);
        var c=pa.GetArray<System.Object>(3);
        UnityEngine.Debug.LogAssertionFormat(a,b,c);
    }
    private static void _s_get_property_unityLogger(Lua.Param pa)
    {
        pa.Return(UnityEngine.Debug.unityLogger, typeof(UnityEngine.ILogger));
    }
    private static void _s_get_property_developerConsoleVisible(Lua.Param pa)
    {
        pa.Return(UnityEngine.Debug.developerConsoleVisible);
    }
    private static void _s_set_property_developerConsoleVisible(Lua.Param pa)
    {
        var a=pa.GetBoolean(1);
        UnityEngine.Debug.developerConsoleVisible = a;
    }
    private static void _s_get_property_isDebugBuild(Lua.Param pa)
    {
        pa.Return(UnityEngine.Debug.isDebugBuild);
    }
    private static void _s_method_DrawLine(Lua.Param pa)
    {
        var typecode = pa.GetTypecode();
        // function DrawLine(table, table, table, number, boolean)
        if(typecode == 0x55531UL)
            _s_method_DrawLine_DE67750_55531(pa);
        else
        // function DrawLine(table, table, table, number)
        if(typecode == 0x5553UL)
            _s_method_DrawLine_19F57C0_5553(pa);
        else
        // function DrawLine(table, table, table)
        if(typecode == 0x555UL)
            _s_method_DrawLine_53B73A80_555(pa);
        else
        // function DrawLine(table, table)
        if(typecode == 0x55UL)
            _s_method_DrawLine_8E5F1D40_55(pa);
        else
        {
#if UNITY_EDITOR
            throw new NotImplementedException(string.Format("typecode=0x{0:X}", typecode));
#endif
        }
    }
    private static void _s_method_DrawRay(Lua.Param pa)
    {
        var typecode = pa.GetTypecode();
        // function DrawRay(table, table, table, number)
        if(typecode == 0x5553UL)
            _s_method_DrawRay_C9700_5553(pa);
        else
        // function DrawRay(table, table, table)
        if(typecode == 0x555UL)
            _s_method_DrawRay_269E8A40_555(pa);
        else
        // function DrawRay(table, table)
        if(typecode == 0x55UL)
            _s_method_DrawRay_61466D0_55(pa);
        else
        // function DrawRay(table, table, table, number, boolean)
        if(typecode == 0x55531UL)
            _s_method_DrawRay_9BEE4FC0_55531(pa);
        else
        {
#if UNITY_EDITOR
            throw new NotImplementedException(string.Format("typecode=0x{0:X}", typecode));
#endif
        }
    }
    private static void _s_method_Log(Lua.Param pa)
    {
        var typecode = pa.GetTypecode();
        // function Log(autotype)
        if(Lua.Param.Equal(typecode, 0xFUL))
            _s_method_Log_FB8732C0_F(pa);
        else
        // function Log(autotype, userdata)
        if(Lua.Param.Equal(typecode, 0xF2UL))
            _s_method_Log_4BE5F80_F2(pa);
        else
        {
#if UNITY_EDITOR
            throw new NotImplementedException(string.Format("typecode=0x{0:X}", typecode));
#endif
        }
    }
    private static void _s_method_LogFormat(Lua.Param pa)
    {
        var typecode = pa.GetTypecode();
        // function LogFormat(string, table)
        if(typecode == 0x45UL)
            _s_method_LogFormat_868DDAC0_45(pa);
        else
        // function LogFormat(userdata, string, table)
        if(typecode == 0x245UL)
            _s_method_LogFormat_C135BD80_245(pa);
        else
        {
#if UNITY_EDITOR
            throw new NotImplementedException(string.Format("typecode=0x{0:X}", typecode));
#endif
        }
    }
    private static void _s_method_LogError(Lua.Param pa)
    {
        var typecode = pa.GetTypecode();
        // function LogError(autotype)
        if(Lua.Param.Equal(typecode, 0xFUL))
            _s_method_LogError_FBDDA040_F(pa);
        else
        // function LogError(autotype, userdata)
        if(Lua.Param.Equal(typecode, 0xF2UL))
            _s_method_LogError_3685830_F2(pa);
        else
        {
#if UNITY_EDITOR
            throw new NotImplementedException(string.Format("typecode=0x{0:X}", typecode));
#endif
        }
    }
    private static void _s_method_LogErrorFormat(Lua.Param pa)
    {
        var typecode = pa.GetTypecode();
        // function LogErrorFormat(string, table)
        if(typecode == 0x45UL)
            _s_method_LogErrorFormat_712D65C0_45(pa);
        else
        // function LogErrorFormat(userdata, string, table)
        if(typecode == 0x245UL)
            _s_method_LogErrorFormat_ABD54880_245(pa);
        else
        {
#if UNITY_EDITOR
            throw new NotImplementedException(string.Format("typecode=0x{0:X}", typecode));
#endif
        }
    }
    private static void _s_method_LogException(Lua.Param pa)
    {
        var typecode = pa.GetTypecode();
        // function LogException(userdata)
        if(typecode == 0x2UL)
            _s_method_LogException_9674D380_2(pa);
        else
        // function LogException(userdata, userdata)
        if(typecode == 0x22UL)
            _s_method_LogException_D11CB640_22(pa);
        else
        {
#if UNITY_EDITOR
            throw new NotImplementedException(string.Format("typecode=0x{0:X}", typecode));
#endif
        }
    }
    private static void _s_method_LogWarning(Lua.Param pa)
    {
        var typecode = pa.GetTypecode();
        // function LogWarning(autotype)
        if(Lua.Param.Equal(typecode, 0xFUL))
            _s_method_LogWarning_BC4990_F(pa);
        else
        // function LogWarning(autotype, userdata)
        if(Lua.Param.Equal(typecode, 0xF2UL))
            _s_method_LogWarning_466C7BC0_F2(pa);
        else
        {
#if UNITY_EDITOR
            throw new NotImplementedException(string.Format("typecode=0x{0:X}", typecode));
#endif
        }
    }
    private static void _s_method_LogWarningFormat(Lua.Param pa)
    {
        var typecode = pa.GetTypecode();
        // function LogWarningFormat(string, table)
        if(typecode == 0x45UL)
            _s_method_LogWarningFormat_81145E80_45(pa);
        else
        // function LogWarningFormat(userdata, string, table)
        if(typecode == 0x245UL)
            _s_method_LogWarningFormat_BBBC4140_245(pa);
        else
        {
#if UNITY_EDITOR
            throw new NotImplementedException(string.Format("typecode=0x{0:X}", typecode));
#endif
        }
    }
    private static void _s_method_Assert(Lua.Param pa)
    {
        var typecode = pa.GetTypecode();
        // function Assert(boolean)
        if(typecode == 0x1UL)
            _s_method_Assert_F664240_1(pa);
        else
        // function Assert(boolean, userdata)
        if(typecode == 0x12UL)
            _s_method_Assert_31C6C0_12(pa);
        else
        // function Assert(boolean, autotype)
        if(Lua.Param.Equal(typecode, 0x1FUL))
            _s_method_Assert_6BB3E980_1F(pa);
        else
        // function Assert(boolean, string)
        if(typecode == 0x14UL)
            _s_method_Assert_A65BCC40_14(pa);
        else
        // function Assert(boolean, autotype, userdata)
        if(Lua.Param.Equal(typecode, 0x1F2UL))
            _s_method_Assert_E13AF0_1F2(pa);
        else
        // function Assert(boolean, string, userdata)
        if(typecode == 0x142UL)
            _s_method_Assert_1BAB91C0_142(pa);
        else
        {
#if UNITY_EDITOR
            throw new NotImplementedException(string.Format("typecode=0x{0:X}", typecode));
#endif
        }
    }
    private static void _s_method_AssertFormat(Lua.Param pa)
    {
        var typecode = pa.GetTypecode();
        // function AssertFormat(boolean, string, table)
        if(typecode == 0x145UL)
            _s_method_AssertFormat_56537480_145(pa);
        else
        // function AssertFormat(boolean, userdata, string, table)
        if(typecode == 0x1245UL)
            _s_method_AssertFormat_90FB5740_1245(pa);
        else
        {
#if UNITY_EDITOR
            throw new NotImplementedException(string.Format("typecode=0x{0:X}", typecode));
#endif
        }
    }
    private static void _s_method_LogAssertion(Lua.Param pa)
    {
        var typecode = pa.GetTypecode();
        // function LogAssertion(autotype)
        if(Lua.Param.Equal(typecode, 0xFUL))
            _s_method_LogAssertion_CBA33A0_F(pa);
        else
        // function LogAssertion(autotype, userdata)
        if(Lua.Param.Equal(typecode, 0xF2UL))
            _s_method_LogAssertion_64B1CC0_F2(pa);
        else
        {
#if UNITY_EDITOR
            throw new NotImplementedException(string.Format("typecode=0x{0:X}", typecode));
#endif
        }
    }
    private static void _s_method_LogAssertionFormat(Lua.Param pa)
    {
        var typecode = pa.GetTypecode();
        // function LogAssertionFormat(string, table)
        if(typecode == 0x45UL)
            _s_method_LogAssertionFormat_40F2FF80_45(pa);
        else
        // function LogAssertionFormat(userdata, string, table)
        if(typecode == 0x245UL)
            _s_method_LogAssertionFormat_7B9AE240_245(pa);
        else
        {
#if UNITY_EDITOR
            throw new NotImplementedException(string.Format("typecode=0x{0:X}", typecode));
#endif
        }
    }
    /// <summary>
    /// function Constructor()
    /// ex. UnityEngine.Debug.Constructor()
    /// ex. UnityEngine.Debug()
    /// </summary>
    private static void Constructor_8298F140_0(Lua.Param pa)
    {
        var inst=new UnityEngine.Debug();
        pa.Return(inst, typeof(UnityEngine.Debug));
    }
    /// <summary>
    /// function Constructor()
    /// ex. UnityEngine.Debug.Constructor()
    /// ex. UnityEngine.Debug()
    /// </summary>
    private static void ConstructorRef_8298F140_5(Lua.Param pa)
    {
        var inst=new UnityEngine.Debug();
        pa.Return(inst, typeof(UnityEngine.Debug));
    }
    public static Lua.Metatable OpenLib(Lua.State state)
    {
        Lua.Metatable metatable = null;
        var constructor_ref = state.newref(ConstructorRef_8298F140_5);
        var rt = state.get_table_ref_with_path("UnityEngine.Debug");
        var _rt = state.newrefmetatable(new Dictionary<string, Lua.Ref>
        {
            {"__newindex", state.newref(param=>{})},
            {"__call", constructor_ref},
            {"GetUnityLogger", state.newref(_s_get_property_unityLogger)},
            {"GetDeveloperConsoleVisible", state.newref(_s_get_property_developerConsoleVisible)},
            {"SetDeveloperConsoleVisible", state.newref(_s_set_property_developerConsoleVisible)},
            {"GetIsDebugBuild", state.newref(_s_get_property_isDebugBuild)},
            {"DrawLine", state.newref(_s_method_DrawLine)},
            {"DrawRay", state.newref(_s_method_DrawRay)},
            {"Break", state.newref(_s_method_Break_D6963280_0)},
            {"DebugBreak", state.newref(_s_method_DebugBreak_113E1540_0)},
            {"Log", state.newref(_s_method_Log)},
            {"LogFormat", state.newref(_s_method_LogFormat)},
            {"LogError", state.newref(_s_method_LogError)},
            {"LogErrorFormat", state.newref(_s_method_LogErrorFormat)},
            {"ClearDeveloperConsole", state.newref(_s_method_ClearDeveloperConsole_E67D2B40_0)},
            {"LogException", state.newref(_s_method_LogException)},
            {"LogWarning", state.newref(_s_method_LogWarning)},
            {"LogWarningFormat", state.newref(_s_method_LogWarningFormat)},
            {"Assert", state.newref(_s_method_Assert)},
            {"AssertFormat", state.newref(_s_method_AssertFormat)},
            {"LogAssertion", state.newref(_s_method_LogAssertion)},
            {"LogAssertionFormat", state.newref(_s_method_LogAssertionFormat)},
            {"Constructor", state.newref(Constructor_8298F140_0)},
        });
        state.set_metatable(rt, _rt);
        return metatable;  
    }

}
}
