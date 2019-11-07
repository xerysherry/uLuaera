using UnityEngine;
using System;
using System.Collections;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace Lua
{
    public static class Resource
    {
        /// <summary>
        /// Lua发布代码文件夹
        /// </summary>
        static readonly string kLuaScriptResourcePath = "auL";
        /// <summary>
        /// Lua调试代码文件夹
        /// </summary>
        public static readonly string kLuaScriptRuntimePath = "/Lua";
        public static readonly string kLuaScriptDevelopmentPath = "/LuaDevelopment";

#if UNITY_EDITOR
        static void CreatePath(string path)
        {
            if(Directory.Exists(path))
                return;
            CreatePath(Path.GetDirectoryName(path));
            Directory.CreateDirectory(path);
        }

        public static void Deploy(string name)
        {
            var debug_path = Application.dataPath + name;
            var resources_path = Application.dataPath + "/Resources";
            var deploy_path = resources_path + "/" +  kLuaScriptResourcePath;

            //if(Directory.Exists(deploy_path))
            //{
            //    DirectoryInfo deploy_di = new DirectoryInfo(deploy_path);
            //    deploy_di.Delete(true);
            //}

            FileInfo[] fileinfos = null;
            DirectoryInfo di = new DirectoryInfo(debug_path);
            var debug_path_length = di.FullName.Length;
            if(di != null)
                fileinfos = di.GetFiles("*", SearchOption.AllDirectories);

            foreach(var fi in fileinfos)
            {
                var suffix = Path.GetExtension(fi.FullName);
                if(suffix.ToLower() != ".lua")
                    continue;
                var filepath = fi.FullName.Substring(debug_path_length);
                filepath = Path.GetDirectoryName(filepath);
                var filename = Path.GetFileName(fi.FullName);
                filename = Path.GetFileNameWithoutExtension(filename);
                byte[] bytes = null;
                using(var s = new StreamReader(fi.FullName))
                {
                    var b = s.ReadToEnd();
                    bytes = LZMA.Compress(Encoding.UTF8.GetBytes(b));
                }
                var path = deploy_path + "/" + filepath;
                DeployFile(path, filename, bytes);
            }
        }

        static void DeployFile(string path, string name, byte[] bytes)
        {
            CreatePath(path);
            using(var s = new FileStream(path + "/" + name + ".bytes",
                                            FileMode.Create))
            {
                s.Write(bytes, 0, bytes.Length);
            }
        }
#endif

        static string LoadScript(string name, string fullpath)
        {
            if(File.Exists(fullpath))
            {
                //Debug.Log("Exist");
                try
                {
                    var fs = new StreamReader(fullpath, Encoding.UTF8);
                    var script = fs.ReadToEnd();
                    fs.Close();
                    fs.Dispose();
                    include_files[name] = script;
                    return script;
                }
                catch(System.Exception e)
                { }
            }
            return null;
        }

        public static string Load(string name)
        {
            string script = null;

            var index = name.IndexOf("(Clone)");
            if(index >= 0)
                name = name.Substring(0, index);

            if(include_files.TryGetValue(name, out script))
                return script;

            var fullpath = string.Concat(script_path, kLuaScriptRuntimePath, "/", name, ".lua");
            script = LoadScript(name, fullpath);
            if(!string.IsNullOrEmpty(script))
                return script;

#if UNITY_EDITOR
            fullpath = string.Concat(script_path, kLuaScriptDevelopmentPath, "/", name, ".lua");
            script = LoadScript(name, fullpath);
            if(!string.IsNullOrEmpty(script))
                return script;
#endif

            var ta = Resources.Load<TextAsset>(string.Concat(kLuaScriptResourcePath, "/", name));
            if(ta == null)
            {
                include_files[name] = null;
                return null;
            }

            var bytes = LZMA.Decompress(ta.bytes);
            script = Encoding.UTF8.GetString(bytes);
            include_files[name] = script;
            return script;
        }
        public static void SetScriptPath(string path)
        {
            script_path = path;
        }
        public static List<string> EnumScripts(string path)
        {
            if (string.IsNullOrEmpty(path))
                path = "";

            List<string> list = new List<string>();
            var fullpath = string.Concat(script_path, kLuaScriptRuntimePath, "/",  path);
            var files = Directory.GetFiles(fullpath, "*.lua", SearchOption.AllDirectories);
            for (var i = 0; i < files.Length; ++i)
            {
                files[i] = files[i].Substring(fullpath.Length, files[i].Length - fullpath.Length - 4);
            }
            list.AddRange(files);

            fullpath = string.Concat(script_path, kLuaScriptDevelopmentPath, "/", path);
            files = Directory.GetFiles(fullpath, "*.lua", SearchOption.AllDirectories);
            for (var i = 0; i < files.Length; ++i)
            {
                files[i] = files[i].Substring(fullpath.Length, files[i].Length - fullpath.Length - 4);
            }
            list.AddRange(files);

            return list;
        }
        static string script_path = Application.dataPath;
        static Dictionary<string, string> include_files = new Dictionary<string, string>();
    }
}