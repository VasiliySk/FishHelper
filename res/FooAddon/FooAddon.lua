-- First, we create a namespace for our addon by declaring a top-level table that will hold everything else.
FooAddon = {}
 
-- This isn't strictly necessary, but we'll use this string later when registering events.
-- Better to define it in a single place rather than retyping the same string.
FooAddon.name = "FooAddon"
 
-- Next we create a function that will initialize our addon
function FooAddon:Initialize()
  self.inCombat = IsUnitInCombat("player")
  FooAddonIndicator:SetHidden(not inCombat)
  EVENT_MANAGER:RegisterForEvent(self.name, EVENT_PLAYER_COMBAT_STATE, self.OnPlayerCombatState)
end
 
-- Then we create an event handler function which will be called when the "addon loaded" event
-- occurs. We'll use this to initialize our addon after all of its resources are fully loaded.
function FooAddon.OnAddOnLoaded(event, addonName)
  -- The event fires each time *any* addon loads - but we only care about when our own addon loads.
  if addonName == FooAddon.name then
    FooAddon:Initialize()
  end
end
 
function FooAddon.OnPlayerCombatState(event, inCombat)
  -- The ~= operator is "not equal to" in Lua.
  if inCombat ~= FooAddon.inCombat then
    -- The player's state has changed. Update the stored state...
    FooAddon.inCombat = inCombat
 
    -- ...and then announce the change.
    if inCombat then
      --d("Entering combat.")
    else
      --d("Exiting combat.")	  
    end
	FooAddonIndicator:SetHidden(not inCombat)
  end
end

 
-- Finally, we'll register our event handler function to be called when the proper event occurs.
EVENT_MANAGER:RegisterForEvent(FooAddon.name, EVENT_ADD_ON_LOADED, FooAddon.OnAddOnLoaded)