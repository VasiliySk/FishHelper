--[[
	ESOlocate
	==========================================
	An addon that displays current zone and coordinates.
	==========================================
	Written by Sean McKeown - 4/8/2014
	Last Updated 8/12/2016
]]--

ESOlocate = {}
ESOlocate.SavedVars = {}

ESOlocate.name = "ESOlocate"
ESOlocate.command = "/esolocate"
ESOlocate.version = "v1.3.0"

local loc_x = 5
local loc_y = 5
local loc_z = 0
local loc_v = 0
local heading = 0
local zone = ""
local unitID = "player"

local coords = ""

local display_locZ = false
local display_zone = true

local timer = 0

function ESOlocate.Initialize( eventCode, addOnName )

	if ( addOnName ~= ESOlocate.name ) then
		return
	end
	
	ESOlocate.SavedVars = ZO_SavedVars:New("ESOlocate_SavedVars", 1, "ESOlocate", {5, 0, TOPLEFT, nil, true})
	
	if(ESOlocate.SavedVars[0] == nil or ESOlocate.SavedVars[1] == nil) then
		ESOlocate.SavedVars[0] = 5
		ESOlocate.SavedVars[1] = 0
	end
	
	--Set anchor position
	ESOlocateUI:ClearAnchors()
	ESOlocateUI:SetAnchor(ESOlocate.SavedVars[2],
	GuiRoot,
	nil,
	ESOlocate.SavedVars[0],
	ESOlocate.SavedVars[1])
	
	SLASH_COMMANDS[ESOlocate.command] = ESOlocate.SlashCommands;

end

-- Initialize on ADD_ON_LOADED Event
EVENT_MANAGER:RegisterForEvent( ESOlocate.name, EVENT_ADD_ON_LOADED, ESOlocate.Initialize )

function ESOlocate.Update()

	ESOlocate.UpdateAnchor(5)

	loc_x, loc_y, heading, zone = ESOlocate.getCoords(unitID)
	
	display_zone = ESOlocate.SavedVars[4]
	display_locZ = ESOlocate.SavedVars[5]

	ESOlocateUIcoords:SetText(ESOlocate.generateCoordsText(display_zone, display_locZ))
	
end

function ESOlocate.lockFrame()
	
	ESOlocateUI:SetMovable(false)

end

function ESOlocate.unlockFrame()

	ESOlocateUI:SetMovable(true)

end

function ESOlocate.SlashCommands(text)

	if(text == "reset") then
		d(string.format("ESOlocate: %s", text))
		ESOlocate.SavedVars[0] = 5
		ESOlocate.SavedVars[1] = 0
		ESOlocate.SavedVars[2] = TOPLEFT
		ESOlocate.SavedVars[3] = nil
		ESOlocate.SavedVars[4] = true
		ESOlocate.SavedVars[5] = false
		ESOlocate.UpdateAnchor(0)
	elseif(text == "toggle_zone") then
		if(ESOlocate.SavedVars[4] == true) then
			d(string.format("ESOlocate: %s OFF", text))
			ESOlocate.SavedVars[4] = false
		else
			d(string.format("ESOlocate: %s ON", text))
			ESOlocate.SavedVars[4] = true
		end
	elseif(text == "toggle_locZ") then
		d(string.format("ESOlocate: %s", text))
		if(ESOlocate.SavedVars[5] == true) then
			ESOlocate.SavedVars[5] = false
		else
			ESOlocate.SavedVars[5] = true
		end
	elseif(text == "version") then
		d(string.format("ESOlocate %s", ESOlocate.version))
	elseif(text == "lock") then
		ESOlocate.lockFrame()
		d("ESOlocate frame is now locked.")
	elseif(text == "unlock") then
		ESOlocate.unlockFrame()
		d("ESOlocate frame is now unlocked.")
	else
		d(string.format("ESOlocate %s", ESOlocate.version))
		d("Usage: /esolocate [reset, toggle_zone, version, lock, unlock]")
	end
	
end

function ESOlocate.generateCoordsText(display_zone, display_locZ)

	if(display_zone == true and display_locZ == true) then
		coords = string.format("%.2f, %.2f (%.2f) - %s", loc_x, loc_y, loc_z, zone)
	elseif(display_zone == true and display_locZ == false) then
		coords = string.format("%.2f, %.2f - %s", loc_x, loc_y, zone)
	elseif(display_zone == false and display_locZ == true) then
		coords = string.format("%.2f, %.2f (%.2f)", loc_x, loc_y, zone)
	else
		coords = string.format("%.2f %.2f %.2f", loc_x, loc_y, loc_v) --Добавлено направление взгляда персонажа
	end

	return coords
	
end

function ESOlocate.getCoords(unitID)
	
	loc_x, loc_y, heading = GetMapPlayerPosition(unitID)
	loc_x = loc_x * 100	
	loc_y = loc_y * 100
	loc_v = GetPlayerCameraHeading()*57.3248 -- Получение направления взгляда персонажа
	
	zone = GetUnitZone(unitID)
	
	return loc_x, loc_y, heading, zone

end

function ESOlocate.UpdateAnchor(updateTimer)

	timer = timer + 1
	
	local validAnchor,point,relativeTo, relativePoint, offSetX, offSetY = ESOlocateUI:GetAnchor()
	
	if(updateTimer == 0) then
		offSetX = 5
		offSetY = 0
		point = TOPLEFT
	end
	
	if(timer == updateTimer or updateTimer == 0) then
		
		if(offSetX ~= ESOlocate.SavedVars[0] or offSetY ~= ESOlocate.SavedVars[1] or updateTimer == 0) then
			ESOlocate.SavedVars[0] = offSetX
			ESOlocate.SavedVars[1] = offSetY
			ESOlocate.SavedVars[2] = point
			if(relativePoint ~= nil) then
				ESOlocate.SavedVars[3] = relativePoint
			end
		end
		
		if(updateTimer == 0) then
			ReloadUI()
		end
		
		timer = 0
	end
	
end