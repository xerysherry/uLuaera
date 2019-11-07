using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class GenericHelper
{
    public static uint TickCount
    {
        get
        {
            return (uint)(DateTime.Now.Ticks / 10000);
        }
    }
    /// <summary>
    /// 获得子对象
    /// </summary>
    public static Component FindChildByName(System.Type type, GameObject obj,
                                            string childname, bool includeInactive = false)
    {
        if(!obj)
            return null;
        var list = obj.GetComponentsInChildren(type, includeInactive);
        foreach(var v in list)
        {
            if(v.name.CompareTo(childname) == 0)
                return v;
        }
        return null;
    }
    /// <summary>
    /// 获得子对象
    /// </summary>
    public static T FindChildByName<T>(GameObject obj, string childname, bool includeInactive = false) where T : Component
    {
        if(!obj)
            return null;
        var list = obj.GetComponentsInChildren<T>(includeInactive);
        foreach(var v in list)
        {
            if(v.name.CompareTo(childname) == 0)
                return v;
        }
        return null;
    }
    /// <summary>
    /// 标准化目录
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static string NormalizePath(string path)
    {
        var ps = path.Split('/', '\\');
        var n = "";
        for(int i = 0; i < ps.Length - 1; ++i)
        {
            var p = ps[i];
            if(string.IsNullOrEmpty(p))
                continue;
            n = string.Concat(n, p, '/');
        }
        if(ps.Length == 1)
            return ps[0];
        else if(ps.Length > 0)
            return n + ps[ps.Length - 1];
        return "";
    }

    /// <summary>
    /// 获得文件名
    /// </summary>
    /// <param name="filename"></param>
    /// <returns></returns>
    public static string GetFilename(string filepath)
    {
        if(string.IsNullOrEmpty(filepath))
            return filepath;

        filepath = NormalizePath(filepath);
        var index = filepath.IndexOf('/');
        if(index >= 0)
            filepath = filepath.Substring(index + 1, filepath.Length - index);

        index = filepath.IndexOf('.');
        if(index < 0)
            return filepath;
        return filepath.Substring(0, index);
    }

    public static string GetFolder(string filepath)
    {
        if(string.IsNullOrEmpty(filepath))
            return filepath;

        filepath = NormalizePath(filepath);
        var index = filepath.LastIndexOf('/');
        if(index < 0)
            return "";
        return filepath.Substring(0, index);
    }
    /// <summary>
    /// 后缀名
    /// </summary>
    /// <param name="filename"></param>
    /// <returns></returns>
    public static string GetSuffix(string filename)
    {
        int last_slash = filename.LastIndexOf('.');
        if(last_slash != -1)
            return filename.Substring(last_slash + 1);
        return filename;
    }
    public static string GetColorCode(Color color)
    {
        return string.Format("{0:x2}{1:x2}{2:x2}{3:x2}", 
            (int)(color.r * 255), (int)(color.g * 255), 
            (int)(color.b * 255), (int)(color.a * 255));
    }

    public class PointerClickListener : MonoBehaviour, IPointerClickHandler
    {
        public virtual void OnPointerClick(PointerEventData eventData)
        {
            var _callbacks1 = callbacks1;
            foreach(var callback in _callbacks1)
                callback();
            var _callbacks2 = callbacks2;
            foreach(var callback in _callbacks2)
                callback(eventData);
        }
        void OnDestroy()
        {
            callbacks1.Clear();
            callbacks2.Clear();
        }
        public HashSet<Action> callbacks1 = new HashSet<Action>();
        public HashSet<Action<PointerEventData>> callbacks2 = new HashSet<Action<PointerEventData>>();
    }
    /// <summary>
    /// 设置OnClick回调
    /// </summary>
    /// <param name="obj">设置回调的目标UI</param>
    /// <param name="callback">回调函数</param>
    public static void SetListenerOnClick(GameObject obj, Action callback)
    {
        if(!obj || callback == null)
            return;
        var l = obj.GetComponent<PointerClickListener>();
        if(!l)
            l = obj.AddComponent<PointerClickListener>();
        l.callbacks1.Add(callback);
    }
    public static void SetListenerOnClick(GameObject obj, Action<PointerEventData> callback)
    {
        if(!obj || callback == null)
            return;
        var l = obj.GetComponent<PointerClickListener>();
        if(!l)
            l = obj.AddComponent<PointerClickListener>();
        l.callbacks2.Add(callback);
    }
    public static void RemoveListenerOnClick(GameObject obj, Action callback)
    {
        if(!obj || callback == null)
            return;
        var l = obj.GetComponent<PointerClickListener>();
        if(!l)
            return;
        l.callbacks1.Remove(callback);
    }
    public static void RemoveListenerOnClick(GameObject obj, Action<PointerEventData> callback)
    {
        if(!obj || callback == null)
            return;
        var l = obj.GetComponent<PointerClickListener>();
        if(!l)
            return;
        l.callbacks2.Remove(callback);
    }
    public static void RemoveListenerOnClick(GameObject obj)
    {
        if(!obj)
            return;
        var l = obj.GetComponent<PointerClickListener>();
        if(!l)
            return;
        l.callbacks1 = new HashSet<Action>();
        l.callbacks2 = new HashSet<Action<PointerEventData>>();
    }
    class PointerUpListener : MonoBehaviour, IPointerUpHandler
    {
        public virtual void OnPointerUp(PointerEventData eventData)
        {
            foreach(var callback in callbacks)
                callback(eventData);
        }
        void OnDestroy()
        {
            callbacks.Clear();
        }
        public HashSet<Action<PointerEventData>> callbacks = new HashSet<Action<PointerEventData>>();
    }
    public static void SetListenerOnPointerUp(GameObject obj, Action<PointerEventData> callback)
    {
        if(!obj || callback == null)
            return;
        var l = obj.GetComponent<PointerUpListener>();
        if(!l)
            l = obj.AddComponent<PointerUpListener>();
        l.callbacks.Add(callback);
    }
    public static void RemoveListenerOnPointerUp(GameObject obj, Action<PointerEventData> callback)
    {
        if(!obj || callback == null)
            return;
        var l = obj.GetComponent<PointerUpListener>();
        if(!l)
            return;
        l.callbacks.Remove(callback);
    }
    public static void RemoveListenerOnPointerUp(GameObject obj)
    {
        if(!obj)
            return;
        var l = obj.GetComponent<PointerUpListener>();
        if(!l)
            return;
        l.callbacks.Clear();
    }
    //监听类
    class BeginDragListener : MonoBehaviour, IBeginDragHandler
    {
        public virtual void OnBeginDrag(PointerEventData eventData)
        {
            foreach(var callback in callbacks)
                callback(eventData);
        }
        void OnDestroy()
        {
            callbacks.Clear();
        }
        public HashSet<Action<PointerEventData>> callbacks = new HashSet<Action<PointerEventData>>();
    }
    class DragListener : MonoBehaviour, IDragHandler
    {
        public virtual void OnDrag(PointerEventData eventData)
        {
            foreach(var callback in callbacks)
                callback(eventData);
        }
        void OnDestroy()
        {
            callbacks.Clear();
        }
        public HashSet<Action<PointerEventData>> callbacks = new HashSet<Action<PointerEventData>>();
    }
    class EndDragListener : MonoBehaviour, IEndDragHandler
    {
        public virtual void OnEndDrag(PointerEventData eventData)
        {
            foreach(var callback in callbacks)
                callback(eventData);
        }
        void OnDestroy()
        {
            callbacks.Clear();
        }
        public HashSet<Action<PointerEventData>> callbacks = new HashSet<Action<PointerEventData>>();
    }
    /// <summary>
    /// 设置OnDrag回调
    /// </summary>
    /// <param name="obj">设置回调的目标UI</param>
    /// <param name="callback">回调函数</param>
    public static void SetListenerOnDrag(GameObject obj, Action<PointerEventData> callback)
    {
        if(!obj || callback == null)
            return;
        var l = obj.GetComponent<DragListener>();
        if(!l)
            l = obj.AddComponent<DragListener>();
        l.callbacks.Add(callback);
    }
    public static void RemoveListenerOnDrag(GameObject obj, Action<PointerEventData> callback)
    {
        if(!obj || callback == null)
            return;
        var l = obj.GetComponent<DragListener>();
        if(!l)
            return;
        l.callbacks.Remove(callback);
    }
    public static void RemoveListenerOnDrag(GameObject obj)
    {
        if(!obj)
            return;
        var l = obj.GetComponent<DragListener>();
        if(!l)
            return;
        l.callbacks.Clear();
    }
    /// <summary>
    /// 设置OnBeginDrag回调
    /// </summary>
    /// <param name="obj">设置回调的目标UI</param>
    /// <param name="callback">回调函数</param>
    public static void SetListenerOnBeginDrag(GameObject obj, Action<PointerEventData> callback)
    {
        if(!obj || callback == null)
            return;
        var l = obj.GetComponent<BeginDragListener>();
        if(!l)
            l = obj.AddComponent<BeginDragListener>();
        l.callbacks.Add(callback);
    }
    public static void RemoveListenerOnBeginDrag(GameObject obj, Action<PointerEventData> callback)
    {
        if(!obj || callback == null)
            return;
        var l = obj.GetComponent<BeginDragListener>();
        if(!l)
            return;
        l.callbacks.Remove(callback);
    }
    public static void RemoveListenerOnBeginDrag(GameObject obj)
    {
        if(!obj)
            return;
        var l = obj.GetComponent<BeginDragListener>();
        if(!l)
            return;
        l.callbacks.Clear();
    }
    /// <summary>
    /// 设置OnEndDrag回调
    /// </summary>
    /// <param name="obj">设置回调的目标UI</param>
    /// <param name="callback">回调函数</param>
    public static void SetListenerOnEndDrag(GameObject obj, Action<PointerEventData> callback)
    {
        if(!obj || callback == null)
            return;
        var l = obj.GetComponent<EndDragListener>();
        if(!l)
            l = obj.AddComponent<EndDragListener>();
        l.callbacks.Add(callback);
    }
    public static void RemoveListenerOnEndDrag(GameObject obj, Action<PointerEventData> callback)
    {
        if(!obj || callback == null)
            return;
        var l = obj.GetComponent<EndDragListener>();
        if(!l)
            return;
        l.callbacks.Remove(callback);
    }
    public static void RemoveListenerOnEndDrag(GameObject obj)
    {
        if(!obj)
            return;
        var l = obj.GetComponent<EndDragListener>();
        if(!l)
            return;
        l.callbacks.Clear();
    }

    class ScrollListener : MonoBehaviour, IScrollHandler
    {
        public void OnScroll(PointerEventData eventData)
        {
            foreach(var callback in callbacks)
                callback(eventData);
        }
        void OnDestroy()
        {
            callbacks.Clear();
        }
        public HashSet<Action<PointerEventData>> callbacks = new HashSet<Action<PointerEventData>>();
    }
    public static void SetListenerOnScroll(GameObject obj, Action<PointerEventData> callback)
    {
        if(!obj || callback == null)
            return;
        var l = obj.GetComponent<ScrollListener>();
        if(!l)
            l = obj.AddComponent<ScrollListener>();
        l.callbacks.Add(callback);
    }
    public static void RemoveListenerOnScroll(GameObject obj, Action<PointerEventData> callback)
    {
        if(!obj || callback == null)
            return;
        var l = obj.GetComponent<ScrollListener>();
        if(!l)
            return;
        l.callbacks.Remove(callback);
    }
    public static void RemoveListenerOnScroll(GameObject obj)
    {
        if(!obj)
            return;
        var l = obj.GetComponent<ScrollListener>();
        if(!l)
            return;
        l.callbacks.Clear();
    }

    class PointerEnterListener : MonoBehaviour, IPointerEnterHandler
    {
        public void OnPointerEnter(PointerEventData eventData)
        {
            foreach(var callback in callbacks)
                callback(eventData);
        }
        public HashSet<Action<PointerEventData>> callbacks = new HashSet<Action<PointerEventData>>();
    }
    class PointerExitListener : MonoBehaviour, IPointerExitHandler
    {
        public void OnPointerExit(PointerEventData eventData)
        {
            foreach(var callback in callbacks)
                callback(eventData);
        }
        public HashSet<Action<PointerEventData>> callbacks = new HashSet<Action<PointerEventData>>();
    }

    public static void SetListenerOnPointerEnter(GameObject obj, Action<PointerEventData> callback)
    {
        if(!obj || callback == null)
            return;
        var l = obj.GetComponent<PointerEnterListener>();
        if(!l)
            l = obj.AddComponent<PointerEnterListener>();
        l.callbacks.Add(callback);
    }
    public static void RemoveListenerOnPointerEnter(GameObject obj, Action<PointerEventData> callback)
    {
        if(!obj || callback == null)
            return;
        var l = obj.GetComponent<PointerEnterListener>();
        if(!l)
            return;
        l.callbacks.Remove(callback);
    }
    public static void RemoveListenerOnPointerEnter(GameObject obj)
    {
        if(!obj)
            return;
        var l = obj.GetComponent<PointerEnterListener>();
        if(!l)
            return;
        l.callbacks.Clear();
    }
    public static void SetListenerOnPointerExit(GameObject obj, Action<PointerEventData> callback)
    {
        if(!obj || callback == null)
            return;
        var l = obj.GetComponent<PointerEnterListener>();
        if(!l)
            l = obj.AddComponent<PointerEnterListener>();
        l.callbacks.Add(callback);
    }
    public static void RemoveListenerOnPointerExi(GameObject obj, Action<PointerEventData> callback)
    {
        if(!obj || callback == null)
            return;
        var l = obj.GetComponent<PointerEnterListener>();
        if(!l)
            return;
        l.callbacks.Remove(callback);
    }
    public static void RemoveListenerOnPointerExi(GameObject obj)
    {
        if(!obj)
            return;
        var l = obj.GetComponent<PointerEnterListener>();
        if(!l)
            return;
        l.callbacks.Clear();
    }

    class CoroutineHelper : MonoBehaviour
    {
        public static CoroutineHelper instance
        {
            get
            {
                if(!instance_)
                {
                    var obj = new GameObject();
                    obj.name = "CoroutineHelper";
                    instance_ = obj.AddComponent<CoroutineHelper>();
                }
                return instance_;
            }
        }
        static CoroutineHelper instance_ = null;

        public Coroutine DoCoroutine(System.Collections.IEnumerator e)
        {
            return StartCoroutine(e);
        }
    }
    /// <summary>
    /// 开启协程，方便在非MonoBehaviour对象中使用协程
    /// </summary>
    public static Coroutine StartCoroutine(System.Collections.IEnumerator e)
    {
        return CoroutineHelper.instance.DoCoroutine(e);
    }
    public static void StopAllCoroutines()
    {
        CoroutineHelper.instance.StopAllCoroutines();
    }
    public static void StopCoroutine(Coroutine co)
    {
        CoroutineHelper.instance.StopCoroutine(co);
    }

    //    public static List<string> GetFiles(string search, string extension, SearchOption option)
    //    {
    //        var files = Directory.GetFiles(search, "*.???", option);
    //        var result = new List<string>();
    //        foreach(var file in files)
    //        {
    //            string ext = Path.GetExtension(file);
    //            if(string.Compare(ext, extension, true) == 0)
    //                result.Add(file);
    //        }
    //        return result;
    //    }
    //    public static List<string> GetFiles(string search, string[] extensions, SearchOption option)
    //    {
    //        var extension_checker = new HashSet<string>();
    //        for(int i = 0; i < extensions.Length; ++i)
    //            extension_checker.Add(extensions[i].ToUpper());

    //        var files = Directory.GetFiles(search, "*.???", option);
    //        var result = new List<string>();
    //        foreach(var file in files)
    //        {
    //            string ext = Path.GetExtension(file).ToUpper();
    //            if(extension_checker.Contains(ext))
    //                result.Add(file);
    //        }
    //        return result;
    //    }
    //    public static Dictionary<string, string> GetContentFiles()
    //    {
    //        if(content_files != null)
    //            return content_files;
    //        content_files = new Dictionary<string, string>();

    //        var contentdir = MinorShift._Library.Sys.ExeDir + "resources/";
    //        if(!Directory.Exists(contentdir))
    //            return content_files;

    //        List<string> bmpfilelist = new List<string>();
    //        bmpfilelist.AddRange(Directory.GetFiles(contentdir, "*.png", SearchOption.TopDirectoryOnly));
    //        bmpfilelist.AddRange(Directory.GetFiles(contentdir, "*.bmp", SearchOption.TopDirectoryOnly));
    //        bmpfilelist.AddRange(Directory.GetFiles(contentdir, "*.jpg", SearchOption.TopDirectoryOnly));
    //        bmpfilelist.AddRange(Directory.GetFiles(contentdir, "*.gif", SearchOption.TopDirectoryOnly));
    //#if(UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
    //            bmpfilelist.AddRange(Directory.GetFiles(contentdir, "*.PNG", SearchOption.TopDirectoryOnly));
    //            bmpfilelist.AddRange(Directory.GetFiles(contentdir, "*.BMP", SearchOption.TopDirectoryOnly));
    //            bmpfilelist.AddRange(Directory.GetFiles(contentdir, "*.JPG", SearchOption.TopDirectoryOnly));
    //            bmpfilelist.AddRange(Directory.GetFiles(contentdir, "*.GIF", SearchOption.TopDirectoryOnly));
    //#endif
    //        foreach(var filename in bmpfilelist)
    //        {
    //            string name = Path.GetFileName(filename).ToUpper();
    //            content_files.Add(name, filename);
    //        }
    //        return content_files;
    //    }
    //    public static string[] GetResourceCSVLines(
    //        string csvpath, System.Text.Encoding encoding)
    //    {
    //        string[] lines = null;
    //        if(resource_csv_lines_ != null &&
    //            resource_csv_lines_.TryGetValue(csvpath, out lines))
    //            return lines;
    //        lines = File.ReadAllLines(csvpath, encoding);
    //        return lines;
    //    }
    //    public static void ResourcePrepare()
    //    {
    //        var content_files = GetContentFiles();
    //        if(content_files.Count == 0)
    //            return;

    //        var contentdir = MinorShift._Library.Sys.ExeDir + "resources/";
    //        List<string> csvFiles = new List<string>(Directory.GetFiles(
    //            contentdir, "*.csv", SearchOption.TopDirectoryOnly));
    //#if(UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
    //            csvFiles.AddRange(Directory.GetFiles(
    //                contentdir, "*.CSV", SearchOption.TopDirectoryOnly));
    //#endif
    //        resource_csv_lines_ = new Dictionary<string, string[]>();

    //        var encoder = MinorShift.Emuera.Config.Encode;
    //        foreach(var filename in csvFiles)
    //        {
    //            //SpriteManager.ClearResourceCSVLines(filename);
    //            string[] lines = SpriteManager.GetResourceCSVLines(filename);
    //            if(lines != null)
    //            {
    //                resource_csv_lines_.Add(filename, lines);
    //                continue;
    //            }

    //            List<string> newlines = new List<string>();
    //            lines = File.ReadAllLines(filename, encoder);
    //            int fixcount = 0;
    //            for(int i = 0; i < lines.Length; ++i)
    //            {
    //                var line = lines[i];
    //                if(line.Length == 0)
    //                    continue;
    //                string str = line.Trim();
    //                if(str.Length == 0 || str.StartsWith(";"))
    //                    continue;

    //                string[] tokens = str.Split(',');
    //                if(tokens.Length > 4)
    //                {
    //                    if(!string.IsNullOrEmpty(tokens[2]) &&
    //                        !string.IsNullOrEmpty(tokens[3]))
    //                    {
    //                        newlines.Add(line);
    //                        continue;
    //                    }
    //                }

    //                string name = tokens[1].ToUpper();
    //                string imagepath = null;
    //                content_files.TryGetValue(name, out imagepath);
    //                if(imagepath == null)
    //                    continue;

    //                var ti = SpriteManager.GetTextureInfo(name, imagepath);
    //                if(ti == null)
    //                    continue;
    //                line = string.Format("{0},{1},0,0,{2},{3}",
    //                    tokens[0], tokens[1], ti.width, ti.height);
    //                newlines.Add(line);
    //                fixcount += 1;
    //            }
    //            lines = newlines.ToArray();
    //            resource_csv_lines_.Add(filename, lines);
    //            if(fixcount > 0)
    //                SpriteManager.SetResourceCSVLine(filename, lines);
    //        }
    //    }
    //    public static void ResourceClear()
    //    {
    //        if(content_files != null)
    //        {
    //            content_files.Clear();
    //            content_files = null;
    //        }
    //        if(resource_csv_lines_ != null)
    //        {
    //            resource_csv_lines_.Clear();
    //            resource_csv_lines_ = null;
    //        }
    //    }
    //    static Dictionary<string, string> content_files = null;
    //    static Dictionary<string, string[]> resource_csv_lines_ = null;
}