using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSpellBrigadeHelper.Modules
{
    [HarmonyPatch]
    internal class AutoArtifact
    {
        // 补丁：自动捡起神器
        [HarmonyPatch(typeof(ArtifactChestWithPickup), "Awake")]
        [HarmonyPostfix]
        static void Update_ArtifactChestWithPickup(ArtifactChestWithPickup __instance)
        {
            if (Plugin.Instance.AutoArtifact.Value)
                __instance.PickUp();
        }
    }
}
