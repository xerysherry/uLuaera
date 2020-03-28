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
    public class PrinterWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Printer);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 114, 6, 6);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "SelectConsole", _m_SelectConsole_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetTargetFrame", _m_SetTargetFrame_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "TargetFrame", _m_TargetFrame_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetBackgroundColor", _m_SetBackgroundColor_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetBackgroundColor", _m_GetBackgroundColor_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetBackgroundImage", _m_SetBackgroundImage_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetOrientation", _m_SetOrientation_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PushFlags", _m_PushFlags_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PopFlags", _m_PopFlags_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DefaultFlags", _m_DefaultFlags_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetFlags", _m_GetFlags_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetFlags", _m_SetFlags_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PushColor", _m_PushColor_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PopColor", _m_PopColor_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DefaultColor", _m_DefaultColor_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PushGradientColor", _m_PushGradientColor_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PopGradientColor", _m_PopGradientColor_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DefaultGradientColor", _m_DefaultGradientColor_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PushShadowColor", _m_PushShadowColor_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PopShadowColor", _m_PopShadowColor_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DefaultShadowColor", _m_DefaultShadowColor_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PushOutlineColor", _m_PushOutlineColor_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PopOutlineColor", _m_PopOutlineColor_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DefaultOutlineColor", _m_DefaultOutlineColor_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PushImageColor", _m_PushImageColor_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PopImageColor", _m_PopImageColor_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DefaultImageColor", _m_DefaultImageColor_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PushAllConfig", _m_PushAllConfig_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PopAllConfig", _m_PopAllConfig_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DefaultAllConfig", _m_DefaultAllConfig_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetFontSize", _m_SetFontSize_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetFontSize", _m_GetFontSize_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetLineHeight", _m_SetLineHeight_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetLineHeight", _m_GetLineHeight_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetButtonStyle", _m_SetButtonStyle_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ClearButtonStyle", _m_ClearButtonStyle_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ShowFPS", _m_ShowFPS_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Quit", _m_Quit_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DataPath", _m_DataPath_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PersistentDataPath", _m_PersistentDataPath_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "IsMobilePlatform", _m_IsMobilePlatform_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Platform", _m_Platform_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "RunInBackground", _m_RunInBackground_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetRunInBackground", _m_SetRunInBackground_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "OpenURL", _m_OpenURL_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetResolution", _m_SetResolution_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetResolution", _m_GetResolution_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetDragEnable", _m_SetDragEnable_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetConsoleBorder", _m_SetConsoleBorder_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "NowStamp", _m_NowStamp_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DateToStamp", _m_DateToStamp_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Now", _m_Now_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Date", _m_Date_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "StampToDate", _m_StampToDate_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetLogFile", _m_SetLogFile_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetLogEnable", _m_SetLogEnable_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LogWrite", _m_LogWrite_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LogWriteLn", _m_LogWriteLn_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LogShiftLine", _m_LogShiftLine_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetAutoLine", _m_SetAutoLine_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetAutoLine", _m_GetAutoLine_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetStringLines", _m_GetStringLines_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PrintT", _m_PrintT_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PrintTLn", _m_PrintTLn_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PrintTF", _m_PrintTF_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PrintTFLn", _m_PrintTFLn_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PrintF", _m_PrintF_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PrintFLn", _m_PrintFLn_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Print", _m_Print_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PrintLn", _m_PrintLn_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetSpriteImage", _m_SetSpriteImage_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetSpriteAnimation", _m_SetSpriteAnimation_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetAnimationLoop", _m_SetAnimationLoop_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CheckSprite", _m_CheckSprite_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetErrorImage", _m_SetErrorImage_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Image", _m_Image_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ImageP", _m_ImageP_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ImageS", _m_ImageS_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ImagePS", _m_ImagePS_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetCode", _m_SetCode_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "RemoveLine", _m_RemoveLine_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Clear", _m_Clear_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "MovePosByPixel", _m_MovePosByPixel_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "MovePosByWord", _m_MovePosByWord_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ResetPosByPixel", _m_ResetPosByPixel_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ResetPosByWord", _m_ResetPosByWord_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetCurrentPos", _m_GetCurrentPos_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "NextTextPart", _m_NextTextPart_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "NextImagePart", _m_NextImagePart_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ShiftLine", _m_ShiftLine_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetMsg", _m_SetMsg_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetMsg", _m_GetMsg_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "EmptyMsg", _m_EmptyMsg_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ClearMsg", _m_ClearMsg_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetTextListCount", _m_GetTextListCount_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetTextListWeight", _m_GetTextListWeight_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetTextList", _m_SetTextList_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetTextWeightList", _m_SetTextWeightList_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetTextByIndex", _m_GetTextByIndex_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetTextByWeight", _m_GetTextByWeight_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "MessageBox", _m_MessageBox_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "MessageBoxIsShow", _m_MessageBoxIsShow_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "MessageBoxResult", _m_MessageBoxResult_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "InputBoxShow", _m_InputBoxShow_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "InputBoxIsShow", _m_InputBoxIsShow_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "InputBoxResult", _m_InputBoxResult_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "EnumScripts", _m_EnumScripts_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LoadCsv", _m_LoadCsv_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Save", _m_Save_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Load", _m_Load_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Exist", _m_Exist_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Delete", _m_Delete_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "EnumSaves", _m_EnumSaves_xlua_st_);
            
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "flags", _g_get_flags);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "color", _g_get_color);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "gradient_color", _g_get_gradient_color);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "shadow_color", _g_get_shadow_color);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "outline_color", _g_get_outline_color);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "image_color", _g_get_image_color);
            
			Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "flags", _s_set_flags);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "color", _s_set_color);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "gradient_color", _s_set_gradient_color);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "shadow_color", _s_set_shadow_color);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "outline_color", _s_set_outline_color);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "image_color", _s_set_image_color);
            
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "Printer does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SelectConsole_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    ConsoleContent _con = (ConsoleContent)translator.GetObject(L, 1, typeof(ConsoleContent));
                    
                    Printer.SelectConsole( _con );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetTargetFrame_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    int _frame = LuaAPI.xlua_tointeger(L, 1);
                    
                    Printer.SetTargetFrame( _frame );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TargetFrame_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        int gen_ret = Printer.TargetFrame(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetBackgroundColor_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Color _color;translator.Get(L, 1, out _color);
                    
                    Printer.SetBackgroundColor( _color );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBackgroundColor_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    
                        UnityEngine.Color gen_ret = Printer.GetBackgroundColor(  );
                        translator.PushUnityEngineColor(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetBackgroundImage_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _name = LuaAPI.lua_tostring(L, 1);
                    bool _tiled = LuaAPI.lua_toboolean(L, 2);
                    bool _aspect = LuaAPI.lua_toboolean(L, 3);
                    
                    Printer.SetBackgroundImage( _name, _tiled, _aspect );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetOrientation_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    Printer.ScreenOrientation _o;translator.Get(L, 1, out _o);
                    
                    Printer.SetOrientation( _o );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PushFlags_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    Printer.PushFlags(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PopFlags_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    Printer.PopFlags(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DefaultFlags_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    Printer.DefaultFlags(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFlags_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        uint gen_ret = Printer.GetFlags(  );
                        LuaAPI.xlua_pushuint(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetFlags_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    uint _f = LuaAPI.xlua_touint(L, 1);
                    
                    Printer.SetFlags( _f );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PushColor_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    Printer.PushColor(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PopColor_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    Printer.PopColor(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DefaultColor_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    Printer.DefaultColor(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PushGradientColor_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    Printer.PushGradientColor(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PopGradientColor_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    Printer.PopGradientColor(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DefaultGradientColor_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    Printer.DefaultGradientColor(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PushShadowColor_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    Printer.PushShadowColor(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PopShadowColor_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    Printer.PopShadowColor(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DefaultShadowColor_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    Printer.DefaultShadowColor(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PushOutlineColor_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    Printer.PushOutlineColor(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PopOutlineColor_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    Printer.PopOutlineColor(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DefaultOutlineColor_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    Printer.DefaultOutlineColor(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PushImageColor_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    Printer.PushImageColor(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PopImageColor_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    Printer.PopImageColor(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DefaultImageColor_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    Printer.DefaultImageColor(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PushAllConfig_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    Printer.PushAllConfig(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PopAllConfig_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    Printer.PopAllConfig(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DefaultAllConfig_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    Printer.DefaultAllConfig(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetFontSize_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    int _size = LuaAPI.xlua_tointeger(L, 1);
                    
                    Printer.SetFontSize( _size );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFontSize_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        int gen_ret = Printer.GetFontSize(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetLineHeight_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    int _height = LuaAPI.xlua_tointeger(L, 1);
                    
                    Printer.SetLineHeight( _height );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLineHeight_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        int gen_ret = Printer.GetLineHeight(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetButtonStyle_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Color _normal;translator.Get(L, 1, out _normal);
                    UnityEngine.Color _highlighted;translator.Get(L, 2, out _highlighted);
                    UnityEngine.Color _pressed;translator.Get(L, 3, out _pressed);
                    UnityEngine.Color _disabled;translator.Get(L, 4, out _disabled);
                    
                    Printer.SetButtonStyle( _normal, _highlighted, _pressed, _disabled );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClearButtonStyle_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    Printer.ClearButtonStyle(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowFPS_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    bool _value = LuaAPI.lua_toboolean(L, 1);
                    
                    Printer.ShowFPS( _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Quit_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    Printer.Quit(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DataPath_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        string gen_ret = Printer.DataPath(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PersistentDataPath_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        string gen_ret = Printer.PersistentDataPath(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsMobilePlatform_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        bool gen_ret = Printer.IsMobilePlatform(  );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Platform_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        string gen_ret = Printer.Platform(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RunInBackground_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        bool gen_ret = Printer.RunInBackground(  );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetRunInBackground_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    bool _value = LuaAPI.lua_toboolean(L, 1);
                    
                    Printer.SetRunInBackground( _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OpenURL_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _url = LuaAPI.lua_tostring(L, 1);
                    
                    Printer.OpenURL( _url );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetResolution_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    int _width = LuaAPI.xlua_tointeger(L, 1);
                    int _height = LuaAPI.xlua_tointeger(L, 2);
                    bool _fullscreen = LuaAPI.lua_toboolean(L, 3);
                    
                    Printer.SetResolution( _width, _height, _fullscreen );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetResolution_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    int _width;
                    int _height;
                    
                    Printer.GetResolution( out _width, out _height );
                    LuaAPI.xlua_pushinteger(L, _width);
                        
                    LuaAPI.xlua_pushinteger(L, _height);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetDragEnable_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    bool _value = LuaAPI.lua_toboolean(L, 1);
                    
                    Printer.SetDragEnable( _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetConsoleBorder_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    int _left = LuaAPI.xlua_tointeger(L, 1);
                    int _top = LuaAPI.xlua_tointeger(L, 2);
                    int _right = LuaAPI.xlua_tointeger(L, 3);
                    int _bottom = LuaAPI.xlua_tointeger(L, 4);
                    
                    Printer.SetConsoleBorder( _left, _top, _right, _bottom );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_NowStamp_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        int gen_ret = Printer.NowStamp(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DateToStamp_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    int _year = LuaAPI.xlua_tointeger(L, 1);
                    int _month = LuaAPI.xlua_tointeger(L, 2);
                    int _day = LuaAPI.xlua_tointeger(L, 3);
                    int _hour = LuaAPI.xlua_tointeger(L, 4);
                    int _min = LuaAPI.xlua_tointeger(L, 5);
                    int _sec = LuaAPI.xlua_tointeger(L, 6);
                    
                        int gen_ret = Printer.DateToStamp( _year, _month, _day, _hour, _min, _sec );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Now_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    
                        System.Collections.Generic.Dictionary<string, int> gen_ret = Printer.Now(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Date_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    int _year = LuaAPI.xlua_tointeger(L, 1);
                    int _month = LuaAPI.xlua_tointeger(L, 2);
                    int _day = LuaAPI.xlua_tointeger(L, 3);
                    int _hour = LuaAPI.xlua_tointeger(L, 4);
                    int _min = LuaAPI.xlua_tointeger(L, 5);
                    int _sec = LuaAPI.xlua_tointeger(L, 6);
                    
                        System.Collections.Generic.Dictionary<string, int> gen_ret = Printer.Date( _year, _month, _day, _hour, _min, _sec );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StampToDate_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    int _stamp = LuaAPI.xlua_tointeger(L, 1);
                    
                        System.Collections.Generic.Dictionary<string, int> gen_ret = Printer.StampToDate( _stamp );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetLogFile_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _name = LuaAPI.lua_tostring(L, 1);
                    bool _create = LuaAPI.lua_toboolean(L, 2);
                    
                    Printer.SetLogFile( _name, _create );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetLogEnable_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    bool _value = LuaAPI.lua_toboolean(L, 1);
                    
                    Printer.SetLogEnable( _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LogWrite_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _text = LuaAPI.lua_tostring(L, 1);
                    
                    Printer.LogWrite( _text );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LogWriteLn_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _text = LuaAPI.lua_tostring(L, 1);
                    
                    Printer.LogWriteLn( _text );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LogShiftLine_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    Printer.LogShiftLine(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAutoLine_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    int _words = LuaAPI.xlua_tointeger(L, 1);
                    
                    Printer.SetAutoLine( _words );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAutoLine_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        int gen_ret = Printer.GetAutoLine(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetStringLines_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    string _str = LuaAPI.lua_tostring(L, 1);
                    int _count = LuaAPI.xlua_tointeger(L, 2);
                    
                        System.Collections.Generic.List<string> gen_ret = Printer.GetStringLines( _str, _count );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    string _str = LuaAPI.lua_tostring(L, 1);
                    bool _richedit = LuaAPI.lua_toboolean(L, 2);
                    int _count = LuaAPI.xlua_tointeger(L, 3);
                    
                        System.Collections.Generic.List<string> gen_ret = Printer.GetStringLines( _str, _richedit, _count );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Printer.GetStringLines!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PrintT_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    int _t = LuaAPI.xlua_tointeger(L, 1);
                    Printer.Align _align;translator.Get(L, 2, out _align);
                    string _c = LuaAPI.lua_tostring(L, 3);
                    
                    Printer.PrintT( _t, _align, _c );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PrintTLn_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    int _t = LuaAPI.xlua_tointeger(L, 1);
                    Printer.Align _align;translator.Get(L, 2, out _align);
                    string _c = LuaAPI.lua_tostring(L, 3);
                    
                    Printer.PrintTLn( _t, _align, _c );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PrintTF_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    int _t = LuaAPI.xlua_tointeger(L, 1);
                    Printer.Align _align;translator.Get(L, 2, out _align);
                    string _format = LuaAPI.lua_tostring(L, 3);
                    object[] _args = translator.GetParams<object>(L, 4);
                    
                    Printer.PrintTF( _t, _align, _format, _args );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PrintTFLn_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    int _t = LuaAPI.xlua_tointeger(L, 1);
                    Printer.Align _align;translator.Get(L, 2, out _align);
                    string _format = LuaAPI.lua_tostring(L, 3);
                    object[] _args = translator.GetParams<object>(L, 4);
                    
                    Printer.PrintTFLn( _t, _align, _format, _args );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PrintF_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _format = LuaAPI.lua_tostring(L, 1);
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                    Printer.PrintF( _format, _args );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PrintFLn_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _format = LuaAPI.lua_tostring(L, 1);
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                    Printer.PrintFLn( _format, _args );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Print_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _c = LuaAPI.lua_tostring(L, 1);
                    
                    Printer.Print( _c );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PrintLn_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _c = LuaAPI.lua_tostring(L, 1);
                    
                    Printer.PrintLn( _c );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetSpriteImage_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _name = LuaAPI.lua_tostring(L, 1);
                    string _file = LuaAPI.lua_tostring(L, 2);
                    System.Collections.Generic.List<float> _rect = (System.Collections.Generic.List<float>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<float>));
                    System.Collections.Generic.List<float> _border = (System.Collections.Generic.List<float>)translator.GetObject(L, 4, typeof(System.Collections.Generic.List<float>));
                    bool _hidden = LuaAPI.lua_toboolean(L, 5);
                    
                    Printer.SetSpriteImage( _name, _file, _rect, _border, _hidden );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetSpriteAnimation_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _name = LuaAPI.lua_tostring(L, 1);
                    float _fps = (float)LuaAPI.lua_tonumber(L, 2);
                    System.Collections.Generic.List<System.Collections.Generic.List<object>> _sprites = (System.Collections.Generic.List<System.Collections.Generic.List<object>>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<System.Collections.Generic.List<object>>));
                    
                    Printer.SetSpriteAnimation( _name, _fps, _sprites );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAnimationLoop_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    int _count = LuaAPI.xlua_tointeger(L, 1);
                    
                    Printer.SetAnimationLoop( _count );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckSprite_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _name = LuaAPI.lua_tostring(L, 1);
                    
                        bool gen_ret = Printer.CheckSprite( _name );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetErrorImage_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _name = LuaAPI.lua_tostring(L, 1);
                    UnityEngine.Color _color;translator.Get(L, 2, out _color);
                    
                    Printer.SetErrorImage( _name, _color );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Image_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _name = LuaAPI.lua_tostring(L, 1);
                    float _x = (float)LuaAPI.lua_tonumber(L, 2);
                    float _y = (float)LuaAPI.lua_tonumber(L, 3);
                    float _w = (float)LuaAPI.lua_tonumber(L, 4);
                    float _h = (float)LuaAPI.lua_tonumber(L, 5);
                    bool _tiled = LuaAPI.lua_toboolean(L, 6);
                    
                    Printer.Image( _name, _x, _y, _w, _h, _tiled );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ImageP_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _name = LuaAPI.lua_tostring(L, 1);
                    int _x = LuaAPI.xlua_tointeger(L, 2);
                    int _y = LuaAPI.xlua_tointeger(L, 3);
                    bool _tiled = LuaAPI.lua_toboolean(L, 4);
                    
                    Printer.ImageP( _name, _x, _y, _tiled );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ImageS_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _name = LuaAPI.lua_tostring(L, 1);
                    int _w = LuaAPI.xlua_tointeger(L, 2);
                    int _h = LuaAPI.xlua_tointeger(L, 3);
                    bool _tiled = LuaAPI.lua_toboolean(L, 4);
                    
                    Printer.ImageS( _name, _w, _h, _tiled );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ImagePS_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _name = LuaAPI.lua_tostring(L, 1);
                    int _x = LuaAPI.xlua_tointeger(L, 2);
                    int _y = LuaAPI.xlua_tointeger(L, 3);
                    int _w = LuaAPI.xlua_tointeger(L, 4);
                    int _h = LuaAPI.xlua_tointeger(L, 5);
                    bool _tiled = LuaAPI.lua_toboolean(L, 6);
                    
                    Printer.ImagePS( _name, _x, _y, _w, _h, _tiled );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetCode_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _c = LuaAPI.lua_tostring(L, 1);
                    
                    Printer.SetCode( _c );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveLine_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    int _count = LuaAPI.xlua_tointeger(L, 1);
                    
                    Printer.RemoveLine( _count );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clear_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    Printer.Clear(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MovePosByPixel_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    int _x = LuaAPI.xlua_tointeger(L, 1);
                    
                    Printer.MovePosByPixel( _x );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MovePosByWord_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    int _w = LuaAPI.xlua_tointeger(L, 1);
                    
                    Printer.MovePosByWord( _w );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ResetPosByPixel_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    int _x = LuaAPI.xlua_tointeger(L, 1);
                    
                    Printer.ResetPosByPixel( _x );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ResetPosByWord_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    int _w = LuaAPI.xlua_tointeger(L, 1);
                    
                    Printer.ResetPosByWord( _w );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCurrentPos_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        int gen_ret = Printer.GetCurrentPos(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_NextTextPart_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 1)) 
                {
                    bool _isbutton = LuaAPI.lua_toboolean(L, 1);
                    
                    Printer.NextTextPart( _isbutton );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 0) 
                {
                    
                    Printer.NextTextPart(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Printer.NextTextPart!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_NextImagePart_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 1)) 
                {
                    bool _isbutton = LuaAPI.lua_toboolean(L, 1);
                    
                    Printer.NextImagePart( _isbutton );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 0) 
                {
                    
                    Printer.NextImagePart(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Printer.NextImagePart!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShiftLine_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    int _n = LuaAPI.xlua_tointeger(L, 1);
                    bool _roll_to_bottom = LuaAPI.lua_toboolean(L, 2);
                    
                    Printer.ShiftLine( _n, _roll_to_bottom );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    int _n = LuaAPI.xlua_tointeger(L, 1);
                    
                    Printer.ShiftLine( _n );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 0) 
                {
                    
                    Printer.ShiftLine(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Printer.ShiftLine!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetMsg_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _s = LuaAPI.lua_tostring(L, 1);
                    
                    Printer.SetMsg( _s );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMsg_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        string gen_ret = Printer.GetMsg(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EmptyMsg_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    bool _null_or_empty = LuaAPI.lua_toboolean(L, 1);
                    
                        bool gen_ret = Printer.EmptyMsg( _null_or_empty );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClearMsg_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    Printer.ClearMsg(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTextListCount_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _name = LuaAPI.lua_tostring(L, 1);
                    
                        int gen_ret = Printer.GetTextListCount( _name );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTextListWeight_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _name = LuaAPI.lua_tostring(L, 1);
                    
                        int gen_ret = Printer.GetTextListWeight( _name );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetTextList_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _name = LuaAPI.lua_tostring(L, 1);
                    System.Collections.Generic.List<string> _list = (System.Collections.Generic.List<string>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<string>));
                    
                    Printer.SetTextList( _name, _list );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetTextWeightList_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _name = LuaAPI.lua_tostring(L, 1);
                    System.Collections.Generic.List<System.Collections.Generic.Dictionary<int, object>> _list = (System.Collections.Generic.List<System.Collections.Generic.Dictionary<int, object>>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<System.Collections.Generic.Dictionary<int, object>>));
                    
                    Printer.SetTextWeightList( _name, _list );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTextByIndex_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _listname = LuaAPI.lua_tostring(L, 1);
                    int _index = LuaAPI.xlua_tointeger(L, 2);
                    
                        string gen_ret = Printer.GetTextByIndex( _listname, _index );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTextByWeight_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _listname = LuaAPI.lua_tostring(L, 1);
                    int _weight = LuaAPI.xlua_tointeger(L, 2);
                    int _index;
                    
                        string gen_ret = Printer.GetTextByWeight( _listname, _weight, out _index );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    LuaAPI.xlua_pushinteger(L, _index);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MessageBox_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _content = LuaAPI.lua_tostring(L, 1);
                    Printer.MsgType _type;translator.Get(L, 2, out _type);
                    string _left_button_text = LuaAPI.lua_tostring(L, 3);
                    string _right_button_text = LuaAPI.lua_tostring(L, 4);
                    UnityEngine.Color _border_color;translator.Get(L, 5, out _border_color);
                    UnityEngine.Color _content_color;translator.Get(L, 6, out _content_color);
                    UnityEngine.Color _left_color;translator.Get(L, 7, out _left_color);
                    UnityEngine.Color _left_text_color;translator.Get(L, 8, out _left_text_color);
                    UnityEngine.Color _right_color;translator.Get(L, 9, out _right_color);
                    UnityEngine.Color _right_text_color;translator.Get(L, 10, out _right_text_color);
                    System.Collections.Generic.List<float> _size = (System.Collections.Generic.List<float>)translator.GetObject(L, 11, typeof(System.Collections.Generic.List<float>));
                    
                    Printer.MessageBox( _content, _type, _left_button_text, _right_button_text, _border_color, _content_color, _left_color, _left_text_color, _right_color, _right_text_color, _size );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MessageBoxIsShow_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        bool gen_ret = Printer.MessageBoxIsShow(  );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MessageBoxResult_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    
                        Printer.MsgResult gen_ret = Printer.MessageBoxResult(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InputBoxShow_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _content = LuaAPI.lua_tostring(L, 1);
                    Printer.InputType _type;translator.Get(L, 2, out _type);
                    string _default_value = LuaAPI.lua_tostring(L, 3);
                    string _placeholder = LuaAPI.lua_tostring(L, 4);
                    string _right_button_text = LuaAPI.lua_tostring(L, 5);
                    UnityEngine.Color _border_color;translator.Get(L, 6, out _border_color);
                    UnityEngine.Color _content_color;translator.Get(L, 7, out _content_color);
                    UnityEngine.Color _text_color;translator.Get(L, 8, out _text_color);
                    UnityEngine.Color _placeholder_color;translator.Get(L, 9, out _placeholder_color);
                    UnityEngine.Color _right_color;translator.Get(L, 10, out _right_color);
                    UnityEngine.Color _right_text_color;translator.Get(L, 11, out _right_text_color);
                    UnityEngine.Color _input_color;translator.Get(L, 12, out _input_color);
                    
                    Printer.InputBoxShow( _content, _type, _default_value, _placeholder, _right_button_text, _border_color, _content_color, _text_color, _placeholder_color, _right_color, _right_text_color, _input_color );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InputBoxIsShow_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        bool gen_ret = Printer.InputBoxIsShow(  );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InputBoxResult_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        string gen_ret = Printer.InputBoxResult(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EnumScripts_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 1);
                    
                        System.Collections.Generic.List<string> gen_ret = Printer.EnumScripts( _path );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadCsv_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _name = LuaAPI.lua_tostring(L, 1);
                    
                        string gen_ret = Printer.LoadCsv( _name );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Save_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _name = LuaAPI.lua_tostring(L, 1);
                    string _content = LuaAPI.lua_tostring(L, 2);
                    string _password = LuaAPI.lua_tostring(L, 3);
                    
                    Printer.Save( _name, _content, _password );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Load_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _name = LuaAPI.lua_tostring(L, 1);
                    string _password = LuaAPI.lua_tostring(L, 2);
                    
                        string gen_ret = Printer.Load( _name, _password );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Exist_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _name = LuaAPI.lua_tostring(L, 1);
                    
                        bool gen_ret = Printer.Exist( _name );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Delete_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _name = LuaAPI.lua_tostring(L, 1);
                    
                    Printer.Delete( _name );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EnumSaves_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    
                        System.Collections.Generic.List<string> gen_ret = Printer.EnumSaves(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_flags(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, Printer.flags);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_color(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.PushUnityEngineColor(L, Printer.color);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_gradient_color(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.PushUnityEngineColor(L, Printer.gradient_color);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_shadow_color(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.PushUnityEngineColor(L, Printer.shadow_color);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_outline_color(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.PushUnityEngineColor(L, Printer.outline_color);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_image_color(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.PushUnityEngineColor(L, Printer.image_color);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_flags(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			FlagBit gen_value;translator.Get(L, 1, out gen_value);
				Printer.flags = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_color(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			UnityEngine.Color gen_value;translator.Get(L, 1, out gen_value);
				Printer.color = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_gradient_color(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			UnityEngine.Color gen_value;translator.Get(L, 1, out gen_value);
				Printer.gradient_color = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_shadow_color(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			UnityEngine.Color gen_value;translator.Get(L, 1, out gen_value);
				Printer.shadow_color = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_outline_color(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			UnityEngine.Color gen_value;translator.Get(L, 1, out gen_value);
				Printer.outline_color = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_image_color(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			UnityEngine.Color gen_value;translator.Get(L, 1, out gen_value);
				Printer.image_color = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
