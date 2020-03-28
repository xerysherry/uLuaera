#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class ConfigWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Config);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 7, 14, 14);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "GetProjectPath", _m_GetProjectPath_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetSavePath", _m_GetSavePath_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetSavePath", _m_SetSavePath_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetCsvPath", _m_GetCsvPath_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetCsvPath", _m_SetCsvPath_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetResourcePath", _m_SetResourcePath_xlua_st_);
            
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "Flags", _g_get_Flags);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "FlagBit", _g_get_FlagBit);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "FontColor", _g_get_FontColor);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "FontGradientColor", _g_get_FontGradientColor);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "FontShadowColor", _g_get_FontShadowColor);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "FontOutlineColor", _g_get_FontOutlineColor);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "FontSize", _g_get_FontSize);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "ImageColor", _g_get_ImageColor);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "BackgroundColor", _g_get_BackgroundColor);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "ResourcePath", _g_get_ResourcePath);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "location", _g_get_location);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "FontName", _g_get_FontName);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "MaxLog", _g_get_MaxLog);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "LineHeight", _g_get_LineHeight);
            
			Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "Flags", _s_set_Flags);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "FlagBit", _s_set_FlagBit);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "FontColor", _s_set_FontColor);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "FontGradientColor", _s_set_FontGradientColor);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "FontShadowColor", _s_set_FontShadowColor);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "FontOutlineColor", _s_set_FontOutlineColor);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "FontSize", _s_set_FontSize);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "ImageColor", _s_set_ImageColor);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "BackgroundColor", _s_set_BackgroundColor);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "ResourcePath", _s_set_ResourcePath);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "location", _s_set_location);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "FontName", _s_set_FontName);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "MaxLog", _s_set_MaxLog);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "LineHeight", _s_set_LineHeight);
            
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "Config does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetProjectPath_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        string gen_ret = Config.GetProjectPath(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSavePath_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        string gen_ret = Config.GetSavePath(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetSavePath_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 1);
                    
                    Config.SetSavePath( _path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCsvPath_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        string gen_ret = Config.GetCsvPath(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetCsvPath_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 1);
                    
                    Config.SetCsvPath( _path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetResourcePath_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 1);
                    Config.Location _l;translator.Get(L, 2, out _l);
                    
                    Config.SetResourcePath( _path, _l );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Flags(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushuint(L, Config.Flags);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FlagBit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, Config.FlagBit);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FontColor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, Config.FontColor);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FontGradientColor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, Config.FontGradientColor);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FontShadowColor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, Config.FontShadowColor);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FontOutlineColor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, Config.FontOutlineColor);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FontSize(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, Config.FontSize);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ImageColor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, Config.ImageColor);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BackgroundColor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.PushUnityEngineColor(L, Config.BackgroundColor);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ResourcePath(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, Config.ResourcePath);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_location(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, Config.location);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FontName(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, Config.FontName);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MaxLog(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, Config.MaxLog);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LineHeight(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, Config.LineHeight);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Flags(RealStatePtr L)
        {
		    try {
                
			    Config.Flags = LuaAPI.xlua_touint(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FlagBit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			FlagBit gen_value;translator.Get(L, 1, out gen_value);
				Config.FlagBit = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FontColor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			UnityEngine.Color32 gen_value;translator.Get(L, 1, out gen_value);
				Config.FontColor = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FontGradientColor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			UnityEngine.Color32 gen_value;translator.Get(L, 1, out gen_value);
				Config.FontGradientColor = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FontShadowColor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			UnityEngine.Color32 gen_value;translator.Get(L, 1, out gen_value);
				Config.FontShadowColor = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FontOutlineColor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			UnityEngine.Color32 gen_value;translator.Get(L, 1, out gen_value);
				Config.FontOutlineColor = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FontSize(RealStatePtr L)
        {
		    try {
                
			    Config.FontSize = LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ImageColor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			UnityEngine.Color32 gen_value;translator.Get(L, 1, out gen_value);
				Config.ImageColor = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_BackgroundColor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			UnityEngine.Color gen_value;translator.Get(L, 1, out gen_value);
				Config.BackgroundColor = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ResourcePath(RealStatePtr L)
        {
		    try {
                
			    Config.ResourcePath = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_location(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Config.Location gen_value;translator.Get(L, 1, out gen_value);
				Config.location = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FontName(RealStatePtr L)
        {
		    try {
                
			    Config.FontName = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MaxLog(RealStatePtr L)
        {
		    try {
                
			    Config.MaxLog = LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LineHeight(RealStatePtr L)
        {
		    try {
                
			    Config.LineHeight = LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
