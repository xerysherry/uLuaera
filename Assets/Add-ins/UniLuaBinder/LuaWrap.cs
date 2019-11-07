using System;
using System.Collections;
using System.Collections.Generic;

namespace Lua
{
    public static partial class Wrap
    {
        public static void OpenLib(Lua.State state)
        {
            var type = typeof(Wrap);
            var method = type.GetMethod("InitMetatable",
                System.Reflection.BindingFlags.Public |
                System.Reflection.BindingFlags.Static);
            if(method == null)
                return;
            method.Invoke(null, new object[] { state });
        }
    }
}