// THIS IS A GENERATED FILE. PLEASE DO NOT MODIFY IT!
using System;
using System.Collections;
using System.Collections.Generic;
using Lua;

namespace Lua
{
public static class Wrap_LuaUtils 
{
    /// <summary>
    /// function ToLuaObj(autotype)
    /// ex. LuaUtils.ToLuaObj(autotype1)
    /// </summary>
    private static void _s_method_ToLuaObj_CD5FBE0_F(Lua.Param pa)
    {
        var a=pa.GetOneobject(1);
        var ra=LuaUtils.ToLuaObj(a);
        if(ra == null)
            pa.Return();
        else
            pa.Return(ra, ra.GetType());
    }
    /// <summary>
    /// function ToLuaObj(autotype, string)
    /// ex. LuaUtils.ToLuaObj(autotype1, string2)
    /// </summary>
    private static void _s_method_ToLuaObj_87A0C0_F4(Lua.Param pa)
    {
        var a=pa.GetOneobject(1);
        var b=pa.GetString(2);
        var ra=LuaUtils.ToLuaObj(a,b);
        if(ra == null)
            pa.Return();
        else
            pa.Return(ra, ra.GetType());
    }
    /// <summary>
    /// function ToObj(autotype, string)
    /// ex. LuaUtils.ToObj(autotype1, string2)
    /// </summary>
    private static void _s_method_ToObj_42AF8380_F4(Lua.Param pa)
    {
        var a=pa.GetOneobject(1);
        var b=pa.GetString(2);
        var ra=LuaUtils.ToObj(a,b);
        if(ra == null)
            pa.Return();
        else
            pa.Return(ra, ra.GetType());
    }
    /// <summary>
    /// function ToString(autotype)
    /// ex. LuaUtils.ToString(autotype1)
    /// </summary>
    private static void _s_method_ToString_7D576640_F(Lua.Param pa)
    {
        var a=pa.GetOneobject(1);
        var ra=LuaUtils.ToString(a);
        pa.Return(ra);
    }
    /// <summary>
    /// function ToType(autotype)
    /// ex. LuaUtils.ToType(autotype1)
    /// </summary>
    private static void _s_method_ToType_B7FF490_F(Lua.Param pa)
    {
        var a=pa.GetOneobject(1);
        var ra=LuaUtils.ToType(a);
        pa.Return(ra);
    }
    /// <summary>
    /// function GetType(string)
    /// ex. LuaUtils.GetType(string1)
    /// </summary>
    private static void _s_method_GetType_F2A72BC0_4(Lua.Param pa)
    {
        var a=pa.GetString(1);
        var ra=LuaUtils.GetType(a);
        pa.Return(ra, typeof(System.Type));
    }
    /// <summary>
    /// function SetValue(autotype, string, autotype)
    /// ex. LuaUtils.SetValue(autotype1, string2, autotype3)
    /// </summary>
    private static void _s_method_SetValue_2D4FE80_F4F(Lua.Param pa)
    {
        var a=pa.GetOneobject(1);
        var b=pa.GetString(2);
        var c=pa.GetOneobject(3);
        LuaUtils.SetValue(a,b,c);
    }
    /// <summary>
    /// function GetValue(autotype, string)
    /// ex. LuaUtils.GetValue(autotype1, string2)
    /// </summary>
    private static void _s_method_GetValue_67F6F140_F4(Lua.Param pa)
    {
        var a=pa.GetOneobject(1);
        var b=pa.GetString(2);
        var ra=LuaUtils.GetValue(a,b);
        if(ra == null)
            pa.Return();
        else
            pa.Return(ra, ra.GetType());
    }
    private static void _s_method_ToLuaObj(Lua.Param pa)
    {
        var typecode = pa.GetTypecode();
        // function ToLuaObj(autotype)
        if(Lua.Param.Equal(typecode, 0xFUL))
            _s_method_ToLuaObj_CD5FBE0_F(pa);
        else
        // function ToLuaObj(autotype, string)
        if(Lua.Param.Equal(typecode, 0xF4UL))
            _s_method_ToLuaObj_87A0C0_F4(pa);
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
        var rt = state.get_table_ref_with_path("LuaUtils");
        var _rt = state.newrefmetatable(new Dictionary<string, Lua.Ref>
        {
            {"__newindex", state.newref(param=>{})},
            {"ToLuaObj", state.newref(_s_method_ToLuaObj)},
            {"ToObj", state.newref(_s_method_ToObj_42AF8380_F4)},
            {"ToString", state.newref(_s_method_ToString_7D576640_F)},
            {"ToType", state.newref(_s_method_ToType_B7FF490_F)},
            {"GetType", state.newref(_s_method_GetType_F2A72BC0_4)},
            {"SetValue", state.newref(_s_method_SetValue_2D4FE80_F4F)},
            {"GetValue", state.newref(_s_method_GetValue_67F6F140_F4)},
        });
        state.set_metatable(rt, _rt);
        return metatable;  
    }

}
}
