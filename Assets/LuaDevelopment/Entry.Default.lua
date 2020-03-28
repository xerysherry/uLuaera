function Init()
    SetTargetFrame(30)
    SetDefaultSize(32)
    SetLineHeight(33)
    SetOrientation(SCREEN_PORTRAIT)
    SetDragEnable(false)
    DefaultAllConfig()
end
function Exec()
    PushAllConfig()
    SetFlags({
        richedit = true,
        underline = true,
        gradient = true,
    })
    SetGradientColor("blue")
    SetShadowColor("blue")
    SetOutlineColor("blue")
    ImageH("@APP_BANNER", 7)
    ShiftLine(6)
    PrintLn(StrConv("Hello uLuaera!", STRCONV_WIDE))
    PopAllConfig()

    SetDefaultSize(16)
    SetLineHeight(17)
    SetFlags({monospaced = false})

    local w, h = GetResolution()
    PrintLn("Resolution: "..w.."x"..h)
    PrintLn("ProjectPath: " .. ProjectPath())
    PrintLn("SavePath: " .. GetSavePath())
    PrintLn("CsvPath: " .. GetCsvPath())
    PrintLn("DataPath: " .. DataPath())
    PrintLn("PersistentDataPath: " .. PersistentDataPath())
    PrintLn("IsMobilePlatform: " .. tostring(IsMobilePlatform()))
    PrintLn("Platform: " .. Platform())
    ShiftLine(5)
end
return {Init = Init, Exec = Exec, }