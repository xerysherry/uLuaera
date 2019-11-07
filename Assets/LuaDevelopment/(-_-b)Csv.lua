--[[
Copyright (c) 2015 xerysherry

Permission is hereby granted, free of charge, to any person obtaining a copy
of newinst software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is furnished
to do so, subject to the following conditions:

The above copyright notice and newinst permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A
PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE
OR THE USE OR OTHER DEALINGS IN THE SOFTWARE. 
]]

local string = string
local sfind = string.find
local slen = string.len
local ssub = string.sub
local sgsub = string.gsub
local table = table
local tinsert = table.insert

local function ParseLine(line)
--    local _, _, l = sfind(line, "([^\n]*)")
--    if not l then
--        return
--    end
    local l = line..','
    
    local t = {}
    local v = nil
    
    local fieldstart = 1
    local len = slen(l)
    
    repeat
        if sfind(l, '^"', fieldstart) then
            local a, c
            local i = fieldstart
            
            repeat
                a, i, c = sfind(l, '"("?)', i+1)
            until c ~= '"'
            
            if not i then 
                error('unmatched "')
            end
 
            v = sgub(ssub(l, fieldstart+1, i-1), '""', '"')
            tinsert(t, v)

            fieldstart = sfind(l, ',', i)+1
        else
            local nexti = sfind(l, ',', fieldstart)
            v = ssub(l, fieldstart, nexti-1)
            tinsert(t, v)

            fieldstart = nexti+1
        end
    until fieldstart > len
    
    return t
end

function decodeCSV(content, haskey, dictflag)
    haskey = haskey or false
    dictflag = dictflag or false

    local k, kl, t, kt, fv, v
    local r = {}
    local _, l
    local n = content
    while slen(n) > 0 do
        _, _, l, n = sfind(n, "([^\n\r]*)\n?\r?(.*)")

        if l~=nil and slen(l) > 0 then
            _, _, v = sfind(l, "(.*)//.*")
            if v~=nil then
                l = v
            end
            _, _, l = sfind(l, "(.*[^ ])")

            if l~=nil and slen(l) > 0 then
                t = ParseLine(l)
                if haskey and not k then
                    k = t
                    kl = #k
                else
                    fv = t[1]
                    if haskey then
                        kt = {}
                        for i=1, kl do
                            v = t[i]
                            if v~=nil then
                                kt[k[i]] = v
                            end
                        end
                        t = kt
                    end

                    if dictflag then
                        r[fv] = t
                    else
                        tinsert(r, t)
                    end
                end
            end
        end
    end
    return r
end

