using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace QuickLoad {
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    public class Plugin : BaseUnityPlugin {
        public const string PluginGUID = "com.maxsch.BelowTheStone.QuickLoad";
        public const string PluginName = "QuickLoad";
        public const string PluginVersion = "0.1.0";

        public static ManualLogSource Log { get; private set; }

        private void Awake() {
            Harmony harmony = new Harmony(PluginGUID);
            harmony.PatchAll();

            Log = Logger;
        }
    }
}
