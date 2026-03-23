using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSpellBrigadeHelper.Modules
{
    [HarmonyPatch]
    internal class KillAura
    {

        // 补丁：修改伤害
        [HarmonyPatch(typeof(Hitbox), "Hit")]
        [HarmonyPrefix]
        static void Hitbox(Hitbox __instance, DamageInfo __0)
        {
            if (__instance is PlayerHitBox)
            {
                return;
            }
            if (Plugin.Instance.KillAura.Value)
            {
                __0.Damage = float.MaxValue;
            }
        }


        // 补丁：全图秒杀
        [HarmonyPatch(typeof(Enemy), "Update")]
        [HarmonyPrefix]
        static void Update_Enemy(Enemy __instance)
        {
            if (Plugin.Instance.KillAll.Value)
            {
                DamageInfo damage = new DamageInfo();
                damage.Damage = float.MaxValue;
                __instance.hitbox.Hit(damage);
            }
        }
    }
}
