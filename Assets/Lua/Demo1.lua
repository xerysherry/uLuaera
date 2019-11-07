function Demo1()
    -- Print 例子
    Print("Hello World!")
    ShiftLine()
    PrintLn("Hello World!")
    ShiftLine()

    -- PrintF 例子
    SetColor(1, 0.1, 0.1)
    PrintFLn("{0:C3}", 2)
    SetColor("red")
    PrintFLn("{0:F3}", 2)
    SetColor(0.1, 1, 0.1)
    PrintFLn("{0:G}", 2)
    SetColor("green")
    PrintFLn("{0:N}", 250000)
    SetColor(0.1, 0.1, 1)
    PrintFLn("{0:P}", 0.5)
    SetColor("blue")
    PrintFLn("{0:E2}", 100000000)
    SetColor(0.5, 0.5, 0.5)
    PrintFLn("{0:#.0000}", 1.23)
    ShiftLine()

    -- PrintT 例子
    SetColor("#EFEFEF")
    Print("|") PrintT(20, ALIGN_LEFT, "left") PrintLn("|")  
    Print("|") PrintT(20, ALIGN_CENTER, "center") PrintLn("|") 
    Print("|") PrintT(20, ALIGN_RIGHT, "right") PrintLn("|")
    
    PrintT(10, ALIGN_LEFT, "A =")    Print("|") PrintTFLn(10, ALIGN_RIGHT, "{0}", 1)
    PrintT(10, ALIGN_LEFT, "BB =")   Print("|") PrintTFLn(10, ALIGN_RIGHT, "{0}", 12)
    PrintT(10, ALIGN_LEFT, "CCC =")  Print("|") PrintTFLn(10, ALIGN_RIGHT, "{0}", 123)
    PrintT(10, ALIGN_LEFT, "DDDD =") Print("|") PrintTFLn(10, ALIGN_RIGHT, "{0}", 1234)
end