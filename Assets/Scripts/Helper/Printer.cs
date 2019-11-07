using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityEngine;

public static class Printer
{
    public enum Align
    {
        kLeft,
        kCenter,
        kRight,
    }
    public enum ScreenOrientation
    {
        Unknown = 0, //UnityEngine.ScreenOrientation.Unknown,
        Portrait = UnityEngine.ScreenOrientation.Portrait,
        PortraitUpsideDown = UnityEngine.ScreenOrientation.PortraitUpsideDown,
        LandscapeLeft = UnityEngine.ScreenOrientation.LandscapeLeft,
        Landscape = UnityEngine.ScreenOrientation.Landscape,
        LandscapeRight = UnityEngine.ScreenOrientation.LandscapeRight,
        AutoRotation = UnityEngine.ScreenOrientation.AutoRotation
    }

    static Printer()
    {
        DefaultAllConfig();
    }

    /// <summary>
    /// 选择输出对象
    /// </summary>
    public static void SelectConsole(ConsoleContent con)
    {
        console = con;
    }
    static ConsoleContent console;

    public static void SetTargetFrame(int frame)
    {
        Application.targetFrameRate = frame;
    }
    public static int TargetFrame()
    {
        return Application.targetFrameRate;
    }
    public static void SetBackgroundColor(Color color)
    {
        Config.BackgroundColor = color;
        console.SetBackgroundColor(color);
    }
    public static Color GetBackgroundColor()
    {
        return console.GetBackgroundColor();
    }
    public static void SetBackgroundImage(string name, bool tiled, bool aspect)
    {
        if(string.IsNullOrEmpty(name))
        {
            console.SetBackgroundImage(null, false, false);
            return;
        }
        var v = SpriteManager.GetSpriteBase(name);
        if(v != null && v is SpriteImage)
        {
            SpriteManager.GetSpriteSync(v as SpriteImage, null,
                (obj, sprite, info) =>
            {
                console.SetBackgroundImage(info.sprite, tiled, aspect);
            });
        }
        else
        {
            console.SetBackgroundImage(null, false, false);
        }
    }

    public static void SetOrientation(ScreenOrientation o)
    {
        Screen.orientation = (UnityEngine.ScreenOrientation)o;
        if (o == ScreenOrientation.AutoRotation)
        {
            Screen.autorotateToLandscapeLeft = true;
            Screen.autorotateToLandscapeRight = true;
            Screen.autorotateToPortrait = true;
            Screen.autorotateToPortraitUpsideDown = true;
        }
        else
        {
            Screen.autorotateToLandscapeLeft = false;
            Screen.autorotateToLandscapeRight = false;
            Screen.autorotateToPortrait = false;
            Screen.autorotateToPortraitUpsideDown = false;
        }
    }

    /// <summary>
    /// 保存当前标记
    /// </summary>
    public static void PushFlags()
    {
        stack_flags.Push(flags);
    }
    /// <summary>
    /// 恢复保存的标记
    /// </summary>
    public static void PopFlags()
    {
        if (stack_flags.Count > 0)
            flags = stack_flags.Pop();
    }
    public static void DefaultFlags()
    {
        flags = Config.FlagBit;
    }
    public static FlagBit flags;
    static Stack<FlagBit> stack_flags = new Stack<FlagBit>();

    public static uint GetFlags()
    {
        return flags.GetFlags();
    }
    public static void SetFlags(uint f)
    {
        flags.SetFlags(f);
    }

    /// <summary>
    /// 保存当前主颜色
    /// </summary>
    public static void PushColor()
    {
        stack_color.Push(color);
    }
    /// <summary>
    /// 恢复保存的主颜色
    /// </summary>
    public static void PopColor()
    {
        if (stack_color.Count > 0)
            color = stack_color.Pop();
    }
    public static void DefaultColor()
    {
        color = Config.FontColor;
    }
    public static Color color;
    static Stack<Color> stack_color = new Stack<Color>();

    /// <summary>
    /// 保存当前次颜色
    /// </summary>
    public static void PushGradientColor()
    {
        stack_gradient_color2.Push(gradient_color);
    }
    /// <summary>
    /// 恢复保存的次颜色
    /// </summary>
    public static void PopGradientColor()
    {
        if (stack_gradient_color2.Count > 0)
            gradient_color = stack_gradient_color2.Pop();
    }
    public static void DefaultGradientColor()
    {
        gradient_color = Config.FontGradientColor;
    }
    public static Color gradient_color;
    static Stack<Color> stack_gradient_color2 = new Stack<Color>();

    /// <summary>
    /// 保存当前阴影颜色
    /// </summary>
    public static void PushShadowColor()
    {
        stack_shadow_color.Push(shadow_color);
    }
    /// <summary>
    /// 恢复保存的阴影颜色
    /// </summary>
    public static void PopShadowColor()
    {
        if (stack_shadow_color.Count > 0)
            shadow_color = stack_shadow_color.Pop();
    }
    public static void DefaultShadowColor()
    {
        shadow_color = Config.FontShadowColor;
    }
    public static Color shadow_color;
    static Stack<Color> stack_shadow_color = new Stack<Color>();

    /// <summary>
    /// 保存当前外边框颜色
    /// </summary>
    public static void PushOutlineColor()
    {
        stack_outline_color.Push(outline_color);
    }
    /// <summary>
    /// 恢复保存的外边框颜色
    /// </summary>
    public static void PopOutlineColor()
    {
        if (stack_outline_color.Count > 0)
            outline_color = stack_outline_color.Pop();
    }
    public static void DefaultOutlineColor()
    {
        outline_color = Config.FontOutlineColor;
    }
    public static Color outline_color;
    static Stack<Color> stack_outline_color = new Stack<Color>();

    /// <summary>
    /// 保存当前图片颜色
    /// </summary>
    public static void PushImageColor()
    {
        stack_image_color.Push(image_color);
    }
    /// <summary>
    /// 恢复保存的图片颜色
    /// </summary>
    public static void PopImageColor()
    {
        if (stack_image_color.Count > 0)
            image_color = stack_image_color.Pop();
    }
    public static void DefaultImageColor()
    {
        image_color = Config.ImageColor;
    }
    public static Color image_color;
    static Stack<Color> stack_image_color = new Stack<Color>();

    public static void PushAllConfig()
    {
        PushFlags();
        PushColor();
        PushGradientColor();
        PushShadowColor();
        PushOutlineColor();
        PushImageColor();
    }
    public static void PopAllConfig()
    {
        PopFlags();
        PopColor();
        PopGradientColor();
        PopShadowColor();
        PopOutlineColor();
        PopImageColor();
    }
    public static void DefaultAllConfig()
    {
        DefaultColor();
        DefaultFlags();
        DefaultGradientColor();
        DefaultShadowColor();
        DefaultOutlineColor();
        DefaultImageColor();
    }

    public static void SetFontSize(int size)
    {
        fontsize = size;
    }
    public static int GetFontSize()
    {
        return fontsize;
    }
    static int fontsize = 0;
    static int FontSize { get { return fontsize > 0 ? fontsize : Config.FontSize; } }

    public static void SetLineHeight(int height)
    {
        lineheight = height;
    }
    public static int GetLineHeight()
    {
        return lineheight;
    }
    static int lineheight = 0;
    internal static int LineHeight { get { return lineheight > 0 ? lineheight : Config.LineHeight; } }

    public static void SetButtonStyle(Color normal, Color highlighted,
                                      Color pressed, Color disabled)
    {
        button_style = new ButtonStyle
        {
            normal = normal,
            highlighted = highlighted,
            pressed = pressed,
            disabled = disabled,
        };
    }
    public static void ClearButtonStyle()
    {
        button_style = null;
    }
    static ButtonStyle button_style;

    public static void ShowFPS(bool value)
    {
        if(!fps)
            fps = GameObject.FindObjectOfType<ShowFPS>();
        if(fps)
            fps.enabled = value;
    }
    static ShowFPS fps;

    public static void Quit()
    {
        Application.Quit();
    }

    //==========================================================================
    public static string DataPath()
    {
        return Application.dataPath;
    }
    public static string PersistentDataPath()
    {
        return Application.persistentDataPath;
    }
    public static bool IsMobilePlatform()
    {
        return Application.isMobilePlatform;
    }
    public static string Platform()
    {
        return Application.platform.ToString();
    }
    public static bool RunInBackground()
    {
        return Application.runInBackground;
    }
    public static void SetRunInBackground(bool value)
    {
        Application.runInBackground = value;
    }
    public static void OpenURL(string url)
    {
        Application.OpenURL(url);
    }
    public static void SetResolution(int width, int height, bool fullscreen)
    {
        if (width == 0 || height == 0)
        {
            width = Screen.width;
            height = Screen.height;
        }
        else if (width == 0)
        {
            float asp = (float)Screen.width / Screen.height;
            width = (int)(asp * height);
        }
        else if (height == 0)
        {
            float asp = (float)Screen.height / Screen.width;
            height = (int)(asp * width);
        }
        Screen.SetResolution(width, height, fullscreen);
    }
    public static void GetResolution(out int width, out int height)
    {
        width = Screen.width;
        height = Screen.height;
    }
    public static void SetDragEnable(bool value)
    {
        ConsoleContent.GetConsole(0).SetDragEnable(value);
    }
    public static void SetConsoleBorder(int left, int top, 
                                        int right, int bottom)
    {
        var console = ConsoleContent.GetConsole(0);
        var rt = console.transform as RectTransform;

        rt.anchoredPosition = new Vector2((left - right)/2.0f, (bottom - top)/2.0f);
        rt.sizeDelta = new Vector2(- right - left, - bottom - top);
    }

    //==========================================================================
    public static int NowStamp()
    {
        return (int)((System.DateTime.Now - kBaseTime).Seconds);
    }
    public static int DateToStamp(int year, int month, int day, int hour, int min, int sec)
    {
        return (int)(new System.DateTime(year, month, day, hour, min, sec) - kBaseTime).Seconds;
    }
    public static Dictionary<string, int> Now()
    {
        var now = System.DateTime.Now;
        return DateTime(now);
    }
    public static Dictionary<string, int> Date(int year, int month, int day, int hour, int min, int sec)
    {
        var date = new System.DateTime(year, month, day, hour, min, sec);
        return DateTime(date);
    }
    public static Dictionary<string, int> StampToDate(int stamp)
    {
        return DateTime(kBaseTime + new System.TimeSpan(0, 0, stamp));
    }

    static Dictionary<string, int> DateTime(System.DateTime date)
    {
        return new Dictionary<string, int>
        {
            { "Year", date.Year },
            { "Month", date.Month},
            { "Day", date.Day},
            { "Hour", date.Hour},
            { "Minute", date.Minute},
            { "Second", date.Second},
            { "DayOfYear", date.DayOfYear},
            { "DayOfWeek", (int)date.DayOfWeek},
        };
    }
    static System.DateTime kBaseTime = new System.DateTime(1970, 1, 1);

    //==========================================================================
    public static void SetLogFile(string name, bool create)
    {
        logfilepath = string.Concat(Application.dataPath, "/", name);
        logcreate_new = create;
    }
    public static void SetLogEnable(bool value)
    {
        logenable = value;
    }
    public static void LogWrite(string text)
    {
        if(string.IsNullOrEmpty(text))
            return;

        MakeSureLogStreamRead();
        if(logfile == null)
            return;

        var bytes = Encoding.UTF8.GetBytes(text);
        logfile.Write(bytes, 0, bytes.Length);
        logfile.Flush();
    }
    public static void LogWriteLn(string text)
    {
        LogWrite(text);
        LogShiftLine();
    }
    public static void LogShiftLine()
    {
        MakeSureLogStreamRead();
        if(logfile == null)
            return;
        logfile.Write(log_shiftline, 0, log_shiftline.Length);
        logfile.Flush();
    }
    internal static void LogClose()
    {
        if(logfile != null)
        {
            logfile.Close();
            logfile.Dispose();
            logfile = null;
        }
    }
    static byte[] log_shiftline = new byte[] { 0xd, 0xa };
    static void MakeSureLogStreamRead()
    {
        if(logfile == null)
            logfile = new FileStream(logfilepath,
                logcreate_new ? FileMode.CreateNew : FileMode.OpenOrCreate,
                FileAccess.Write, 
                FileShare.Read);
    }
#if UNITY_EDITOR || UNITY_STANDALONE
    static string logfilepath = Application.dataPath + "/log.txt";
#elif UNITY_ANDROID
    static string logfilepath = Application.persistentDataPath + "/log.txt";
#endif
    static bool logcreate_new = false;
    static bool logenable = false;
    static FileStream logfile = null;

    //==========================================================================
    public static void SetAutoLine(int words)
    {
        auto_line_words = words;
    }
    public static int GetAutoLine()
    {
        return auto_line_words;
    }
    static int auto_line_words = 0;

    public static List<string> GetStringLines(string str, int count)
    {
        if(str == null)
            return new List<string>();
        return StringHelper.GetStringLine(str, flags.richedit, 0, count);
    }
    public static List<string> GetStringLines(string str, bool richedit, int count)
    {
        if(str == null)
            return new List<string>();
        return StringHelper.GetStringLine(str, richedit, 0, count);
    }
    //==========================================================================
    // F 格式化文本
    // T 表格对齐文本
    // Ln 换行
    /// <summary>
    /// 对齐化文本
    /// </summary>
    /// <param name="c">文本</param>
    /// <param name="t">字符数</param>
    /// <param name="align">对齐</param>
    public static void PrintT(int t, Align align, string c)
    {
        var words = StringHelper.GetWordCount(c, flags.richedit);
        if (words >= t)
        {
            //var width = words * FontSize / 2;
            //last_textbuilder.Append(c);
            //last_text_words += words;
            //last_text_weight += width;
            Print(c);
            return;
        }

        switch(align)
        {
        case Align.kLeft:
            Print(c);
            MovePosByWord(t - words, !string.IsNullOrEmpty(code));
            break;
        case Align.kRight:
            MovePosByWord(t - words);
            Print(c);
            break;
        case Align.kCenter:
            var lt = (t - words) / 2;
            MovePosByWord(lt);
            var rt = t - lt - words;
            //Print(string.Concat(StringHelper.Space(lt), c, StringHelper.Space(rt)));
            Print(c);
            MovePosByWord(rt, !string.IsNullOrEmpty(code));
            break;
        }
    }
    /// <summary>
    /// 对齐化文本
    /// 换行
    /// </summary>
    /// <param name="c"></param>
    public static void PrintTLn(int t, Align align, string c)
    {
        PrintT(t, align, c);
        ShiftLine();
    }
    /// <summary>
    /// 对齐化文本
    /// </summary>
    /// <param name="t"></param>
    /// <param name="align"></param>
    /// <param name="format"></param>
    /// <param name="args"></param>
    public static void PrintTF(int t, Align align, string format, params object[] args)
    {
        PrintT(t, align, string.Format(format, args));
    }
    /// <summary>
    /// 对齐化文本
    /// 换行
    /// </summary>
    public static void PrintTFLn(int t, Align align, string format, params object[] args)
    {
        PrintTF(t, align, format, args);
        ShiftLine();
    }
    /// <summary>
    /// 格式化文本
    /// </summary>
    /// <param name="format"></param>
    /// <param name="args"></param>
    public static void PrintF(string format, params object[] args)
    {
        Print(string.Format(format, args));
    }
    /// <summary>
    /// 格式化文本
    /// 换行
    /// </summary>
    /// <param name="format"></param>
    /// <param name="args"></param>
    public static void PrintFLn(string format, params object[] args)
    {
        PrintF(format, args);
        ShiftLine();
    }
    /// <summary>
    /// 基本输入
    /// </summary>
    /// <param name="c"></param>
    public static void Print(string c)
    {
        CheckFlagAndOthers();

        //if(auto_line_words <= 0)
        //{
        //    var words = StringHelper.GetWordCount(c, flags.richedit);
        //    var width = words * FontSize / 2;
        //    last_textbuilder.Append(c);
        //    last_text_words += words;
        //    last_text_weight += width;
        //}
        //else
        //{
            var lines = StringHelper.GetStringLineAndCount(c, flags.richedit, last_text_words, auto_line_words);
            var linecount = lines.Count;
            for(var i = 0; i < linecount; ++i)
            {
                var line = lines[i];
                var words = line.Value;
                var width = words * FontSize / 2;
                last_textbuilder.Append(line.Key);
                last_text_words += words;
                last_text_weight += width;
                if(i < linecount - 1)
                    ShiftLine();
            }
        //}
    }
    /// <summary>
    /// 基本输入
    /// 换行
    /// </summary>
    /// <param name="c"></param>
    public static void PrintLn(string c)
    {
        Print(c);
        ShiftLine();
    }

    //==========================================================================
    public static void SetSpriteImage(string name, string file, List<float> rect, List<float> border, bool hidden)
    {
        SpriteManager.SetSpriteImage(name, file, rect, border, hidden);
    }
    static SpriteImage GetSpriteImage(string name)
    {
        return SpriteManager.GetSpriteImage(name);
    }

    public static void SetSpriteAnimation(string name, float fps, List<List<object>> sprites)
    {
        SpriteManager.SetSpriteAnimation(name, fps, sprites);
    }
    static SpriteAnimation GetSpriteAnimation(string name)
    {
        return SpriteManager.GetSpriteAnimation(name);
    }

    public static void SetAnimationLoop(int count)
    {
        animation_loop_count = count;
    }
    static int animation_loop_count = 0x7FFFFF00;

    public static bool CheckSprite(string name)
    {
        if(string.IsNullOrEmpty(name))
            return false;
        return SpriteManager.CheckSpriteBase(name);
    }

    //==========================================================================
    public static void SetErrorImage(string name, Color color)
    {
        error_image_name = name;
        error_image_color = color;
    }
    static string error_image_name = "@ERROR";
    static Color error_image_color = Color.white;

    public static void Image(string name, float x, float y, float w, float h, bool tiled)
    {
        if(string.IsNullOrEmpty(name))
        {
            return;
        }
        NextTextPart();

        var sb = SpriteManager.GetSpriteBase(name);
        var imagecolor = image_color;
        if(sb == null)
        {
            sb = SpriteManager.GetSpriteImage(error_image_name);
            imagecolor = error_image_color;
        }
        var image = new UnitImage
        {
            name = name,
            posx = (int)(last_text_pos + x),
            posy = (int)y,
            color = imagecolor,
            src = sb,
            loop = animation_loop_count,
            width = (w == 0 || float.IsNaN(w) ? sb.GetWidth() : (int)w),
            height = (h == 0 || float.IsNaN(h) ? sb.GetHeight() : (int)h),
            tiled = tiled,
            isanimation = sb is SpriteAnimation,
        };
        var words = (int)Mathf.Ceil(image.width * 2.0f / FontSize);
        last_text_pos += words * FontSize / 2;
        last_line.AddImage(image);
    }
    public static void ImageP(string name, int x, int y, bool tiled)
    {
        Image(name, x * FontSize / 2, y * LineHeight, 0, 0, tiled);
    }
    public static void ImageS(string name, int w, int h, bool tiled)
    {
        ImagePS(name, 0, 0, w, h, tiled);
    }
    public static void ImagePS(string name, int x, int y, int w, int h, bool tiled)
    {
        var px = x * FontSize / 2.0f;
        var py = y * LineHeight;

        if (w == 0 && h == 0)
        {
            Image(name, px, py, 0, 0, tiled);
            return;
        }

        var si = SpriteManager.GetSpriteBase(name);
        var width = (float)w * FontSize / 2;
        var height = (float)h * LineHeight;
        if(si != null)
        {
            if(width == 0)
                width = (float)height * si.GetWidth() / si.GetHeight();
            if(height == 0)
                height = (float)width * si.GetHeight() / si.GetWidth();
        }
        Image(name, px, py, width, height, tiled);
    }

    //==========================================================================
    public static void SetCode(string c)
    {
        code = c;
    }

    //==========================================================================
    public static void RemoveLine(int count)
    {
        console.RemoveLine(count);
    }
    public static void Clear()
    {
        console.Clear();
        last_text_pos = 0;
        last_text_weight = 0;
        last_text_height = 0;
        _last_textbuilder = null;
        _last_line = null;
    }

    public static void MovePosByPixel(int x)
    {
        NextTextPart();
        last_text_pos += x;
    }
    public static void MovePosByWord(int w)
    {
        NextTextPart();
        last_text_pos += w * FontSize / 2;
    }
    static void MovePosByPixel(int x, bool isbutton)
    {
        NextTextPart(isbutton);
        last_text_pos += x;
    }
    static void MovePosByWord(int w, bool isbutton)
    {
        NextTextPart(isbutton);
        last_text_pos += w * FontSize / 2;
    }
    public static void ResetPosByPixel(int x)
    {
        NextTextPart();
        last_text_pos = x;
    }
    public static void ResetPosByWord(int w)
    {
        NextTextPart();
        last_text_pos = w * FontSize / 2;
    }
    public static int GetCurrentPos()
    {
        return last_text_pos;
    }

    public static void NextTextPart(bool isbutton = false)
    {
        if (_last_textbuilder == null)
            return;
        var unit = new UnitText();
        var text = last_textbuilder.ToString();
        unit.text = text;//.TrimEnd();
        unit.posx = last_text_pos;
        unit.relative_posx = 0;
        if (unit.text.Length != text.Length)
            unit.width = StringHelper.GetDisplayLength(unit.text);
        else
            unit.width = last_text_weight;
        unit.color = curr_color;
        unit.flags = curr_flags;
        if (unit.flags.gradient)
            unit.second_color = curr_gradient;
        if (unit.flags.shadow)
            unit.shadow_color = curr_shadow;
        if (unit.flags.outline)
            unit.outline_color = curr_outline;

        unit.flags.isbutton = isbutton;
        if (unit.flags.isbutton)
        {
            unit.buttonstyle = button_style;
            unit.generation = generation;
            unit.code = code;
        }
        else
        {
            unit.buttonstyle = null;
            unit.generation = -1;
        }
        unit.fontsize = FontSize;

        last_line.AddText(unit);

        last_text_pos += unit.width;
        last_text_words = 0;
        last_text_weight = 0;
        _last_textbuilder = null;

        if(logenable)
            LogWrite(unit.text);
    }
    public static void NextImagePart(bool isbutton = false)
    {
        if (last_line.images != null && last_line.images.Count > last_image_index)
        {
            UnitText ut = new UnitText();
            if (last_line.units == null)
                last_line.units = new List<UnitText>();
            last_line.units.Add(ut);

            ut.image_indices = new List<int>();

            var posx = int.MaxValue;
            for (var i = last_image_index; i < last_line.images.Count; ++i)
            {
                var image = last_line.images[i];
                posx = Mathf.Min(image.posx, posx);
                ut.image_indices.Add(i);

                if(logenable)
                    LogWrite("[" + image.name + "]");
            }
            ut.posx = posx;
            if (isbutton)
            {
                ut.generation = generation;
                ut.flags.isbutton = isbutton;
                ut.code = code;
            }
            last_image_index = last_line.images.Count;
        }
    }

    static void CheckFlagAndOthers()
    {
        NextImagePart();
        if (flags.flags == curr_flags.flags &&
            color == curr_color &&
            shadow_color == curr_shadow &&
            gradient_color == curr_gradient &&
            outline_color == curr_outline)
            return;
        NextTextPart();
    }

    public static void ShiftLine(int n = 1, bool roll_to_bottom = true)
    {
        NextTextPart();
        NextImagePart();

        if (n <= 0)
            n = 1;
        for (var i = 0; i < n; ++i)
        {
            console.AddLine(last_line, roll_to_bottom);
            _last_line = null;
        }
        last_text_pos = 0;
        last_text_weight = 0;
        last_text_height = 0;
        last_image_index = 0;
        _last_textbuilder = null;

        if(logenable)
            LogShiftLine();
    }
    static FlagBit curr_flags;
    static Color curr_color;
    static Color curr_gradient;
    static Color curr_shadow;
    static Color curr_outline;

    static StringBuilder last_textbuilder
    {
        get
        {
            if (_last_textbuilder == null)
            {
                _last_textbuilder = new StringBuilder();
                curr_flags = flags;
                curr_color = color;
                curr_gradient = gradient_color;
                curr_shadow = shadow_color;
                curr_outline = outline_color;
            }
            return _last_textbuilder;
        }
    }
    static StringBuilder _last_textbuilder;
    static int last_text_pos = 0;
    static int last_text_words = 0;
    static int last_text_weight = 0;
    static int last_text_height = 0;
    static int last_image_index = 0;

    static LineInfo last_line
    {
        get
        {
            if (_last_line == null)
                _last_line = new LineInfo();
            return _last_line;
        }
    }
    static LineInfo _last_line = null;
    static int generation { get { return console.button_generation; } }
    static string code = null;

    public static void SetMsg(string s)
    {
        msg = s;
    }
    public static string GetMsg()
    {
        return msg;
    }
    public static bool EmptyMsg(bool null_or_empty)
    {
        return null_or_empty ? string.IsNullOrEmpty(msg) : msg == null;
    }
    public static void ClearMsg()
    {
        console.NextButtonGeneration();
        msg = null;
    }
    static string msg = null;

    //==========================================================================
    public struct TextWeight
    {
        public string text;
        public int weight;
    }
    struct TextWeightRange
    {
        public string text;
        public int start;
        public int end;
    }
    public static int GetTextListCount(string name)
    {
        if (last_text_list != null && last_text_name == name)
            return last_text_list.Count;

        text_lists.TryGetValue(name, out last_text_list);
        if (last_text_list == null)
            return 0;
        last_text_name = name;
        return last_text_list.Count - 1;
    }
    public static int GetTextListWeight(string name)
    {
        if (last_text_list != null && last_text_name == name)
            return last_text_list.Count;

        text_lists.TryGetValue(name, out last_text_list);
        if (last_text_list == null)
            return 0;
        last_text_name = name;
        return last_text_list[0].start;
    }
    public static void SetTextList(string name, List<string> list)
    {
        if (string.IsNullOrEmpty(name) || list == null || list.Count == 0)
            return;
        List<TextWeightRange> l = new List<TextWeightRange>();
        l.Add(new TextWeightRange());
        for (var i = 0; i < list.Count; ++i)
        {
            l.Add(new TextWeightRange { text = list[i], start = i, end = i+1 });
        }
        l[0] = new TextWeightRange { text = null, start = list.Count, end = 0 };

        text_lists[name] = l;
        last_text_name = name;
        last_text_list = l;
    }
    public static void SetTextWeightList(string name, List<Dictionary<int, object>> list)
    {
        if (string.IsNullOrEmpty(name) || list == null || list.Count == 0)
            return;
        List<TextWeightRange> l = new List<TextWeightRange>();
        l.Add(new TextWeightRange());
        int weight = 0;
        for (var i = 0; i < list.Count; ++i)
        {
            var d = list[i];
            var s = (string)(d[1]);
            var w = (double)(d[2]);
            l.Add(new TextWeightRange { text = s, start = weight, end = weight + (int)w });
            weight += (int)w;
        }
        l[0] = new TextWeightRange { text = null, start = weight, end = 0 };

        text_lists[name] = l;
        last_text_name = name;
        last_text_list = l;
    }
    static List<TextWeightRange> GetTextList(string name)
    {
        if (string.IsNullOrEmpty(name))
            return null;
        if (last_text_list != null && last_text_name == name)
            return last_text_list;
        text_lists.TryGetValue(name, out last_text_list);
        if (last_text_list != null)
            last_text_name = name;
        return last_text_list;
    }
    public static string GetTextByIndex(string listname, int index)
    {
        var list = GetTextList(listname);
        if (list == null || list.Count <= 1)
            return null;

        return list[index % (list.Count - 1) + 1].text;
    }
    public static string GetTextByWeight(string listname, int weight, out int index)
    {
        index = -1;

        var list = GetTextList(listname);
        if (list == null || list.Count <= 1)
            return null;

        if (weight >= list[0].start)
            weight = list[0].start - 1;

        int begin = 1;
        int end = list.Count - 1;
        int mid = 0;
        int sw = 0;
        int ew = 0;

        while (begin <= end)
        {
            mid = (begin + end) / 2;
            sw = list[mid].start;
            ew = list[mid].end;
            if(weight < sw)
                end = mid - 1;
            else if(weight >= ew)
                begin = mid + 1;
            else
            {
                index = mid;
                return list[mid].text;
            }
        }
        return null;
    }
    static string last_text_name;
    static List<TextWeightRange> last_text_list;
    static Dictionary<string, List<TextWeightRange>> text_lists = new Dictionary<string, List<TextWeightRange>>();

    //==========================================================================
    public enum MsgType
    {
        ONE_BUTTON,
        TWO_BUTTON,
    }
    public enum MsgResult
    {
        LEFT,
        RIGHT,
    }
    public static void MessageBox(string content, MsgType type,
        string left_button_text, string right_button_text, 
        Color border_color, Color content_color, 
        Color left_color, Color left_text_color, 
        Color right_color, Color right_text_color,
        List<float> size)
    {
        MsgBox.Show(content, type);

        var box = MsgBox.instance;
        box.border.color = border_color;
        box.content.color = content_color;

        box.left_button_text.text = left_button_text;
        box.left_button_text.color = left_text_color;
        box.left_button.color = left_color;

        box.right_button_text.text = right_button_text;
        box.right_button_text.color = right_text_color;
        box.right_button.color = right_color;

        var rt = box.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(size[0], size[1]);
    }
    public static bool MessageBoxIsShow()
    {
        return MsgBox.IsShow();
    }
    public static MsgResult MessageBoxResult()
    {
        return MsgBox.LastResult();
    }

    public enum InputType
    {
        STANDARD = UnityEngine.UI.InputField.ContentType.Standard,
        INTEGER = UnityEngine.UI.InputField.ContentType.IntegerNumber,
        DECIMAL = UnityEngine.UI.InputField.ContentType.DecimalNumber,
        ALPHANUMERIC = UnityEngine.UI.InputField.ContentType.Alphanumeric,
        PASSWORD = UnityEngine.UI.InputField.ContentType.Password,
    }

    public static void InputBoxShow(string content, InputType type,
        string default_value, 
        string placeholder,
        string right_button_text,
        Color border_color, Color content_color,
        Color text_color, Color placeholder_color,
        Color right_color, Color right_text_color,
        Color input_color)
    {
        InputBox.Show(content);

        var box = InputBox.instance;
        box.border.color = border_color;
        box.content.color = content_color;

        box.inputfield.text = default_value;
        box.inputfield.contentType = (UnityEngine.UI.InputField.ContentType)type;
        box.text.color = text_color;

        box.input.color = input_color;

        box.placeholder.text = placeholder;
        box.placeholder.color = placeholder_color;

        box.right_button_text.text = right_button_text;
        box.right_button_text.color = right_text_color;
        box.right_button.color = right_color;
    }
    public static bool InputBoxIsShow()
    {
        return InputBox.IsShow();
    }
    public static string InputBoxResult()
    {
        return InputBox.LastResult();
    }

    //==========================================================================
    public static List<string> EnumScripts(string path)
    {
        return Lua.Resource.EnumScripts(path);
    }

    //==========================================================================
    public static string LoadCsv(string name)
    {
        var ta = Resources.Load<TextAsset>(string.Concat("Csv/", name));
        if(ta != null)
            return ta.text;

        name = name.Replace('/', '_');
        name = name.Replace('\\', '_');
        var dir = Config.GetCsvPath() + "/" + name + ".csv";

        string content = null;
        try
        {
            content = System.IO.File.ReadAllText(dir);
        }
        catch(System.Exception e)
        {
            Debug.LogError(e);
            return null;
        }
        return content;
    }

    //==========================================================================
    public static void Save(string name, string content, string password)
    {
        name = name.Replace('/', '_');
        name = name.Replace('\\', '_');
        var dir = Config.GetSavePath() + "/" + name;
        if(string.IsNullOrEmpty(password))
            System.IO.File.WriteAllText(dir, content);
        else
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(content);
            var passbytes = System.Text.Encoding.UTF8.GetBytes(password);

            for(int i = 0, pi = 0; 
                i < bytes.Length; 
                ++i, pi = (pi + 1) % passbytes.Length)
            {
                bytes[i] ^= passbytes[pi];
            }
            var base64 = System.Convert.ToBase64String(bytes);
            System.IO.File.WriteAllText(dir, base64);
        }
    }
    public static string Load(string name, string password)
    {
        name = name.Replace('/', '_');
        name = name.Replace('\\', '_');
        var dir = Config.GetSavePath() + "/" + name;

        string content = null;
        try
        {
            content = System.IO.File.ReadAllText(dir);
        }
        catch(System.Exception e)
        {
            //Debug.LogError(e);
            return null;
        }

        if(!string.IsNullOrEmpty(password))
        {
            var bytes = System.Convert.FromBase64String(content);
            var passbytes = System.Text.Encoding.UTF8.GetBytes(password);
            for(int i = 0, pi = 0;
                i < bytes.Length;
                ++i, pi = (pi + 1) % passbytes.Length)
            {
                bytes[i] ^= passbytes[pi];
            }
            content = System.Text.Encoding.UTF8.GetString(bytes);
        }
        return content;
    }
    public static bool Exist(string name)
    {
        name = name.Replace('/', '_');
        name = name.Replace('\\', '_');
        var dir = Config.GetSavePath() + "/" + name;
        return System.IO.File.Exists(name);
    }
    public static void Delete(string name)
    {
        name = name.Replace('/', '_');
        name = name.Replace('\\', '_');
        var dir = Config.GetSavePath() + "/" + name;
        System.IO.File.Delete(dir);
    }
    public static List<string> EnumSaves()
    {
        var savepath = Config.GetSavePath();
        var pathlength = savepath.Length;
        var files = Directory.GetFiles(savepath, "*.*", SearchOption.AllDirectories);

        for(var i = 0; i < files.Length; ++i)
        {
            files[i] = GenericHelper.NormalizePath(
                files[i].Substring(pathlength, files[i].Length - pathlength));
            if(files[i][0] == '/')
                files[i] = files[i].Substring(1, files[i].Length - 1);
        }
        return new List<string>(files);
    }
}
