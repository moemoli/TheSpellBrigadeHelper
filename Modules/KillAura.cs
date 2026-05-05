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
            if (Plugin.Instance.GodMode.Value)
            {
                if (__instance.healthContainer is PlayerHealthContainer)
                {
                    __0.Damage = 0;
                    return;
                }

            }
            if (Plugin.Instance.KillAura.Value)
            {
                __0.Damage = __instance.healthContainer.CurrentHealth;
            }
        }


        // 补丁：全图秒杀
        [HarmonyPatch(typeof(Enemy), "Update")]
        [HarmonyPostfix]
        static void Update_Enemy(Enemy __instance)
        {
            if (Plugin.Instance.KillAll.Value)
            {
                DamageInfo damage = new DamageInfo();
                damage.Damage = __instance.hitbox.healthContainer.CurrentHealth;
                __instance.hitbox.Hit(damage);
            }
        }
    }
}
