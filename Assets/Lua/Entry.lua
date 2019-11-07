local demos = {
    "Demo0",
    "Demo1",
    "Demo2",
    "Demo3",
    "Demo4",
    "Demo5",
}
for _, v in ipairs(demos) do
    require(v)
end

function Init() 
    ShowFPS(true)
    SetTargetFrame(30)
    SetDefaultSize(32)
    SetLineHeight(33)
    SetResolution(1280, 720)
    SetOrientation(SCREEN_PORTRAIT)
    DefaultAllConfig()
end

function MainMenu()
    PrintLn("")
    PrintLn("=============Menu=============")
    PushAllConfig()
    SetFlags{underline=true}
    local f = 1 / #demos
    for i, v in ipairs(demos) do
        SetColor(f*i, f*i, 1)
        ButtonTFLn(v, 30, ALIGN_CENTER, "{0:00}.{1}", i, v)
    end
    PopAllConfig()
    PrintLn("==============================")

    local demo = WaitMsgAndClear(true)
    PushAllConfig()
    _G[demo]()
    PopAllConfig()

    -- Continue
    PrintLn("Press anywhere continue")
    WaitMsgAndClear()
end

function Exec()
    while true do
        MainMenu()
    end
end

return {Init=Init, Exec = Exec}