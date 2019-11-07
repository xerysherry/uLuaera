using System;
using System.Collections;
using System.Collections.Generic;

namespace Lua
{
    public static class Singleton
    {
        public static readonly string kStartLuaScript = "(-_-b)";

        /// <summary>
        /// 状态机
        /// </summary>
        public static State state 
        { 
            get 
            {
                if(state_ == null)
                {
                    state_ = new State();
                    Wrap.OpenLib(state_);

                    var script = Lua.Resource.Load(kStartLuaScript);
                    if(!string.IsNullOrEmpty(script))
                    {
                        if(state_.dostring(script, kStartLuaScript) != Error.LUA_OK)
                        {
                            UnityEngine.Debug.Log(state_.last_error_string);
                            state_.state.Pop(-1);
                        }
                        else
                            //不关心返回值
                            state_.state.Pop(-1);
                    }
                }
                return state_;
            } 
        }
        /// <summary>
        /// 新线程
        /// </summary>
        /// <returns></returns>
        public static State newthread()
        {
            return state.newthread();
        }

        /// <summary>
        /// 注册函数
        /// </summary>
        /// <param name="name"></param>
        /// <param name="func"></param>
        public static void register(string name, Action<Param> func)
        {
            state_.register(name, func);
        }
        /// <summary>
        /// 请求
        /// </summary>
        /// <param name="module"></param>
        public static void require(Module module)
        {
            state_.require(module);
        }

        // UniLua没有完善的metatable机制，以下代码调用会导致__index索引异常
        ///// <summary>
        ///// 注册元表
        ///// </summary>
        ///// <param name="type"></param>
        ///// <param name="tables"></param>
        ///// <param name="parent"></param>
        //public static void register(System.Type type,
        //                            Dictionary<string, Ref> tables,
        //                            System.Type parent = null)
        //{
        //    state_.register(type, tables, parent);
        //}
        ///// <summary>
        ///// 注册元表
        ///// </summary>
        ///// <param name="name"></param>
        ///// <param name="tables"></param>
        ///// <param name="parent"></param>
        //public static void register(string name,
        //                            Dictionary<string, Ref> tables,
        //                            string parent = null)
        //{
        //    state_.register(name, tables, parent);
        //}

        /// <summary>
        /// 状态
        /// </summary>
        static State state_;
    }
}
