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
    public class StringHelperWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(StringHelper);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 7, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "CheckHalfSize", _m_CheckHalfSize_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetWordCount", _m_GetWordCount_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetDisplayLength", _m_GetDisplayLength_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetStringBar", _m_GetStringBar_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Space", _m_Space_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "StrConv", _m_StrConv_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "StringHelper does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckHalfSize_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    char _c = (char)LuaAPI.xlua_tointeger(L, 1);
                    
                        bool gen_ret = StringHelper.CheckHalfSize( _c );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetWordCount_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string _str = LuaAPI.lua_tostring(L, 1);
                    
                        int gen_ret = StringHelper.GetWordCount( _str );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    string _str = LuaAPI.lua_tostring(L, 1);
                    bool _richedit = LuaAPI.lua_toboolean(L, 2);
                    
                        int gen_ret = StringHelper.GetWordCount( _str, _richedit );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to StringHelper.GetWordCount!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetDisplayLength_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string _s = LuaAPI.lua_tostring(L, 1);
                    
                        int gen_ret = StringHelper.GetDisplayLength( _s );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    string _s = LuaAPI.lua_tostring(L, 1);
                    int _fontsize = LuaAPI.xlua_tointeger(L, 2);
                    
                        int gen_ret = StringHelper.GetDisplayLength( _s, _fontsize );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    string _s = LuaAPI.lua_tostring(L, 1);
                    bool _richtext = LuaAPI.lua_toboolean(L, 2);
                    
                        int gen_ret = StringHelper.GetDisplayLength( _s, _richtext );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    string _s = LuaAPI.lua_tostring(L, 1);
                    int _fontsize = LuaAPI.xlua_tointeger(L, 2);
                    bool _richtext = LuaAPI.lua_toboolean(L, 3);
                    
                        int gen_ret = StringHelper.GetDisplayLength( _s, _fontsize, _richtext );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to StringHelper.GetDisplayLength!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetStringBar_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    char _c = (char)LuaAPI.xlua_tointeger(L, 1);
                    int _fontsize = LuaAPI.xlua_tointeger(L, 2);
                    float _totalsize = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        string gen_ret = StringHelper.GetStringBar( _c, _fontsize, _totalsize );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    string _s = LuaAPI.lua_tostring(L, 1);
                    int _count = LuaAPI.xlua_tointeger(L, 2);
                    
                        string gen_ret = StringHelper.GetStringBar( _s, _count );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to StringHelper.GetStringBar!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Space_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    int _count = LuaAPI.xlua_tointeger(L, 1);
                    
                        string gen_ret = StringHelper.Space( _count );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StrConv_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _str = LuaAPI.lua_tostring(L, 1);
                    StringHelper.StrConvMode _Conversion;translator.Get(L, 2, out _Conversion);
                    
                        string gen_ret = StringHelper.StrConv( _str, _Conversion );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
