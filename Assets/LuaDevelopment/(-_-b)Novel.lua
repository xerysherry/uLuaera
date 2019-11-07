
local default_wait_time = 1/30
local default_auto_line = 40

--[[
Novel = {
    
    {
        "",

    }
}
]]

local novel_event = {}

NOVEL_EVENT_WAITKEY = 1

novel_event[NOVEL_EVENT_WAITKEY] = function()
    WaitMsgAndClear()
end

local function NovelPrint(l)
    PrintLn(l)
    WaitSecond(default_wait_time)
end

local function NovelString(str)
    local lines = GetStringLines(str, default_auto_line)
    for _, l in ipairs(lines) do
        NovelPrint(l)
    end
end

Novel = function(novel)
    local t
    for _, v in ipairs(novel) do
        t = type(v)
        if t=="nil" then
            -- do nothing
        elseif t == "string" then
            NovelString(v)
        elseif t == "number" then
            local ne = novel_event[v]
            if type(ne) == "function" then
                ne()
            end
        elseif t == "function" then
            v()
        end
        
    end

end