using System;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace Mo_Money
{
	[BepInPlugin(myGUID, pluginName, versionString)]
	public class Mo_Money : BaseUnityPlugin
	{
		private static readonly Harmony harmony = new Harmony("com.ramune.MoMoney");

		private const string myGUID = "com.ramune.MoMoney";

		private const string pluginName = "Mo' Money";

		private const string versionString = "1.0.0";

		public static ManualLogSource logger;

		public void Awake()
		{
			Mo_Money.harmony.PatchAll();
			Initializer.Init();
			base.Logger.LogInfo($"{pluginName} {versionString} loaded");
			Mo_Money.logger = base.Logger;
		}
	}
}
