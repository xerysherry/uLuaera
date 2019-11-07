// THIS IS A GENERATED FILE. PLEASE DO NOT MODIFY IT!
using System;
using System.Collections;
using System.Collections.Generic;
using Lua;

namespace Lua
{
public static class Wrap_System_Object 
{
    /// <summary>
    /// function Equals(autotype, autotype)
    /// ex. System.Object.Equals(autotype1, autotype2)
    /// </summary>
    private static void _s_method_Equals_D4F5D740_FF(Lua.Param pa)
    {
        var a=pa.GetOneobject(1);
        var b=pa.GetOneobject(2);
        var ra=System.Object.Equals(a,b);
        pa.Return(ra);
    }
    /// <summary>
    /// function ReferenceEquals(autotype, autotype)
    /// ex. System.Object.ReferenceEquals(autotype1, autotype2)
    /// </summary>
    private static void _s_method_ReferenceEquals_F9DBA0_FF(Lua.Param pa)
    {
        var a=pa.GetOneobject(1);
        var b=pa.GetOneobject(2);
        var ra=System.Object.ReferenceEquals(a,b);
        pa.Return(ra);
    }
    /// <summary>
    /// function Constructor()
    /// ex. System.Object.Constructor()
    /// ex. System.Object()
    /// </summary>
    private static void Constructor_F8DB800_0(Lua.Param pa)
    {
        var inst=new System.Object();
        if(inst == null)
            pa.Return();
        else
            pa.Return(inst, inst.GetType());
    }
    /// <summary>
    /// function Constructor()
    /// ex. System.Object.Constructor()
    /// ex. System.Object()
    /// </summary>
    private static void ConstructorRef_F8DB800_5(Lua.Param pa)
    {
        var inst=new System.Object();
        if(inst == null)
            pa.Return();
        else
            pa.Return(inst, inst.GetType());
    }
    /// <summary>
    /// function Equals(self, autotype)
    /// ex. self:Equals(autotype1)
    /// </summary>
    private static void _inst_method_Equals_EFB400_2F(Lua.Param pa)
    {
        var a=pa.GetOneobject(1);
        var b=pa.GetOneobject(2);
        var ra=a.Equals(b);
        pa.Return(ra);
    }
    /// <summary>
    /// function GetHashCode(self)
    /// ex. self:GetHashCode()
    /// </summary>
    private static void _inst_method_GetHashCode_5A96490_0(Lua.Param pa)
    {
        var a=pa.GetOneobject(1);
        var ra=a.GetHashCode();
        pa.Return(ra);
    }
    /// <summary>
    /// function GetType(self)
    /// ex. self:GetType()
    /// </summary>
    private static void _inst_method_GetType_54B31940_0(Lua.Param pa)
    {
        var a=pa.GetOneobject(1);
        var ra=a.GetType();
        pa.Return(ra, typeof(System.Type));
    }
    /// <summary>
    /// function ToString(self)
    /// ex. self:ToString()
    /// </summary>
    private static void _inst_method_ToString_1AFA660_0(Lua.Param pa)
    {
        var a=pa.GetOneobject(1);
        var ra=a.ToString();
        pa.Return(ra);
    }
    public static Lua.Metatable OpenLib(Lua.State state)
    {
        Lua.Metatable metatable = null;
        var constructor_ref = state.newref(ConstructorRef_F8DB800_5);
        var rt = state.get_table_ref_with_path("System.Object");
        var _rt = state.newrefmetatable(new Dictionary<string, Lua.Ref>
        {
            {"__newindex", state.newref(param=>{})},
            {"__call", constructor_ref},
            {"Equals", state.newref(_s_method_Equals_D4F5D740_FF)},
            {"ReferenceEquals", state.newref(_s_method_ReferenceEquals_F9DBA0_FF)},
            {"Constructor", state.newref(Constructor_F8DB800_0)},
        });
        state.set_metatable(rt, _rt);
        metatable = Lua.State.CreateMetatable(typeof(System.Object), 
            new Dictionary<string, Action<Lua.Param>>
        {
            {"Equals", _inst_method_Equals_EFB400_2F},
            {"GetHashCode", _inst_method_GetHashCode_5A96490_0},
            {"GetType", _inst_method_GetType_54B31940_0},
            {"ToString", _inst_method_ToString_1AFA660_0},
        });
        return metatable;  
    }

}
}
