using System;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace Ramune.Mo_Money
{
	// Token: 0x02000002 RID: 2
	[BepInPlugin("com.ramune.MoMoney", "Mo' Money", "1.0.0")]
	public class Mo_Money : BaseUnityPlugin
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public void Awake()
		{
			Mo_Money.harmony.PatchAll();
			Initializer.Init();
			base.Logger.LogInfo("Mo' Money 1.0.0 loaded");
			Mo_Money.logger = base.Logger;
		}

		// Token: 0x04000001 RID: 1
		public static ManualLogSource logger;

		// Token: 0x04000002 RID: 2
		private static readonly Harmony harmony = new Harmony("com.ramune.MoMoney");

		// Token: 0x04000003 RID: 3
		private const string myGUID = "com.ramune.MoMoney";

		// Token: 0x04000004 RID: 4
		private const string pluginName = "Mo' Money";

		// Token: 0x04000005 RID: 5
		private const string versionString = "1.0.0";
	}
}
