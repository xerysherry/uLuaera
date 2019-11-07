using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public struct FlagBit
{
    const int kIsButton =      0;
    const int kUnderline =     1;
    const int kStrickout =     2;
    const int kEmpty =         3;
    const int kRichedit =      4;
    const int kMonospaced =    5;
    const int kGradient =      6;
    const int kOutline =       7;
    const int kShadow =        8;
    const int kBold =          9;
    const int kItalic =       10;
    const int kTiled =        11;
    const int kIsAnimation =  12;

    public FlagBit(uint flags)
    {
        this._flags = flags;
    }
    public uint flags { get { return _flags; } }
    uint _flags;

    public uint GetFlags() { return _flags; }
    public void SetFlags(uint flags) { _flags = flags; }

    public bool isbutton
    {
        get { return (_flags & 0x1) == 1; }
        set { _flags = value ? (_flags | (0x1U << kIsButton)) : (_flags & (0xFFFFFFFF ^ (0x1U << kIsButton))); }
    }
    public bool underline
    {
        get { return ((_flags >> kUnderline) & 0x1) == 1; }
        set { _flags = value ? (_flags | (0x1U << kUnderline)) : (_flags & (0xFFFFFFFF ^ (0x1U << kUnderline))); }
    }
    public bool strickout
    {
        get { return ((_flags >> kStrickout) & 0x1) == 1; }
        set { _flags = value ? (_flags | (0x1U << kStrickout)) : (_flags & (0xFFFFFFFF ^ (0x1U << kStrickout))); }
    }
    public bool empty
    {
        get { return ((_flags >> kEmpty) & 0x1) == 1; }
        set { _flags = value ? (_flags | (0x1U << kEmpty)) : (_flags & (0xFFFFFFFF ^ (0x1U << kEmpty))); }
    }
    public bool richedit
    {
        get { return ((_flags >> kRichedit) & 0x1) == 1; }
        set { _flags = value ? (_flags | (0x1U << kRichedit)) : (_flags & (0xFFFFFFFF ^ (0x1U << kRichedit))); }
    }
    public bool monospaced
    {
        get { return ((_flags >> kMonospaced) & 0x1) == 1; }
        set { _flags = value ? (_flags | (0x1U << kMonospaced)) : (_flags & (0xFFFFFFFF ^ (0x1U << kMonospaced))); }
    }
    public bool gradient
    {
        get { return ((_flags >> kGradient) & 0x1) == 1; }
        set { _flags = value ? (_flags | (0x1U << kGradient)) : (_flags & (0xFFFFFFFF ^ (0x1U << kGradient))); }
    }
    public bool outline
    {
        get { return ((_flags >> kOutline) & 0x1) == 1; }
        set { _flags = value ? (_flags | (0x1U << kOutline)) : (_flags & (0xFFFFFFFF ^ (0x1U << kOutline))); }
    }
    public bool shadow
    {
        get { return ((_flags >> kShadow) & 0x1) == 1; }
        set { _flags = value ? (_flags | (0x1U << kShadow)) : (_flags & (0xFFFFFFFF ^ (0x1U << kShadow))); }
    }
    public bool bold
    {
        get { return ((_flags >> kBold) & 0x1) == 1; }
        set { _flags = value ? (_flags | (0x1U << kBold)) : (_flags & (0xFFFFFFFF ^ (0x1U << kBold))); }
    }
    public bool italic
    {
        get { return ((_flags >> kItalic) & 0x1) == 1; }
        set { _flags = value ? (_flags | (0x1U << kItalic)) : (_flags & (0xFFFFFFFF ^ (0x1U << kItalic))); }
    }

    //===========================================
    internal bool tiled
    {
        get { return ((_flags >> kTiled) & 0x1) == 1; }
        set { _flags = value ? (_flags | (0x1U << kTiled)) : (_flags & (0xFFFFFFFF ^ (0x1U << kTiled))); }
    }
    internal bool isanimation
    {
        get { return ((_flags >> kIsAnimation) & 0x1) == 1; }
        set { _flags = value ? (_flags | (0x1U << kIsAnimation)) : (_flags & (0xFFFFFFFF ^ (0x1U << kIsAnimation))); }
    }
}

public class ButtonStyle
{
    public Color32 normal = Color.white;
    public Color32 highlighted = Color.white;
    public Color32 pressed = Color.gray;
    public Color32 disabled = new Color(0.5f, 0.5f, 0.5f, 0.5f);
}

public class UnitInfo
{
    public string content;
    public string code;
    public int generation;
    public int posx;
    public int relative_posx;
    public int width;
    public int height;
    public Color color;
    public List<int> image_indices;
    public FlagBit flags;
}

public class UnitText : UnitInfo
{
    public string text
    {
        get { return content; }
        set { content = value; }
    }
    public string fontname;
    public int fontsize;
    public Color32 second_color;
    public Color32 shadow_color;
    public Color32 outline_color;
    public ButtonStyle buttonstyle = null;
}

public class UnitImage : UnitInfo
{
    public string name
    {
        get { return content; }
        set { content = value; }
    }
    public int posy;
    public SpriteBase src;
    public SpriteImage src_image { get { return src as SpriteImage; } }
    public SpriteAnimation src_animation { get { return src as SpriteAnimation; } }
    public int playcount = 0;
    public int loop;
    public bool isbutton
    {
        get { return flags.isbutton; }
        set { flags.isbutton = value; }
    }
    public bool tiled
    {
        get { return flags.tiled; }
        set { flags.tiled = value; }
    }
    public bool isanimation
    {
        get { return flags.isanimation; }
        set { flags.isanimation = value; }
    }
}

public class LineInfo
{
    public enum FontStyle
    {
        Regular = 0,
        Bold = 1,
        Italic = 2,
        Underline = 4,
        Strikeout = 8
    }
    public enum Align
    {
        LEFT = 0,
        CENTER = 1,
        RIGHT = 2,
    }
    /// <summary>
    /// 构造
    /// </summary>
    /// <param name="posy"></param>
    /// <param name="h"></param>
    public LineInfo(float posy, float h)
    {
        position_y = posy;
        height = h;
    }
    public LineInfo()
    { }
    public override string ToString()
    {
        StringBuilder str = new StringBuilder();
        foreach(var u in units)
            str.Append(u.content);
        return str.ToString();
    }
    public void AddText(UnitText desc)
    {
        if(units == null)
            units = new List<UnitText>();
        units.Add(desc);
    }
    public void AddImage(UnitImage desc)
    {
        if(images == null)
            images = new List<UnitImage>();
        images.Add(desc);
    }
    /// <summary>
    /// 对其方式
    /// </summary>
    public Align align;
    /// <summary>
    /// 行号
    /// </summary>
    public int LineNo;
    /// <summary>
    /// 是否为逻辑行
    /// </summary>
    public bool IsLogicalLine;
    /// <summary>
    /// 坐标Y
    /// </summary>
    public float position_y = 0.0f;
    /// <summary>
    /// 高度
    /// </summary>
    public float height = 0.0f;
    /// <summary>
    /// 文本子对象
    /// </summary>
    public List<UnitText> units = null;
    /// <summary>
    /// 图片
    /// </summary>
    public List<UnitImage> images = null;
}
