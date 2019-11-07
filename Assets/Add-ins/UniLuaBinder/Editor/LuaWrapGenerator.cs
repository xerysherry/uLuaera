using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.IO;

public class LuaWrapGenerator
{
    /// <summary>
    /// LuaWrap生成文件夹，可以根据需求修改路径
    /// </summary>
    static readonly string kGeneratedPath = "./Assets/LuaWrap/";

    /// <summary>
    /// 清空
    /// </summary>
    public static void ClearClass()
    {
        skip_class.Clear();
        skip_method.Clear();
        be_created_class.Clear();
        class_list.Clear();
    }

    /// <summary>
    /// 设置Lua绑定跳过的类
    /// </summary>
    /// <param name="types"></param>
    public static void SetSkipClass(List<Type> types)
    {
        foreach(var type in types)
            skip_class.Add(type);
    }

    /// <summary>
    /// 设置Lua绑定跳过函数
    /// </summary>
    /// <param name="methods"></param>
    public static void SetSkipMethod(List<string> methods)
    {
        foreach(var method in methods)
            skip_method.Add(method);
    }

    /// <summary>
    /// 生成Lua绑定文件
    /// </summary>
    /// <param name="types"></param>
    public static void Create(List<Type> types)
    {
        foreach(var type in types)
            Create(type);
    }

    /// <summary>
    /// 生成Lua绑定文件
    /// </summary>
    /// <param name="type"></param>
    /// <param name="include_super_member">是否绑定父类</param>
    public static void Create(Type type, bool include_super_member = false)
    {
        if(be_created_class.Contains(type))
            return;

        if(type.IsEnum)
        {
            CreateEnum(type);
        }
        else if(type.IsClass || type.IsValueType)
        {
            if(!include_super_member)
            {
                Stack<Type> t = new Stack<Type>();
                var basetype = type.BaseType;
                while(basetype != null)
                {
                    if(basetype == typeof(System.ValueType))
                        break;
                    if(!skip_class.Contains(basetype) &&
                        !be_created_class.Contains(basetype))
                        t.Push(basetype);
                    basetype = basetype.BaseType;
                }
                while(t.Count > 0)
                {
                    basetype = t.Peek();
                    CreateClass(basetype, include_super_member);
                    t.Pop();
                    be_created_class.Add(basetype);
                }
            }
            CreateClass(type, include_super_member);
        }
        else
            throw new NotImplementedException();
        be_created_class.Add(type);
    }

    static HashSet<Type> skip_class = new HashSet<Type>();
    static HashSet<string> skip_method = new HashSet<string>();
    static HashSet<Type> be_created_class = new HashSet<Type>();
    static List<string> class_list = new List<string>();

    //==========================================================================
    static readonly string[] kSpaceLine = new string[]
    {
        "",
        " ",
        "  ",
        "   ",
        "    ",
        "     ",
        "      ",
        "       ",
        "        ",
        "         ",
        "          ",
        "           ",
        "            ",
        "             ",
        "              ",
        "               ",
        "                ",
        "                 ",
        "                  ",
        "                   ",
        "                    ",
        "                     ",
        "                      ",
        "                       ",
    };
    static readonly string[] kParamNameList = new string[]
    {
        "a","b","c","d","e","f","g",
        "h","i","j","k","l","m","n",
        "o","p","q","r","s","t","u",
        "v","w","x","y","z",
    };
    static readonly string[] kReturnNameList = new string[]
    {
        "ra","rb","rc","rd","re","rf","rg",
        "rh","ri","rj","rk","rl","rm","rn",
        "ro","rp","rq","rr","rs","rt","ru",
        "rv","rw","rx","ry","rz",
    };
    static readonly string[] kDelegateParamNameList = new string[]
    {
        "da","db","dc","dd","de","df","dg",
        "dh","di","dj","dk","dl","dm","dn",
        "do","dp","dq","dr","ds","dt","du",
        "dv","dw","dx","dy","dz",
    };
    static readonly string[] kDelegateReturnNameList = new string[]
    {
        "dra","drb","drc","drd","dre","drf","drg",
        "drh","dri","drj","drk","drl","drm","drn",
        "dro","drp","drq","drr","drs","drt","dru",
        "drv","drw","drx","dry","drz",
    };
    static readonly string[] kClassScript = new string[]
    {
@"// THIS IS A GENERATED FILE. PLEASE DO NOT MODIFY IT!
using System;
using System.Collections;
using System.Collections.Generic;
using Lua;

namespace Lua
{{
public static class {0} 
{{",
@"
}
}"
    };
    //==========================================================================
    //create enum
    /// <summary>
    /// 创建枚举
    /// </summary>
    /// <param name="type"></param>
    static void CreateEnum(Type type)
    {
        var classname = GetReflectTypeName(type, "_");
        classname = classname.Split('`')[0];
        classname = classname.Replace('.', '_');
        classname = "Wrap_" + classname;

        using(var writer = CreateFile(kGeneratedPath + classname + ".cs"))
        {
            writer.WriteLine(string.Format(kClassScript[0], classname));

            List<string> enums = new List<string>();
            var fields = type.GetFields();
            foreach(var f in fields)
            {
                if(!f.FieldType.IsEnum)
                    continue;
                var attribs = f.GetCustomAttributes(typeof(ObsoleteAttribute), true);
                if(attribs != null && attribs.Length > 0)
                    continue;

                enums.Add(f.Name);
            }
            OpenLibMethod(writer, type, enums);
            writer.WriteLine(kClassScript[1]);
        }
        class_list.Add(classname);
    }
    //==========================================================================
    //create class
    /// <summary>
    /// 创建类
    /// </summary>
    /// <param name="type"></param>
    static void CreateClass(Type type, bool include_super_member = false)
    {
        var nestedtypes = type.GetNestedTypes(BindingFlags.Public);
        var classname = GetReflectTypeName(type, "_");
        classname = classname.Split('`')[0];
        classname = classname.Replace('.', '_');
        classname = "Wrap_" + classname;

        Dictionary<string, List<string>> enum_tables = new Dictionary<string, List<string>>();
        Dictionary<string, List<string>> static_method_record = new Dictionary<string, List<string>>();
        Dictionary<string, string> static_member_record = new Dictionary<string, string>();
        Dictionary<string, List<string>> instance_method_record = new Dictionary<string, List<string>>();
        Dictionary<string, string> instance_member_record = new Dictionary<string, string>();

        HashSet<string> temp_member_record = new HashSet<string>();
        using(var writer = CreateFile(kGeneratedPath + classname + ".cs"))
        {
            writer.WriteLine(string.Format(kClassScript[0], classname));
            //类中定义枚举
            foreach(var t in nestedtypes)
            {
                if(!t.IsEnum)
                    continue;
                List<string> enums = new List<string>();
                var fields = t.GetFields();
                foreach(var f in fields)
                {
                    if(!f.FieldType.IsEnum)
                        continue;
                    enums.Add(f.Name);
                }
                if(enums.Count > 0)
                    enum_tables.Add(t.Name, enums);
            }
            //静态方法，属性，变量
            var members = type.GetMembers(BindingFlags.Static | BindingFlags.Public);
            foreach(var m in members)
            {
                if(!include_super_member && m.DeclaringType != type)
                    continue;

                switch(m.MemberType)
                {
                    case MemberTypes.Method:
                        {
                            //函数
                            var name = WriteMethod("_s_method_", writer, (MethodInfo)m, true);
                            if(!string.IsNullOrEmpty(name))
                            {
                                List<string> list = null;
                                if(!static_method_record.TryGetValue(m.Name, out list))
                                {
                                    list = new List<string>();
                                    static_method_record[m.Name] = list;
                                }
                                list.Add(name);
                            }
                            temp_member_record.Add(m.Name);
                        }
                        break;
                    case MemberTypes.Property:
                        {
                            //属性
                            string name;
                            PropertyInfo info = (PropertyInfo)m;
                            if(info.CanRead && temp_member_record.Contains("get_" + m.Name))
                            {
                                name = WriteGetProperty("_s_get_property_", writer, info, true);
                                if(!string.IsNullOrEmpty(name))
                                    static_member_record["Get" + GetFirstCharUpper(m.Name)] = name;
                            }
                            if(info.CanWrite && temp_member_record.Contains("set_" + m.Name))
                            {
                                name = WriteSetProperty("_s_set_property_", writer, info, true);
                                if(!string.IsNullOrEmpty(name))
                                    static_member_record["Set" + GetFirstCharUpper(m.Name)] = name;
                            }
                        }
                        break;
                    case MemberTypes.Field:
                        {
                            //变量
                            var name = WriteGetField("_s_get_field_", writer, (FieldInfo)m, true);
                            if(!string.IsNullOrEmpty(name))
                                static_member_record["get_" + m.Name] = name;
                            name = WriteSetField("_s_set_field_", writer, (FieldInfo)m, true);
                            if(!string.IsNullOrEmpty(name))
                                static_member_record["set_" + m.Name] = name;
                        }
                        break;
                }
            }
            temp_member_record.Clear();
            foreach(var dv in static_method_record)
            {
                var n = SelectMethod("_s_method_" + dv.Key, writer, dv.Value);
                static_member_record[dv.Key] = n;
            }
            
            //构造函数
            var constructors = type.GetConstructors();
            bool has_no_param_list = false;
            if(constructors.Length > 0)
            {
                List<string> instance_constructor_record = new List<string>();
                List<string> instance_constructor_ref_record = new List<string>();
                foreach(var c in constructors)
                {
                    if(!include_super_member && c.DeclaringType != type)
                        continue;

                    var name = WriteConstructor(writer, c, 1);
                    if(!string.IsNullOrEmpty(name))
                    {
                        instance_constructor_record.Add(name);
                        var s = name.Split('_');
                        if(!has_no_param_list && s[s.Length - 1] == "0")
                        {
                            has_no_param_list = true;
                        }
                    }
                    name = WriteConstructor(writer, c, 2);
                    if(!string.IsNullOrEmpty(name))
                    {
                        instance_constructor_ref_record.Add(name);
                    }
                }
                if(!has_no_param_list)
                {
                    var name = WriteConstructorNoParam(writer, type, false);
                    if(!string.IsNullOrEmpty(name))
                        instance_constructor_record.Add(name);
                    name = WriteConstructorNoParam(writer, type, true);
                    if(!string.IsNullOrEmpty(name))
                        instance_constructor_ref_record.Add(name);
                }
                var constructor_name = SelectMethod("Constructor", writer, instance_constructor_record);
                static_member_record["Constructor"] = constructor_name;
                constructor_name = SelectMethod("ConstructorRef", writer, instance_constructor_ref_record);
                static_member_record["ConstructorRef"] = constructor_name;
            }

            //非静态方法，属性，变量
            members = type.GetMembers(BindingFlags.Instance | BindingFlags.Public);
            foreach(var m in members)
            {
                if(!include_super_member && m.DeclaringType != type)
                    continue;
                
                switch(m.MemberType)
                {
                    case MemberTypes.Method:
                        {
                            //函数
                            var info = (MethodInfo)m;
                            var name = WriteMethod("_inst_method_", writer, info, false);
                            if(!string.IsNullOrEmpty(name))
                            {
                                List<string> list = null;
                                if(!instance_method_record.TryGetValue(m.Name, out list))
                                {
                                    list = new List<string>();
                                    instance_method_record[m.Name] = list;
                                }
                                list.Add(name);
                            }
                            temp_member_record.Add(m.Name);
                        }
                        break;
                    case MemberTypes.Property:
                        //属性
                        {
                            //属性
                            string name;
                            PropertyInfo info = (PropertyInfo)m;
                            if(info.CanRead && temp_member_record.Contains("get_" + m.Name))
                            {
                                if(info.Name.CompareTo("Item") == 0)
                                {
                                    name = WriteGetProperty("_inst_get_property_", writer, info, false);
                                    if(!string.IsNullOrEmpty(name))
                                    {
                                        List<string> list = null;
                                        if(!instance_method_record.TryGetValue("Get", out list))
                                        {
                                            list = new List<string>();
                                            instance_method_record["Get"] = list;
                                        }
                                        list.Add(name);
                                    }
                                }
                                else
                                {
                                    name = WriteGetProperty("_inst_get_property_", writer, info, false);
                                    if(!string.IsNullOrEmpty(name))
                                    {
                                        instance_member_record["Get" + GetFirstCharUpper(m.Name)] = name;
                                    }
                                }
                            }
                            if(info.CanWrite && temp_member_record.Contains("set_" + m.Name))
                            {
                                if(info.Name.CompareTo("Item") == 0)
                                {
                                    name = WriteGetProperty("_inst_set_property_", writer, info, false);
                                    if(!string.IsNullOrEmpty(name))
                                    {
                                        List<string> list = null;
                                        if(!instance_method_record.TryGetValue("Set", out list))
                                        {
                                            list = new List<string>();
                                            instance_method_record["Set"] = list;
                                        }
                                        list.Add(name);
                                    }
                                }
                                else
                                {
                                    name = WriteSetProperty("_inst_set_property_", writer, info, false);
                                    if(!string.IsNullOrEmpty(name))
                                        instance_member_record["Set" + GetFirstCharUpper(m.Name)] = name;
                                }
                            }
                        }
                        break;
                    case MemberTypes.Field:
                        //变量
                        {
                            //变量
                            var name = WriteGetField("_inst_get_field_", writer, (FieldInfo)m, false);
                            if(!string.IsNullOrEmpty(name))
                                instance_member_record["get_" + m.Name] = name;
                            name = WriteSetField("_inst_set_field_", writer, (FieldInfo)m, false);
                            if(!string.IsNullOrEmpty(name))
                                instance_member_record["set_" + m.Name] = name;
                        }
                        break;
                }
            }
            foreach(var dv in instance_method_record)
            {
                var n = SelectMethod("_inst_method_" + dv.Key, writer, dv.Value);
                instance_member_record[dv.Key] = n;
            }
            ////特殊处理Item属性
            //List<string> get_item_list = null;
            //if(instance_method_record.TryGetValue("Get", out get_item_list))
            //{
            //    if(get_item_list.Contains("_inst_get_property_Item_49"))
            //    {
            //        get_item_list.Remove("_inst_get_property_Item_49");
            //        var n = SelectMethod("_inst_method_" + "GetForRef", writer, get_item_list);
            //        instance_member_record["*Get"] = n;
            //    }
            //    else
            //        instance_member_record["*Get"] = instance_member_record["Get"];
            //}

            OpenLibMethod(writer, type, enum_tables, 
                static_member_record, instance_member_record);

            writer.WriteLine(kClassScript[1]);
        }
        class_list.Add(classname);
    }

    //==========================================================================
    // constructor
    static string WriteConstructorNoParam(StreamWriter writer, Type type, bool is_ref)
    {
        if(!(type.IsValueType && !type.IsEnum && !IsBaseType(type)))
            return null;

        var methodname = (is_ref ? "ConstructorRef_" : "Constructor_") +
                    GetHashCode(type.GetHashCode()) + 
                    (is_ref ? "_5" : "_0");
        WriteStart(writer);

        WriteBeginComments();
        var comments = GetParamlistComment(GetTypeName(type), "Constructor",
                                            new ParameterInfo[0] { }, 0);
        WriteComments(comments);
        WriteEndComments();

        //写入函数头
        WriteMethodHead(methodname);

        //写入参数获取
        string paramlist = "";
        //写入结果返回
        WriteConstructionMethod(type, paramlist);

        //写入函数尾
        WriteMethodTail();
        //写入结束
        WriteEnd();
        return methodname;
    }
    static string WriteConstructor(StreamWriter writer, ConstructorInfo info, 
                                    int offset)
    {
        if(!info.IsPublic)
            return null;

        var attribs = info.GetCustomAttributes(typeof(ObsoleteAttribute), true);
        if(attribs != null && attribs.Length > 0)
            return null;

        var parameters = info.GetParameters();
        var typecode = (ulong)(GetTypecode(parameters, 0L) + 
                        (offset == 1 ?  0UL : 5 * Math.Pow(0x10UL, parameters.Length)));
        var methodname = (offset == 1 ? "Constructor_" : "ConstructorRef_") + 
                        GetHashCode(info.GetHashCode()) + "_" +
                        string.Format("{0:X}", typecode);
        var paramindex = offset;
        
        WriteStart(writer);

        WriteBeginComments();
        var comments = GetParamlistComment(GetTypeName(info.DeclaringType), 
                                            "Constructor", parameters, 0);
        WriteComments(comments);
        WriteEndComments();

        //写入函数头
        WriteMethodHead(methodname);

        //写入参数获取
        string paramlist = "";
        for(int i = 0; i < parameters.Length; ++i)
        {
            var p = parameters[i];
            var pt = p.ParameterType;
            var param = WriteGetCode(pt, paramindex++);
            paramlist += param;
            if(i + 1 < parameters.Length)
                paramlist += ",";
        }

        //写入结果返回
        WriteConstructionMethod(info.DeclaringType, paramlist);

        //写入函数尾
        WriteMethodTail();
        //写入结束
        WriteEnd();
        return methodname;
    }

    //==========================================================================
    // static method
    static string WriteMethod(string prefix, 
                                StreamWriter writer, 
                                MethodInfo method, 
                                bool is_static)
    {
        if(method.IsSpecialName || method.ContainsGenericParameters)
            return null;
        var declaring_type = Lua.State.GetTypeFullName(method.DeclaringType);
        if(skip_method.Contains(declaring_type + "." + method.Name))
            return null;

        var attribs = method.GetCustomAttributes(typeof(ObsoleteAttribute), true);
        if(attribs != null && attribs.Length > 0)
            return null;

        ulong typecode_init = 0;
        if(!is_static)
            typecode_init = (ulong)
                (method.DeclaringType.IsValueType ? Lua.Type.LUA_TTABLE : Lua.Type.LUA_TLIGHTUSERDATA);
        var parameters = method.GetParameters();
        var returntype = method.ReturnType;
        var methodname = prefix + method.Name + "_" + 
            GetHashCode(method.GetHashCode())+ "_" +
            string.Format("{0:X}", GetTypecode(parameters, typecode_init));
        var comments = GetParamlistComment(declaring_type, method.Name, 
                                            parameters, typecode_init);
        
        int paramindex = 1;


        WriteStart(writer);

        if(comments != null && comments.Count > 0)
        {
            WriteBeginComments();
            WriteComments(comments);
            WriteEndComments();
        }

        //写入函数头
        WriteMethodHead(methodname);
        if(!is_static)
            WriteGetCode(method.DeclaringType, paramindex++);

        //写入参数获取
        string paramlist = "";
        for(int i = 0; i < parameters.Length; ++i)
        {
            var p = parameters[i];
            var pt = p.ParameterType;
            var param = WriteGetCode(pt, paramindex++, p.IsOut);
            if(pt.IsByRef)
            {
                if(p.IsOut)
                {
                    paramlist += "out ";
                    paramindex -= 1;
                }
                else
                {
                    paramlist += "ref ";
                }
            }
            paramlist += param;
            if(i + 1 < parameters.Length)
                paramlist += ",";
        }

        //写入C#函数调用
        string callmethod = null;
        if(is_static)
            callmethod = GetTypeName(method.ReflectedType) + ".";
        else
            callmethod = kParamNameList[0] + ".";
        callmethod += method.Name;
        WriteCallMethod(returntype, callmethod, paramlist);

        //写入结果返回
        WriteReturns();
        if(!is_static)
            WriteStructUpdates(1, method.DeclaringType, kParamNameList[0]);

        //写入函数尾
        WriteMethodTail();
        //写入结束
        WriteEnd();
        return methodname;
    }
    //==========================================================================
    // static property
    static string WriteGetProperty(string prefix, 
                                    StreamWriter writer, 
                                    PropertyInfo info,
                                    bool is_static)
    {
        if(skip_method.Contains(Lua.State.GetTypeFullName(info.DeclaringType) +
                                "." + info.Name))
            return null;
        if(!info.CanRead)
            return null;
        var attribs = info.GetCustomAttributes(typeof(ObsoleteAttribute), true);
        if(attribs != null && attribs.Length > 0)
            return null;

        MethodInfo item_method = null;
        bool is_item = (info.Name.CompareTo("Item") == 0);
        if(is_item)
        {
            item_method = info.GetGetMethod(false);
            if(item_method == null)
                return null;
        }

        //写入函数头
        var methodname = prefix + info.Name;
        if(is_item)
        {
            ulong typecode_init = (ulong)
                    (item_method.DeclaringType.IsValueType ? Lua.Type.LUA_TTABLE : Lua.Type.LUA_TLIGHTUSERDATA);
            methodname += "_" + string.Format("{0:X}", GetTypecode(item_method.GetParameters(), typecode_init));
        }

        WriteStart(writer);
        WriteMethodHead(methodname);
        
        if(is_static)
        {
            //写入返回值
            //if(is_item)
            //{
            //    var p = item_method.GetParameters()[0];
            //    var param = WriteGetCode(p.ParameterType, 1);

            //    var reflectname = GetTypeName(info.ReflectedType);
            //    reflectname += "[" + param + "]";
            //    WriteReturn(info.PropertyType, reflectname);
            //}
            //else
            //{
                var reflectname = GetTypeName(info.ReflectedType);
                if(string.IsNullOrEmpty(reflectname))
                    reflectname = info.Name;
                else
                    reflectname = reflectname + "." + info.Name;
                WriteReturn(info.PropertyType, reflectname);
            //}
        }
        else
        {
            //非静态，获取实例对象
            WriteGetCode(info.DeclaringType, 1);
            if(is_item)
            {
                var p = item_method.GetParameters()[0];
                var param = WriteGetCode(p.ParameterType, 2);
                var returnname = kParamNameList[0] + "[" + param + "]";
                WriteReturn(info.PropertyType, returnname);
            }
            else
            {
                var returnname = kParamNameList[0] + "." + info.Name;
                WriteReturn(info.PropertyType, returnname);
            }
        }

        if(!is_static)
            WriteStructUpdates(1, info.DeclaringType, kParamNameList[0]);

        //写入函数尾
        WriteMethodTail();
        WriteEnd();
        return methodname;
    }
    static string WriteSetProperty(string prefix, 
                                    StreamWriter writer, 
                                    PropertyInfo info,
                                    bool is_static)
    {
        if(skip_method.Contains(Lua.State.GetTypeFullName(info.DeclaringType) +
                                "." + info.Name))
            return null;
        if(!info.CanWrite)
            return null;
        var attribs = info.GetCustomAttributes(typeof(ObsoleteAttribute), true);
        if(attribs != null && attribs.Length > 0)
            return null;

        MethodInfo item_method = null;
        bool is_item = (info.Name.CompareTo("Item") == 0);
        if(is_item)
        {
            item_method = info.GetSetMethod(false);
            if(item_method == null)
                return null;
        }


        //写入函数头
        var methodname = prefix + info.Name;
        if(is_item)
        {
            ulong typecode_init = (ulong)
                    (item_method.DeclaringType.IsValueType ? Lua.Type.LUA_TTABLE : Lua.Type.LUA_TLIGHTUSERDATA);
            methodname += "_" + string.Format("{0:X}", GetTypecode(item_method.GetParameters(), typecode_init));
        }

        WriteStart(writer);
        WriteMethodHead(methodname);

        if(is_static)
        {
            //写入获取
            //if(is_item)
            //{
            //    var ps = item_method.GetParameters();
            //    var param1 = WriteGetCode(ps[0].ParameterType, 1);
            //    var param2 = WriteGetCode(ps[1].ParameterType, 2);
            //    var reflectname = GetTypeName(info.ReflectedType);
            //    writer.WriteLine(kSpaceLine[8] + reflectname + "[" + param1+ "] = " + param2 + ";");
            //}
            //else
            //{
                var reflectname = GetTypeName(info.ReflectedType);
                if(string.IsNullOrEmpty(reflectname))
                    reflectname = info.Name;
                else
                    reflectname = reflectname + "." + info.Name;
                var param = WriteGetCode(info.PropertyType, 1);
                writer.WriteLine(kSpaceLine[8] + reflectname + " = " + param + ";");
            //}
        }
        else
        {
            WriteGetCode(info.DeclaringType, 1);
            if(is_item)
            {
                var ps = item_method.GetParameters();
                var param1 = WriteGetCode(ps[0].ParameterType, 1);
                var param2 = WriteGetCode(ps[1].ParameterType, 2);
                writer.WriteLine(kSpaceLine[8] +
                    kParamNameList[0] + "[" + param1 + "] = " + param2 + ";");
            }
            else
            {
                var param = WriteGetCode(info.PropertyType, 2);
                writer.WriteLine(kSpaceLine[8] +
                    kParamNameList[0] + "." + info.Name + " = " + param + ";");
            }
        }

        if(!is_static)
            WriteStructUpdates(1, info.DeclaringType, kParamNameList[0]);

        //写入函数尾
        WriteMethodTail();
        WriteEnd();
        return methodname;
    }
    //==========================================================================
    // static field
    static string WriteGetField(string prefix, 
                                StreamWriter writer, 
                                FieldInfo info, 
                                bool is_static)
    {
        if(skip_method.Contains(Lua.State.GetTypeFullName(info.DeclaringType) +
                                "." + info.Name))
            return null;
        //写入函数头
        var methodname = prefix + info.Name;
        WriteStart(writer);
        WriteMethodHead(methodname);

        if(is_static)
        {
            //写入返回值
            var reflectname = GetTypeName(info.ReflectedType);
            if(string.IsNullOrEmpty(reflectname))
                reflectname = info.Name;
            else
                reflectname = reflectname + "." + info.Name;
            WriteReturn(info.FieldType, reflectname);
        }
        else
        {
            //非静态，获取实例对象
            var returnname = kParamNameList[0] + "." + info.Name;
            WriteGetCode(info.DeclaringType, 1);
            WriteReturn(info.FieldType, returnname);
        }

        //写入函数尾
        WriteMethodTail();
        WriteEnd();
        return methodname;
    }
    static string WriteSetField(string prefix, 
                                StreamWriter writer, 
                                FieldInfo info,
                                bool is_static)
    {
        if(skip_method.Contains(Lua.State.GetTypeFullName(info.DeclaringType) +
                                "." + info.Name))
            return null;
        if(info.IsInitOnly || info.IsLiteral)
            return null;

        //写入函数头
        var methodname = prefix + info.Name;
        WriteStart(writer);
        WriteMethodHead(methodname);

        string resultname = null;
        if(is_static)
        {
            //写入获取
            var reflectname = GetTypeName(info.ReflectedType);
            if(string.IsNullOrEmpty(reflectname))
                reflectname = info.Name;
            else
                reflectname = reflectname + "." + info.Name;
            resultname = reflectname;
            var param = WriteGetCode(info.FieldType, 1);
            writer.WriteLine(kSpaceLine[8] + reflectname + " = " + param + ";");
        }
        else
        {
            WriteGetCode(info.DeclaringType, 1);
            var param = WriteGetCode(info.FieldType, 2);
            writer.WriteLine(kSpaceLine[8] +
                kParamNameList[0] + "." + info.Name + " = " + param + ";");
        }

        if(!is_static)
        {
            var dtype = info.DeclaringType;
            if(dtype.IsValueType && !dtype.IsEnum && !IsBaseType(dtype))
                WriteStructUpdate(1, info.Name, kParamNameList[0], info.FieldType);
        }

        //写入函数尾
        WriteMethodTail();
        WriteEnd();
        return methodname;
    }

    //==========================================================================
    /// <summary>
    /// 开始写
    /// </summary>
    /// <param name="writer"></param>
    static void WriteStart(StreamWriter writer)
    {
        __writer = writer;
        __in_index = 0;
        __out_index = 1;
        __dict_caststring = new Dictionary<int, string>();
        __dict_type = new Dictionary<int, Type>();
        __out_param = new List<string>() { kReturnNameList[0] };
        __state_written = false;
    }
    /// <summary>
    /// 结束写
    /// </summary>
    static void WriteEnd()
    {
        __writer = null;
    }
    /// <summary>
    /// 写入函数头
    /// </summary>
    /// <param name="methodname"></param>
    static void WriteMethodHead(string methodname)
    {
        __writer.WriteLine(
@"    private static void {0}(Lua.Param pa)
    {{", 
                        methodname);
    }
    /// <summary>
    /// 写入函数尾
    /// </summary>
    /// <param name="methodname"></param>
    static void WriteMethodTail()
    {
        __writer.WriteLine("    }");
    }
    /// <summary>
    /// 写入从Lua层获取参数
    /// </summary>
    /// <param name="type"></param>
    /// <param name="paramindex"></param>
    /// <returns></returns>
    static string WriteGetCode(Type type, int paramindex, bool is_out = false)
    {
        string result = null;
        if(is_out)
        {
            // out&ref 参数处理
            __dict_caststring[__out_index] = GetCastTo(type);

            var paramtype = GetParamTypePointerBaseType(type);
            var elementtype = type.GetElementType();
            __dict_type[__out_index] = elementtype;

            __writer.Write(kSpaceLine[8]);
            if(elementtype.IsValueType && !elementtype.IsEnum && !IsBaseType(elementtype))
                __writer.WriteLine("var {0}=new {1}();",
                                kReturnNameList[__out_index],
                                paramtype);
            else
                __writer.WriteLine("var {0}=default({1});",
                                kReturnNameList[__out_index],
                                paramtype);
            result = kReturnNameList[__out_index];
            __out_param.Add(result);
            __out_index += 1;
        }
        else
        {
            // 普通参数
            if(type.IsByRef)
            {
                type = type.GetElementType();
                __out_param.Add(kParamNameList[__in_index]);
                __dict_type[__out_index] = type;
                __out_index += 1;
            }
            var paramtype = GetParamTypeName(type);

            __writer.Write(kSpaceLine[8]);
            
            if(type.IsValueType && !type.IsEnum && !IsBaseType(type))
            {
                __writer.WriteLine("var s{0}=pa.Get{1}({2});",
                            paramindex,
                            paramtype, paramindex);
                __writer.Write(kSpaceLine[8]);
                __writer.WriteLine("var {0} = new {1}();", kParamNameList[__in_index], GetTypeName(type));
                var fs = type.GetFields(BindingFlags.Public | BindingFlags.Instance |
                    BindingFlags.GetField | BindingFlags.SetField);
                foreach(var f in fs)
                {
                    __writer.WriteLine(
                        WriteStructMemberUpdate(f.FieldType, f.Name, kParamNameList[__in_index], "s" + paramindex, 8));
                }
                var ps = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | 
                    BindingFlags.GetProperty | BindingFlags.SetProperty);
                foreach(var p in ps)
                {
                    if(!p.CanWrite)
                        continue;
                    if(p.Name == "Item")
                        continue;
                    var attribs = p.GetCustomAttributes(typeof(ObsoleteAttribute), true);
                    if(attribs != null && attribs.Length > 0)
                        continue;
                    __writer.WriteLine(
                        WriteStructMemberUpdate(p.PropertyType, p.Name, kParamNameList[__in_index], "s" + paramindex, 8));
                }
                result = kParamNameList[__in_index];
            }
            else
            {
                __writer.WriteLine("var {0}=pa.Get{1}({2});",
                            kParamNameList[__in_index],
                            paramtype, paramindex);
                if(type.BaseType != typeof(System.MulticastDelegate))
                {
                    result = GetCastFrom(type);
                    result += kParamNameList[__in_index];
                }
                else
                {
                    // Delegate
                    var member = type.GetMembers()[0];
                    var m = (MethodInfo)member;
                    var ps = m.GetParameters();
                    var rt = m.ReturnType;
                    var delegate_out = 0;
                    var delegate_type = new Dictionary<int, Type>();
                    var delegate_outname = new Dictionary<int, string>();
                    var func = kParamNameList[__in_index];

                    result = "\xd\xa" + kSpaceLine[12] + "(";
                    for(int i = 0; i < ps.Length; ++i)
                    {
                        var p = ps[i];
                        var pt = p.ParameterType;
                        if(pt.IsByRef)
                        {
                            result += (p.IsOut ? "out " : "ref ");
                            result += GetParamTypePointerBaseType(pt) + " ";
                        }
                        else
                        {
                            result += GetTypeName(pt) + " ";
                        }
                        result += kDelegateParamNameList[i];
                        if(i + 1 < ps.Length)
                            result += ",";
                    }
                    result += ")=>{\xd\xa";
                    result += kSpaceLine[16] + func + ".Start();\xd\xa";
                    if(rt != typeof(void))
                    {
                        delegate_outname[delegate_out] = kDelegateReturnNameList[0];
                        delegate_type[delegate_out] = rt;
                        delegate_out += 1;
                        result += kSpaceLine[16] + GetTypeName(rt) + " " + 
                                kDelegateReturnNameList[0] + "=default(" +
                                GetTypeName(rt) + ");\xd\xa";
                    }
                    for(int i = 0; i < ps.Length; ++i)
                    {
                        var p = ps[i];
                        var pt = p.ParameterType;

                        if(p.IsOut)
                        {
                            delegate_type[delegate_out] = pt.GetElementType();
                            delegate_outname[delegate_out] = kDelegateParamNameList[i];
                            delegate_out += 1;
                        }
                        else
                        {
                            if(pt.IsByRef)
                            {
                                pt = pt.GetElementType();
                                delegate_type[delegate_out] = pt;
                                delegate_outname[delegate_out] = kDelegateParamNameList[i];
                                delegate_out += 1;
                            }

                            if( pt == typeof(Lua.Ref) ||
                                pt == typeof(Lua.Function) ||
                                pt == typeof(int) ||
                                pt == typeof(uint) ||
                                pt == typeof(short) ||
                                pt == typeof(ushort) ||
                                pt == typeof(char) ||
                                pt == typeof(byte) ||
                                pt == typeof(long) ||
                                pt == typeof(ulong) ||
                                pt == typeof(string) ||
                                pt == typeof(bool) ||
                                pt == typeof(double) ||
                                pt.BaseType == typeof(Array) ||
                                pt.GetInterface("System.Collections.IList") != null ||
                                pt.GetInterface("System.Collections.IDictionary") != null)
                            {
                                result += kSpaceLine[16] + func +
                                    ".Push(" + kDelegateParamNameList[i] + ");\xd\xa";
                            }
                            else if(pt.BaseType == typeof(System.Enum))
                            {
                                result += kSpaceLine[16] + func +
                                    ".Push((int)" + kDelegateParamNameList[i] + ");\xd\xa";
                            }
                            else if(pt.IsValueType && !IsBaseType(pt))
                            {
                                result += kSpaceLine[16] + func + (".Push(new Dictionary<string, object>{\xd\xa");
                                var fs = pt.GetFields(BindingFlags.Public | BindingFlags.Instance);
                                foreach(var f in fs)
                                    result += kSpaceLine[20] +
                                        string.Format("{{\"{0}\", {1}.{0}}},\xd\xa",
                                        f.Name, kDelegateParamNameList[i]);
                                result += kSpaceLine[16] + "},\"" + GetTypeName(pt) + "\");\xd\xa";
                            }
                            else
                            {
                                result += kSpaceLine[16] + func +
                                    ".Push(" + kDelegateParamNameList[i] + ");\xd\xa";
                            }
                        }
                    }

                    result += string.Format(
                        kSpaceLine[16] + "if(!{0}.Call())\xd\xa" +  
                        kSpaceLine[16] + "{{\xd\xa" +
                        kSpaceLine[16] + "    var error = {0}.last_error_string;\xd\xa" +
                        kSpaceLine[16] + "    {0}.ClearCall();\xd\xa" +
                        kSpaceLine[16] + "    throw new Lua.Exception(error);\xd\xa" + 
                        kSpaceLine[16] + "}}\xd\xa", func);

                    for(int i=0; i < delegate_out; ++i)
                    {
                        var pt = delegate_type[i];
                        if(pt.IsValueType && !pt.IsEnum && !IsBaseType(pt))
                        {
                            result += kSpaceLine[16] +
                                string.Format("var ds{0}={1}.Get{2}({3});\xd\xa", i,
                                func, GetParamTypeName(pt), i + 1);

                            var fs = pt.GetFields(BindingFlags.Public | BindingFlags.Instance);
                            foreach(var f in fs)
                            {
                                result += string.Format(
                                    WriteStructMemberUpdate(f.FieldType, f.Name, delegate_outname[i], "ds" + i, 16)) 
                                    + "\xd\xa";

                            }
                            var pps = pt.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                            foreach(var p in pps)
                            {
                                if(!p.CanWrite)
                                    continue;
                                if(p.Name == "Item")
                                    continue;
                                var attribs = p.GetCustomAttributes(typeof(ObsoleteAttribute), true);
                                if(attribs != null && attribs.Length > 0)
                                    continue;
                                result += string.Format(
                                    WriteStructMemberUpdate(p.PropertyType, p.Name, delegate_outname[i], "ds" + i, 16))
                                    + "\xd\xa";
                            }
                        }
                        else
                        {
                            result += string.Format(
                                kSpaceLine[16] + "{0}={1}.Get{2}({3});\xd\xa",
                                delegate_outname[i],
                                GetCastTo(pt) + func,
                                GetParamTypeName(pt), i + 1);
                        }
                    }
                    result += string.Format(kSpaceLine[16] + "{0}.ClearCall();\xd\xa", func);
                    if(rt != typeof(void))
                    {
                        result += kSpaceLine[16] + "return " +
                            GetCastTo(rt) + kDelegateReturnNameList[0] + ";\xd\xa";
                    }
                    result += kSpaceLine[12] + "}";
                }
            }
            __in_index += 1;
        }
        return result;
    }
    /// <summary>
    /// 写入构造函数
    /// </summary>
    /// <param name="type"></param>
    /// <param name="param"></param>
    static void WriteConstructionMethod(Type type, string param)
    {
        __writer.Write(kSpaceLine[8]);
        __writer.WriteLine("var inst=new {0}({1});", GetTypeName(type), param);
        WriteReturn(type, "inst");
    }
    /// <summary>
    /// 写入函数调用
    /// </summary>
    /// <param name="returntype"></param>
    /// <param name="methodname"></param>
    /// <param name="paramlist"></param>
    static void WriteCallMethod(Type returntype, string methodname, string paramlist)
    {
        __writer.Write(kSpaceLine[8]);
        if(returntype != typeof(void))
        {
            __writer.Write("var " + kReturnNameList[0] + "=");
            __dict_caststring[0] = GetCastTo(returntype);
            __dict_type[0] = returntype;
        }
        __writer.WriteLine(methodname + "(" + paramlist + ");");
    }
    /// <summary>
    /// 写入返回
    /// </summary>
    /// <param name="type"></param>
    /// <param name="i"></param>
    static void WriteReturn(Type type, int i)
    {
        WriteReturn(type, __out_param[i]);
    }
    static void WriteReturn(Type type, string name)
    {
        if(type.IsValueType && !type.IsEnum && !IsBaseType(type))
        {
            var tempname = name;
            __writer.WriteLine(kSpaceLine[8] + "pa.Return(new Dictionary<string, object>{");
            var fs = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
            foreach(var f in fs)
                __writer.WriteLine(kSpaceLine[16] + "{{\"{0}\", {1}.{0}}},",
                    f.Name, tempname);
            var ps = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach(var p in ps)
            {
                if(!p.CanRead)
                    continue;
                if(p.Name == "Item")
                    continue;
                var attribs = p.GetCustomAttributes(typeof(ObsoleteAttribute), true);
                if(attribs != null && attribs.Length > 0)
                    continue;
                __writer.WriteLine(kSpaceLine[16] + "{{\"{0}\", {1}.{0}}},",
                    p.Name, tempname);
            }
            __writer.WriteLine(kSpaceLine[8] + "}}, \"{0}\");", GetTypeName(type));
        }
        else
        {
            if(IsBaseType(type))
                __writer.WriteLine(kSpaceLine[8] + "pa.Return({0});", GetCastTo(type)+ name);
            else if(type == typeof(object))
                __writer.WriteLine(kSpaceLine[8] + "if({0} == null)\xd\xa" +
                                   kSpaceLine[8] + "    pa.Return();\xd\xa" +
                                   kSpaceLine[8] + "else\xd\xa" +
                                   kSpaceLine[8] + "    pa.Return({0}, {0}.GetType());",
                                   GetCastTo(type) + name);
            else 
                __writer.WriteLine(kSpaceLine[8] + "pa.Return({0}, typeof({1}));", 
                                    GetCastTo(type)+ name, GetTypeName(type));
        }
    }
    /// <summary>
    /// 写入返回
    /// </summary>
    static void WriteReturns()
    {
        for(int i = 0; i < __out_index; ++i)
        {
            if(!__dict_type.ContainsKey(i))
                continue;
            var d = __dict_type[i];
            WriteReturn(d, i);
        }
    }

    static void WriteStructUpdate(int index, string fieldname, string param, Type type)
    {
        if(!__state_written)
        {
            __writer.WriteLine(kSpaceLine[8] + "var __state__=pa.state;");
            __state_written = true;
        }
        __writer.WriteLine(kSpaceLine[8] + "Lua.State.Push(pa.state, \"{0}\");", fieldname);
        if(IsBaseType(type))
            __writer.WriteLine(kSpaceLine[8] + "Lua.State.Push(pa.state, {0}.{1}); ", param, fieldname);
        else
            __writer.WriteLine(kSpaceLine[8] + "Lua.State.Push(pa.state, {0}.{1}, typeof({2}));", 
                                param, fieldname, GetTypeName(type));
        __writer.WriteLine(kSpaceLine[8] + "__state__.SetTable({0});", index);
    }

    static void WriteStructUpdates(int index, Type type, string param)
    {
        if(type.IsValueType && !type.IsEnum && !IsBaseType(type))
        {
            var fs = type.GetFields(BindingFlags.Public | BindingFlags.Instance |
                    BindingFlags.GetField | BindingFlags.SetField);
            foreach(var f in fs)
                WriteStructUpdate(index, f.Name, param, f.FieldType);
            var ps = type.GetProperties(BindingFlags.Public | BindingFlags.Instance |
                    BindingFlags.GetProperty | BindingFlags.SetProperty);
            foreach(var p in ps)
            {
                if(!p.CanRead)
                    continue;
                if(p.Name == "Item")
                    continue;
                var attribs = p.GetCustomAttributes(typeof(ObsoleteAttribute), true);
                if(attribs != null && attribs.Length > 0)
                    continue;
                WriteStructUpdate(index, p.Name, param, p.PropertyType);
            }
        }
    }

    static string WriteStructMemberUpdate(Type type, string name, string paramname, 
                                        string tablename, int space)
    {
        //if(type == typeof(bool))
        //{
        //    return string.Format(
        //        kSpaceLine[space] + "object {0}_{1} = null;\xd\xa" +
        //        kSpaceLine[space] + "if({2}.TryGetValue(\"{1}\", out {0}_{1}))\xd\xa" +
        //        kSpaceLine[space] + "    {0}.{1} = ((int)(double){0}_{1})!=0;",
        //                    paramname, name, tablename);
        //}
        //else
        //{
            var updatetype = GetTypeName(type);

            if(type == typeof(int))
                updatetype = "int)(double";
            else if(type == typeof(float))
                updatetype = "float)(double";
            else if(type == typeof(uint))
                updatetype = "uint)(double";
            else if(type == typeof(short))
                updatetype = "short)(double";
            else if(type == typeof(ushort))
                updatetype = "ushort)(double";
            else if(type == typeof(char))
                updatetype = "char)(double";
            else if(type == typeof(byte))
                updatetype = "byte)(double";
            else if(type == typeof(long))
                updatetype = "long)(double";
            else if(type == typeof(ulong))
                updatetype = "ulong)(double";

        return string.Format(
                kSpaceLine[space] + "object {0}_{1} = null;\xd\xa" +
                kSpaceLine[space] + "if({3}.TryGetValue(\"{1}\", out {0}_{1}))\xd\xa" +
                kSpaceLine[space] + "    {0}.{1} = ({2}){0}_{1};",
                            paramname, name,
                            updatetype, tablename);
        //}
    }

    static void WriteBeginComments()
    {
        __writer.WriteLine("    /// <summary>");
    }
    static void WriteComments(List<string> list)
    {
        foreach(var l in list)
            __writer.WriteLine("    /// " + l);
    }
    static void WriteEndComments()
    {
        __writer.WriteLine("    /// </summary>");
    }
    static void WriteComment(string comment)
    {
        if(comment != null)
            __writer.WriteLine("        //" + comment);
    }

    static StreamWriter __writer = null;
    static int __in_index = 0;
    static int __out_index = 1;
    static Dictionary<int, string> __dict_caststring;
    static Dictionary<int, Type> __dict_type;
    static List<string> __out_param;
    static bool __state_written = false;

    //==========================================================================
    static readonly string[] kSelectMethodScript = new string[] { 
@"    private static void {0}(Lua.Param pa)
    {{
        var typecode = pa.GetTypecode();",
@"        if(typecode == 0x{0}UL)
            {1}(pa);
        else",
@"        if(Lua.Param.Equal(typecode, 0x{0}UL))
            {1}(pa);
        else",
@"        {
#if UNITY_EDITOR
            throw new NotImplementedException(string.Format(""typecode=0x{0:X}"", typecode));
#endif
        }
    }"
};
    static string SelectMethod(string methodname, StreamWriter writer, List<string> methods)
    {
        if(methods == null || methods.Count <= 1)
            return methods[0];

        HashSet<string> set = new HashSet<string>();
        for(int i = 0; i < methods.Count; ++i)
        {
            var m = methods[i];
            var s = m.Split('_');
            var code = s[s.Length - 1];
            if(set.Contains(code))
                continue;
            set.Add(code);
        }
        if(set.Count == 1)
            return methods[0];
        set.Clear();

        var mn = methodname;
        var mi = mn.IndexOf("method_");
        if(mi > 0)
        {
            mn = methodname.Substring(mi + 7);
        }


        writer.WriteLine(kSelectMethodScript[0], methodname);
        for(int i=0; i<methods.Count; ++i)
        {
            var m = methods[i];
            var s = m.Split('_');
            var code = s[s.Length - 1];
            if(set.Contains(code))
                continue;
            set.Add(code);

            ulong icode = ulong.Parse(code, System.Globalization.NumberStyles.AllowHexSpecifier);
            writer.WriteLine("        // " + GetParamComment(mn, icode));

            if(code.IndexOf("F") < 0)
                writer.WriteLine(kSelectMethodScript[1], code, m);
            else
                writer.WriteLine(kSelectMethodScript[2], code, m);
        }
        writer.WriteLine(kSelectMethodScript[3]);
        return methodname;
    }
    //==========================================================================
    static readonly string[] kOpenLibScript = new string[]{
@"    public static Lua.Metatable OpenLib(Lua.State state)
    {
        Lua.Metatable metatable = null;",  
@"        var _{0} = state.newrefmetatable(new Dictionary<string, Lua.Ref>
        {{
            {{""__newindex"", state.newref(param=>{{}})}},",
@"            {{""{0}"", state.newref({1})}},",
@"        }});
        var {0} = state.newreftable();
        state.set_metatable({0}, _{0});",

@"        var {0} = state.newref({1});",
@"        var rt = state.get_table_ref_with_path(""{0}"");
        var _rt = state.newrefmetatable(new Dictionary<string, Lua.Ref>
        {{
            {{""__newindex"", state.newref(param=>{{}})}},",
@"            {{""{0}"", {1}}},",
@"            {{""{0}"", state.newref({1})}},",
@"        });
        state.set_metatable(rt, _rt);",
@"        var constructor_metatable = state.newrefmetatable(new Dictionary<string, Lua.Ref>{",
@"            {{""{0}"", {1}}},",
@"        });
        state.set_metatable(rt, constructor_metatable);",
@"        metatable = Lua.State.CreateMetatable(typeof({0}), 
            new Dictionary<string, Action<Lua.Param>>
        {{",
@"            {{""{0}"", {1}}},",
@"        }}, typeof({0}));",
@"        });",
@"        return metatable;  
    }",
};
    static void OpenLibMethod(StreamWriter writer,
                            Type type,
                            Dictionary<string, List<string>> enums,
                            Dictionary<string, string> table, 
                            Dictionary<string, string> metatable)
    {
        var typefullname = GetTypeName(type);

        writer.WriteLine(kOpenLibScript[0]);
        if(table.Count > 0 || enums.Count > 0)
        {
            foreach(var dv in enums)
            {
                writer.WriteLine(kOpenLibScript[1], dv.Key);
                var ss = dv.Key.Split('.');
                var s = ss[ss.Length - 1];
                var f = typefullname + "." + dv.Key + ".";
                foreach(var n in dv.Value)
                {
                    writer.WriteLine(kOpenLibScript[2], n, "(int)" + f + n);
                }
                writer.WriteLine(kOpenLibScript[3], dv.Key);
            }

            string constructor_methodname = null;
            table.TryGetValue("ConstructorRef", out constructor_methodname);
            if(!string.IsNullOrEmpty(constructor_methodname))
            {
                writer.WriteLine(kOpenLibScript[4], "constructor_ref", constructor_methodname);
                table.Remove("ConstructorRef");
            }
            var tablename = typefullname.Replace('<', '_');
            tablename = tablename.Replace('>', '_');
            writer.WriteLine(kOpenLibScript[5], tablename);

            if(!string.IsNullOrEmpty(constructor_methodname))
                writer.WriteLine(kOpenLibScript[6], "__call", "constructor_ref");
            foreach(var dv in enums)
            {
                writer.WriteLine(kOpenLibScript[6], dv.Key, dv.Key);
            }
            foreach(var dv in table)
            {
                writer.WriteLine(kOpenLibScript[7], dv.Key, dv.Value);
            }
            writer.WriteLine(kOpenLibScript[8]);

            //writer.WriteLine(kOpenLibScript[9]);
            //if(!string.IsNullOrEmpty(constructor_methodname))
            //    writer.WriteLine(kOpenLibScript[10], "__call", "constructor_ref");
            //writer.WriteLine(kOpenLibScript[11]);
        }

        if(metatable.Count > 0)
        {
            writer.WriteLine(kOpenLibScript[12], typefullname);
            //if(metatable.ContainsKey("*Get"))
            //{
            //    writer.WriteLine(kOpenLibScript[13], "__index", metatable["*Get"]);
            //    metatable.Remove("*Get");
            //}
            foreach(var dv in metatable)
            {
                writer.WriteLine(kOpenLibScript[13], dv.Key, dv.Value);
            }

            var basetype = type.BaseType;
            if(basetype != null)
            {
                while(basetype != null && skip_class.Contains(basetype))
                    basetype = basetype.BaseType;
            }
            if(basetype != null)
                writer.WriteLine(kOpenLibScript[14], GetTypeName(basetype));
            else
                writer.WriteLine(kOpenLibScript[15]);
        }

        writer.WriteLine(kOpenLibScript[kOpenLibScript.Length - 1]);
    }

    static void OpenLibMethod(StreamWriter writer, Type type, List<string> names)
    {
        var typename = GetTypeName(type);
        writer.WriteLine(kOpenLibScript[0]);

        writer.WriteLine(kOpenLibScript[5], typename);
        foreach(var name in names)
        {
            writer.WriteLine(kOpenLibScript[7], name, "(int)" + typename + "." + name);
        }
        writer.WriteLine(kOpenLibScript[8]);

        writer.WriteLine(kOpenLibScript[kOpenLibScript.Length - 1]);
    }

    //==========================================================================
    static string[] kWrapClassScript = new string[]
    {
@"// THIS IS A GENERATED FILE. PLEASE DO NOT MODIFY IT!
using System;
using System.Collections;
using System.Collections.Generic;

namespace Lua
{
public static partial class Wrap
{
    public static void InitMetatable(Lua.State state)
    {",
@"        state.register({0}.OpenLib);",
@"
    }
}
}"
    };
    public static void CreateWrapClassScript()
    {
        using(var writer = CreateFile(kGeneratedPath + "Wrap.cs"))
        {
            writer.WriteLine(kWrapClassScript[0]);
            for(int i = 0; i < class_list.Count; ++i)
            {
                var classname = class_list[i];
                writer.WriteLine(kWrapClassScript[1], classname);
            }
            writer.WriteLine(kWrapClassScript[2]);
        }
    }

    //==========================================================================
    static readonly char[] kPathSplitChars = new char[] { '\\', '/' };
    static StreamWriter CreateFile(string filename)
    {
        if(string.IsNullOrEmpty(filename))
            return null;

        var path = ".";
        var dirs = filename.Split(kPathSplitChars);
        for(int i = 0; i < dirs.Length - 1; ++i)
        {
            var dir = dirs[i];
            if(string.IsNullOrEmpty(dir))
                continue;
            path += "/" + dir;
            if(!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }
        path += "/" + dirs[dirs.Length - 1];

        return new StreamWriter(path, false, System.Text.Encoding.UTF8);
    }

    static ulong GetTypecode(ParameterInfo[] ps, ulong typecode_init)
    {
        if(ps == null || ps.Length == 0)
            return 0;

        ulong typecode = typecode_init;
        for(int i = 0; i < ps.Length; ++i)
        {
            var p = ps[i];
            var pt = p.ParameterType;
            if(pt.IsByRef)
                continue;
            ulong t = 0;
            if(pt == typeof(int) ||
                pt == typeof(short) ||
                pt == typeof(uint) ||
                pt == typeof(UInt16) ||
                pt == typeof(float) ||
                pt == typeof(double) ||
                pt.IsEnum)
                t = (ulong)Lua.Type.LUA_TNUMBER;
            else if(pt == typeof(string))
                t = (ulong)Lua.Type.LUA_TSTRING;
            else if(pt == typeof(bool))
                t = (ulong)Lua.Type.LUA_TBOOLEAN;
            else if(pt == typeof(UInt64))
                t = (ulong)Lua.Type.LUA_TUINT64;
            else if(pt == typeof(object))
                t = (ulong)Lua.Type.LUA_AUTOTYPE;
            else if(pt.IsValueType ||
                pt.GetInterface("System.Collections.IList") != null ||
                pt.GetInterface("System.Collections.IDictionary") != null)
                t = (ulong)Lua.Type.LUA_TTABLE;
            else if(pt.BaseType == typeof(System.MulticastDelegate))
                t = (ulong)Lua.Type.LUA_TFUNCTION;
            else
                t = (ulong)Lua.Type.LUA_TLIGHTUSERDATA;
            typecode = t + typecode * 0x10UL;
        }
        return typecode;
    }

    static List<string> GetParamlistComment(string declaring_name,
                                            string methodname,
                                            ParameterInfo[] ps, 
                                            ulong typecode_init)
    {
        List<string> param_typename_list = new List<string>();
        for(int i = 0; i < ps.Length; ++i)
        {
            var p = ps[i];
            var pt = p.ParameterType;
            if(pt.IsByRef)
                continue;
            if(pt == typeof(int) ||
                pt == typeof(short) ||
                pt == typeof(uint) ||
                pt == typeof(UInt16) ||
                pt == typeof(float) ||
                pt == typeof(double) ||
                pt.IsEnum)
                param_typename_list.Add("number");
            else if(pt == typeof(string))
                param_typename_list.Add("string");
            else if(pt == typeof(bool))
                param_typename_list.Add("boolean");
            else if(pt == typeof(UInt64))
                param_typename_list.Add("number");
            else if(pt == typeof(object))
                param_typename_list.Add("autotype");
            else if(pt.IsValueType ||
                pt.GetInterface("System.Collections.IList") != null ||
                pt.GetInterface("System.Collections.IDictionary") != null)
                param_typename_list.Add("table");
            else if(pt.BaseType == typeof(System.MulticastDelegate))
                param_typename_list.Add("function");
            else
                param_typename_list.Add("userdata");
        }

        List<string> retn = new List<string>();
        var temp = "function " + methodname + "(";
        if(typecode_init > 0)
        {
            temp += "self";
            if(param_typename_list.Count > 0)
                temp += ", ";
        }
        for(int i = 0; i < param_typename_list.Count; ++i)
        {
            var name = param_typename_list[i];
            temp = temp + name;
            if(i != param_typename_list.Count - 1)
                temp += ", ";
        }
        temp += ")";
        retn.Add(temp);

        var tempparam = "(";
        for(int i = 0; i < param_typename_list.Count; ++i)
        {
            var name = param_typename_list[i];
            tempparam = tempparam + name + (i + 1);
            if(i != param_typename_list.Count - 1)
                tempparam += ", ";
        }
        tempparam += ")";

        temp = "ex. ";
        if(typecode_init > 0)
        {
            temp += "self:" + methodname;
            retn.Add(temp + tempparam);
        }
        else
        {
            temp += declaring_name + "." + methodname;
            retn.Add(temp + tempparam);
            if(methodname == "Constructor")
            {
                temp = "ex. " + declaring_name;
                retn.Add(temp + tempparam);
            }
        }
        return retn;
    }

    static string GetParamComment(string methodname, ulong typecode)
    { 
        List<string> param_name_list = new List<string>();
        while(typecode != 0)
        {
            var code = typecode % 0x10;
            switch(code)
            { 
                case Lua.Constant.LUA_TNIL:
                    param_name_list.Add("nil");
                    break;
                case Lua.Constant.LUA_TBOOLEAN:
                    param_name_list.Add("boolean");
                    break;
                case Lua.Constant.LUA_TLIGHTUSERDATA:
                case Lua.Constant.LUA_TUSERDATA:
                    param_name_list.Add("userdata");
                    break;
                case Lua.Constant.LUA_TNUMBER:
                case Lua.Constant.LUA_TUINT64:
                    param_name_list.Add("number");
                    break;
                case Lua.Constant.LUA_TFUNCTION:
                    param_name_list.Add("function");
                    break;
                case Lua.Constant.LUA_TSTRING:
                    param_name_list.Add("string");
                    break;
                case Lua.Constant.LUA_TTABLE:
                    param_name_list.Add("table");
                    break;
                case 0xF:
                    param_name_list.Add("autotype");
                    break;
                default:
                    param_name_list.Add("unsupported");
                    break;
            }
            typecode = typecode / 0x10;
        }
        string pstr = "";
        for(int i = param_name_list.Count - 1; i >=0; --i)
        {
            pstr += param_name_list[i];
            if(i != 0)
                pstr += ", ";
        }
        return "function " + methodname + "(" + pstr + ")"; 
    }

    static string GetTypeName(Type type)
    {
        return Lua.State.GetTypeFullName(type);
    }

    static bool IsBaseType(Type type)
    {
        return 
            type == typeof(char) ||
            type == typeof(byte) ||
            type == typeof(int) ||
            type == typeof(uint) ||
            type == typeof(short) ||
            type == typeof(ushort) ||
            type == typeof(long) ||
            type == typeof(ulong) ||
            type.BaseType == typeof(System.Enum) ||
            type == typeof(string) ||
            type == typeof(float) ||
            type == typeof(bool) ||
            type == typeof(double);
    }

    static string GetParamTypeName(Type type)
    {
        if(type == typeof(int) ||
            type.BaseType == typeof(System.Enum))
            return "Integer";
        else if(type == typeof(uint))
            return "UInteger";
        else if(type == typeof(short))
            return "Short";
        else if(type == typeof(ushort))
            return "UShort";
        else if(type == typeof(string))
            return "String";
        else if(type == typeof(float))
            return "Float";
        else if(type == typeof(bool))
            return "Boolean";
        else if(type == typeof(double))
            return "Double";
        else if(type == typeof(char))
            return "Char";
        else if(type == typeof(byte))
            return "Byte";
        else if(type == typeof(long))
            return "Long";
        else if(type == typeof(ulong))
            return "ULong";
        else if(type == typeof(object))
            return "Oneobject";
        else if(type.BaseType == typeof(System.MulticastDelegate))
            return "Function";
        else if(type.IsValueType)
            return "Dictionary<string, object>";
        else if(type.BaseType == typeof(System.Array))
        {
            var t = type.GetElementType();
            return "Array<" + GetTypeName(t) + ">";
        }
        else if(type.GetInterface("System.Collections.IList") != null)
        {
            var t = type.GetGenericArguments()[0];
            return "List<" + GetTypeName(t) + ">";
        }
        else if(type.GetInterface("System.Collections.IDictionary") != null)
        {
            var args = type.GetGenericArguments();
            var left = args[0];
            var right = args[1];
            return "Dictionary<" + GetTypeName(left) + "," + GetTypeName(right) + ">";
        }
        else
        {
            string typename = Lua.State.GetTypeFullName(type);
            return "Userdata<" + typename + ">";
        }
    }

    static string GetParamTypePointerBaseType(Type type)
    {
        type = type.GetElementType();

        var fullname = type.FullName;
        if(type == typeof(int))
            return "int";
        if(type == typeof(uint))
            return "uint";
        if(type == typeof(short))
            return "short";
        if(type == typeof(ushort))
            return "ushort";
        if(type == typeof(char))
            return "char";
        if(type == typeof(byte))
            return "byte";
        if(type == typeof(long))
            return "long";
        if(type == typeof(ulong))
            return "ulong";
        else if(type == typeof(string))
            return "string";
        else if(type == typeof(float))
            return "float";
        else if(type == typeof(double))
            return "double";
        else if(type.BaseType == typeof(System.Array))
        {
            var t = type.GetElementType();
            return GetTypeName(t) + "[]";
        }
        else if(type.GetInterface("System.Collections.IList") != null)
        {
            var t = type.GetGenericArguments()[0];
            return "System.Collections.Generic.List<" + GetTypeName(t) + ">";
        }
        else if(type.GetInterface("System.Collections.IDictionary") != null)
        {
            var args = type.GetGenericArguments();
            var left = args[0];
            var right = args[1];
            return "System.Collections.Generic.Dictionary<"
                + GetTypeName(left) + "," + GetTypeName(right) + ">";
        }
        else
        {
            var str = type.UnderlyingSystemType.FullName;
            str = str.Split('`')[0].Replace('+', '.');

            var args = type.GetGenericArguments();
            if(args.Length > 0)
            {
                str += "<";
                for(int i = 0; i < args.Length; ++i)
                {
                    str += GetTypeName(args[i]);
                    if(i + 1 < args.Length)
                        str += ",";
                }
                str += ">";
            }
            return str;
        }
    }

    static string GetReflectTypeName(Type type, string concat)
    {
        string name = type.Name;
        var t = type.ReflectedType;
        while(t != null)
        {
            name = t.Name + concat + name;
            t = t.ReflectedType;
        }
        if(!string.IsNullOrEmpty(type.Namespace))
            name = type.Namespace + concat + name;
        return name;
    }

    static string GetHashCode(int code)
    {
        var a = (code >> 24) & 0xFF;
        var b = (code >> 16) & 0xFF;
        var c = (code >> 8) & 0xFF;
        var d = (code) & 0xFF;
        return a.ToString("X") +
                b.ToString("X") +
                c.ToString("X") +
                d.ToString("X");
    }

    static string GetCastTo(Type type)
    {
        if(type.BaseType == typeof(System.Enum))
            return "(int)";
        return "";
    }

    static string GetCastFrom(Type type)
    {
        if(type.BaseType == typeof(System.Enum))
            return "(" + GetTypeName(type) + ")";
        return "";
    }

    static string GetFirstCharUpper(string name)
    {
        var c = name[0];
        if('A' <= c && c <= 'Z')
            return name;
        return name.Substring(0, 1).ToUpper() + name.Substring(1);
    }
}

