using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSpellBrigadeHelper.Modules
{
    [HarmonyPatch]
    internal class SpellsModifier
    {

        // 补丁：修改技能冷却
        [HarmonyPatch(typeof(PlayerSpell), "HasCooldown")]
        [HarmonyPrefix]
        static void HasCooldown(PlayerSpell __instance, bool __result)
        {
            if (Plugin.Instance.NoSpellCoolDown.Value)
            {
                __result = false;
            }
        }

        // 补丁：修改技能冷却
        [HarmonyPatch(typeof(PlayerSpell), "GetCooldownProgress")]
        [HarmonyPrefix]
        static void GetCooldownProgress(PlayerSpell __instance, float __result)
        {
            if (Plugin.Instance.NoSpellCoolDown.Value)
            {
                __result = 9999f;
            }
        }
    }
}
