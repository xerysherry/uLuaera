function Demo4()
    local i = 0
    local count = 30

    while true do    
        if i >= count then
            Print("|") Print(GetStringBar('=', count)) PrintFLn("| {0:P0}", 1)
            i = 0
        end
        Print("|") PrintT(count, ALIGN_LEFT, GetStringBar('=', i) .. '>') PrintFLn("| {0:P0}", 1/count * i)
        i = i + 0.5
        
        -- Check Msg
        if not EmptyMsg() then
            break
        end
        coroutine.yield()
        
        RemoveLine(1)
    end
end