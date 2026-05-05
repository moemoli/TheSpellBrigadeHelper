using BepInEx.Configuration;
using Epic.OnlineServices;
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
        [HarmonyPatch(typeof(PlayerStats), "GetPlayerStats")]
        [HarmonyPostfix]
        static void GetPlayerStats(PlayerStats __instance,ref List<Stat> __result)
        {
            if (Plugin.Instance.StatsModifier.Value)
            {
                foreach (var stat in __result)
                {
                    StatType statType = stat.StatType;
                    if (Plugin.Instance.stats.ContainsKey(statType))
                    {
                        float value = ((ConfigEntry<float>)Plugin.Instance.stats[statType]).Value;
                        if (value > 0)
                            stat.baseValue = value;
                    }

                    if (Plugin.Instance.PickUpAll.Value)
                    {
                        if (statType == StatType.PickupRadius)
                        {
                            stat.baseValue = 99999999f;
                        }
                    }
                }
            }
          
        }
        // 补丁：修改属性数值
        [HarmonyPatch(typeof(CharacterStatsData), "GetCharacterStats")]
        [HarmonyPostfix]
        static void GetCharacterStats(CharacterStatsData __instance,ref List<Stat> __result)
        {
            if (Plugin.Instance.StatsModifier.Value)
            {
                foreach (var stat in __result)
                {
                    StatType statType = stat.StatType;
                    if (Plugin.Instance.stats.ContainsKey(statType))
                    {
                        float value = ((ConfigEntry<float>)Plugin.Instance.stats[statType]).Value;
                        if (value > 0)
                            stat.baseValue = value;
                    }

                    if (Plugin.Instance.PickUpAll.Value)
                    {
                        if (statType == StatType.PickupRadius)
                        {
                            stat.baseValue = 99999999f;
                        }
                    }
                }
            }
          
        }
        // 补丁：修改属性数值
        [HarmonyPatch(typeof(PlayerStats), "GetCharacterValue")]
        [HarmonyPostfix]
        static void GetCharacterValue(PlayerStats __instance,StatType __0,ref float __result)
        {
            if (Plugin.Instance.StatsModifier.Value)
            {
                StatType statType = __0;
                if (Plugin.Instance.stats.ContainsKey(statType))
                {
                    float value = ((ConfigEntry<float>)Plugin.Instance.stats[statType]).Value;
                    if (value > 0)
                        __result = value;
                }
            }
            if (Plugin.Instance.PickUpAll.Value)
            {
                StatType statType = __0;
                if (statType == StatType.PickupRadius)
                {
                    __result = 99999999f;
                }
            }
        }
        // 补丁：修改属性数值
        [HarmonyPatch(typeof(StaticStatModifier), "GetValue")]
        [HarmonyPostfix]
        static void GetValue(StaticStatModifier __instance,ref float __result)
        {
            if (Plugin.Instance.StatsModifier.Value)
            {
                StatType statType = __instance.GetStatType();
                if (Plugin.Instance.stats.ContainsKey(statType))
                {
                    float value = ((ConfigEntry<float>)Plugin.Instance.stats[statType]).Value;
                    if (value > 0)
                        __result = value;
                }
            }
            if (Plugin.Instance.PickUpAll.Value)
            {
                StatType statType = __instance.GetStatType();
                if (statType == StatType.PickupRadius)
                {
                    __result = 99999999f;
                }
            }
        }
        // 补丁：修改属性数值
        [HarmonyPatch(typeof(StatModifier), "GetValue")]
        [HarmonyPostfix]
        static void GetValue(StatModifier __instance,ref float __result)
        {
            if (Plugin.Instance.StatsModifier.Value)
            {
                StatType statType = __instance.GetStatType();
                if (Plugin.Instance.stats.ContainsKey(statType))
                {
                    float value = ((ConfigEntry<float>)Plugin.Instance.stats[statType]).Value;
                    if (value > 0)
                        __result = value;
                }
            }
            if (Plugin.Instance.PickUpAll.Value)
            {
                StatType statType = __instance.GetStatType();
                if (statType == StatType.PickupRadius)
                {
                    __result = 99999999f;
                }
            }
        }
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
    
        // 补丁：修改属性数值
        [HarmonyPatch(typeof(Stat), "GetDisplayValue")]
        [HarmonyPostfix]
        static void GetDisplayValue(Stat __instance,ref float __result)
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

        // 补丁：修改属性数值
        [HarmonyPatch(typeof(Stat), "GetValueWithExtraModifiers")]
        [HarmonyPostfix]
        static void GetValueWithExtraModifiers(Stat __instance, ref float __result)
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

        // 补丁：修改属性数值
        [HarmonyPatch(typeof(Stat), "GetDisplayValueWithExtraModifiers")]
        [HarmonyPostfix]
        static void GetDisplayValueWithExtraModifiers(Stat __instance, ref float __result)
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
