using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpriteBase
{
    public SpriteBase(string name)
    {
        _name = name;
    }

    public string name { get { return _name; } }
    string _name;

    public abstract int GetWidth();
    public abstract int GetHeight();
}

public class SpriteImage : SpriteBase
{
    public SpriteImage(string name, Rect rect, Vector4 border, ResourceInfo resinfo)
        :base(name)
    {
        this.rect = rect;
        this.border = border;
        this.resinfo = resinfo;

        sliced = border.x != 0
            || border.y != 0
            || border.z != 0
            || border.w != 0;
    }
    public readonly ResourceInfo resinfo;
    public readonly bool sliced;
    public Rect rect;
    public Vector4 border;
    public int width
    {
        get { return (int)rect.width; }
        set { rect.width = value; }
    }
    public int height
    {
        get { return (int)rect.height; }
        set { rect.height = value; }
    }

    public override int GetWidth()
    {
        return width;
    }

    public override int GetHeight()
    {
        return height;
    }
}

public class SpriteAnimation : SpriteBase
{
    public SpriteAnimation(string name)
        :base(name)
    { }
    public class Frame
    {
        public SpriteImage sprite;
        public float time;
        public string name { get { return sprite.name; } }
        public ResourceInfo resinfo { get { return sprite.resinfo; } }
        public Rect rect { get { return sprite.rect; } }
        public int width { get { return sprite.width; } }
        public int height { get { return sprite.height; } }
    }
    public List<Frame> frames = new List<Frame>();
    public Frame firstframe { get { return frames[0]; } }
    public int width { get { return firstframe.width; } }
    public int height { get { return firstframe.height; } }
    public float fps;

    public override int GetWidth()
    {
        return width;
    }

    public override int GetHeight()
    {
        return height;
    }
}


public static class SpriteManager
{
    static float kPastTime = 300.0f;

    public class SpriteInfo : IDisposable
    {
        internal SpriteInfo(TextureInfo p, Sprite s)
        {
            parent = p;
            sprite = s;
        }
        public void Dispose()
        {
            UnityEngine.Object.Destroy(sprite);
            sprite = null;
        }
        internal Sprite sprite;
        internal TextureInfo parent;
    }
    public class TextureInfo : IDisposable
    {
        internal TextureInfo(string b, Texture2D tex)
        {
            imagename = b;
            texture = tex;
            pasttime = Time.unscaledTime + kPastTime;
        }
        internal SpriteInfo GetSprite(SpriteImage src)
        {
            SpriteInfo sprite = null;
            if(!sprites.TryGetValue(src.name, out sprite))
            {
                if(src.width == 0)
                    src.width = texture.width;
                if(src.height == 0)
                    src.height = texture.height;
                sprite = new SpriteInfo(this, 
                    Sprite.Create(texture, src.rect, Vector2.zero, 100, 0, 
                    SpriteMeshType.FullRect, src.border != null ? src.border : Vector4.zero, false));
                sprites.Add(src.name, sprite);
            }
            if(sprite != null)
                refcount += 1;
            return sprite;
        }
        internal void Release()
        {
            refcount -= 1;
            pasttime = Time.unscaledTime + kPastTime;
        }
        public void Dispose()
        {
            foreach(var kv in sprites)
            {
                kv.Value.Dispose();
            }
            sprites.Clear();
            sprites = null;

            UnityEngine.Object.Destroy(texture);
            texture = null;
        }
        internal string imagename = null;
        internal int refcount = 0;
        internal float pasttime = 0;
        internal float width { get { return texture.width; } }
        internal float height { get { return texture.height; } }
        internal Texture2D texture = null;
        Dictionary<string, SpriteInfo> sprites = new Dictionary<string, SpriteInfo>();
    }
    class CallbackInfo
    {
        public CallbackInfo(SpriteImage src, object obj, 
                            Action<object, SpriteImage, SpriteInfo> callback)
        {
            this.src = src;
            this.obj = obj;
            this.callback = callback;
        }
        public void DoCallback(SpriteInfo info)
        {
            callback(obj, src, info);
        }
        public SpriteImage src;
        object obj;
        Action<object, SpriteImage, SpriteInfo> callback;
    }

    public static void SetSpriteImage(string name, string file, List<float> rect, List<float> border, bool hidden = false)
    {
        var res = new ResourceInfo(file);
        if(rect == null)
            rect = new List<float> { 0,0,0,0 };
        while(rect.Count < 4)
        {
            rect.Add(0);
            rect.Add(0);
        }
        var si = new SpriteImage(name, new Rect(rect[0], rect[1], rect[2], rect[3]),
            border == null ? Vector4.zero : new Vector4(border[0], border[1], border[2], border[3]), res);
        sprite_images[name] = si;
        if(!hidden)
            sprites[name] = si;
    }
    public static void SetSpriteImage(string name, string file, Rect rect, Vector4 border, bool hidden = false)
    {
        var res = new ResourceInfo(file);
        var si = new SpriteImage(name, rect, border, res);
        sprite_images[name] = si;
        if (!hidden)
            sprites[name] = si;
    }
    public static SpriteImage GetSpriteImage(string name)
    {
        SpriteImage si = null;
        sprite_images.TryGetValue(name, out si);
        if(si == null)
            return null;
        if(si.width == 0 || si.height == 0)
            Loading(si);
        return si;
    }
    static Dictionary<string, SpriteImage> sprite_images = new Dictionary<string, SpriteImage>();

    public static void SetSpriteAnimation(string name, float fps, List<List<object>> spritenames)
    {
        var sa = new SpriteAnimation(name);
        sa.fps = fps;

        var frame = 0;
        for (var i = 0; i < spritenames.Count; ++i)
        {
            var kv = spritenames[i];
            var df = (double)kv[1];
            var f = (int)df;
            if (f == 0)
                continue;
            var n = (string)kv[0];
            var s = GetSpriteImage(n);
            if (s == null)
                continue;

            frame += f;
            var fr = new SpriteAnimation.Frame
            {
                sprite = s,
                time = frame / fps,
            };
            sa.frames.Add(fr);
        }
        sprite_animations[name] = sa;
        sprites[name] = sa;
    }
    public static SpriteAnimation GetSpriteAnimation(string name)
    {
        SpriteAnimation sa = null;
        sprite_animations.TryGetValue(name, out sa);
        if (sa == null)
            return null;
        if (sa.width == 0 || sa.height == 0)
            Loading(sa.firstframe.sprite);
        return sa;
    }
    static Dictionary<string, SpriteAnimation> sprite_animations = new Dictionary<string, SpriteAnimation>();

    public static SpriteBase GetSpriteBase(string name)
    {
        SpriteBase sb = null;
        sprites.TryGetValue(name, out sb);
        if (sb == null)
            return null;
        TryLoad(sb);
        return sb;
    }
    public static bool CheckSpriteBase(string name)
    {
        return sprites.ContainsKey(name);
    }
    static void TryLoad(SpriteBase b)
    {
        if (b is SpriteAnimation)
        {
            var sa = b as SpriteAnimation;
            if (sa.width == 0 || sa.height == 0)
                Loading(sa.firstframe.sprite);
        }
        else if (b is SpriteImage)
        {
            var si = b as SpriteImage;
            if (si.width == 0 || si.height == 0)
                Loading(si);
        }
    }
    static Dictionary<string, SpriteBase> sprites = new Dictionary<string, SpriteBase>();

    public static void Init()
    {
#if UNITY_EDITOR
        kPastTime = 300.0f;
        GenericHelper.StartCoroutine(Update());
#else
        var memorysize = SystemInfo.systemMemorySize;
        if(memorysize <= 4096)
        {
            kPastTime = 300.0f;
            GenericHelper.StartCoroutine(Update());
        }
        else if(memorysize <= 8192)
        {
            kPastTime = 600.0f;
            GenericHelper.StartCoroutine(Update());
        }
        else
        {
            //
        }
#endif
    }
    public static void GetSprite(string name,
                                object obj, Action<object, SpriteImage, SpriteInfo> callback)
    {
        var si = GetSpriteImage(name);
        if(si == null)
            si = GetSpriteImage("@ERROR");
        GetSprite(si, obj, callback);
    }
    public static void GetSprite(SpriteImage src, 
                                object obj, Action<object, SpriteImage, SpriteInfo> callback)
    {
        if(src == null)
            return;

        var basename = src.resinfo.filepath;
        TextureInfo ti = null;
        texture_dict.TryGetValue(basename, out ti);
        if(ti == null)
        {
            var item = new CallbackInfo(src, obj, callback);
            List<CallbackInfo> list = null;
            if(loading_set.TryGetValue(basename, out list))
                list.Add(item);
            else
            {
                list = new List<CallbackInfo> { item };
                loading_set.Add(basename, list);
                GenericHelper.StartCoroutine(LoadingAsync(src.resinfo));
            }
        }
        else
            callback(obj, src, GetSpriteInfo(ti, src));
    }

    public static void GetSpriteSync(SpriteImage src,
                                object obj, Action<object, SpriteImage, SpriteInfo> callback)
    {
        if (src == null)
            return;

        var basename = src.resinfo.filepath;
        TextureInfo ti = null;
        texture_dict.TryGetValue(basename, out ti);
        if (ti == null)
        {
            var item = new CallbackInfo(src, obj, callback);
            List<CallbackInfo> list = null;
            if (loading_set.TryGetValue(basename, out list))
                list.Add(item);
            else
            {
                list = new List<CallbackInfo> { item };
                loading_set.Add(basename, list);
                Loading(src);
            }
        }
        else
            callback(obj, src, GetSpriteInfo(ti, src));
    }

    //public static TextureInfo GetTextureInfo(string name, string filename)
    //{
    //    TextureInfo ti = null;
    //    if(texture_dict.TryGetValue(name, out ti))
    //        return ti;
    //    if(string.IsNullOrEmpty(filename))
    //        return null;

    //    FileInfo fi = new FileInfo(filename);
    //    if(!fi.Exists)
    //        return null;

    //    FileStream fs = fi.OpenRead();
    //    var filesize = fs.Length;
    //    byte[] content = new byte[filesize];
    //    fs.Read(content, 0, (int)filesize);

    //    TextureFormat format = TextureFormat.DXT1;
    //    if(GenericHelper.GetSuffix(filename).ToLower() == "png")
    //        format = TextureFormat.DXT5;

    //    var tex = new Texture2D(4, 4, format, false);
    //    if(tex.LoadImage(content))
    //    {
    //        ti = new TextureInfo(name, tex);
    //        texture_dict.Add(name, ti);
    //    }
    //    return ti;
    //}

    static IEnumerator LoadingAsync(ResourceInfo res)
    {
        TextureInfo ti = null;
        if (res.location == Config.Location.FILE_SYSTEM)
        {
            FileInfo fi = new FileInfo(res.filepath);
            if (fi.Exists)
            {
                FileStream fs = fi.OpenRead();
                var filesize = fs.Length;
                byte[] content = new byte[filesize];

                var async = fs.BeginRead(content, 0, (int)filesize, null, null);
                while (!async.IsCompleted)
                    yield return null;

                TextureFormat format = TextureFormat.DXT1;
                if (GenericHelper.GetSuffix(res.filepath).ToLower() == "png")
                    format = TextureFormat.DXT5;

                var tex = new Texture2D(4, 4, format, false);
                if (tex.LoadImage(content))
                {
                    ti = new TextureInfo(res.filepath, tex);
                    texture_dict.Add(res.filepath, ti);
                }
            }
        }
        else if (res.location == Config.Location.PACKAGE)
        {
            var request = Resources.LoadAsync<Texture2D>(res.filepath);
            while (!request.isDone)
                yield return null;
            var t = request.asset as Texture2D;
            if (t)
            {
                ti = new TextureInfo(res.filepath, t);
                texture_dict.Add(res.filepath, ti);
            }
        }
        //else if (res.location == Config.Location.ASSET_BUNDLE)
        //{}

        var list = loading_set[res.filepath];
        foreach(var item in list)
        {
            item.DoCallback(GetSpriteInfo(ti, item.src));
        }
        list.Clear();
        loading_set.Remove(res.filepath);

    }
    static void Loading(SpriteImage img)
    {
        TextureInfo ti = null;
        var res = img.resinfo;

        if (res.location == Config.Location.FILE_SYSTEM)
        {
            FileInfo fi = new FileInfo(res.filepath);
            if (fi.Exists)
            {
                FileStream fs = fi.OpenRead();
                var filesize = fs.Length;
                byte[] content = new byte[filesize];
                fs.Read(content, 0, (int)filesize);
                fs.Close();

                TextureFormat format = TextureFormat.DXT1;
                if (GenericHelper.GetSuffix(res.filepath).ToLower() == "png")
                    format = TextureFormat.DXT5;

                var tex = new Texture2D(4, 4, format, false);
                if (tex.LoadImage(content))
                {
                    ti = new TextureInfo(res.filepath, tex);
                    texture_dict.Add(res.filepath, ti);
                }

                if (img.width == 0)
                    img.width = tex.width;
                if (img.height == 0)
                    img.height = tex.height;
            }
        }
        else if (res.location == Config.Location.PACKAGE)
        {
            var t= Resources.Load<Texture2D>(res.filepath);
            if (t)
            {
                ti = new TextureInfo(res.filepath, t);
                texture_dict.Add(res.filepath, ti);
            }
        }

        var list = loading_set[res.filepath];
        foreach (var item in list)
        {
            item.DoCallback(GetSpriteInfo(ti, item.src));
        }
        list.Clear();
        loading_set.Remove(res.filepath);
    }
    static SpriteInfo GetSpriteInfo(TextureInfo textinfo, SpriteImage src)
    {
        return textinfo.GetSprite(src);
    }
    public static void GivebackSpriteInfo(SpriteInfo info)
    {
        if(info == null)
            return;
        info.parent.Release();
    }
    static IEnumerator Update()
    {
        while(true)
        {
            do
            {
                yield return new WaitForSeconds(15.0f);
            } while(texture_dict.Count == 0);

            var now = Time.unscaledTime;
            TextureInfo tinfo = null;
            foreach(var ti in texture_dict.Values)
            {
                if(ti.refcount == 0 && now > ti.pasttime)
                {
                    tinfo = ti;
                    break;
                }
            }
            if(tinfo != null)
            {
                Debug.Log("Unload Texture " + tinfo.imagename);

                tinfo.Dispose();
                texture_dict.Remove(tinfo.imagename);
                tinfo = null;

                GC.Collect();
            }
        }
    }
    public static void ForceClear()
    {
        foreach(var ti in texture_dict.Values)
        {
            ti.Dispose();
        }
        texture_dict.Clear();
        GC.Collect();
    }
    static Dictionary<string, List<CallbackInfo>> loading_set =
        new Dictionary<string, List<CallbackInfo>>();
    static Dictionary<string, TextureInfo> texture_dict =
        new Dictionary<string, TextureInfo>();
}
