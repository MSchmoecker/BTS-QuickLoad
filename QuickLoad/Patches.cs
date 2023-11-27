using HarmonyLib;
using UnityEngine;

namespace QuickLoad {
    [HarmonyPatch]
    public static class Patches {
        private static bool firstLoad = true;

        [HarmonyPatch(typeof(MainMenu), "Start"), HarmonyPostfix]
        private static void MainMenu_Awake_Postfix(MainMenu __instance) {
            if (!firstLoad) {
                return;
            }

            firstLoad = false;

            int lastProfile = PlayerPrefs.GetInt("MS_QuickLoad_LastProfile", -1);

            if (lastProfile >= 0 && lastProfile < __instance.profileSlots.Length && __instance.profileSlots[lastProfile].profile != null) {
                __instance.profileSlots[lastProfile].OnPlayConfirm();
            }
        }

        [HarmonyPatch(typeof(ProfileSlot), "OnPlayConfirm"), HarmonyPostfix]
        private static void ProfileSlot_OnPlayConfirm_Postfix(ProfileSlot __instance) {
            PlayerPrefs.SetInt("MS_QuickLoad_LastProfile", __instance.slot);
            Plugin.Log.LogInfo($"Set last profile to {__instance.slot}");
        }
    }
}
