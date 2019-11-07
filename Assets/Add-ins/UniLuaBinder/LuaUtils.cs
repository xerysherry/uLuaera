using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public static class LuaUtils
{
    public static object ToLuaObj(object obj)
    {
        if(obj == null)
            return null;

        var type = obj.GetType();
        if(type == typeof(char) ||
            type == typeof(byte) ||
            type == typeof(int) ||
            type == typeof(uint) ||
            type == typeof(short) ||
            type == typeof(ushort) ||
            type == typeof(long) ||
            type == typeof(ulong) ||
            type == typeof(string) ||
            type == typeof(float) ||
            type == typeof(bool) ||
            type == typeof(double))
            return obj;
        else if(type.BaseType == typeof(System.Enum))
            return (int)obj;
        else if(type.GetInterface("System.Collections.IList") != null)
        {
            var list = new List<object>();
            foreach(var k in (IList)obj)
                list.Add(k);
            return list;
        }
        else if(type.GetInterface("System.Collections.IDictionary") != null)
        {
            var dict = new Dictionary<object, object>();
            var odict = ((IDictionary)obj);
            foreach(var k in odict.Keys)
                dict[k] = odict[k];
            return dict;
        }
        else
        {
            var dict = new Dictionary<string, object>();
            var members = obj.GetType().GetMembers(System.Reflection.BindingFlags.Public |
                                                    System.Reflection.BindingFlags.Instance);
            foreach(var m in members)
            {
                switch(m.MemberType)
                {
                case System.Reflection.MemberTypes.Property:
                    {
                        var info = (System.Reflection.PropertyInfo)m;
                        if(info.CanRead && info.Name != "Item")
                            dict[info.Name] = info.GetValue(obj, null);
                    }
                    break;
                case System.Reflection.MemberTypes.Field:
                    {
                        var info = (System.Reflection.FieldInfo)m;
                        dict[info.Name] = info.GetValue(obj);
                    }
                    break;
                case System.Reflection.MemberTypes.Method:
                default:
                    break;
                }
            }
            return dict;

        }
        return null;
    }

    public static object ToLuaObj(object obj, string path)
    {
        var r = ToObj(obj, path);
        return ToLuaObj(r);
    }

    public static object ToObj(object obj, string path)
    {
        if(string.IsNullOrEmpty(path))
            return obj;
        if(obj == null)
            return null;

        var index = path.IndexOf('.');
        string curr = path;
        string next = null;
        if(index >= 0)
        {
            curr = path.Substring(0, index - 1);
            next = path.Substring(index + 1);
        }

        var type = obj.GetType();
        if(type == typeof(char) ||
            type == typeof(byte) ||
            type == typeof(int) ||
            type == typeof(uint) ||
            type == typeof(short) ||
            type == typeof(ushort) ||
            type == typeof(long) ||
            type == typeof(ulong) ||
            type == typeof(string) ||
            type == typeof(float) ||
            type == typeof(bool) ||
            type.BaseType == typeof(System.Enum) ||
            type == typeof(double))
            return null;
        else if(type.GetInterface("System.Collections.IList") != null)
        {
            var list = (IList)obj;
            int i = 0;
            try
            {
                i = int.Parse(curr);
            }
            catch(System.Exception e)
            {
                return null;
            }
            if(list.Count >= i)
                return null;
            return ToObj(list[i], next);
        }
        else if(type.GetInterface("System.Collections.IDictionary") != null)
        {
            var dict = (IDictionary)obj;
            var atype = obj.GetType().GetGenericArguments()[0];
            if(atype == typeof(int))
            {
                try
                {
                    int i = int.Parse(curr);
                    return ToLuaObj(dict[i], next);
                }
                catch(System.Exception e) { return null; }
            }
            else
            {
                return ToObj(dict[curr], next);
            }
            return null;
        }
        else
        {
            var dict = new Dictionary<string, object>();
            var members = obj.GetType().GetMembers(System.Reflection.BindingFlags.Public |
                                                    System.Reflection.BindingFlags.Instance);
            foreach(var m in members)
            {
                if(m.Name != curr)
                    continue;
                if(m.MemberType == System.Reflection.MemberTypes.Property)
                    return ToObj(((System.Reflection.PropertyInfo)m).GetValue(obj, null), next);
                else if(m.MemberType == System.Reflection.MemberTypes.Field)
                    return ToObj(((System.Reflection.FieldInfo)m).GetValue(obj), next);
                else
                    return null;
            }
            return null;
        }
    }

    public static string ToString(object value)
    {
        if(value == null)
            return "nil";

        var type = value.GetType();
        if(type == typeof(char) ||
            type == typeof(byte) ||
            type == typeof(int) ||
            type == typeof(uint) ||
            type == typeof(short) ||
            type == typeof(ushort) ||
            type == typeof(long) ||
            type == typeof(ulong) ||
            type == typeof(string) ||
            type == typeof(float) ||
            type == typeof(bool) ||
            type == typeof(double))
            return value.ToString();
        else if(type == typeof(Lua.Ref))
        {
            var r = (Lua.Ref)value;
            r.Push();
            var name = Lua.Constant.TypeName[(int)r.state.Type(-1) + 1] + "@lua";
            r.state.Pop(1);
            return name;
        }
        else
            return Lua.State.GetTypeFullName(type);
    }

    public static string ToType(object value)
    {
        if(value == null)
            return "nil";
        var type = value.GetType();
        if(type == typeof(Lua.Ref))
        {
            var r = (Lua.Ref)value;
            r.Push();
            var name = Lua.Constant.TypeName[(int)r.state.Type(-1) + 1];
            r.state.Pop(1);
            return name;
        }
        else
            return Lua.State.GetTypeFullName(value.GetType());
    }

    public static System.Type GetType(string name)
    {
        if(string.IsNullOrEmpty(name))
            return null;

        var type = System.Type.GetType(name);
        if(type == null)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach(var a in assemblies)
            {
                type = a.GetType(name);
                if(type != null)
                    break;
            }
        }
        return type;
    }

    public static void SetValue(object obj, string name, object value)
    {
        var type = obj.GetType();
        var p = type.GetProperty(name, System.Reflection.BindingFlags.Instance |
                                      System.Reflection.BindingFlags.Public |
                                      System.Reflection.BindingFlags.SetProperty);
        if(p != null)
        {
            p.SetValue(obj, value, null);
            return;
        }
        var f = type.GetField(name, System.Reflection.BindingFlags.Instance |
                                    System.Reflection.BindingFlags.Public |
                                    System.Reflection.BindingFlags.SetField);
        if(f != null)
        {
            f.SetValue(obj, value);
            return;
        }
    }

    public static object GetValue(object obj, string name)
    {
        var type = obj.GetType();
        var p = type.GetProperty(name, System.Reflection.BindingFlags.Instance |
                                       System.Reflection.BindingFlags.Public |
                                       System.Reflection.BindingFlags.GetProperty);
        if(p != null)
            return p.GetValue(obj, null);
        var f = type.GetField(name, System.Reflection.BindingFlags.Instance |
                                    System.Reflection.BindingFlags.Public |
                                    System.Reflection.BindingFlags.GetField);
        if(f != null)
            return f.GetValue(obj);
        return null;
    }
}
