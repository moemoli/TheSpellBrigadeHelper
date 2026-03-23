using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSpellBrigadeHelper.Modules
{
    [HarmonyPatch]
    internal class AutoTask
    {
        // 补丁：自动完成任务
        [HarmonyPatch(typeof(OrderObjective), "Update")] 
        [HarmonyPostfix]
        static void Update_Task(OrderObjective __instance)
        {
            if (Plugin.Instance.AutoTask.Value)
            {
                __instance.EndObjective(true);
            }
        }
        // 补丁：自动完成任务
        [HarmonyPatch(typeof(ObjectiveDirector), "Start")] 
        [HarmonyPostfix]
        static void Update_Task(ObjectiveDirector __instance)
        {
            if (Plugin.Instance.AutoTask.Value)
            {
                __instance.SuccessfullyCompletedObjectives = 99999;
            }
        }
    }
}
