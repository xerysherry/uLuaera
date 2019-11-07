// THIS IS A GENERATED FILE. PLEASE DO NOT MODIFY IT!
using System;
using System.Collections;
using System.Collections.Generic;
using Lua;

namespace Lua
{
public static class Wrap_StringHelper 
{
    /// <summary>
    /// function CheckHalfSize(table)
    /// ex. StringHelper.CheckHalfSize(table1)
    /// </summary>
    private static void _s_method_CheckHalfSize_D861340_5(Lua.Param pa)
    {
        var a=pa.GetChar(1);
        var ra=StringHelper.CheckHalfSize(a);
        pa.Return(ra);
    }
    /// <summary>
    /// function GetWordCount(string)
    /// ex. StringHelper.GetWordCount(string1)
    /// </summary>
    private static void _s_method_GetWordCount_138E60_4(Lua.Param pa)
    {
        var a=pa.GetString(1);
        var ra=StringHelper.GetWordCount(a);
        pa.Return(ra);
    }
    /// <summary>
    /// function GetWordCount(string, boolean)
    /// ex. StringHelper.GetWordCount(string1, boolean2)
    /// </summary>
    private static void _s_method_GetWordCount_4DB0C8C0_41(Lua.Param pa)
    {
        var a=pa.GetString(1);
        var b=pa.GetBoolean(2);
        var ra=StringHelper.GetWordCount(a,b);
        pa.Return(ra);
    }
    /// <summary>
    /// function GetDisplayLength(string)
    /// ex. StringHelper.GetDisplayLength(string1)
    /// </summary>
    private static void _s_method_GetDisplayLength_72F83680_4(Lua.Param pa)
    {
        var a=pa.GetString(1);
        var ra=StringHelper.GetDisplayLength(a);
        pa.Return(ra);
    }
    /// <summary>
    /// function GetDisplayLength(string, number)
    /// ex. StringHelper.GetDisplayLength(string1, number2)
    /// </summary>
    private static void _s_method_GetDisplayLength_ADA01940_43(Lua.Param pa)
    {
        var a=pa.GetString(1);
        var b=pa.GetInteger(2);
        var ra=StringHelper.GetDisplayLength(a,b);
        pa.Return(ra);
    }
    /// <summary>
    /// function GetDisplayLength(string, boolean)
    /// ex. StringHelper.GetDisplayLength(string1, boolean2)
    /// </summary>
    private static void _s_method_GetDisplayLength_E847FC0_41(Lua.Param pa)
    {
        var a=pa.GetString(1);
        var b=pa.GetBoolean(2);
        var ra=StringHelper.GetDisplayLength(a,b);
        pa.Return(ra);
    }
    /// <summary>
    /// function GetDisplayLength(string, number, boolean)
    /// ex. StringHelper.GetDisplayLength(string1, number2, boolean3)
    /// </summary>
    private static void _s_method_GetDisplayLength_22EFDEC0_431(Lua.Param pa)
    {
        var a=pa.GetString(1);
        var b=pa.GetInteger(2);
        var c=pa.GetBoolean(3);
        var ra=StringHelper.GetDisplayLength(a,b,c);
        pa.Return(ra);
    }
    /// <summary>
    /// function GetStringBar(table, number, number)
    /// ex. StringHelper.GetStringBar(table1, number2, number3)
    /// </summary>
    private static void _s_method_GetStringBar_983FA440_533(Lua.Param pa)
    {
        var a=pa.GetChar(1);
        var b=pa.GetInteger(2);
        var c=pa.GetFloat(3);
        var ra=StringHelper.GetStringBar(a,b,c);
        pa.Return(ra);
    }
    /// <summary>
    /// function GetStringBar(string, number)
    /// ex. StringHelper.GetStringBar(string1, number2)
    /// </summary>
    private static void _s_method_GetStringBar_D2E7870_43(Lua.Param pa)
    {
        var a=pa.GetString(1);
        var b=pa.GetInteger(2);
        var ra=StringHelper.GetStringBar(a,b);
        pa.Return(ra);
    }
    /// <summary>
    /// function Space(number)
    /// ex. StringHelper.Space(number1)
    /// </summary>
    private static void _s_method_Space_D8F69C0_3(Lua.Param pa)
    {
        var a=pa.GetInteger(1);
        var ra=StringHelper.Space(a);
        pa.Return(ra);
    }
    /// <summary>
    /// function StrConv(string, number)
    /// ex. StringHelper.StrConv(string1, number2)
    /// </summary>
    private static void _s_method_StrConv_48374C80_43(Lua.Param pa)
    {
        var a=pa.GetString(1);
        var b=pa.GetInteger(2);
        var ra=StringHelper.StrConv(a,(StringHelper.StrConvMode)b);
        pa.Return(ra);
    }
    private static void _s_method_GetWordCount(Lua.Param pa)
    {
        var typecode = pa.GetTypecode();
        // function GetWordCount(string)
        if(typecode == 0x4UL)
            _s_method_GetWordCount_138E60_4(pa);
        else
        // function GetWordCount(string, boolean)
        if(typecode == 0x41UL)
            _s_method_GetWordCount_4DB0C8C0_41(pa);
        else
        {
#if UNITY_EDITOR
            throw new NotImplementedException(string.Format("typecode=0x{0:X}", typecode));
#endif
        }
    }
    private static void _s_method_GetDisplayLength(Lua.Param pa)
    {
        var typecode = pa.GetTypecode();
        // function GetDisplayLength(string)
        if(typecode == 0x4UL)
            _s_method_GetDisplayLength_72F83680_4(pa);
        else
        // function GetDisplayLength(string, number)
        if(typecode == 0x43UL)
            _s_method_GetDisplayLength_ADA01940_43(pa);
        else
        // function GetDisplayLength(string, boolean)
        if(typecode == 0x41UL)
            _s_method_GetDisplayLength_E847FC0_41(pa);
        else
        // function GetDisplayLength(string, number, boolean)
        if(typecode == 0x431UL)
            _s_method_GetDisplayLength_22EFDEC0_431(pa);
        else
        {
#if UNITY_EDITOR
            throw new NotImplementedException(string.Format("typecode=0x{0:X}", typecode));
#endif
        }
    }
    private static void _s_method_GetStringBar(Lua.Param pa)
    {
        var typecode = pa.GetTypecode();
        // function GetStringBar(table, number, number)
        if(typecode == 0x533UL)
            _s_method_GetStringBar_983FA440_533(pa);
        else
        // function GetStringBar(string, number)
        if(typecode == 0x43UL)
            _s_method_GetStringBar_D2E7870_43(pa);
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
        var _StrConvMode = state.newrefmetatable(new Dictionary<string, Lua.Ref>
        {
            {"__newindex", state.newref(param=>{})},
            {"None", state.newref((int)StringHelper.StrConvMode.None)},
            {"Uppercase", state.newref((int)StringHelper.StrConvMode.Uppercase)},
            {"Lowercase", state.newref((int)StringHelper.StrConvMode.Lowercase)},
            {"Wide", state.newref((int)StringHelper.StrConvMode.Wide)},
            {"Narrow", state.newref((int)StringHelper.StrConvMode.Narrow)},
        });
        var StrConvMode = state.newreftable();
        state.set_metatable(StrConvMode, _StrConvMode);
        var rt = state.get_table_ref_with_path("StringHelper");
        var _rt = state.newrefmetatable(new Dictionary<string, Lua.Ref>
        {
            {"__newindex", state.newref(param=>{})},
            {"StrConvMode", StrConvMode},
            {"CheckHalfSize", state.newref(_s_method_CheckHalfSize_D861340_5)},
            {"GetWordCount", state.newref(_s_method_GetWordCount)},
            {"GetDisplayLength", state.newref(_s_method_GetDisplayLength)},
            {"GetStringBar", state.newref(_s_method_GetStringBar)},
            {"Space", state.newref(_s_method_Space_D8F69C0_3)},
            {"StrConv", state.newref(_s_method_StrConv_48374C80_43)},
        });
        state.set_metatable(rt, _rt);
        return metatable;  
    }

}
}
