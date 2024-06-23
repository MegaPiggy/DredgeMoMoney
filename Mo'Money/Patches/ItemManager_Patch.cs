using System;
using HarmonyLib;

namespace Ramune.Mo_Money.Patches
{
	// Token: 0x02000004 RID: 4
	[HarmonyPatch(typeof(ItemManager), "GetItemValue")]
	public static class ItemManager_Patch
	{
		// Token: 0x06000007 RID: 7 RVA: 0x00002C74 File Offset: 0x00000E74
		[HarmonyPostfix]
		public static void GetItemValue(ref decimal __result, SpatialItemInstance itemInstance, ItemManager.BuySellMode mode, float sellValueModifier = 1f)
		{
			bool flag = mode != 1;
			if (!flag)
			{
				string text;
				Initializer.FishDictionary.TryGetValue(itemInstance.id, out text);
				string text2;
				Initializer.TrinketDictionary.TryGetValue(itemInstance.id, out text2);
				bool flag2 = text != null;
				if (flag2)
				{
					float value;
					Initializer.FishMultipliers.TryGetValue(text, out value);
					__result *= (decimal)value;
				}
				bool flag3 = text2 != null;
				if (flag3)
				{
					float value2;
					Initializer.TrinketMultipliers.TryGetValue(text2, out value2);
					__result *= (decimal)value2;
				}
			}
		}
	}
}
