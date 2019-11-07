API 参考说明
===========

目录
----
##### 基本
* [*function* Color(name)](#Color1)
* [*function* Color(r, g, b, a)](#Color2)
* [*function* GetWordCount(str, richedit)](#GetWordCount)
* [*function* GetDisplayLength(str, fontsize, richedit)](#GetDisplayLength)
* [*function* GetStringBar(str, count)](#GetStringBar)
* [*function* Space(count)](#Space)
* [*function* StrConv(str, convmode)](#StrConv)
##### 属性设置
* [*function* SetFlags(flags)](#SetFlags)
* [*function* GetFlags()](#GetFlags)
* [*function* PushFlags()](#PushFlags)
* [*function* PopFlags()](#PopFlags)
* [*function* DefaultFlags()](#DefaultFlags)
* [*function* SetColor(name)](#SetColor1)
* [*function* SetColor(r, g, b, a)](#SetColor2)
* [*function* GetColor()](#GetColor)
* [*function* PushColor()](#PushColor)
* [*function* PopColor()](#PopColor)
* [*function* DefaultColor()](#DefaultColor)
* [*function* SetGradientColor(name)](#SetGradientColor1)
* [*function* SetGradientColor(r, g, b, a)](#SetGradientColor2)
* [*function* GetGetGradientColor()](#GetGetGradientColor)
* [*function* PushGradientColor()](#PushGradientColor)
* [*function* PopGradientColor()](#PopGradientColor)
* [*function* DefaultGradientColor()](#DefaultGradientColor)
* [*function* SetShadowColor(name)](#SetShadowColor1)
* [*function* SetShadowColor(r, g, b, a)](#SetShadowColor2)
* [*function* GetShadowColor()](#GetShadowColor)
* [*function* PushGradientColor()](#PushGradientColor)
* [*function* PopGradientColor()](#PopGradientColor)
* [*function* DefaultGradientColor()](#DefaultGradientColor)
* [*function* SetOutlineColor(name)](#SetOutlineColor1)
* [*function* SetOutlineColor(r, g, b, a)](#SetOutlineColor2)
* [*function* GetOutlineColor()](#GetOutlineColor)
* [*function* PushOutlineColor()](#PushOutlineColor)
* [*function* PopOutlineColor()](#PopOutlineColor)
* [*function* DefaultOutlineColor()](#DefaultOutlineColor)
* [*function* SetImageColor(name)](#SetImageColor1)
* [*function* SetImageColor(r, g, b, a)](#SetImageColor2)
* [*function* GetImageColor()](#GetImageColor)
* [*function* PushImageColor()](#PushImageColor)
* [*function* PopImageColor()](#PopImageColor)
* [*function* DefaultImageColor()](#DefaultImageColor)
* [*function* PushAllConfig()](#PushAllConfig)
* [*function* PopAllConfig()](#PopAllConfig)
* [*function* DefaultAllConfig()](#DefaultAllConfig)
* [*function* SetButtonStyle(normal, highlighted, pressed, disabled)](#SetButtonStyle)
* [*function* ClearButtonStyle()](#ClearButtonStyle)
* [*function* SetStyle(name, flags, color, gradient_color, shadow_color, outline_color, image_color, button_style, line_height)](#SetStyle)
* [*function* PushStyle(name)](#PushStyle)
* [*function* PopStyle()](#PopStyle)
* [*function* SetLineHeight(height)](#SetLineHeight)
* [*function* GetLineHeight()](#GetLineHeight)
* [*function* DefaultLineHeight()](#DefaultLineHeight)
##### 默认属性设置
* [*function* SetDefaultFlags(flags)](#SetDefaultFlags)
* [*function* GetDefaultFlags()](#GetDefaultFlags)
* [*function* SetDefaultColor(name)](#SetDefaultColor1)
* [*function* SetDefaultColor(r, g, b, a)](#SetDefaultColor2)
* [*function* GetDefaultColor()](#GetDefaultColor)
* [*function* SetDefaultGradientColor(name)](#SetDefaultGradientColor1)
* [*function* SetDefaultGradientColor(r, g, b, a)](#SetDefaultGradientColor2)
* [*function* GetDefaultGradientColor()](#GetDefaultGradientColor)
* [*function* SetDefaultShadowColor(name)](#SetDefaultShadowColor1)
* [*function* SetDefaultShadowColor(r, g, b, a)](#SetDefaultShadowColor2)
* [*function* GetDefaultShadowColor()](#GetDefaultShadowColor)
* [*function* SetDefaultOutlineColor(name)](#SetDefaultOutlineColor1)
* [*function* SetDefaultOutlineColor(r, g, b, a)](#SetDefaultOutlineColor2)
* [*function* GetDefaultOutlineColor()](#GetDefaultOutlineColor)
* [*function* SetDefaultImageColor(name)](#SetDefaultImageColor1)
* [*function* SetDefaultImageColor(r, g, b, a)](#SetDefaultImageColor2)
* [*function* GetDefaultImageColor()](#GetDefaultImageColor)
* [*function* SetDefaultSize(size)](#SetDefaultSize)
* [*function* GetDefaultSize()](#GetDefaultSize)
* [*function* SetDefaultLineHeight(height)](#SetDefaultLineHeight)
* [*function* GetDefaultLineHeight()](#GetDefaultLineHeight)
##### 显示
* [*function* Print(str)](#Print)
* [*function* PrintLn(str)](#PrintLn)
* [*function* PrintF(format, ...)](#PrintF)
* [*function* PrintFLn(format, ...)](#PrintFLn)
* [*function* PrintT(t, align, str)](#PrintT)
* [*function* PrintTLn(t, align, str)](#PrintTLn)
* [*function* PrintTF(t, align, format, ...)](#PrintTF)
* [*function* PrintTFLn(t, align, format, ...)](#PrintTFLn)
* [*function* Image(name, x, y, w, h, tiled)](#Image)
* [*function* ImageP(name, x, y, tiled)](#ImageP)
* [*function* ImageW(name, w, tiled)](#ImageW)
* [*function* ImageH(name, h, tiled)](#ImageH)
* [*function* ImageS(name, w, h, tiled)](#ImageS)
* [*function* ImagePS(name, x, y, w, h, tiled)](#ImagePS)
* [*function* ImagePS(name, x, y, w, h, tiled)](#ImagePS)
* [*function* Button(code, text)](#Button)
* [*function* ButtonLn(code, text)](#ButtonLn)
* [*function* ButtonF(code, ...)](#ButtonF)
* [*function* ButtonFLn(code, ...)](#ButtonFLn)
* [*function* ButtonT(code, ...)](#ButtonT)
* [*function* ButtonTLn(code, ...)](#ButtonTLn)
* [*function* ButtonTF(code, ...)](#ButtonTF)
* [*function* ButtonTFLn(code, ...)](#ButtonTFLn)
* [*function* ButtonImage(code, ...)](#ButtonImage)
* [*function* ButtonImageP(code, ...)](#ButtonImageP)
* [*function* ButtonImageW(code, ...)](#ButtonImageW)
* [*function* ButtonImageH(code, ...)](#ButtonImageH)
* [*function* ButtonImageS(code, ...)](#ButtonImageS)
* [*function* ButtonImagePS(code, ...)](#ButtonImagePS)
* [*function* RemoveLine(count)](#RemoveLine)
* [*function* Clear()](#Clear)
* [*function* MovePosByPixel(count)](#MovePosByPixel)
* [*function* MovePosByWord(count)](#MovePosByWord)
* [*function* ResetPosByPixel(count)](#ResetPosByPixel)
* [*function* ResetPosByWord(count)](#ResetPosByWord)
* [*function* GetCurrentPos()](#GetCurrentPos)
* [*function* SetAutoLine(line_count)](#SetAutoLine)
* [*function* GetAutoLine()](#GetAutoLine)
* [*function* GetStringLines(str, richedit, count)](#GetStringLines)
* [*function* SetBackgroundColor(name)](#SetBackgroundColor1)
* [*function* SetBackgroundColor(r, g, b, a)](#SetBackgroundColor2)
* [*function* SetBackgroundImage(name, tiled=false, keep_aspect=false)](#SetBackgroundImage)
* [*function* BeginSection(line, clearflag=false)](#BeginSection)
* [*function* EndSection()](#EndSection)
* [*function* GetSectionCurrentLine()](#GetSectionCurrentLine)
* [*function* GetSectionLine()](#GetSectionLine)
* [*function* ClearSectionCurrentLine()](#ClearSectionCurrentLine)
##### 交互
* [*function* SetMsg(msg)](#SetMsg)
* [*function* GetMsg()](#GetMsg)
* [*function* ClearMsg()](#ClearMsg)
* [*function* EmptyMsg(need_content=false)](#EmptyMsg)
* [*function* WaitMsg(need_content=false)](#WaitMsg)
* [*function* WaitMsgAndClear(need_content=false)](#WaitMsgAndClear)
##### 图片配置
* [*function* SetResourcePath(path, location)](#SetResourcePath)
* [*function* GetResourcePath()](#GetResourcePath)
* [*function* SetSpriteImage(name, file, rect, border, hidden=false)](#SetSpriteImage)
* [*function* SetSpriteImages(sprites)](#SetSpriteImage)
* [*function* SetSpriteAnimation(name, fps, sprites)](#SetSpriteAnimation)
* [*function* SetSpriteAnimations(anims)](#SetSpriteAnimations)
* [*function* SetAnimationLoop(count)](#SetAnimationLoop)
* [*function* CheckSprite(name)](#CheckSprite)
##### Json
* [*function* JsonEncode(value)](#JsonEncode)
* [*function* JsonDecode(json)](#JsonDecode)
##### Csv
* [*function* SetCsvPath(path)](#SetCsvPath)
* [*function* GetCsvPath()](#GetCsvPath)
* [*function* CsvDecode(name, haskey, dictflag)](#CsvDecode)
##### 存档
* [*function* SetSavePath(path)](#SetSavePath)
* [*function* GetSavePath()](#GetSavePath)
* [*function* Save(name, content, password)](#Save)
* [*function* SaveString(name, content, password)](#SaveString)
* [*function* SaveTable(name, content, password)](#SaveTable)
* [*function* LoadString(name, password)](#LoadString)
* [*function* LoadTable(name, password)](#LoadString)
* [*function* Exist(name)](#Exist)
* [*function* Delete(name)](#Delete)
* [*function* EnumSaves()](#EnumSaves)
##### 文本库
* [*function* SetTextWeightList(name, table)](#SetTextWeightList)
* [*function* SetTextList(name, table)](#SetTextList)
* [*function* GetTextListCount(name)](#GetTextListCount)
* [*function* GetTextListWeight(name)](#GetTextListWeight)
* [*function* GetTextByIndex(name)](#GetTextByIndex)
* [*function* GetTextByWeight(name)](#GetTextByWeight)
##### 时间
* [*function* NowStamp()](#NowStamp)
* [*function* Now()](#Now)
* [*function* DateToStamp(date_table)](#DateToStamp1)
* [*function* DateToStamp(year, month, day, hour, min, sec)](#DateToStamp2)
* [*function* Date(year, month, day, hour, min, sec)](#Date)
* [*function* StampToDate(stamp)](#StampToDate)
##### 其他
* [*function* SetMaxLineCount(count)](#SetMaxLineCount)
* [*function* GetMaxLineCount()](#GetMaxLineCount)
* [*function* ShowFPS(value)](#ShowFPS)
* [*function* SetTargetFrame(count)](#SetTargetFrame)
* [*function* SetOrientation(orientation)](#SetOrientation)
* [*function* SetDragEnable(value)](#SetDragEnable)
* [*function* DataPath()](#DataPath)
* [*function* PersistentDataPath()](#PersistentDataPath)
* [*function* ProjectPath()](#ProjectPath)
* [*function* IsMobilePlatform()](#IsMobilePlatform)
* [*function* Platform()](#Platform)
* [*function* RunInBackground()](#RunInBackground)
* [*function* SetRunInBackground(value)](#SetRunInBackground)
* [*function* OpenURL(url)](#OpenURL)
* [*function* SetResolution(w, h)](#SetResolution)
* [*function* GetResolution()](#GetResolution)
* [*function* SetConsoleBorder(left, top, right, bottom)](#SetConsoleBorder)

基本
---

#### *function* <tag id=Color1>Color</tag>(name)
> name: 颜色名，或者使用编码#RRGGBBAA

颜色定义函数
<tag id=color_list>有效颜色名:</tag>
|名字|说明|
|:----:|:----:|
|white | 白色|
|black | 黑色|
|blue | 蓝色|
|clear | |
|gray | 灰色|
|grey | 灰色|
|green | 绿色|
|magenta | 紫红色|
|red | 红色|
|yellow | 黄色|
```lua
    Color("red")
    Color("#ff00ff")
```

#### *function* <tag id=Color2>Color</tag>(r, g, b, a=1)
> r: 数值, R通道, [0, 1]
> g: 数值, G通道, [0, 1]
> b: 数值, B通道, [0, 1]
> a: 数值, Alpha通道, 默认值为1, [0, 1]

颜色定义函数  
```lua
Color(1, 1, 1)
```
  
#### *function* <tag id=GetWordCount>GetWordCount</tag>(str, richedit=false)
> str: 字符串, 文本内容
> richedit: 布尔型, 是否启用富文本(默认为false)

计算文本字符数。小于0x7f的字符计为1，另外计为2
```lua
local count = GetWordCount("Hello World!")
```

#### *function* <tag id=GetDisplayLength>GetDisplayLength</tag>(str, fontsize=[Config.FontSize], richedit=false)
> str: 字符串, 文本内容
> richedit: 布尔型, 是否启用富文本(默认为false)
> fontsize: 数值型, 字体尺寸(默认为当前字体尺寸)

计算文本宽度。
```lua
local width = GetDisplayLength("Hello World!")
```

#### *function* <tag id=GetStringBar>GetStringBar</tag>(str, count)
> str: 字符串, 文本内容
> count: 数值, 数量

生成一个文本条
```lua
local bar1 = GetStringBar("*", 10) -- bar = "**********"
local bar1 = GetStringBar("-", 20) -- bar = "--------------------"
```

#### *function* <tag id=Space>Space</tag>(count)
> count: 数值, 空格数量

生成空格数量

#### *function* <tag id=StrConv>StrConv</tag>(str, convmode)
> str: 字符串, 文本内容, 需要转换的字符串
> convmode: 值枚举, 转换枚举

字符串按模式转换

|枚举|转换模式|
|:--:|:---:|
|STRCONV_UPPER|转换为大写|
|STRCONV_LOWER|转换为小写|
|STRCONV_WIDE|转换为宽字符|
|STRCONV_NARROW|转换为窄字符|

```lua
local str1 = StrConv("ABC123", STRCONV_LOWER) -- str1 = "abc123"
local str2 = StrConv("ABC123", STRCONV_WIDE) -- str2 = "ＡＢＣ１２３"
```

属性设置
-------

#### *function* <tag id=SetFlags>SetFlags</tag>(flags)
> flags: 表, 标识

设置标识表, <tag id=flag_list>标识说明表</tag>

|键名|说明|
|:--|:--|
|isbutton|是否为按钮, 建议使用Button系列函数|
|underline|下划线|
|strickout|删除线|
|richedit|富文本|
|monospaced|等宽字符, 默认为true|
|gradient|渐变|
|outline|描边|
|shadow|阴影|
|bold|粗体|
|italic|斜体|

```lua
SetFlags({
    underline = true,
    richedit = true,
    monospaced = true,
})
```

#### *function* <tag id=GetFlags>GetFlags</tag>()

过去当前标识表

#### *function* <tag id=PushFlags>PushFlags</tag>()

当前标识配置压入存储栈

#### *function* <tag id=PopFlags>PopFlags</tag>()

弹出存储栈到当前标识配置

```lua
PushFlags()
SetFlags({underline = true})
-- ...
PopFlags()
```

#### *function* <tag id=DefaultFlags>DefaultFlags</tag>()

恢复默认标记配置, 默认标记配置[参看这里](#flag_list)

#### *function* <tag id=SetColor1>SetColor</tag>(name)
> name: 颜色名, 或者使用编码#RRGGBBAA, 配置表[参看这里](#color_list)

设置打印文本颜色

#### *function* <tag id=SetColor2>SetColor</tag>(r, g, b, a)
> r: 数值, R通道, [0, 1]
> g: 数值, G通道, [0, 1]
> b: 数值, B通道, [0, 1]
> a: 数值, Alpha通道, 默认值为1, [0, 1]

设置打印文本颜色

#### *function* <tag id=GetColor>GetColor</tag>()

获取当前打印文本颜色

#### *function* <tag id=PushColor>PushColor</tag>()

当前打印文本颜色压入存储栈

#### *function* <tag id=PopColor>PopColor</tag>()

弹出存储栈到当前打印文本颜色

#### *function* <tag id=DefaultColor>DefaultColor</tag>()

恢复默认打印文本颜色

#### *function* <tag id=SetGradientColor1>SetGradientColor</tag>(name)
> name: 颜色名, 或者使用编码#RRGGBBAA, 配置表[参看这里](#color_list)

设置打印渐变文本颜色

#### *function* <tag id=SetGradientColor2>SetGradientColor</tag>(r, g, b, a)
> r: 数值, R通道, [0, 1]
> g: 数值, G通道, [0, 1]
> b: 数值, B通道, [0, 1]
> a: 数值, Alpha通道, 默认值为1, [0, 1]

设置打印渐变文本颜色

#### *function* <tag id=GetGetGradientColor>GetGetGradientColor</tag>()

获取当前打印渐变文本颜色

#### *function* <tag id=PushGradientColor>PushGradientColor</tag>()

当前打印渐变文本颜色压入存储栈

#### *function* <tag id=PopGradientColor>PopGradientColor</tag>()

弹出存储栈到当前打印渐变文本颜色

#### *function* <tag id=DefaultGradientColor>DefaultGradientColor</tag>()

恢复默认打印渐变文本颜色

#### *function* <tag id=SetShadowColor1>SetShadowColor</tag>(name)
> name: 颜色名, 或者使用编码#RRGGBBAA, 配置表[参看这里](#color_list)

设置打印渐变文本颜色

#### *function* <tag id=SetShadowColor2>SetShadowColor</tag>(r, g, b, a)
> r: 数值, R通道, [0, 1]
> g: 数值, G通道, [0, 1]
> b: 数值, B通道, [0, 1]
> a: 数值, Alpha通道, 默认值为1, [0, 1]

设置打印阴影文本颜色

#### *function* <tag id=GetShadowColor>GetShadowColor</tag>()

获取当前打印阴影文本颜色

#### *function* <tag id=PushShadowColor>PushShadowColor</tag>()

当前打印阴影文本颜色压入存储栈

#### *function* <tag id=PopShadowColor>PopShadowColor</tag>()

弹出存储栈到当前打印阴影文本颜色

#### *function* <tag id=DefaultShadowColor>DefaultShadowColor</tag>()

恢复默认打印阴影文本颜色

#### *function* <tag id=SetOutlineColor1>SetOutlineColor</tag>(name)
> name: 颜色名, 或者使用编码#RRGGBBAA, 配置表[参看这里](#color_list)

设置打印描边文本颜色

#### *function* <tag id=SetOutlineColor2>SetOutlineColor</tag>(r, g, b, a)
> r: 数值, R通道, [0, 1]
> g: 数值, G通道, [0, 1]
> b: 数值, B通道, [0, 1]
> a: 数值, Alpha通道, 默认值为1, [0, 1]

设置打印描边文本颜色

#### *function* <tag id=GetOutlineColor>GetOutlineColor</tag>()

获取当前打印描边文本颜色

#### *function* <tag id=PushOutlineColor>PushOutlineColor</tag>()

当前打印描边文本颜色压入存储栈

#### *function* <tag id=PopOutlineColor>PopOutlineColor</tag>()

弹出存储栈到当前打印描边文本颜色

#### *function* <tag id=DefaultOutlineColor>DefaultOutlineColor</tag>()

恢复默认打印描边文本颜色

#### *function* <tag id=SetImageColor1>SetImageColor</tag>(name)
> name: 颜色名, 或者使用编码#RRGGBBAA, 配置表[参看这里](#color_list)

设置图片颜色

#### *function* <tag id=SetImageColor2>SetImageColor</tag>(r, g, b, a)
> r: 数值, R通道, [0, 1]
> g: 数值, G通道, [0, 1]
> b: 数值, B通道, [0, 1]
> a: 数值, Alpha通道, 默认值为1, [0, 1]

设置图片颜色

#### *function* <tag id=GetImageColor>GetImageColor</tag>()

获取当前图片颜色

#### *function* <tag id=PushImageColor>PushImageColor</tag>()

当前图片颜色压入存储栈

#### *function* <tag id=PopImageColor>PopImageColor</tag>()

弹出存储栈到当前图片颜色

#### *function* <tag id=DefaultImageColor>DefaultImageColor</tag>()

恢复默认图片颜色

#### *function* <tag id=PushAllConfig>PushAllConfig</tag>()

当前所有配置压入存储栈

#### *function* <tag id=PopAllConfig>PopAllConfig</tag>()

弹出存储栈到所有配置

#### *function* <tag id=DefaultAllConfig>DefaultAllConfig</tag>()

恢复所有默认配置

#### *function* <tag id=SetButtonStyle>SetButtonStyle</tag>(normal, highlighted, pressed, disabled)
> normal: 颜色, 普通状态颜色
> highlighted: 颜色, 高亮状态颜色
> pressed: 颜色, 按下状态颜色
> disabled: 颜色, 禁用状态颜色

设置按钮状态

```lua
SetButtonStyle(Color("white"), Color("#ff0000"), Color(1,1,0,1), Color("gray"))
```

#### *function* <tag id=ClearButtonStyle>ClearButtonStyle</tag>()

清空按钮状态

#### *function* <tag id=SetStyle>SetStyle</tag>(name, flags, color, gradient_color, shadow_color, outline_color, image_color, button_style, line_height)
> name: 字符串, 风格名字
> flags: 表, 标识表
> colors: 颜色, 文本颜色
> gradient_color: 颜色, 渐变颜色
> shadow_color: 颜色, 阴影颜色
> outline_color: 颜色, 描边颜色
> image_color: 颜色, 图片颜色
> button_style: 表, 按钮风格表
> line_height: 数值, 行高

设置风格

#### *function* <tag id=PushStyle>PushStyle</tag>(name)
> name: 字符串, 风格名字

当前所有配置压入存储栈, 并使用当前风格

#### *function* <tag id=PopStyle>PopStyle</tag>()

弹出存储栈到所有配置, 包括按钮风格

#### *function* <tag id=SetLineHeight>SetLineHeight</tag>(height)
> height: 数值, 行高

设置行高

#### *function* <tag id=GetLineHeight>GetLineHeight</tag>()

获取行高

#### *function* <tag id=DefaultLineHeight>DefaultLineHeight</tag>()

恢复默认行高

默认属性设置
-----------

#### *function* <tag id=SetDefaultFlags>SetDefaultFlags</tag>(flags)
> flags: 表, 标识

设置默认标识表，[标识说明表](#flag_list)

#### *function* <tag id=GetDefaultFlags>GetDefaultFlags</tag>()

获取默认标识表

#### *function* <tag id=SetDefaultColor1>SetDefaultColor</tag>(name)
> name: 颜色名, 或者使用编码#RRGGBBAA, 配置表[参看这里](#color_list)

设置默认颜色

#### *function* <tag id=SetDefaultColor2>SetDefaultColor</tag>(r, g, b, a)
> r: 数值, R通道, [0, 1]
> g: 数值, G通道, [0, 1]
> b: 数值, B通道, [0, 1]
> a: 数值, Alpha通道, 默认值为1, [0, 1]

设置默认颜色

#### *function* <tag id=GetDefaultColor>GetDefaultColor</tag>()

获取默认颜色

#### *function* <tag id=SetDefaultGradientColor1>SetDefaultGradientColor</tag>(name)
> name: 颜色名, 或者使用编码#RRGGBBAA, 配置表[参看这里](#color_list)

设置默认渐变颜色

#### *function* <tag id=SetDefaultGradientColor2>SetDefaultGradientColor</tag>(r, g, b, a)
> r: 数值, R通道, [0, 1]
> g: 数值, G通道, [0, 1]
> b: 数值, B通道, [0, 1]
> a: 数值, Alpha通道, 默认值为1, [0, 1]

设置默认渐变颜色

#### *function* <tag id=GetDefaultGradientColor>GetDefaultGradientColor</tag>()

获取默认渐变颜色

#### *function* <tag id=SetDefaultShadowColor1>SetDefaultShadowColor</tag>(name)
> name: 颜色名, 或者使用编码#RRGGBBAA, 配置表[参看这里](#color_list)

设置默认阴影颜色

#### *function* <tag id=SetDefaultShadowColor2>SetDefaultShadowColor</tag>(r, g, b, a)
> r: 数值, R通道, [0, 1]
> g: 数值, G通道, [0, 1]
> b: 数值, B通道, [0, 1]
> a: 数值, Alpha通道, 默认值为1, [0, 1]

设置默认阴影颜色

#### *function* <tag id=GetDefaultShadowColor>GetDefaultShadowColor</tag>()

获取默认阴影颜色

#### *function* <tag id=SetDefaultOutlineColor1>SetDefaultOutlineColor</tag>(name)
> name: 颜色名, 或者使用编码#RRGGBBAA, 配置表[参看这里](#color_list)

设置默认描边颜色

#### *function* <tag id=SetDefaultOutlineColor2>SetDefaultOutlineColor</tag>(r, g, b, a)
> r: 数值, R通道, [0, 1]
> g: 数值, G通道, [0, 1]
> b: 数值, B通道, [0, 1]
> a: 数值, Alpha通道, 默认值为1, [0, 1]

设置默认描边颜色

#### *function* <tag id=GetDefaultOutlineColor>GetDefaultOutlineColor</tag>()

获取默认描边颜色

#### *function* <tag id=SetDefaultImageColor1>SetDefaultImageColor</tag>(name)
> name: 颜色名, 或者使用编码#RRGGBBAA, 配置表[参看这里](#color_list)

设置默认图片颜色

#### *function* <tag id=SetDefaultImageColor2>SetDefaultImageColor</tag>(r, g, b, a)
> r: 数值, R通道, [0, 1]
> g: 数值, G通道, [0, 1]
> b: 数值, B通道, [0, 1]
> a: 数值, Alpha通道, 默认值为1, [0, 1]

设置默认图片颜色

#### *function* <tag id=GetDefaultImageColor>GetDefaultImageColor</tag>()

获取默认图片颜色

#### *function* <tag id=SetDefaultSize>SetDefaultSize</tag>(size)
> size: 数值, 文本大小

设置默认文本大小

#### *function* <tag id=GetDefaultSize>GetDefaultSize</tag>()

获取默认文本大小

#### *function* <tag id=SetDefaultLineHeight>SetDefaultLineHeight</tag>(height)
> height: 数值, 行高

设置默认行高

#### *function* <tag id=GetDefaultLineHeight>GetDefaultLineHeight</tag>()

获取默认行高

显示
----

#### *function* <tag id=Print>Print</tag>(str)
> str: 字符串, 文本内容

打印字符串
```lua
Print("Hello World!")
```

#### *function* <tag id=PrintLn>PrintLn</tag>(str)
> str: 字符串, 文本内容

打印字符串，并**换行**
```lua
PrintLn("Hello World!")
```
#### *function* <tag id=PrintF>PrintF</tag>(format, ...)
> format: 字符串, 格式化文本
> ...: 可变参数

打印格式化字符串。<tag id="format_table">格式化文本表</tag>

|字符|说明|示例|输出|
|:--:|:--:|:---|:---|
|C|货币|PrintF("{0:C3}", 2)|$2.000|
|F|浮点|PrintF("{0:F3}", 2)|2.000|
|G|常规|PrintF("{0:G}", 2)|2|
|N|用逗号分隔的数值|PrintF("{0:N1}", 250000)|250,000.0|
|P|百分比|PrintF("{0:P}", 0.5)|50.00%|
|E|科学计算法|PrintF("{0:E2}", 100000000)|1.00E+008|
||自定义|PrintF("{0:#.0000}", 1.23)|1.2300|
```lua
PrintF("{0:C3}", 2)
PrintF("{0:F3}", 2)
PrintF("{0:G}", 2)
PrintF("{0:N}", 250000)
PrintF("{0:P}", 0.5)
PrintF("{0:E2}", 100000000)
PrintF("{0:#.0000}", 1.23)
```

#### *function* <tag id=PrintFLn>PrintFLn</tag>(format, ...)
> format: 字符串, 格式化文本
> ...: 可变参数

打印格式化字符串，并**换行**。格式化文本[参考列表](#format_table)。

#### *function* <tag id=PrintT>PrintT</tag>(t, align, str)
> t: 数值, 对其字符数
> align: 数值, 对齐枚举
> str: 字符串, 文本内容

打印对齐文本, 对齐枚举表
|枚举|说明|
|:--:|:--:|
|ALIGN_LEFT|左对齐|
|ALIGN_CENTER|居中对齐|
|ALIGN_RIGHT|右对齐|

```lua
PrintT(20, ALIGN_LEFT, "left")      --"left                "
PrintT(20, ALIGN_CENTER, "center")  --"       center       "
PrintT(20, ALIGN_RIGHT, "right")    --"               right"
```

#### *function* <tag id=PrintTLn>PrintTLn</tag>(t, align, str)
> t: 数值, 对其字符数
> align: 数值, 对齐枚举
> str: 字符串, 文本内容

打印对齐文本, 并**换行**

```lua
PrintTLn(20, ALIGN_LEFT, "left")  
PrintTLn(20, ALIGN_CENTER, "center") 
PrintTLn(20, ALIGN_RIGHT, "right") 
```

#### *function* <tag id=PrintTF>PrintTF</tag>(t, align, format, ...)
> t: 数值, 对其字符数
> align: 数值, 对齐枚举
> format: 字符串, 格式化文本
> ...: 可变参数

打印对齐格式化文本

```lua
PrintTF(20, ALIGN_CENTER, "Value: {0}", 123)
```

#### *function* <tag id=PrintTFLn>PrintTFLn</tag>(t, align, format, ...)
> t: 数值, 对其字符数
> align: 数值, 对齐枚举
> format: 字符串, 格式化文本
> ...: 可变参数

打印对齐格式化文本, 并**换行**

#### *function* <tag id=Image>Image</tag>(name, x, y, w, h, tiled=false)
> name: 字符串, 图片名
> x: 数值, x像素偏移
> y: 数值, y像素偏移
> w: 数值, 宽, 单位像素
> h: 数值, 高, 单位像素
> tiled: 布尔型, 平铺

打印图片

```lua
Image("img", 10, 0, 100, 100)
```

#### *function* <tag id=ImageP>ImageP</tag>(name, x, y, tiled=false)
> name: 字符串, 图片名
> x: 数值, 字符数偏移
> y: 数值, 行偏移
> w: 数值, 宽, 单位字符宽
> h: 数值, 高, 单位行高
> tiled: 布尔型, 平铺

打印图片

```lua
ImageP("img", 10, 0)
```

#### *function* <tag id=ImageW>ImageW</tag>(name, w, tiled=false)
> name: 字符串, 图片名
> w: 数值, 宽, 单位字符宽
> tiled: 布尔型, 平铺

打印图片

```lua
ImageW("img", 20)
```

#### *function* <tag id=ImageH>ImageH</tag>(name, h, tiled=false)
> name: 字符串, 图片名
> h: 数值, 高, 单位行高
> tiled: 布尔型, 平铺

打印图片

```lua
ImageH("img", 5)
```

#### *function* <tag id=ImageS>ImageS</tag>(name, w, h, tiled=false)
> name: 字符串, 图片名
> w: 数值, 宽, 单位字符宽
> h: 数值, 高, 单位行高
> tiled: 布尔型, 平铺

打印图片

```lua
ImageS("img", 10, 5)
```

#### *function* <tag id=ImagePS>ImagePS</tag>(name, x, y, w, h, tiled=false)
> name: 字符串, 图片名
> x: 数值, 字符数偏移
> y: 数值, 行偏移
> w: 数值, 宽, 单位字符宽
> h: 数值, 高, 单位行高
> tiled: 布尔型, 平铺

打印图片

```lua
ImagePS("img", 0, 0, 10, 5)
```

#### *function* <tag id=Button>Button</tag>(code, text)
> code: 字符串, 按钮码
> text: 字符串, 文本

打印按钮

#### *function* <tag id=ButtonLn>ButtonLn</tag>(code, text)
> code: 字符串, 按钮码
> text: 字符串, 文本

打印按钮, 并换行

#### *function* <tag id=ButtonF>ButtonF</tag>(code, ...)
> code: 字符串, 按钮码
> ...: 可变参数, 参看[PrintF](#PrintF)

打印按钮

#### *function* <tag id=ButtonFLn>ButtonFLn</tag>(code, ...)
> code: 字符串, 按钮码
> ...: 可变参数, 参看[PrintFLn](#PrintFLn)

打印按钮, 并换行

#### *function* <tag id=ButtonT>ButtonT</tag>(code, ...)
> code: 字符串, 按钮码
> ...: 可变参数, 参看[PrintT](#PrintT)

打印按钮

#### *function* <tag id=ButtonTLn>ButtonTLn</tag>(code, ...)
> code: 字符串, 按钮码
> ...: 可变参数, 参看[PrintTLn](#PrintTLn)

打印按钮, 并换行

#### *function* <tag id=ButtonTF>ButtonTF</tag>(code, ...)
> code: 字符串, 按钮码
> ...: 可变参数, 参看[PrintTF](#PrintTF)

打印按钮

#### *function* <tag id=ButtonTFLn>ButtonTFLn</tag>(code, ...)
> code: 字符串, 按钮码
> ...: 可变参数, 参看[PrintTFLn](#PrintTFLn)

打印按钮, 并换行

#### *function* <tag id=ButtonImage>ButtonImage</tag>(code, ...)
> code: 字符串, 按钮码
> ...: 可变参数, 参看[Image](#Image)

打印图片按钮

#### *function* <tag id=ButtonImageP>ButtonImageP</tag>(code, ...)
> code: 字符串, 按钮码
> ...: 可变参数, 参看[ImageP](#ImageP)

打印图片按钮

#### *function* <tag id=ButtonImageW>ButtonImageW</tag>(code, ...)
> code: 字符串, 按钮码
> ...: 可变参数, 参看[ImageW](#ImageW)

打印图片按钮

#### *function* <tag id=ButtonImageH>ButtonImageH</tag>(code, ...)
> code: 字符串, 按钮码
> ...: 可变参数, 参看[ImageH](#ImageH)

打印图片按钮

#### *function* <tag id=ButtonImageS>ButtonImageS</tag>(code, ...)
> code: 字符串, 按钮码
> ...: 可变参数, 参看[ImageS](#ImageS)

打印图片按钮

#### *function* <tag id=ButtonImagePS>ButtonImagePS</tag>(code, ...)
> code: 字符串, 按钮码
> ...: 可变参数, 参看[ImagePS](#ImagePS)

打印图片按钮

#### *function* <tag id=ShiftLine>ShiftLine</tag>(count=1, roll_to_bottom=true)
> count: 数值, 换行数
> roll_to_bottom: 布尔型, 滚动到底部

换行

#### *function* <tag id=RemoveLine>RemoveLine</tag>(count)
> count: 数值, 移除行数

移除指定数量的行

#### *function* <tag id=Clear>Clear</tag>()

清空所有内容

#### *function* <tag id=MovePosByPixel>MovePosByPixel</tag>(count)
> count: 数值, 移动打印位置, 单位像素

移动打印位置

#### *function* <tag id=MovePosByWord>MovePosByWord</tag>(count)
> count: 数值, 移动打印位置, 单位字符宽

移动打印位置

#### *function* <tag id=ResetPosByPixel>ResetPosByPixel</tag>(count)
> count: 数值, 重置打印位置, 单位像素

重置打印位置

#### *function* <tag id=ResetPosByWord>ResetPosByWord</tag>(count)
> count: 数值, 重置打印位置, 单位字符宽

重置打印位置

#### *function* <tag id=GetCurrentPos>GetCurrentPos</tag>()

获得当前打印位置, 单位像素

#### *function* <tag id=SetAutoLine>SetAutoLine</tag>(line_count)
> line_count: 数值, 自动换行字符数, 0表示不自动换行

设置自动换行字符数

#### *function* <tag id=GetAutoLine>GetAutoLine</tag>()

获取自动换行字节数

#### *function* <tag id=GetStringLines>GetStringLines</tag>(str, richedit, count)
> str: 字符串, 文本
> richedit: 布尔型, 是否为富文本
> count: 数值, 换行字符数

获取自动换行结果文本表

#### *function* <tag id=SetBackgroundColor1>SetBackgroundColor</tag>(name)
> name: 颜色名, 或者使用编码#RRGGBBAA, 配置表[参看这里](#color_list)

设置背景颜色

#### *function* <tag id=SetBackgroundColor2>SetBackgroundColor</tag>(r, g, b, a)
> r: 数值, R通道, [0, 1]
> g: 数值, G通道, [0, 1]
> b: 数值, B通道, [0, 1]
> a: 数值, Alpha通道, 默认值为1, [0, 1]

设置背景颜色

#### *function* <tag id=SetBackgroundImage>SetBackgroundImage</tag>(name, tiled=false, keep_aspect=false)
> name: 字符串, 图片名
> tiled: 布尔型, 是否平铺
> keep_aspect: 布尔型, 是否保持比例

设置背景图片

#### *function* <tag id=BeginSection>BeginSection</tag>(line, clearflag=false)
> line: 数值, 行数
> clearflag: 布尔型, 是否清除上一个Section

开始一个Section区域

```lua
BeginSection(20)
-- ...
EndSection()
```

#### *function* <tag id=EndSection>EndSection</tag>()

结束一个Section区域

#### *function* <tag id=GetSectionCurrentLine>GetSectionCurrentLine</tag>()

获取当前Section中打印行数

#### *function* <tag id=GetSectionLine>GetSectionLine</tag>()

获取当前Section定义的行数

#### *function* <tag id=ClearSectionCurrentLine>ClearSectionCurrentLine</tag>()

清空当前Section中打印行数

交互
----

#### *function* <tag id=SetMsg>SetMsg</tag>(msg)
> msg: 字符串

设置消息

#### *function* <tag id=GetMsg>GetMsg</tag>()

获取当前记录的消息

#### *function* <tag id=ClearMsg>ClearMsg</tag>()

清空消息

#### *function* <tag id=EmptyMsg>EmptyMsg</tag>(need_content=false)
> need_content: 布尔型, 是否剔除空字符串

检查消息是否为空

#### *function* <tag id=WaitMsg>WaitMsg</tag>(need_content=false)
> need_content: 布尔型, 是否剔除空字符串

等待消息结果，并返回消息。以下为实现代码，可以根据需求修改
```lua
function WaitMsg(need_content)
    while EmptyMsg(need_content) do
        coroutine.yield()
    end
    return GetMsg()
end
```

#### *function* <tag id=WaitMsgAndClear>WaitMsgAndClear</tag>(need_content=false)
> need_content: 布尔型, 是否剔除空字符串

等待消息结果，并返回消息后清空消息

图片配置
-------

#### *function* <tag id=SetResourcePath>SetResourcePath</tag>(path, location)
> path: 字符串, 路径名。如果相对路径，Standalone模式下工作路径为ProjectPath，Android模式下工作路径为PersistentDataPath
> location: 数值

|枚举名|说明|
|:----|:---|
|FILE_SYSTEM|文件系统模式|
|PACKAGE|包文件模式|

#### *function* <tag id=GetResourcePath>GetResourcePath</tag>()

获取当前资源路径

#### *function* <tag id=SetSpriteImage>SetSpriteImage</tag>(name, file, rect, border, hidden=false)
> name: 字符串, 图名字
> file: 字符串, 图片路径
> rect: 表, 图片偏移尺寸
> border: 表, 图片Border, 九宫格配置
> hidden: 布尔型, 是否隐藏

设置图片数据

```lua
SetSpriteImage("moon", "moon.png", {0, 0, 512, 512}, nil, false)
```

#### *function* <tag id=SetSpriteImages>SetSpriteImages</tag>(sprites)
> sprites: 表, 图片配置

设置图片数据

```lua
SetSpriteImages({
    {"moon", "moon.png", {0, 0, 512, 512}},
    {"small_moon", "small_moon.png", {0, 0, 32, 32}},
})
```

#### *function* <tag id=SetSpriteAnimation>SetSpriteAnimation</tag>(name, fps, sprites)
> name: 字符串, 动画名字
> fps: 数值, 动画帧率
> sprites: 表, 动画帧表

设置动画数据

```lua
SetSpriteAnimation("anim", 30, {
    "frame01",      -- {"frame01", 1}
    {"frame02_06", 5},
    {"frame07_08", 2},
    "frame08",
})
```

#### *function* <tag id=SetSpriteAnimations>SetSpriteAnimations</tag>(anims)
> anims: 表, 动画配置

设置动画数据

```lua
SetSpriteAnimations({
    {
        "anim", 30,
        {
            "frame01",      -- {"frame01", 1}
            {"frame02_06", 5},
            {"frame07_08", 2},
            "frame08",
        }
    }
})
```

#### *function* <tag id=SetAnimationLoop>SetAnimationLoop</tag>(count)
> count: 数值, 播放次数。ANIMATION_LOOP_COUNT为无限循环

设置动画播放次数

```lua
SetAnimationLoop(ANIMATION_LOOP_COUNT)
```

#### *function* <tag id=CheckSprite>CheckSprite</tag>(name)
> name: 字符串

检查Sprite是否存在

Json
----

#### *function* <tag id=JsonEncode>JsonEncode</tag>(value)
> value: 数据

Json编码

```lua
local json = JsonEncode({1, 2, 3}) -- "[1, 2, 3]"
```

#### *function* <tag id=JsonDecode>JsonDecode</tag>(json)
> json: 字符串, json文本

Json解码

```lua
local t = JsonDecode("[1, 2, 3]") -- t = {1, 2, 3}
```

Csv
---

#### *function* <tag id=SetCsvPath>SetCsvPath</tag>(path=["Csv"])
> path: 字符串, Csv路径

设置Csv路径

#### *function* <tag id=GetCsvPath>GetCsvPath</tag>()

返回Csv路径

#### *function* <tag id=CsvDecode>CsvDecode</tag>(name, haskey=false, dictflag=false)
> name: 字符串, Csv文件名, 无需.csv后缀名
> haskey: 布尔型, 是否包含列头
> dictflag: 布尔型, 是否解码字典格式

Csv解码, 优先读取Resources/Csv/下文件

```lua
--[[
    Project Path/Csv/test.csv
content:
    a, b, c
    1, 2, 3
    4, 5, 6
    7, 8, 9
]]

SetCsvPath("Csv")
local t1 = CsvDecode("test") 
-- t1 = {{"a", "b", "c"},{"1", "2", "3"},{"4", "5", "6"},{"7", "8", "9"}}
local t2 = CsvDecode("test", true)
-- t2 = {{a="1", b="2", c="3"},{a="4", b="5", c="6"},{a="7", b="8", c="9"}}
local t3 = CsvDecode("test", true, true)
--[[ t2 = {
           ["1"]={a="1", b="2", c="3"}, 
           ["4"]={a="4", b="5", c="6"},
           ["7"]={a="7", b="8", c="9"},
        }]]
```

存档
----

#### *function* <tag id=SetSavePath>SetSavePath</tag>(path=["Save"])
> path: 字符串, Save路径

设置Save路径

#### *function* <tag id=GetSavePath>GetSavePath</tag>()

返回Save路径

#### *function* <tag id=Save>Save</tag>(name, content, password=nil)
> name: 字符串, 文件名
> content: 数据, 存储内容
> password: 字符串, 密码

存储数据

#### *function* <tag id=SaveString>SaveString</tag>(name, content, password=nil)
> name: 字符串, 文件名
> content: 字符串, 存储内容
> password: 字符串, 密码

存储字符串

#### *function* <tag id=SaveTable>SaveTable</tag>(name, content, password=nil)
> name: 字符串, 文件名
> content: 表, 存储表
> password: 字符串, 密码

存储表

#### *function* <tag id=LoadString>LoadString</tag>(name, password=nil)
> name: 字符串, 文件名
> password: 字符串, 密码

读取字符串

#### *function* <tag id=LoadTable>LoadTable</tag>(name, password=nil)
> name: 字符串, 文件名
> password: 字符串, 密码

读取表

#### *function* <tag id=Exist>Exist</tag>(name)
> name: 字符串, 文件名

检查存档是否存在

#### *function* <tag id=Delete>Delete</tag>(name)
> name: 字符串, 文件名

删除存档文件

#### *function* <tag id=EnumSaves>EnumSaves</tag>()

枚举存档文件

文本库
-----

#### *function* <tag id=SetTextWeightList>SetTextWeightList</tag>(name, table)
> name: 字符串, 文本表名
> table: 表, 权重文本表

设置权重文本表

```lua
SetTextWeightList("family_name", 
{
    {"李", 2000},
    {"王", 2000},
    {"张", 2000},
    {"刘", 2000},
    {"陈", 1500},
    {"杨", 1500},
    {"赵", 1500},
    {"黄", 1500},
})
```

#### *function* <tag id=SetTextList>SetTextList</tag>(name, table)
> name: 字符串, 文本表名
> table: 表, 文本表

设置文本表

```lua
SetTextWeightList("family_name", 
{
    "李",
    "王",
    "张",
    "刘",
    "陈",
    "杨",
    "赵",
    "黄",
})
```

#### *function* <tag id=GetTextListCount>GetTextListCount</tag>(name)
> name: 字符串, 文本表名

获取文本表中文本条目数

#### *function* <tag id=GetTextListWeight>GetTextListWeight</tag>(name)
> name: 字符串, 文本表名

获取文本表的总权重值, 如果非权重表, 权重值等于条目数

#### *function* <tag id=GetTextByIndex>GetTextByIndex</tag>(name, index)
> name: 字符串, 文本表名
> index: 数值, 索引值

获取文本表中某一条文本

#### *function* <tag id=GetTextByWeight>GetTextByWeight</tag>(name, weight)
> name: 字符串, 文本表名
> weight: 数值, 权重值

获取文本表中某一条文本, 并返回该文本索引

时间
----

#### *function* <tag id=NowStamp>NowStamp</tag>()

返回当前时间戳

#### *function* <tag id=Now>Now</tag>()

返回当前时间表, <tag id=date_table>时间表</tag>
|键|说明|
|:--|:--|
|Year|年|
|Month|月|
|Day|日|
|Hour|小时|
|Minue|分钟|
|Second|秒|
|DayOfYear|当年总日数|
|DayOfWeek|星期|

#### *function* <tag id=DateToStamp1>DateToStamp</tag>(date_table)
> date_table: 表, [时间表](#date_table)

时间表转换为时间戳

#### *function* <tag id=DateToStamp2>DateToStamp</tag>(year, month, day, hour, min, sec)
> year: 数值, 年
> month: 数值, 月
> day: 数值, 日
> hour: 数值, 小时
> min: 数值, 分钟
> sec: 数值, 秒

转换为时间戳

#### *function* <tag id=Date>Date</tag>(year, month, day, hour, min, sec)
> year: 数值, 年
> month: 数值, 月
> day: 数值, 日
> hour: 数值, 小时
> min: 数值, 分钟
> sec: 数值, 秒

生成[时间表](#date_table)

#### *function* <tag id=StampToDate>StampToDate</tag>(stamp)
>stamp: 数值, 时间戳

时间戳转换为[时间表](#date_table)

其他
----

#### *function* <tag id=SetMaxLineCount>SetMaxLineCount</tag>(count)
> count: 设置最大行数

设置最大行数

#### *function* <tag id=GetMaxLineCount>GetMaxLineCount</tag>()

获取最大行数

#### *function* <tag id=ShowFPS>ShowFPS</tag>(value)
> value: 布尔型, 是否显示FPS

显示FPS

#### *function* <tag id=SetTargetFrame>SetTargetFrame</tag>(count)
> count: 数值, 帧率

设置帧率

#### *function* <tag id=SetOrientation>SetOrientation</tag>(orientation)
> orientation: 枚举, 显示方向枚举

设置方向, 方向枚举表
|枚举|说明|
|:--|:--|
|SCREEN_PORTRAIT|竖屏|
|SCREEN_PORTRAIT_UPSIDE|正向竖屏|
|SCREEN_LANDSCAPE_LEFT|左面朝上横屏|
|SCREEN_LANDSCAPE|横屏|
|SCREEN_LANDSCAPE_RIGHT|右面朝上横屏|
|SCREEN_AUTO_ROTATION|自动旋转|

#### *function* <tag id=SetDragEnable>SetDragEnable</tag>(value)
> value: 布尔型, 拖动是否有效

设置是否允许拖动

#### *function* <tag id=DataPath>DataPath</tag>()

获取Data路径

#### *function* <tag id=PersistentDataPath>PersistentDataPath</tag>()

获取PersistentDataPath

#### *function* <tag id=ProjectPath>ProjectPath</tag>()

获取Project路径

#### *function* <tag id=IsMobilePlatform>IsMobilePlatform</tag>()

获取是否Modile

#### *function* <tag id=Platform>Platform</tag>()

获取平台名

#### *function* <tag id=RunInBackground>RunInBackground</tag>()

获取是否允许运行在后台

#### *function* <tag id=SetRunInBackground>SetRunInBackground</tag>(value)
> value: 布尔型, 是否允许后台运行

设置是否允许后台运行

#### *function* <tag id=OpenURL>OpenURL</tag>(url)
> url: 字符串, 地址

打开Url地址

#### *function* <tag id=SetResolution>SetResolution</tag>(w, h)
> w: 数值, 设置宽
> h: 数值, 设置高

设置分辨率

#### *function* <tag id=GetResolution>GetResolution</tag>()

返回分辨率

#### *function* <tag id=SetConsoleBorder>SetConsoleBorder</tag>(left, top, right, bottom)
> left: 数值, 左边边框值
> top: 数值, 顶边边框值
> right: 数值, 右边边框值
> bottom: 数值, 底边边框值

设置显示边框
