-- XLua
StringHelper = CS.StringHelper
Config = CS.Config
Printer = CS.Printer
UnityEngine = CS.UnityEngine

local int = math.floor
local ssub = string.sub
local slen = string.len
local tinsert = table.insert
local hextable = 
{
    ["0"] = 0,
    ["1"] = 1,
    ["2"] = 2,
    ["3"] = 3,
    ["4"] = 4,
    ["5"] = 5,
    ["6"] = 6,
    ["7"] = 7,
    ["8"] = 8,
    ["9"] = 9,
    ["a"] = 10,
    ["b"] = 11,
    ["c"] = 12,
    ["d"] = 13,
    ["e"] = 14,
    ["f"] = 15,
}
local function HEX2NUMER(h, l)
    if h~=nil and slen(h) == 0 then
        h = nil
    end
    if h~=nil and slen(l) == 0 then
        l = nil
    end
    return hextable[h or "0"] * 16 + hextable[l or "0"]
end

local function StringAt(str, i)
    return ssub(str, i, i)
end

function Color(r, g, b, a)
    if type(r) == "string" then
        local name = string.lower(r)
        if StringAt(name, 1) == "#" then
            r = HEX2NUMER(StringAt(name,20), StringAt(name,3)) / 255.0;
            g = HEX2NUMER(StringAt(name,4), StringAt(name,5)) / 255.0;
            b = HEX2NUMER(StringAt(name,6), StringAt(name,7)) / 255.0;

            local a1 = StringAt(name,8)
            if a1~=nil and slen(a1)>0  then
                a = HEX2NUMER(a1, StringAt(name,9)) / 255.0;
            else
                a = 1
            end
        elseif name == "white" then
            return UnityEngine.Color.white
        elseif name == "black" then
            return UnityEngine.Color.black
        elseif name == "blue" then
            return UnityEngine.Color.blue
        elseif name == "clear" then
            return UnityEngine.Color.clear
        elseif name == "cyan" then
            return UnityEngine.Color.cyan
        elseif name == "gray" or name == "grey" then
            return UnityEngine.Color.gray
        elseif name == "green" then
            return UnityEngine.Color.green
        elseif name == "magenta" then
            return UnityEngine.Color.magenta
        elseif name == "red" then
            return UnityEngine.Color.red
        elseif name == "yellow" then
            return UnityEngine.Color.yellow
        else
            r = 1
            g = 1
            b = 1
            a = 0.5
        end
    end
    return {
        r = r,
        g = g,
        b = b,
        a = a or 1,
    }
end

STRCONV_UPPER = StringHelper.StrConvMode.Uppercase
STRCONV_LOWER = StringHelper.StrConvMode.Lowercase
STRCONV_WIDE = StringHelper.StrConvMode.Wide
STRCONV_NARROW = StringHelper.StrConvMode.Narrow

GetWordCount = StringHelper.GetWordCount
GetDisplayLength = function(s, fontsize, richedit)
    if fontsize == nil then
        fontsize = Config.FontSize
    end
    if richedit == nil then
        richedit = false
    end
    StringHelper.GetDisplayLength(s, int(fontsize), richedit)
end
GetStringBar = function(a, b, c)
    if c~=nil then
        return StringHelper.GetStringBar(a, int(b), c)
    else
        return StringHelper.GetStringBar(a, int(b))
    end
end
Space = function(v) return StringHelper.Space(int(v)) end
StrConv = StringHelper.StrConv

-------------------------------------------------------------------------------
-- Config
SetDefaultFlags = function(v)
    if type(v) == "table" then
        Config.FlagBit = v
    else
        Config.Flags = v
    end
end
GetDefaultFlags = function() return Config.Flags end
GetFlagBit = function() return Config.FlagBit end
SetDefaultColor = function(r, g, b, a)
    if type(r) == "table" then
        Config.FontColor = r
    else
        Config.FontColor = Color(r, g, b, a)
    end
end
GetDefaultColor = function() return Config.FontColor end
SetDefaultGradientColor = function(r, g, b, a)
    if type(r) == "table" then
        Config.FontGradientColor = r
    else
        Config.FontGradientColor = Color(r, g, b, a)
    end
end
GetDefaultGradientColor = function() return Config.FontGradientColor end
SetDefaultShadowColor = function(r, g, b, a)
    if type(r) == "table" then
        Config.FontShadowColor = r
    else
        Config.FontShadowColor = Color(r, g, b, a)
    end
end
GetDefaultShadowColor = function() return Config.FontShadowColor end
SetDefaultOutlineColor = function(r, g, b, a)
    if type(r) == "table" then
        Config.FontOutlineColor = r
    else
        Config.FontOutlineColor = Color(r, g, b, a)
    end
end
GetDefaultOutlineColor = function() return Config.FontOutlineColor end
SetDefaultSize = function(v) Config.FontSize = v end
GetDefaultSize = function() return Config.FontSize end
SetDefaultImageColor = function(r, g, b, a)
    if type(r) == "table" then
        Config.ImageColor = r
    else
        Config.ImageColor = Color(r, g, b, a)
    end
end
GetDefaultImageColor = function() return Config.ImageColor end
-- SetDefaultBackgroundColor = function()
--     if type(r) == "table" then
--         Config.set_BackgroundColor(r)
--     else
--         Config.set_BackgroundColor(Color(r, g, b, a))
--     end
-- end
-- GetDefaultBackgroundColor = Config.get_BackgroundColor

FILE_SYSTEM = Config.Location.FILE_SYSTEM
PACKAGE = Config.Location.PACKAGE
--ASSET_BUNDLE = Config.Location.ASSET_BUNDLE

SetResourcePath = Config.SetResourcePath
GetResourcePath = function() return Config.ResourcePath end
GetSavePath = Config.GetSavePath
SetSavePath = Config.SetSavePath
GetCsvPath = Config.GetCsvPath
SetCsvPath = Config.SetCsvPath

SetMaxLineCount = function(v) Config.MaxLog = v end
GetMaxLineCount = function() return Config.MaxLog end
SetDefaultLineHeight = function(v) Config.LineHeight = v end
GetDefaultLineHeight = function() return Config.LineHeight end

-------------------------------------------------------------------------------
SetLogFile = function(name, create)
    Printer.SetLogFile(name or "log.txt", create or false)
end
SetLogEnable = function(value)
    if value == nil then
        value = true
    end
    Printer.SetLogEnable(value)
end
LogWrite = Printer.LogWrite
LogShiftLine = Printer.LogShiftLine
LogWriteLn = Printer.LogWriteLn

-------------------------------------------------------------------------------
ShowFPS = function(value)
    if value == nil then
        value = true
    end
    Printer.ShowFPS(value)
end

-------------------------------------------------------------------------------
SetTargetFrame = Printer.SetTargetFrame
TargetFrame = Printer.TargetFrame;
SetBackgroundColor = function(r, g, b, a) 
    if type(r) == "table" then
        Printer.SetBackgroundColor(r)
    else
        Printer.SetBackgroundColor(Color(r, g, b, a))
    end
end
GetBackgroundColor = Printer.GetBackgroundColor
SetBackgroundImage = function(name, tiled, keep_aspect)
    if type(tiled) ~= "boolean" then
        tiled = false
    end
    if type(keep_aspect) ~= "boolean" then
        keep_aspect = false
    end
    Printer.SetBackgroundImage(name, tiled, keep_aspect)
end

SCREEN_PORTRAIT = Printer.ScreenOrientation.Portrait
SCREEN_PORTRAIT_UPSIDE = Printer.ScreenOrientation.PortraitUpsideDown
SCREEN_LANDSCAPE_LEFT = Printer.ScreenOrientation.LandscapeLeft
SCREEN_LANDSCAPE = Printer.ScreenOrientation.Landscape
SCREEN_LANDSCAPE_RIGHT = Printer.ScreenOrientation.LandscapeRight
SCREEN_AUTO_ROTATION = Printer.ScreenOrientation.AutoRotation

SetOrientation = Printer.SetOrientation
SetDragEnable = function(v)
    if type(v) ~= "boolean" then
        v = true
    end
    Printer.SetDragEnable(v)
end

-------------------------------------------------------------------------------
DataPath = Printer.DataPath
PersistentDataPath = Printer.PersistentDataPath
ProjectPath = Config.GetProjectPath
IsMobilePlatform = Printer.IsMobilePlatform
Platform = Printer.Platform
RunInBackground = Printer.RunInBackground
SetRunInBackground = Printer.SetRunInBackground
OpenURL = Printer.OpenURL
SetResolution = Printer.SetResolution
GetResolution = Printer.GetResolution
SetConsoleBorder = function(left_or_table, top, right, bottom)
    if type(left_or_table) == "table" then
        local t = left_or_table
        Printer.SetConsoleBorder(
            int(t.left or 0),
            int(t.top or 0),
            int(t.right or 0),
            int(t.bottom or 0))
    else
        Printer.SetConsoleBorder(int(left_or_table or 0), 
                                int(top or 0),
                                int(right or 0), 
                                int(bottom or 0))
    end
end

-------------------------------------------------------------------------------
NowStamp = Printer.NowStamp
Now = Printer.Now
DateToStamp = function(year_or_table, month, day, hour, min, sec)
    if type(year_of_table) == "table" then
        local t = year_of_table
        return Printer.DateToStamp(
            int(t.Year or 0),
            int(t.Month or 0),
            int(t.Day or 0),
            int(t.Hour or 0),
            int(t.Minue or 0),
            int(t.Second or 0))
    else
        return Printer.DateToStamp(
            int(year_or_table or 0),
            int(month or 0), int(day or 0),
            int(hour or 0),
            int(min or 0),
            int(sec or 0))
    end
end
Date = function(year, month, day, hour, min, sec)
    return Printer.Date(int(year), int(month), int(day), int(hour), int(min), int(sec))
end
StampToDate = Printer.StampToDate

-------------------------------------------------------------------------------
GetTextListCount = Printer.GetTextListCount
GetTextListWeight = Printer.GetTextListWeight
SetTextList = Printer.SetTextList
SetTextWeightList = Printer.SetTextWeightList
GetTextByIndex = Printer.GetTextByIndex
GetTextByWeight = Printer.GetTextByWeight

-------------------------------------------------------------------------------
HSVToRGB = UnityEngine.Color.HSVToRGB
RGBToHSV = UnityEngine.Color.RGBToHSV

PushFlags = Printer.PushFlags
PopFlags = Printer.PopFlags
DefaultFlags = Printer.DefaultFlags

local pflags = CS.FlagBit(0)
SetFlags = function(flags)
    if not flags then
        flags = {monospaced=true}
    elseif flags.monospaced == nil then
        flags.monospaced = true
    end
    pflags.isbutton = flags.isbutton or false
    pflags.underline = flags.underline or false
    pflags.strickout = flags.strickout or false
    pflags.richedit = flags.richedit or false
    pflags.monospaced = flags.monospaced
    pflags.gradient = flags.gradient or false
    pflags.outline = flags.outline or false
    pflags.shadow = flags.shadow or false
    pflags.bold = flags.bold or false
    pflags.italic = flags.italic or false
    Printer.flags = pflags
end
GetFlags = function() return Printer.flags end

PushColor = Printer.PushColor
PopColor = Printer.PopColor
DefaultColor = Printer.DefaultColor
SetColor = function(r, g, b, a) 
    if type(r) == "table" then
        Printer.color = r
    else
        Printer.color = Color(r, g, b, a)
    end
end
GetColor = function() return Printer.color end

PushGradientColor = Printer.PushGradientColor
PopGradientColor = Printer.PopGradientColor
DefaultGradientColor = Printer.DefaultGradientColor
SetGradientColor = function(r, g, b, a) 
    if type(r) == "table" then
        Printer.gradient_color = (r)
    else
        Printer.gradient_color = (Color(r, g, b, a))
    end
end
GetGradientColor = function() return Printer.gradient_color end

PushShadowColor = Printer.PushShadowColor
PopShadowColor = Printer.PopShadowColor
DefaultShadowColor = Printer.DefaultShadowColor
SetShadowColor = function(r, g, b, a) 
    if type(r) == "table" then
        Printer.shadow_color = (r)
    else
        Printer.shadow_color = (Color(r, g, b, a))
    end
end
GetShadowColor = function() return Printer.shadow_color end

PushOutlineColor = Printer.PushOutlineColor
PopOutlineColor = Printer.PopOutlineColor
DefaultOutlineColor = DefaultOutlineColor
SetOutlineColor = function(r, g, b, a)
    if type(r) == "table" then
        Printer.outline_color=(r)
    else
        Printer.outline_color=(Color(r, g, b, a))
    end
end
GetOutlineColor = function() return Printer.outline_color end

PushImageColor = Printer.PushImageColor
PopImageColor = Printer.PopImageColor
DefaultImageColor = DefaultImageColor
SetImageColor = function(r, g, b, a) 
    if type(r) == "table" then
        Printer.image_color=(r)
    else
        Printer.image_color=(Color(r, g, b, a))
    end
end
GetImageColor = function() return Printer.image_color end

PushAllConfig = Printer.PushAllConfig
PopAllConfig = Printer.PopAllConfig
DefaultAllConfig = Printer.DefaultAllConfig

SetButtonStyle = function(normal, highlighted, pressed, disabled)
    local normal_color, highlighted_color, pressed_color, disabled_color
    if type(normal) == "table" then
        normal_color = Color(unpack(normal))
    elseif type(normal) == "string" then
        normal_color = Color(normal)
    else
        normal_color = Color("white")
    end
    if type(highlighted) == "table" then
        highlighted_color = Color(unpack(highlighted))
    elseif type(highlighted) == "string" then
        highlighted_color = Color(highlighted)
    else
        highlighted_color = Color("white")
    end
    if type(pressed) == "table" then
        pressed_color = Color(unpack(pressed))
    elseif type(pressed) == "string" then
        pressed_color = Color(pressed)
    else
        pressed_color = Color("white")
    end
    if type(disabled) == "table" then
        disabled_color = Color(unpack(disabled))
    elseif type(disabled) == "string" then
        disabled_color = Color(disabled)
    else
        disabled_color = Color(0.5, 0.5, 0.5, 0.5)
    end
    Printer.SetButtonStyle(normal_color, highlighted_color,
                        pressed_color, disabled_color)
end
ClearButtonStyle = Printer.ClearButtonStyle

SetStyle = function(name, flags, color, 
                    gradient_color, shadow_color, 
                    outline_color, image_color, button_style, 
                    line_height)
    styles[name] = 
    {
        flags = flags,
        color = color,
        gradient_color = gradient_color,
        shadow_color = shadow_color,
        outline_color = outline_color,
        image_color = image_color,
        button_style = button_style,
        line_height = line_height,
    }
end
PushStyle = function(name)
    PushAllConfig()
    ClearButtonStyle()

    local style = styles[name]
    if not style then
        return
    end
    if style.flags then
        SetFlags(style.flags)
    end
    if style.color then
        SetColor(style.color)
    end
    if style.gradient_color then
        SetGradientColor(style.gradient_color)
    end
    if style.shadow_color then
        SetShadowColor(style.shadow_color)
    end
    if style.outline_color then
        SetOutlineColor(style.outline_color)
    end
    if style.image_color then
        SetImageColor(style.image_color)
    end
    if style.button_style then
        local bs = style.button_style
        SetButtonStyle(
            bs.normal_color,
            bs.highlighted_color,
            bs.pressed_color,
            bs.disable_color)
    end
    if not style.line_height then
        SetLineHeight(style.line_height)
    end
end
PopStyle = function()
    PopAllConfig()
    ClearButtonStyle()
    DefaultLineHeight()
end
local styles = {}

SetLineHeight = Printer.SetLineHeight
GetLineHeight = Printer.GetLineHeight
DefaultLineHeight = function()
    SetLineHeight(GetDefaultLineHeight())
end

-------------------------------------------------------------------------------
local section_flag = false
local section_line = 0
local section_currline = 0
BeginSection = function(line, clearflag)
    if clearflag then
        RemoveLine(section_line)
    end
    section_flag = true
    section_line = line
    section_currline = 0
end
EndSection = function()
    section_flag = false

    local line = section_line - section_currline
    if line <= 0 then
        return
    end
    ShiftLine(line)
end
GetSectionCurrentLine = function()
    return section_currline
end
GetSectionLine = function()
    return section_line
end
ClearSectionCurrentLine = function()
    section_currline = 0
end

-------------------------------------------------------------------------------
SetAutoLine = function(line_count)
    if type(line_count) ~= "number" then
        line_count = 0
    elseif line_count < 0 then
        line_count = 0
    end
    Printer.SetAutoLine(int(line_count))
end
GetAutoLine = Printer.GetAutoLine
GetStringLines = Printer.GetStringLines

-------------------------------------------------------------------------------
-- F 格式化文本
-- T 表格对齐文本
-- Ln 换行
ALIGN_LEFT = Printer.Align.kLeft
ALIGN_CENTER = Printer.Align.kCenter
ALIGN_RIGHT = Printer.Align.kRight

PrintF = function(format, ...)
    Printer.PrintF(format, ...)
end
PrintFLn = function(format, ...)
    Printer.PrintFLn(format, ...)
    if section_flag then
        section_currline = section_currline + 1
    end
end
PrintT = Printer.PrintT
PrintTLn = function(...)
    Printer.PrintTLn(...)
    if section_flag then
        section_currline = section_currline + 1
    end
end
PrintTF = function(t, align, format, ...)
    Printer.PrintTF(t, align, format, ...)
end
PrintTFLn = function(t, align, format, ...)
    Printer.PrintTFLn(t, align, format, ...)
    if section_flag then
        section_currline = section_currline + 1
    end
end
Print = function(v) Printer.Print(tostring(v)) end
PrintLn = function(v)
    Printer.PrintLn(tostring(v))
    if section_flag then
        section_currline = section_currline + 1
    end
end

-------------------------------------------------------------------------------
SetSpriteImage = Printer.SetSpriteImage
SetSpriteImages = function(sprites)
    for _, v in ipairs(sprites) do
        local n = v[1]
        if not n then
            goto next
        end
        local f = v[2]
        if not f then
            goto next
        end
        local t = v[3]
        if not t then 
            t = {0,0,0,0}
        else
            t[1] = t[1] or 0
            t[2] = t[2] or 0
            t[3] = t[3] or 0
            t[4] = t[4] or 0
        end
        local b = v[4]
        if not b then 
            b = {0,0,0,0}
        else
            b[1] = b[1] or 0
            b[2] = b[2] or 0
            b[3] = b[3] or 0
            b[4] = b[4] or 0  
        end
        SetSpriteImage(n, f, t, b, v[5] or false)
        ::next::
    end
end
SetSpriteAnimation = Printer.SetSpriteAnimation
SetSpriteAnimations = function(sanimations)
    for _, v in ipairs(sanimations) do
        local n = v[1]
        if not n then
            goto next
        end
        local f = v[2]
        local list = v[3]
        if list == nil or #list == 0 then
            goto next
        end

        local pt = list
        local at = {}
        for _, pv in ipairs(pt) do
            local ty = type(pv) 
            if ty == "table" then
                tinsert(at, pv)
            elseif ty == "string" then
                tinsert(at, {pv, 1})
            end
        end
        SetSpriteAnimation(n, f, at)
        ::next::
    end
end
ANIMATION_LOOP_COUNT = 0x7fffff00
SetAnimationLoop = function(loop)
    if loop == nil then
        loop = ANIMATION_LOOP_COUNT
    end
    Printer.SetAnimationLoop(loop)
end
CheckSprite = Printer.CheckSprite
-------------------------------------------------------------------------------
SetErrorImage = function(name, color)
    Printer.SetErrorImage(name or "@ERROR", color or Color("white"))
end

Image = function(name, x, y, w, h, tiled)
    Printer.Image(name, x or 0, y or 0, w or 0, h or 0, tiled or false)
end
ImageP = function(name, x, y, tiled)
    Printer.ImageP(name, x or 0, y or 0, tiled or false)
end
ImageW = function(name, w, tiled)
    Printer.ImageS(name, w or 0, 0, tiled or false)
end
ImageH = function(name, h, tiled)
    Printer.ImageS(name, 0, h or 0, tiled or false)
end
ImageS = function(name, w, h, tiled)
    Printer.ImageS(name, w or 0, h or 0, tiled or false)
end
ImagePS = function(name, x, y, w, h, tiled)
    Printer.ImagePS(name, x or 0, y or 0, w or 0, h or 0, tiled or false)
end

-------------------------------------------------------------------------------
RemoveLine = function(count)
    if not count then
        count = 1
    end
    if count == 0 then
        return
    end
    Printer.RemoveLine(count)
    if section_flag then
        section_currline = section_currline - count
    end
end
Clear = Printer.Clear

-------------------------------------------------------------------------------
SetCode = Printer.SetCode
PreButton = function()
    Printer.NextTextPart(false)
    Printer.NextImagePart(false)
end
NextButton = function()
    Printer.NextTextPart(true)
    Printer.NextImagePart(true)
end

Button = function(code, text)
    PreButton()
    SetCode(code)
    Print(text)
    NextButton()
    SetCode(nil)
end
ButtonLn = function(code, text)
    PreButton()
    SetCode(code)
    Print(text)
    NextButton()
    SetCode(nil)
    ShiftLine()
end
ButtonF = function(code, ...)
    PreButton()
    SetCode(code)
    PrintF(...)
    NextButton()
    SetCode(nil)
end
ButtonFLn = function(code, ...)
    PreButton()
    SetCode(code)
    PrintF(...)
    NextButton()
    SetCode(nil)
    ShiftLine()
end
ButtonT = function(code, ...)
    PreButton()
    SetCode(code)
    PrintT(...)
    NextButton()
    SetCode(nil)
end
ButtonTLn = function(code, ...)
    PreButton()
    SetCode(code)
    PrintT(...)
    NextButton()
    SetCode(nil)
    ShiftLine()
end
ButtonTF = function(code, ...)
    PreButton()
    SetCode(code)
    PrintTF(...)
    NextButton()
    SetCode(nil)
end
ButtonTFLn = function(code, ...)
    PreButton()
    SetCode(code)
    PrintTF(...)
    NextButton()
    SetCode(nil)
    ShiftLine()
end

ButtonImage = function(code, ...)
    PreButton()
    SetCode(code)
    Image(...)
    NextButton()
    SetCode(nil)
end
ButtonImageP = function(code, ...)
    PreButton()
    SetCode(code)
    ImageP(...)
    NextButton()
    SetCode(nil)
end
ButtonImageW = function(code, ...)
    PreButton()
    SetCode(code)
    ImageW(...)
    NextButton()
    SetCode(nil)
end
ButtonImageH = function(code, ...)
    PreButton()
    SetCode(code)
    ImageH(...)
    NextButton()
    SetCode(nil)
end
ButtonImageS = function(code, ...)
    PreButton()
    SetCode(code)
    ImageS(...)
    NextButton()
    SetCode(nil)
end
ButtonImagePS = function(code, ...)
    PreButton()
    SetCode(code)
    ImagePS(...)
    NextButton()
    SetCode(nil)
end

-------------------------------------------------------------------------------
Quit = Printer.Quit

-------------------------------------------------------------------------------
MSG_ONE_BUTTON = Printer.MsgType.ONE_BUTTON
MSG_TWO_BUTTON = Printer.MsgType.TWO_BUTTON

MSG_RESULT_LEFT = Printer.MsgResult.LEFT
MSG_RESULT_RIGHT = Printer.MsgResult.RIGHT
MSG_RESULT_NO = MSG_RESULT_LEFT
MSG_RESULT_CANCEL = MSG_RESULT_LEFT
MSG_RESULT_OK = MSG_RESULT_RIGHT

function WaitMessageBox()
    local IsShow = Printer.MessageBoxIsShow
    while IsShow() do
        coroutine.yield()
    end
    return Printer.MessageBoxResult()
end

MessageBoxshow = function(content_or_table)
    if content_or_table == nil then
        return
    end
  
    local t = content_or_table
    if type(t) == "string" then
        t = {content = content_or_table}
    end
    Printer.MessageBox(
        t.content or "",
        t.type or MSG_ONE_BUTTON,
        t.left_button_text or "Cancel",
        t.right_button_text or "OK",
        t.border_color or Color("white"),
        t.content_color or Color("black"),
        t.left_color or Color("white"),
        t.left_text_color or Color("black"),
        t.right_color or Color("white"),
        t.right_text_color or Color("black"),
        t.size or {400, 200}
    )
end

MessageBox = function(content_or_table)
    MessageBoxshow(content_or_table)
    return WaitMessageBox()
end

function WaitInputBox()
    local IsShow = Printer.InputBoxIsShow
    while IsShow() do
        coroutine.yield()
    end
    return Printer.InputBoxResult()
end

INPUTTYPE_STANDARD = Printer.InputType.STANDARD
INPUTTYPE_INTEGER = Printer.InputType.INTEGER
INPUTTYPE_DECIMAL = Printer.InputType.DECIMAL
INPUTTYPE_ALPHANUMERIC = Printer.InputType.ALPHANUMERIC
INPUTTYPE_PASSWORD = Printer.InputType.PASSWORD

InputBoxShow = function(content_or_table, inputtype)
    if content_or_table == nil then
        return
    end
    
    local t = content_or_table
    if type(t) == "string" then
        t = {content = content_or_table, inputtype = inputtype}
    end
    Printer.InputBoxShow(
        t.content or "",
        t.inputtype or INPUTTYPE_STANDARD,
        t.default or "",
        t.placeholder or "",
        t.button_text or "OK",
        t.border_color or Color("white"),
        t.content_color or Color("green"),
        t.text_color or Color("black"),
        t.placeholder_color or Color("gray"),
        t.button_color or Color("white"),
        t.button_text_color or Color("black"),
        t.input_color or Color("white")
    )
end

InputBox = function(content_or_table, inputtype)
    InputBoxShow(content_or_table, inputtype)
    return WaitInputBox()
end

-------------------------------------------------------------------------------
EnumScripts = Printer.EnumScripts

-------------------------------------------------------------------------------
require "(-_-b)Csv"
CsvDecode = function(name, haskey, dictflag)
    local content = Printer.LoadCsv(name)
    if content == nil then
        return nil
    end
    if haskey == nil then
        haskey = false
    end
    if dictflag == nil then
        dictflag = false
    end
    return decodeCSV(content, haskey, dictflag)
end

-------------------------------------------------------------------------------
require "(-_-b)Json"
JsonEncode = encode
JsonDecode = decode

-------------------------------------------------------------------------------
require "(-_-b)Novel"

-------------------------------------------------------------------------------
Save = function(name, content, password)
    local t = type(content)
    if t == "string" then
        SaveString(name, content, password)
    elseif t == "table" then
        SaveTable(name, content, password)
    end
end
SaveString = function(name, content, password)
    Printer.Save(name, content, password)
end
SaveTable = function(name, content, password)
    if content == nil then
        return
    end
    local json = JsonEncode(content)
    Printer.Save(name, json, password)
end
LoadString = function(name, password)
    return Printer.Load(name, password)
end
LoadTable = function(name, password)
    local c = LoadString(name, password)
    if c == nil then
        return nil
    end
    return JsonDecode(c)
end
Exist = function(name)
    if name == nil then
        return false
    end
    return Printer.Exist(name)
end
Delete = function(name)
    if name == nil then
        return
    end
    Printer.Delete(name)
end
EnumSaves = Printer.EnumSaves

-------------------------------------------------------------------------------
MovePosByPixel = Printer.MovePosByPixel
MovePosByWord = Printer.MovePosByWord
ResetPosByPixel = function (p)
    Printer.ResetPosByPixel(p or 0)
end
ResetPosByWord = function(w)
    Printer.ResetPosByWord(w or 0)
end
GetCurrentPos = Printer.GetCurrentPos

ShiftLine = function(n, roll_to_bottom)
    if not n then
        n = 1
    end
    if n <= 0 then
        return
    end
    if type(roll_to_bottom) ~= "boolean" then
        roll_to_bottom = true
    end
    Printer.ShiftLine(n, roll_to_bottom)

    if section_flag then
        section_currline = section_currline + n
    end
end

SetMsg = Printer.SetMsg
GetMsg = Printer.GetMsg
ClearMsg = Printer.ClearMsg
EmptyMsg = function(need_content)
    if type(need_content) ~= "boolean" then
        need_content = falses
    end
    return Printer.EmptyMsg(need_content)
end
WaitMsg = function(need_content)
    while EmptyMsg(need_content) do
        coroutine.yield()
    end
    return GetMsg()
end
WaitMsgAndClear = function(need_content)
    local msg = WaitMsg(need_content)
    ClearMsg()
    return msg
end

local ssplit = function(str, sep)
    local sep, result = sep or "\n", {}
    local pattern = string.format("([^%s]+)", sep)
    string.gsub(str, pattern, 
        function (c)
            tinsert(result, c)
        end)
    return result
end
string.split = ssplit

local ErrorFunction = function(err)
    PushAllConfig()
    DefaultAllConfig()
    SetFlags({monospaced=false})
    SetColor("red")
    PrintLn("========================================")
    SetAutoLine(0)
    PrintLn(err)
    PopAllConfig()
end

local Entry = require"Entry"
if Entry == nil then
    Entry = require"Entry.Default"
end
local Mono = MonoBase({})

Mono.StartCoroutine(function ()
    if type(Entry.Init) == "function" then
        Entry.Init()
    end
    xpcall(Entry.Exec, ErrorFunction)
    coroutine.yield()
end)

return Mono