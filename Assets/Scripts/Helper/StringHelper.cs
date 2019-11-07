using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public static class StringHelper
{
    static char[] kLineSplit = new char[] { '\xd', '\xa' };

    /// <summary>
    /// 检查是否半字符
    /// </summary>
    /// <param name="c"></param>
    /// <returns></returns>
    public static bool CheckHalfSize(char c)
    {
        return c < 0x80;
    }
    /// <summary>
    /// 获取字数量，小于127返回1，否则返回2
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static int GetWordCount(string str)
    {
        if(string.IsNullOrEmpty(str))
            return 0;
        var count = 0;
        var length = str.Length;
        for(int i = 0; i < length; ++i)
        {
            if(CheckHalfSize(str[i]))
                count += 1;
            else
                count += 2;
        }
        return count;
    }
    /// <summary>
    /// 返回字符数量
    /// </summary>
    /// <param name="str"></param>
    /// <param name="richedit">是否为富文本</param>
    /// <returns></returns>
    public static int GetWordCount(string str, bool richedit)
    {
        if (richedit)
        {
            if (string.IsNullOrEmpty(str))
                return 0;

            int rcount = 0;
            int count = str.Length;
            for (int i = GetNextValidIndex(str, 0); i < count; ++i)
            {
                var c = str[i];
                if (c == '\n')
                    break;
                else if (c == '<')
                {
                    i = GetNextValidIndex(str, i);
                    if (i >= count)
                        break;
                    c = str[i];
                }
                if (CheckHalfSize(c))
                    rcount += 1;
                else
                    rcount += 2;
            }
            return rcount;

        }
        else
            return GetWordCount(str);
    }
    static string GetRichTextEnd(string str)
    {
        for(int i = 1; i < str.Length; ++i)
        {
            var c = str[i];
            if(!(('A' <= c && c <= 'Z') ||
                 ('a' <= c && c <= 'z') ||
                 ('0' <= c && c <= '9')))
            {
                return string.Concat("</", str.Substring(1, i-1), ">");
            }
        }
        return "";
    }
    static string GetRichTextEnd(List<string> str)
    {
        if(str.Count == 0)
            return "";

        StringBuilder sb = new StringBuilder();
        for(var ri = str.Count - 1; ri >= 0; --ri)
        {
            sb.Append(GetRichTextEnd(str[ri]));
        }
        return sb.ToString();
    }
    /// <summary>
    /// 字符串分行
    /// </summary>
    /// <param name="str"></param>
    /// <param name="word_count"></param>
    /// <returns></returns>
    internal static List<KeyValuePair<string, int>> GetStringLineAndCount(string str, bool richedit, int curr_word, int word_count)
    {
        List<KeyValuePair<string, int>> result = new List<KeyValuePair<string, int>>();
        List<string> richtext = null;
        if(richedit)
            richtext = new List<string>();

        int i = GetNextValidIndex(str, 0);
        int rcount = curr_word;
        int count = str.Length;
        int rindex = 0;
        string prefix = "";
        for(; i < count; ++i)
        {
            var c = str[i];
            if(c == '\n')
            {
                if(richedit)
                {
                    var temp = string.Concat(prefix, str.Substring(rindex, i - rindex));
                    if(richtext.Count == 0)
                        prefix = "";
                    else
                    {
                        temp = string.Concat(temp, GetRichTextEnd(richtext));
                        prefix = string.Concat(richtext.ToArray());
                    }
                    result.Add(new KeyValuePair<string, int>(temp, rcount - curr_word));
                }
                else
                    result.Add(new KeyValuePair<string, int>(str.Substring(rindex, i - rindex), rcount - curr_word));
                rindex = i+1;
                rcount = 0;
                curr_word = 0;
                continue;
            }
            else if(richedit && c == '<')
            {
                while(c == '<')
                {
                    var nexti = GetNextValidIndex(str, i, false);
                    if(nexti >= count)
                        break;

                    if(str[i + 1] == '/')
                    {
                        if(richtext.Count > 0)
                            richtext.RemoveAt(richtext.Count - 1);
                    }
                    else
                    {
                        richtext.Add(str.Substring(i, nexti - i));
                    }

                    i = nexti;
                    c = str[i];
                }
            }

            if(CheckHalfSize(c))
                rcount += 1;
            else
                rcount += 2;

            if(word_count > 0 && rcount >= word_count)
            {
                if(richedit)
                {
                    var temp = string.Concat(prefix, str.Substring(rindex, i - rindex + 1));
                    if(richtext.Count == 0)
                        prefix = "";
                    else
                    {
                        temp = string.Concat(temp, GetRichTextEnd(richtext));
                        prefix = string.Concat(richtext.ToArray());
                    }
                    result.Add(new KeyValuePair<string, int>(temp, rcount - curr_word));
                }
                else
                    result.Add(new KeyValuePair<string, int>(str.Substring(rindex, i - rindex + 1), rcount - curr_word));

                rindex = i + 1;
                if(rindex < count && str[rindex] == '\n')
                {
                    ++i;
                    rindex = i + 1;
                }
                rcount = 0;
                curr_word = 0;
            }
        }
        if(rindex < str.Length)
            result.Add(new KeyValuePair<string, int>(
                string.Concat(prefix, str.Substring(rindex, str.Length - rindex)), rcount - curr_word));
        return result;
    }
    internal static List<string> GetStringLine(string str, bool richedit, int curr_word, int word_count)
    {
        List<string> result = new List<string>();
        List<string> richtext = null;
        if(richedit)
            richtext = new List<string>();

        int i = GetNextValidIndex(str, 0);
        int rcount = curr_word;
        int count = str.Length;
        int rindex = 0;
        string prefix = "";
        for(; i < count; ++i)
        {
            var c = str[i];
            if(c == '\n')
            {
                if(richedit)
                {
                    var temp = string.Concat(prefix, str.Substring(rindex, i - rindex));
                    if(richtext.Count == 0)
                        prefix = "";
                    else
                    {
                        temp = string.Concat(temp, GetRichTextEnd(richtext));
                        prefix = string.Concat(richtext.ToArray());
                    }
                    result.Add(temp);
                }
                else
                    result.Add(str.Substring(rindex, i - rindex));
                rindex = i + 1;
                rcount = 0;
                curr_word = 0;
                continue;
            }
            else if(richedit && c == '<')
            {
                while(c == '<')
                {
                    var nexti = GetNextValidIndex(str, i, false);
                    if(nexti >= count)
                        break;

                    if(str[i + 1] == '/')
                    {
                        if(richtext.Count > 0)
                            richtext.RemoveAt(richtext.Count - 1);
                    }
                    else
                    {
                        richtext.Add(str.Substring(i, nexti - i));
                    }

                    i = nexti;
                    c = str[i];
                }
            }

            if(CheckHalfSize(c))
                rcount += 1;
            else
                rcount += 2;

            if(word_count > 0 && rcount >= word_count)
            {
                if(richedit)
                {
                    var temp = string.Concat(prefix, str.Substring(rindex, i - rindex + 1));
                    if(richtext.Count == 0)
                        prefix = "";
                    else
                    {
                        temp = string.Concat(temp, GetRichTextEnd(richtext));
                        prefix = string.Concat(richtext.ToArray());
                    }
                    result.Add(temp);
                }
                else
                    result.Add(str.Substring(rindex, i - rindex + 1));

                rindex = i + 1;
                if(rindex < count && str[rindex] == '\n')
                {
                    ++i;
                    rindex = i + 1;
                }
                rcount = 0;
                curr_word = 0;
            }
        }
        if(rindex < str.Length)
            result.Add(
                string.Concat(prefix, str.Substring(rindex, str.Length - rindex)));
        return result;
    }
    /// <summary>
    /// 获取文本长
    /// </summary>
    /// <param name="s"></param>
    /// <param name="font"></param>
    /// <returns></returns>
    public static int GetDisplayLength(string s)
    {
        return GetDisplayLength(s, Config.FontSize);
    }
    /// <summary>
    /// 获取文本长
    /// </summary>
    /// <param name="s"></param>
    /// <param name="font"></param>
    /// <returns></returns>
    public static int GetDisplayLength(string s, int fontsize)
    {
        float xsize = 0;
        char c = '\x0';
        for(int i = 0; i < s.Length; ++i)
        {
            c = s[i];
            if(c == '\n')
                break;
            else if(CheckHalfSize(c))
                xsize += fontsize / 2;
            else
                xsize += fontsize;
        }

        return (int)xsize;
    }
    /// <summary>
    /// 文本长宽
    /// </summary>
    /// <returns></returns>
    public static int GetDisplayLength(string s, bool richtext)
    {
        return GetDisplayLength(s, Config.FontSize, richtext);
    }
    /// <summary>
    /// 文本长宽
    /// </summary>
    /// <returns></returns>
    public static int GetDisplayLength(string s, int fontsize, bool richtext)
    {
        if(s == null)
        {
            return 0;
        }
        else if(richtext)
        {
            int cw = 0;
            int count = s.Length;
            for(int i = GetNextValidIndex(s, 0); i < count; ++i)
            {
                var c = s[i];
                if(c == '\n')
                    break;
                else if(c == '<')
                {
                    i = GetNextValidIndex(s, i);
                    if(i >= count)
                        break;
                    c = s[i];
                }
                if(CheckHalfSize(c))
                    cw += fontsize / 2;
                else
                    cw += fontsize;
            }
            return cw;
        }
        else
        {
            return GetDisplayLength(s, fontsize);
        }
    }
    static readonly char[] _index_any = new char[] { '<', '\n' };
    static int GetNextValidIndex(string content, int i, bool loop = true)
    {
        if(i >= content.Length)
            return i;

        var c = content[i];
        while(c == '<')
        {
            var t1 = content.IndexOf('>', i + 1);
            var t2 = content.IndexOfAny(_index_any, i + 1);
            if(t2 == -1)
                t2 = int.MaxValue;
            if(t1 < t2 && t1 - i > 1)
            {
                var sub = content.Substring(i + 1, t1 - i - 1).ToLower();
                if(sub == "b" ||
                    sub == "i" ||
                    sub == "/b" ||
                    sub == "/i" ||
                    sub == "/size" ||
                    sub == "/color" ||
                    sub.IndexOf("size") == 0 ||
                    sub.IndexOf("color") == 0)
                {
                    i = t1 + 1;
                    if(i >= content.Length)
                        return i;
                    c = content[i];
                }
                else
                    break;
            }
            else
                break;
            if(!loop)
                break;
        }
        return i;
    }

    /// <summary>
    /// 返回连续文本
    /// </summary>
    /// <param name="c"></param>
    /// <param name="fontsize"></param>
    /// <param name="totalsize"></param>
    /// <returns></returns>
    public static string GetStringBar(char c, int fontsize, float totalsize)
    {
        float s = fontsize;
        if(CheckHalfSize(c))
            s /= 2;
        var count = (int)System.Math.Floor(totalsize / s);
        var build = new System.Text.StringBuilder(count);
        for(int i = 0; i < count; ++i)
            build.Append(c);
        return build.ToString();
    }
    public static string GetStringBar(string s, int count)
    {
        var build = new System.Text.StringBuilder(count);
        for(int i = 0; i < count; ++i)
            build.Append(s);
        return build.ToString();
    }
    public static string Space(int count)
    {
        if(count < 0)
            return null;
        var slcount = space_list.Count;
        if(count >= slcount)
        {
            for(int i = slcount - 1; i < count; ++i)
                space_list.Add(space_list[i] + " ");
        }
        return space_list[count];
    }
    static List<string> space_list = new List<string> { "" };
    /// <summary>
    /// 转换模式
    /// </summary>
    public enum StrConvMode
    {
        None = 0,
        Uppercase = 1,
        Lowercase = 2,
        Wide = 4,
        Narrow = 8,
    }
    /// <summary>
    /// 全角->半角
    /// </summary>
    static readonly Dictionary<char, char> ToNarrow =
            new Dictionary<char, char>
    {
        {'０', '0'},
        {'１', '1'},
        {'２', '2'},
        {'３', '3'},
        {'４', '4'},
        {'５', '5'},
        {'６', '6'},
        {'７', '7'},
        {'８', '8'},
        {'９', '9'},
        {'ａ', 'a'},
        {'ｂ', 'b'},
        {'ｃ', 'c'},
        {'ｄ', 'd'},
        {'ｅ', 'e'},
        {'ｆ', 'f'},
        {'ｇ', 'g'},
        {'ｈ', 'h'},
        {'ｉ', 'i'},
        {'ｊ', 'j'},
        {'ｋ', 'k'},
        {'ｌ', 'l'},
        {'ｍ', 'm'},
        {'ｎ', 'n'},
        {'ｏ', 'o'},
        {'ｐ', 'p'},
        {'ｑ', 'q'},
        {'ｒ', 'r'},
        {'ｓ', 's'},
        {'ｔ', 't'},
        {'ｕ', 'u'},
        {'ｖ', 'v'},
        {'ｗ', 'w'},
        {'ｘ', 'x'},
        {'ｙ', 'y'},
        {'ｚ', 'z'},
        {'Ａ', 'A'},
        {'Ｂ', 'B'},
        {'Ｃ', 'C'},
        {'Ｄ', 'D'},
        {'Ｅ', 'E'},
        {'Ｆ', 'F'},
        {'Ｇ', 'G'},
        {'Ｈ', 'H'},
        {'Ｉ', 'I'},
        {'Ｊ', 'J'},
        {'Ｋ', 'K'},
        {'Ｌ', 'L'},
        {'Ｍ', 'M'},
        {'Ｎ', 'N'},
        {'Ｏ', 'O'},
        {'Ｐ', 'P'},
        {'Ｑ', 'Q'},
        {'Ｒ', 'R'},
        {'Ｓ', 'S'},
        {'Ｔ', 'T'},
        {'Ｕ', 'U'},
        {'Ｖ', 'V'},
        {'Ｗ', 'W'},
        {'Ｘ', 'X'},
        {'Ｙ', 'Y'},
        {'Ｚ', 'Z'},
        {'　', ' '},
    };
    /// <summary>
    /// 半角->全角
    /// </summary>
    static readonly Dictionary<char, char> ToWide =
        new Dictionary<char, char>
    {
        {'0', '０'},
        {'1', '１'},
        {'2', '２'},
        {'3', '３'},
        {'4', '４'},
        {'5', '５'},
        {'6', '６'},
        {'7', '７'},
        {'8', '８'},
        {'9', '９'},
        {'a', 'ａ'},
        {'b', 'ｂ'},
        {'c', 'ｃ'},
        {'d', 'ｄ'},
        {'e', 'ｅ'},
        {'f', 'ｆ'},
        {'g', 'ｇ'},
        {'h', 'ｈ'},
        {'i', 'ｉ'},
        {'j', 'ｊ'},
        {'k', 'ｋ'},
        {'l', 'ｌ'},
        {'m', 'ｍ'},
        {'n', 'ｎ'},
        {'o', 'ｏ'},
        {'p', 'ｐ'},
        {'q', 'ｑ'},
        {'r', 'ｒ'},
        {'s', 'ｓ'},
        {'t', 'ｔ'},
        {'u', 'ｕ'},
        {'v', 'ｖ'},
        {'w', 'ｗ'},
        {'x', 'ｘ'},
        {'y', 'ｙ'},
        {'z', 'ｚ'},
        {'A', 'Ａ'},
        {'B', 'Ｂ'},
        {'C', 'Ｃ'},
        {'D', 'Ｄ'},
        {'E', 'Ｅ'},
        {'F', 'Ｆ'},
        {'G', 'Ｇ'},
        {'H', 'Ｈ'},
        {'I', 'Ｉ'},
        {'J', 'Ｊ'},
        {'K', 'Ｋ'},
        {'L', 'Ｌ'},
        {'M', 'Ｍ'},
        {'N', 'Ｎ'},
        {'O', 'Ｏ'},
        {'P', 'Ｐ'},
        {'Q', 'Ｑ'},
        {'R', 'Ｒ'},
        {'S', 'Ｓ'},
        {'T', 'Ｔ'},
        {'U', 'Ｕ'},
        {'V', 'Ｖ'},
        {'W', 'Ｗ'},
        {'X', 'Ｘ'},
        {'Y', 'Ｙ'},
        {'Z', 'Ｚ'},
        {' ', '　'},
    };
    /// <summary>
    /// 转换
    /// </summary>
    /// <param name="str"></param>
    /// <param name="Conversion"></param>
    /// <returns></returns>
    public static string StrConv(string str, StrConvMode Conversion)
    {
        switch(Conversion)
        {
        case StrConvMode.None:
            return str;
        case StrConvMode.Uppercase:
            return StrConv(str, StrConvMode.Narrow).ToUpper();
        case StrConvMode.Lowercase:
            return StrConv(str, StrConvMode.Narrow).ToLower();
        case StrConvMode.Wide:
            {
                var result = new StringBuilder();
                for(int i = 0; i < str.Length; ++i)
                {
                    char c = str[i];
                    char found = '\x0';
                    if(ToWide.TryGetValue(c, out found))
                        result.Append(found);
                    else
                    {
                        result.Append(' ');
                        result.Append(c);
                    }
                }
                return result.ToString();
            }
        case StrConvMode.Narrow:
            {
                var result = new StringBuilder();
                for(int i = 0; i < str.Length; ++i)
                {
                    char c = str[i];
                    char found = '\x0';
                    if(ToNarrow.TryGetValue(c, out found))
                        result.Append(found);
                    else
                        result.Append(c);
                }
                return result.ToString();
            }
        }
        return str;
    }
}
