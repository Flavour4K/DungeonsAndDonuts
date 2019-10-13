# DungeonsAndDragons

## General Game Design
	- complete a dungeon with 10 (?) stages
	- dungeon will have entities
		- *insert idea for a theme here*
	- different rooms within the dungeons :
		- basic room (may include entities)
		- shop (?)
		- treasure room
		- challenge room (kill x enemies in y seconds ?)
		- boss room (including door to next area of the dungeon) 
		- armory room (?)
	- dungeon will be generated randomly including atleast: 
		- 5x basic room
		- 1x treasure room 
		- 1x boss room
		- % for armory room 
		- % for challenge room

## Gameplay
	- topdown
	- control with 'WASD'
	- Character has:
		- 1x Weapon Slot (unique with each class/character)
		- 1x Movement Slot (standard->dash)
		- 2x Ability Slots (spells will be found during dungeon run -> treasure room/boss reward)
		- any item the player finds (items have stackable passive effects or stat boosts)
		

## General Notes / Questions 
- do mana points make sense ? Or just cooldowns ? 
- map ? 
- dungeon stages  = different time epochs

## Code ideas
==
- Abilities = List of effects
- 

## Characters


- double dagger assassin
- trickster mage
- elementalist
	- earth
	- wind
	- fire
	- water
- army guy?
- shapeshifter
	- passive, every few second a cube spawns and changes the shape
- Vampire
-Mage
	Basic Attack (binds to weapon slot):
		- Wand
		- Book  (?)
		- Staff 
		- Rings (?)
	Mobility / Utility Ability:
		- small Dash (standard)
		- Blink / Teleport 
		- Mirror Images (??)
		- temporal flight / moving through objects	

	General abilities for ability slot 1 and slot 2 :
		- Fireball (larger projectile dealing damage on impact, scaling with ability power adding ignite to enemies hit  )
			- Empowered: Fireball will explode on impact dealing damage and adding ignite to every enemy hit
				-> Ignite deals x damage over y seconds
		- Chain Lightning (AoE Damage, hitting 3-4 enemies standing next to each other - scaling with 0.X ability power)
			- Empowered: Chain Lightning now hits up to 6 enemies, range and damage increased 
		- Ice Lance (small projectile scaling with x % of ability power + slows enemies on hit)
			- Empowered: Ice Lance also pierces all enemies, dealing damage and slowing all enemies on hit
				-> Ice Lance deals less damage for every enemy hit

- Knight
	Basic Attack (binds to weapon slot): 
		- Sword (standard)
		- Axe 
		- Lance / Spear 
		- Hammer 
	
	Mobility / Utility Ability:
		- small Dash (standard)
		- leap with AoE on impact
		- temporal movement speed buff
		- Charge

	General abilities for ability slot 1 and slot 2 : 
		- Shield Slam (scaling with armor value) 
		- Strong Slash (scaling with attack damage)
		- Berserk (increasing attack damage by x % for y seconds)
		- Whirlewind (AoE damge scaling with 0.X attack damage)
		- Ground slam (slamming the ground for AoE damage and slowing down enemies)
		- Armor Buff ? (increasing armor value by x % for y seconds)
		- Shield ? (increasing parry chance by x % for y seconds)

## Items

## Modes
	- challange mode
		- Completing a Challenge will reward you with a new Item/Spell/Weapon 
		- Separated game mode (unlocked after completing a dungeon run with one character ? )
		- To complete a challenge you have to fullfill a certain task during a dungeon run
			Example: Complete a dungeon run without using abilities (except basic ability/dash)
	

## Map Designs
	- Jungle
	- City
	- Hell
	- Heaven
	- Water

## Riddles

## Skins
