using System;
using HarmonyLib;

namespace Mo_Money.Patches
{
	[HarmonyPatch(typeof(ItemManager), "GetItemValue")]
	public static class ItemManager_Patch
	{
		[HarmonyPostfix]
		public static void GetItemValue(ref decimal __result, SpatialItemInstance itemInstance, ItemManager.BuySellMode mode, float sellValueModifier = 1f)
		{
			if (mode == ItemManager.BuySellMode.SELL)
			{
				if (Main.FishDictionary.TryGetValue(itemInstance.id, out string fishID) && !string.IsNullOrWhiteSpace(fishID) && Main.FishMultipliers.TryGetValue(fishID, out float fishMultiplier))
				{
					__result *= (decimal)fishMultiplier;
				}
				else if (Main.TrinketDictionary.TryGetValue(itemInstance.id, out string trinketID) && !string.IsNullOrWhiteSpace(trinketID) && Main.TrinketMultipliers.TryGetValue(trinketID, out float trinketMultiplier))
				{
					__result *= (decimal) trinketMultiplier;
				}
			}
		}
	}
}
