using HarmonyLib;
using System;

namespace TheSpellBrigadeHelper.Modules
{
    [HarmonyPatch]
    internal class SpellsModifier
    {

        // 补丁：修改技能冷却
        [HarmonyPatch(typeof(PlayerSpell), "HasCooldown")]
        [HarmonyPostfix]
        static void HasCooldown(PlayerSpell __instance, bool __result)
        {
            if (Plugin.Instance.NoSpellCoolDown.Value)
            {
                __result = false;
            }
        }

        // 补丁：修改技能冷却
        [HarmonyPatch(typeof(PlayerSpell), "GetCooldownProgress")]
        [HarmonyPostfix]
        static void GetCooldownProgress(PlayerSpell __instance, float __result)
        {
            if (Plugin.Instance.NoSpellCoolDown.Value)
            {
                __result = 9999f;
            }
        }

        // 补丁：修改槽位技能冷却
        [HarmonyPatch(typeof(SpellSlot), "Update")]
        [HarmonyPostfix]
        static void Update_SpellSlot(SpellSlot __instance)
        {
            if (Plugin.Instance.NoSpellCoolDown.Value)
            {
                __instance.ResetCooldownProgress();
            }
        }

        // 补丁：修改槽位技能条数
        [HarmonyPatch(typeof(SpellVariants), "Count",new Type[] { typeof(SpellType),typeof(SpellVariant) })]
        [HarmonyPostfix]
        static void Count_SpellVariants(SpellVariants __instance,SpellVariant __1,int __result)
        {
            if (Plugin.Instance.AddSpell.Value > 0 && __1 == SpellVariant.ExtraProjectile)
            {
                __result = (int)Plugin.Instance.AddSpell.Value;
                
            }
            if (Plugin.Instance.BigSpell.Value > 0&& __1 == SpellVariant.IncreaseInSize)
            {
                __result = (int)Plugin.Instance.BigSpell.Value;
            }
        }

        // 补丁：修改槽位技能条数
        [HarmonyPatch(typeof(SpellVariants), "Get", new Type[] { typeof(SpellType) })]
        [HarmonyPostfix]
        static void Get_SpellVariants(SpellVariants __instance,Il2CppSystem.Collections.Generic.List<SpellVariant> __result)
        {
            if (Plugin.Instance.AddSpell.Value > 0 )
            {
                __result.Add(SpellVariant.ExtraProjectile);

            }
            if (Plugin.Instance.BigSpell.Value > 0)
            {
                __result.Add(SpellVariant.IncreaseInSize);
            }
        }

        // 补丁：修改槽位技能条数
        [HarmonyPatch(typeof(SpellVariants), "Contains", new Type[] { typeof(SpellType), typeof(SpellVariant) })]
        [HarmonyPostfix]
        static void Contains_SpellVariants(SpellVariants __instance, SpellVariant __1, bool __result)
        {
            if (Plugin.Instance.AddSpell.Value > 0 && __1 == SpellVariant.ExtraProjectile)
            {
                __result = true;

            }
            if (Plugin.Instance.BigSpell.Value > 0&& __1 == SpellVariant.IncreaseInSize)
            {
                __result  = true;
            }
        }

        // 补丁：修改槽位技能条数
        [HarmonyPatch(typeof(PlayerStats), "GetSpellVariants", new Type[] { typeof(SpellType) })]
        [HarmonyPostfix]
        static void Get_PlayerStats(PlayerStats __instance, Il2CppSystem.Collections.Generic.List<SpellVariant> __result)
        {
            if (Plugin.Instance.AddSpell.Value > 0)
            {
                __result.Add(SpellVariant.ExtraProjectile);

            }
            if (Plugin.Instance.BigSpell.Value > 0)
            {
                __result.Add(SpellVariant.IncreaseInSize);
            }
        }

        // 补丁：修改槽位技能条数
        [HarmonyPatch(typeof(PlayerStats), "GetSpellValue", new Type[] { typeof(SpellType), typeof(StatType) })]
        [HarmonyPostfix]
        static void GetSpellValue_PlayerStats(PlayerStats __instance,StatType __1, float __result)
        {
            if (Plugin.Instance.AddSpell.Value > 0 && __1 == StatType.Projectiles)
            {
                __result =  Plugin.Instance.AddSpell.Value;

            }
            if (Plugin.Instance.BigSpell.Value > 0&& __1 == StatType.Range)
            {
                __result =  Plugin.Instance.BigSpell.Value;
            }
        }
    }
}
