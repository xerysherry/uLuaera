-----------------------------------------------------------
-- print
local UnityDebug = UnityEngine.Debug
local Log = UnityDebug.Log
local LogError = UnityDebug.LogError
local LogWarning = UnityDebug.LogWarning
local _print = print
local tconcat = table.concat
local tinsert = table.insert
local tremove = table.remove

ToLuaObj = LuaUtils.ToLuaObj
ToObj = LuaUtils.ToObj
ToString = LuaUtils.ToString
ToType = LuaUtils.ToType
GetType = LuaUtils.GetType

function print(...)
    local text = ""
    for _, v in ipairs({...}) do
        text = text .. ToString(v) .. "\t"
    end
	--local text = tconcat({...})
    Log(text)
end

function printError(...)
    local text = ""
    for _, v in ipairs({...}) do
        text = text .. ToString(v) .. "\t"
    end
	--local text = tconcat({...})
    LogError(text)
end

function printWarning(...)
    local text = ""
    for _, v in ipairs({...}) do
        text = text .. ToString(v) .. "\t"
    end
	--local text = tconcat({...})
    LogWarning(text)
end

-----------------------------------------------------------
-- coroutine
function WaitUntil(pred)
	while not pred()  do
		coroutine.yield();
	end
end

function WaitFrame(count)
    if not count or count==1 then
        coroutine.yield()
    else
	    for i = 1,count do
		    coroutine.yield()
	    end
    end
end

local UnityTime = UnityEngine.Time
local GetUnscaledTime = UnityTime.GetUnscaledTime
local GetTime = UnityTime.GetTime

function WaitSecond(t)
    local r = GetTime() + t
    while r > GetTime() do
        coroutine.yield()
    end
end

function WaitUnscaledSecond(t)
    local r = GetUnscaledTime() + t
    while r > GetUnscaledTime() do
        coroutine.yield()
    end
end
            
-----------------------------------------------------------
-- Mono
local tinsert = table.insert
local tremove = table.remove
local _MonoBase = 
{
    StartCoroutine = function(self, func)
        if self.coroutines == nil then
            self.coroutines = {}
        end
        local co = coroutine.create(func)
        table.insert(self.coroutines, co)
        return co
    end,
    StopCoroutine = function(self, co)
        if self.coroutines == nil then
            return
        end
        local f
        for i, v in ipairs(self.coroutines) do
            if v == co then
                f = i
                break
            end
        end
        if f then
           
        end
    end,
    StopAllCoroutine = function(self)
        self.coroutines = nil
    end,
    UpdateCoroutine = function(self)
        if self.coroutines == nil then
            return
        end
        for _, v in pairs(self.coroutines) do
            local cr, ur = coroutine.resume(v)
            if (not cr) or ur then
                if ur ~= "cannot resume dead coroutine" then
                    -- coroutine error text
                    printError("Coroutine Error : \x0d\x0a" .. ur)
                    self.coroutines[v] = nil
                end
            end
        end
    end,
    -- coroutine list
    coroutines = nil,
}

MonoBase = setmetatable(_MonoBase, {
    __call = function(self, o)
        local newinstance = o or {}
        newinstance = setmetatable(newinstance, {
            __index = _MonoBase
        })
        newinstance.StartCoroutine = function(func)
            return _MonoBase.StartCoroutine(newinstance, func)
        end
        newinstance.StopCoroutine = function(co)
            _MonoBase.StopCoroutine(newinstance, co)
        end
        newinstance.StopAllCoroutine = function()
            _MonoBase.StopAllCoroutine(newinstance)
        end
        newinstance.UpdateCoroutine = function()
            _MonoBase.UpdateCoroutine(newinstance)
        end
        newinstance.SetGameObject = function(gameObject)
            _MonoBase.gameObject = gameObject
        end
        newinstance.SetMonoBehaviour = function(mono)
            _MonoBase.luaMono = mono
        end
        return newinstance
    end,
})
