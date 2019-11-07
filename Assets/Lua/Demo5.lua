-- 注册图片
local sprites = {
    {"moon", "moon.png", {0, 0, 512, 512}},
    {"small_moon", "small_moon.png", {0, 0, 32, 32}},
}
SetResourcePath("Image", FILE_SYSTEM)
SetSpriteImages(sprites)

function Demo5()
    PrintLn("====+====+====+====+====+====+====+====+====+")
    -- 打印图片 Image
    Image("moon", 0, 0, 300, 200)
    Image("moon", 0, 0, 200, 100)
    Image("moon", 0, 0, 100, 50)
    ShiftLine(6)
    WaitFrame(2)

    PrintLn("====+====+====+====+====+====+====+====+====+")
    -- 打印图片 ImageP
    ImageP("moon", 5, 0)
    ShiftLine(16)
    WaitFrame(2)

    PrintLn("====+====+====+====+====+====+====+====+====+")
    -- 打印图片 ImageW
    ImageW("moon", 20)
    ImageW("moon", 10)
    ShiftLine(9)
    WaitFrame(2)

    PrintLn("====+====+====+====+====+====+====+====+====+")
    -- 打印图片 ImageH
    ImageH("moon", 5)
    ShiftLine(5)
    WaitFrame(2)

    PrintLn("====+====+====+====+====+====+====+====+====+")
    -- 打印图片 ImageS
    ImageS("small_moon", 20, 10, true)
    ShiftLine(10)
end
