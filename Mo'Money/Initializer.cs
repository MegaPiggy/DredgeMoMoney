using System;
using System.Collections.Generic;
using System.IO;
using BepInEx;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Ramune.Mo_Money
{
	// Token: 0x02000003 RID: 3
	public static class Initializer
	{
		// Token: 0x06000004 RID: 4 RVA: 0x0000209C File Offset: 0x0000029C
		public static void Init()
		{
			bool flag = !Directory.Exists(Initializer.FolderPath);
			if (flag)
			{
				Directory.CreateDirectory(Initializer.FolderPath);
			}
			Initializer.TrinketMultipliers = Initializer.WriteJsonFile(Initializer.TrinketJsonPath, Initializer.TrinketDictionary);
			Initializer.FishMultipliers = Initializer.WriteJsonFile(Initializer.FishJsonPath, Initializer.FishDictionary);
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000020F0 File Offset: 0x000002F0
		public static Dictionary<string, float> WriteJsonFile(string filepath, Dictionary<string, string> dictionary)
		{
			bool flag = !File.Exists(filepath);
			if (flag)
			{
				JObject jobject = new JObject();
				foreach (KeyValuePair<string, string> keyValuePair in dictionary)
				{
					jobject[keyValuePair.Value] = 1.0;
				}
				File.WriteAllText(filepath, jobject.ToString());
			}
			return JsonConvert.DeserializeObject<Dictionary<string, float>>(File.ReadAllText(filepath));
		}

		// Token: 0x04000006 RID: 6
		public static string FolderPath = Path.Combine(Paths.ConfigPath, "Mo'Money");

		// Token: 0x04000007 RID: 7
		public static string FishJsonPath = Path.Combine(Paths.ConfigPath, "Mo'Money", "FishMultipliers.json");

		// Token: 0x04000008 RID: 8
		public static string TrinketJsonPath = Path.Combine(Paths.ConfigPath, "Mo'Money", "TrinketMultipliers.json");

		// Token: 0x04000009 RID: 9
		public static Dictionary<string, float> TrinketMultipliers = new Dictionary<string, float>();

		// Token: 0x0400000A RID: 10
		public static Dictionary<string, float> FishMultipliers = new Dictionary<string, float>();

		// Token: 0x0400000B RID: 11
		public static JObject TrinketJson;

		// Token: 0x0400000C RID: 12
		public static JObject FishJson;

		// Token: 0x0400000D RID: 13
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

		// Token: 0x0400000E RID: 14
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
			{ "barracuda-ab-2", "Concertina Barracuda" },
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
			{ "blue-crab-ab-1", "Entangled Crab" },
			{ "blue-crab", "Blue Crab" },
			{ "crab-ab-1", "Cerebral Crab" },
			{ "crab", "Common Crab" },
			{ "crown-of-thorns-ab-1", "Crown of Nadir" },
			{ "crown-of-thorns", "Crown of Thorns" },
			{ "decorator-crab-ab-1", "Cortex Decorator" },
			{ "decorator-crab", "Decorator Crab" },
			{ "fiddler-crab-ab-1", "Malignant Pincer" },
			{ "fiddler-crab", "Fiddler Crab" },
			{ "giant-mud-crab-ab-1", "Mire Screecher" },
			{ "giant-mud-crab", "Giant Mud Crab" },
			{ "horseshoe-crab-ab-1", "Effigy Crab" },
			{ "horseshoe-crab", "Horseshoe Crab" },
			{ "rock-crab-ab-1", "Splintered Crab" },
			{ "rock-crab", "Rock Crab" },
			{ "spider-crab-ab-1", "Umbral Puppet" },
			{ "spider-crab", "Spider Crab" },
			{ "spiny-lobster-ab-1", "Imperious Lobster" },
			{ "spiny-lobster", "Spiny Lobster" },
			{ "squat-lobster-ab-1", "Sable Reacher" },
			{ "squat-lobster", "Squat Lobster" },
			{ "volcano-snail-ab-1", "Grasping Snail" },
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
			{ "gar-ab-2", "Grinning Gar" },
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
			{ "grey-mullet-ab-2", "Gleaming Mullet" },
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
			{ "moonfish-ab-2", "Beaked Moonfish" },
			{ "moonfish", "Moonfish" },
			{ "oarfish", "Oarfish" },
			{ "oceanic-perch-ab-1", "Gnashing Perch" },
			{ "oceanic-perch", "Oceanic Perch" },
			{ "pale-skate-ab-1", "Defaced Skate" },
			{ "pale-skate", "Pale Skate" },
			{ "rattail-ab-1", "Congealed Rattail" },
			{ "rattail", "Rattail" },
			{ "red-snapper-ab-1", "Blood Snapper" },
			{ "red-snapper-ab-2", "Latching Snapper" },
			{ "red-snapper", "Red Snapper" },
			{ "sailfish-ab-1", "Sallow Sailfish" },
			{ "sailfish-ab-2", "Hooked Sailfish" },
			{ "sailfish", "Sailfish" },
			{ "scarlet-prawn", "Scarlet Prawn" },
			{ "searobin-ab-1", "Ossified Searobin" },
			{ "searobin", "Armored Searobin" },
			{ "sergeant-fish-ab-1", "Vortex Interloper" },
			{ "sergeant-fish", "Sergeant Fish" },
			{ "snailfish-ab-1", "Calcified Snailfish" },
			{ "snailfish-ab-2", "Seizing Snailfish" },
			{ "snailfish", "Snailfish" },
			{ "snake-mackerel-ab-1", "Serpentine Mackerel" },
			{ "snake-mackerel-ab-2", "Tattered Mackerel" },
			{ "snake-mackerel", "Snake Mackerel" },
			{ "stingray-ab-1", "Shard Ray" },
			{ "stingray", "Stingray" },
			{ "stonefish-ab-1", "Gelatinous Stonefish" },
			{ "stonefish-ab-2", "Enthralled Stonefish" },
			{ "stonefish", "Stonefish" },
			{ "sturgeon-ab-1", "Translucent Sturgeon" },
			{ "sturgeon", "Sturgeon" },
			{ "sunfish-ab-1", "Charred Sunfish" },
			{ "sunfish-ab-2", "Glaring Sunfish" },
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
			{ "wreckfish", "Wreckfish" },
			{ "icefish", "Icefish" },
			{ "icefish-ab-1", "Fractalline Icefish" },
			{ "icefish-ab-2", "Thawed Icefish" },
			{ "icefish-ab-3", "Astral Icefish" },
			{ "char", "Char" },
			{ "char-ab-1", "Bubbling Char" },
			{ "wolffish", "Wolffish" },
			{ "wolffish-ab-1", "Hinged Wolffish" },
			{ "stargazer", "Stargazer" },
			{ "stargazer-ab-1", "Craterous Seer" },
			{ "lizardfish-ab-1", "Feral Lizardfish" },
			{ "lizardfish", "Lizardfish" },
			{ "toothfish", "Toothfish" },
			{ "toothfish-ab-1", "Bulbous Toothfish" },
			{ "goblin-shark", "Goblin Shark" },
			{ "goblin-shark-ab-1", "Grisly Shark" },
			{ "colossal-squid-ab-1", "Pale Grasper" },
			{ "colossal-squid", "Colossal Squid" },
			{ "sea-stars", "Sea Stars" },
			{ "sea-stars-ab-1", "Fallen Stars" },
			{ "king-crab", "King Crab" },
			{ "king-crab-ab-1", "Kings Wreath" },
			{ "sleeper-shark", "Sleeper Shark" }
		};
	}
}
