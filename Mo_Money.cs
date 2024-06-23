using System.Collections.Generic;
using System.IO;
using System.Reflection;
using HarmonyLib;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mo_Money
{
	public static class Main
	{
		public static Dictionary<string, float> TrinketMultipliers = new Dictionary<string, float>();

		public static Dictionary<string, float> FishMultipliers = new Dictionary<string, float>();

		public static void Initialize()
		{
			new Harmony("megapiggy.momoney").PatchAll(Assembly.GetExecutingAssembly());
			LoadJSONs();
		}

		public static void LoadJSONs()
		{
			TrinketMultipliers = Utils.GetJSON(nameof(TrinketMultipliers), TrinketDictionary);
			FishMultipliers = Utils.GetJSON(nameof(FishMultipliers), FishDictionary);
		}

		public static Dictionary<string, string> TrinketDictionary = new Dictionary<string, string>
		{
			{ "relic1", "Ornate Key" },
			{ "relic2", "Rusted Music Box" },
			{ "relic3", "Jewel Encrusted Band" },
			{ "relic4", "Shimmering Necklace" },
			{ "relic5", "Antique Pocket Watch" },
			{ "rot", "Rot" },
			{ "bag-doubloon", "Bag of Doubloons" },
			{ "big-bag-doubloon", "Big Bag of Doubloons" },
			{ "broken-monocle", "Broken Monocle" },
			{ "broken-spectacles", "Broken Spectacles" },
			{ "doubloon", "Doubloon" },
			{ "earring-1", "Pearl Earrings" },
			{ "earring-2", "Opal Earrings" },
			{ "earring-3", "Sapphire Earrings" },
			{ "earring-4", "Emerald Earrings" },
			{ "earring-5", "Ruby Earrings" },
			{ "fancy-boot", "Fancy Boot" },
			{ "goblet", "Goblet" },
			{ "iron-chain", "Old Iron Chain" },
			{ "ring-1", "Worn Gold Ring" },
			{ "ring-2", "Citrine Ring" },
			{ "ring-3", "Opal Ring" },
			{ "ring-4", "Sapphire Ring" },
			{ "ring-5", "Emerald Ring" },
			{ "ring-6", "Ruby Ring" },
			{ "ring-7", "Signet Ring" },
			{ "sextant", "Sextant" },
			{ "silver-plate", "Silver Plate" },
			{ "silver-trinket", "Silver Trinket" }
		};

		public static Dictionary<string, string> FishDictionary = new Dictionary<string, string>
		{
			{ "anchovy-ab-1", "Anchovy King" },
			{ "anchovy", "Anchovy" },
			{ "anglerfish-ab-1", "Bursting Anglerfish" },
			{ "anglerfish", "Anglerfish" },
			{ "squid-ab-1", "Brood Squid" },
			{ "squid-ab-2", "Snag Squid" },
			{ "squid", "Arrow Squid" },
			{ "aurora-jellyfish-ab-1", "Parhelion Jellyfish" },
			{ "aurora-jellyfish", "Aurora Jellyfish" },
			{ "barracuda-ab-1", "Savage Barracuda" },
			{ "barracuda", "Barracuda" },
			{ "barreleye-ab-1", "Voideye" },
			{ "barreleye", "Barreleye" },
			{ "black-grouper-ab-1", "Tusked Grouper" },
			{ "black-grouper-ab-2", "Voltaic Grouper" },
			{ "black-grouper", "Black Grouper" },
			{ "black-sea-bass-ab-1", "Scouring Bass" },
			{ "black-sea-bass", "Black Sea Bass" },
			{ "blackfin-tuna-ab-1", "Razormouth Tuna" },
			{ "blackfin-tuna", "Blackfin Tuna" },
			{ "blackmouth-salmon-ab-1", "Decaying Blackmouth" },
			{ "blackmouth-salmon", "Blackmouth Salmon" },
			{ "blacktip-reef-shark-ab-1", "Cleft-mouth Shark" },
			{ "blacktip-reef-shark", "Blacktip Reef Shark" },
			{ "mackerel", "Blue Mackerel" },
			{ "bronze-whaler-ab-1", "Bloodskin Shark" },
			{ "bronze-whaler", "Bronze Whaler" },
			{ "catfish-ab-1", "Nightwing Catfish" },
			{ "catfish", "Catfish" },
			{ "cod-ab-1", "All-Seeing Cod" },
			{ "cod-ab-2", "Fanged Cod" },
			{ "cod-ab-3", "Three-Headed Cod" },
			{ "cod", "Cod" },
			{ "coelacanth", "Coelacanth" },
			{ "conger-eel-ab-1", "Sprouting Eel" },
			{ "conger-eel", "Conger Eel" },
			{ "coral-grouper-ab-1", "Consumed Grouper" },
			{ "coral-grouper", "Coral Grouper" },
			{ "blue-crab", "Blue Crab" },
			{ "crab", "Common Crab" },
			{ "crown-of-thorns", "Crown of Thorns" },
			{ "decorator-crab", "Decorator Crab" },
			{ "fiddler-crab", "Fiddler Crab" },
			{ "giant-mud-crab", "Giant Mud Crab" },
			{ "horseshoe-crab", "Horseshoe Crab" },
			{ "rock-crab", "Rock Crab" },
			{ "spider-crab", "Spider Crab" },
			{ "spiny-lobster", "Spiny Lobster" },
			{ "squat-lobster", "Squat Lobster" },
			{ "volcano-snail", "Volcano Snail" },
			{ "cusk-eel-ab-1", "Infernal Eel" },
			{ "cusk-eel", "Cusk Eel" },
			{ "devil-ray-ab-1", "Withered Ray" },
			{ "devil-ray", "Devil Ray" },
			{ "fangtooth-ab-1", "Cursed Fangtooth" },
			{ "fangtooth", "Fangtooth" },
			{ "firefly-squid-ab-1", "Radiant Squid" },
			{ "firefly-squid", "Firefly Squid" },
			{ "frilled-shark-ab-1", "Twisted Shark" },
			{ "frilled-shark", "Frilled Shark" },
			{ "gar-ab-1", "Clawfin Gar" },
			{ "gar", "Gar" },
			{ "ghost-shark-ab-1", "Rapt Shark" },
			{ "ghost-shark", "Ghost Shark" },
			{ "giant-amphipod-ab-1", "Ruptured Vessel" },
			{ "giant-amphipod", "Giant Amphipod" },
			{ "glowing-octopus-ab-1", "Medusa Octopus" },
			{ "glowing-octopus", "Glowing Octopus" },
			{ "goliath-tigerfish", "Goliath Tigerfish" },
			{ "eel-ab-1", "Barbed Eel" },
			{ "eel-ab-2", "Host Eel" },
			{ "eel", "Grey Eel" },
			{ "grey-mullet-ab-1", "Entwined Mullet" },
			{ "grey-mullet", "Grey Mullet" },
			{ "flounder-ab-1", "Cyclopean Flounder" },
			{ "flounder-ab-2", "Riddled Flounder" },
			{ "flounder", "Gulf Flounder" },
			{ "gulper-eel", "Gulper Eel" },
			{ "hammerhead-shark-ab-1", "Gazing Shark" },
			{ "hammerhead-shark", "Hammerhead Shark" },
			{ "longfin-eel-ab-1", "Twinned Eels" },
			{ "longfin-eel", "Longfin Eel" },
			{ "stoplight-loosejaw-ab-1", "Perished Loosejaw" },
			{ "stoplight-loosejaw", "Loosejaw" },
			{ "mackerel-ab-1", "Grotesque Mackerel" },
			{ "mackerel-ab-2", "Lumpy Mackerel" },
			{ "mackerel-ab-3", "Many-Eyed Mackerel" },
			{ "moonfish-ab-1", "Skeletal Moonfish" },
			{ "moonfish", "Moonfish" },
			{ "oarfish", "Oarfish" },
			{ "oceanic-perch-ab-1", "Gnashing Perch" },
			{ "oceanic-perch", "Oceanic Perch" },
			{ "pale-skate-ab-1", "Defaced Skate" },
			{ "pale-skate", "Pale Skate" },
			{ "rattail-ab-1", "Congealed Rattail" },
			{ "rattail", "Rattail" },
			{ "red-snapper-ab-1", "Blood Snapper" },
			{ "red-snapper", "Red Snapper" },
			{ "sailfish-ab-1", "Sallow Sailfish" },
			{ "sailfish", "Sailfish" },
			{ "scarlet-prawn", "Scarlet Prawn" },
			{ "searobin-ab-1", "Ossified Searobin" },
			{ "searobin", "Armored Searobin" },
			{ "sergeant-fish-ab-1", "Vortex Interloper" },
			{ "sergeant-fish", "Sergeant Fish" },
			{ "snailfish-ab-1", "Calcified Snailfish" },
			{ "snailfish", "Snailfish" },
			{ "snake-mackerel-ab-1", "Serpentine Mackerel" },
			{ "snake-mackerel", "Snake Mackerel" },
			{ "stingray-ab-1", "Shard Ray" },
			{ "stingray", "Stingray" },
			{ "stonefish-ab-1", "Gelatinous Stonefish" },
			{ "stonefish", "Stonefish" },
			{ "sturgeon-ab-1", "Translucent Sturgeon" },
			{ "sturgeon", "Sturgeon" },
			{ "sunfish-ab-1", "Charred Sunfish" },
			{ "sunfish", "Ocean Sunfish" },
			{ "tarpon-ab-1", "Blistered Tarpon" },
			{ "tarpon", "Tarpon" },
			{ "tiger-mackerel-ab-1", "Flayed Mackerel" },
			{ "tiger-mackerel-ab-2", "Bearded Mackerel" },
			{ "tiger-mackerel", "Tiger Mackerel" },
			{ "viperfish-ab-1", "Decrepit Viperfish" },
			{ "viperfish-ab-2", "Collapsed Viperfish" },
			{ "viperfish", "Viperfish" },
			{ "wreckfish-ab-1", "Shattered Wreckfish" },
			{ "wreckfish-ab-2", "Bony Wreckfish" },
			{ "wreckfish", "Wreckfish" }
		};
	}
}
