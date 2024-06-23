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
				if (Initializer.FishDictionary.TryGetValue(itemInstance.id, out string fishID) && !string.IsNullOrWhiteSpace(fishID) && Initializer.FishMultipliers.TryGetValue(fishID, out float fishMultiplier))
				{
					__result *= fishMultiplier;
				}
				else if (Initializer.TrinketDictionary.TryGetValue(itemInstance.id, out string trinketID) && !string.IsNullOrWhiteSpace(trinketID) && Initializer.TrinketMultipliers.TryGetValue(trinketID, out float trinketMultiplier))
				{
					__result *= trinketMultiplier;
				}
			}
		}
	}
}
