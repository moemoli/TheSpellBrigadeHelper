using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Services.Authentication.Generated;

namespace TheSpellBrigadeHelper.Modules
{
    [HarmonyPatch]
    internal class GodMode
    {

        // 补丁：强制开始上帝模式
        [HarmonyPatch(typeof(PlayerHealthContainer), "Update")]
        [HarmonyPostfix]
        static void Update_PlayerHealthContainer(PlayerHealthContainer __instance)
        {
            if (Plugin.Instance.GodMode.Value)
                __instance.GodModeIsEnabled = Plugin.Instance.GodMode.Value;
        }
        // 补丁：敌人接触伤害设置为0
        [HarmonyPatch(typeof(Enemy), "Update")]
        [HarmonyPostfix]
        static void Update_Enemy(Enemy __instance)
        {
            if (Plugin.Instance.GodMode.Value)
                __instance.contactDamage = 0;
        }


    }
}
