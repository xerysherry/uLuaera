// THIS IS A GENERATED FILE. PLEASE DO NOT MODIFY IT!
using System;
using System.Collections;
using System.Collections.Generic;
using Lua;

namespace Lua
{
public static class Wrap_UnityEngine_Time 
{
    private static void _s_get_property_time(Lua.Param pa)
    {
        pa.Return(UnityEngine.Time.time);
    }
    private static void _s_get_property_timeSinceLevelLoad(Lua.Param pa)
    {
        pa.Return(UnityEngine.Time.timeSinceLevelLoad);
    }
    private static void _s_get_property_deltaTime(Lua.Param pa)
    {
        pa.Return(UnityEngine.Time.deltaTime);
    }
    private static void _s_get_property_fixedTime(Lua.Param pa)
    {
        pa.Return(UnityEngine.Time.fixedTime);
    }
    private static void _s_get_property_unscaledTime(Lua.Param pa)
    {
        pa.Return(UnityEngine.Time.unscaledTime);
    }
    private static void _s_get_property_fixedUnscaledTime(Lua.Param pa)
    {
        pa.Return(UnityEngine.Time.fixedUnscaledTime);
    }
    private static void _s_get_property_unscaledDeltaTime(Lua.Param pa)
    {
        pa.Return(UnityEngine.Time.unscaledDeltaTime);
    }
    private static void _s_get_property_fixedUnscaledDeltaTime(Lua.Param pa)
    {
        pa.Return(UnityEngine.Time.fixedUnscaledDeltaTime);
    }
    private static void _s_get_property_fixedDeltaTime(Lua.Param pa)
    {
        pa.Return(UnityEngine.Time.fixedDeltaTime);
    }
    private static void _s_set_property_fixedDeltaTime(Lua.Param pa)
    {
        var a=pa.GetFloat(1);
        UnityEngine.Time.fixedDeltaTime = a;
    }
    private static void _s_get_property_maximumDeltaTime(Lua.Param pa)
    {
        pa.Return(UnityEngine.Time.maximumDeltaTime);
    }
    private static void _s_set_property_maximumDeltaTime(Lua.Param pa)
    {
        var a=pa.GetFloat(1);
        UnityEngine.Time.maximumDeltaTime = a;
    }
    private static void _s_get_property_smoothDeltaTime(Lua.Param pa)
    {
        pa.Return(UnityEngine.Time.smoothDeltaTime);
    }
    private static void _s_get_property_maximumParticleDeltaTime(Lua.Param pa)
    {
        pa.Return(UnityEngine.Time.maximumParticleDeltaTime);
    }
    private static void _s_set_property_maximumParticleDeltaTime(Lua.Param pa)
    {
        var a=pa.GetFloat(1);
        UnityEngine.Time.maximumParticleDeltaTime = a;
    }
    private static void _s_get_property_timeScale(Lua.Param pa)
    {
        pa.Return(UnityEngine.Time.timeScale);
    }
    private static void _s_set_property_timeScale(Lua.Param pa)
    {
        var a=pa.GetFloat(1);
        UnityEngine.Time.timeScale = a;
    }
    private static void _s_get_property_frameCount(Lua.Param pa)
    {
        pa.Return(UnityEngine.Time.frameCount);
    }
    private static void _s_get_property_renderedFrameCount(Lua.Param pa)
    {
        pa.Return(UnityEngine.Time.renderedFrameCount);
    }
    private static void _s_get_property_realtimeSinceStartup(Lua.Param pa)
    {
        pa.Return(UnityEngine.Time.realtimeSinceStartup);
    }
    private static void _s_get_property_captureFramerate(Lua.Param pa)
    {
        pa.Return(UnityEngine.Time.captureFramerate);
    }
    private static void _s_set_property_captureFramerate(Lua.Param pa)
    {
        var a=pa.GetInteger(1);
        UnityEngine.Time.captureFramerate = a;
    }
    private static void _s_get_property_inFixedTimeStep(Lua.Param pa)
    {
        pa.Return(UnityEngine.Time.inFixedTimeStep);
    }
    /// <summary>
    /// function Constructor()
    /// ex. UnityEngine.Time.Constructor()
    /// ex. UnityEngine.Time()
    /// </summary>
    private static void Constructor_D3F9F880_0(Lua.Param pa)
    {
        var inst=new UnityEngine.Time();
        pa.Return(inst, typeof(UnityEngine.Time));
    }
    /// <summary>
    /// function Constructor()
    /// ex. UnityEngine.Time.Constructor()
    /// ex. UnityEngine.Time()
    /// </summary>
    private static void ConstructorRef_D3F9F880_5(Lua.Param pa)
    {
        var inst=new UnityEngine.Time();
        pa.Return(inst, typeof(UnityEngine.Time));
    }
    public static Lua.Metatable OpenLib(Lua.State state)
    {
        Lua.Metatable metatable = null;
        var constructor_ref = state.newref(ConstructorRef_D3F9F880_5);
        var rt = state.get_table_ref_with_path("UnityEngine.Time");
        var _rt = state.newrefmetatable(new Dictionary<string, Lua.Ref>
        {
            {"__newindex", state.newref(param=>{})},
            {"__call", constructor_ref},
            {"GetTime", state.newref(_s_get_property_time)},
            {"GetTimeSinceLevelLoad", state.newref(_s_get_property_timeSinceLevelLoad)},
            {"GetDeltaTime", state.newref(_s_get_property_deltaTime)},
            {"GetFixedTime", state.newref(_s_get_property_fixedTime)},
            {"GetUnscaledTime", state.newref(_s_get_property_unscaledTime)},
            {"GetFixedUnscaledTime", state.newref(_s_get_property_fixedUnscaledTime)},
            {"GetUnscaledDeltaTime", state.newref(_s_get_property_unscaledDeltaTime)},
            {"GetFixedUnscaledDeltaTime", state.newref(_s_get_property_fixedUnscaledDeltaTime)},
            {"GetFixedDeltaTime", state.newref(_s_get_property_fixedDeltaTime)},
            {"SetFixedDeltaTime", state.newref(_s_set_property_fixedDeltaTime)},
            {"GetMaximumDeltaTime", state.newref(_s_get_property_maximumDeltaTime)},
            {"SetMaximumDeltaTime", state.newref(_s_set_property_maximumDeltaTime)},
            {"GetSmoothDeltaTime", state.newref(_s_get_property_smoothDeltaTime)},
            {"GetMaximumParticleDeltaTime", state.newref(_s_get_property_maximumParticleDeltaTime)},
            {"SetMaximumParticleDeltaTime", state.newref(_s_set_property_maximumParticleDeltaTime)},
            {"GetTimeScale", state.newref(_s_get_property_timeScale)},
            {"SetTimeScale", state.newref(_s_set_property_timeScale)},
            {"GetFrameCount", state.newref(_s_get_property_frameCount)},
            {"GetRenderedFrameCount", state.newref(_s_get_property_renderedFrameCount)},
            {"GetRealtimeSinceStartup", state.newref(_s_get_property_realtimeSinceStartup)},
            {"GetCaptureFramerate", state.newref(_s_get_property_captureFramerate)},
            {"SetCaptureFramerate", state.newref(_s_set_property_captureFramerate)},
            {"GetInFixedTimeStep", state.newref(_s_get_property_inFixedTimeStep)},
            {"Constructor", state.newref(Constructor_D3F9F880_0)},
        });
        state.set_metatable(rt, _rt);
        return metatable;  
    }

}
}
