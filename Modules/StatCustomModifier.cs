using BepInEx.Configuration;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSpellBrigadeHelper.Modules
{
    [HarmonyPatch]
    internal class StatCustomModifier
    {
        // 补丁：修改属性数值
        [HarmonyPatch(typeof(Stat), "GetValue")]
        [HarmonyPostfix]
        static void GetValue(Stat __instance,ref float __result)
        {
            if (Plugin.Instance.StatsModifier.Value)
            {
                StatType statType = __instance.StatType;
                if (Plugin.Instance.stats.ContainsKey(statType))
                {
                    float value = ((ConfigEntry<float>)Plugin.Instance.stats[statType]).Value;
                    if (value > 0)
                        __result = value;
                }
            }
            if (Plugin.Instance.PickUpAll.Value)
            {
                StatType statType = __instance.StatType;
                if (statType == StatType.PickupRadius)
                {
                    __result = 99999999f;
                }
            }
        }
    }
}
