using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using Cpp2IL.Core.Extensions;
using HarmonyLib;
using System;
using System.Collections;
using TheSpellBrigadeHelper.Modules;
using Unity.Services.Authentication.Generated;
using Unity.VisualScripting;
using UnityEngine;

namespace TheSpellBrigadeHelper
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    public class Plugin : BasePlugin
    {
        internal static new ManualLogSource Log;
        public ConfigEntry<bool> GodMode;
        public ConfigEntry<bool> KillAura;
        public ConfigEntry<bool> NoSpellCoolDown;
        public ConfigEntry<bool> StatsModifier;
        public ConfigEntry<bool> PickUpAll;
        public ConfigEntry<bool> KillAll;
        public Hashtable stats;
        public Hashtable statsDesc;

        public bool init = false;
        public static Plugin Instance { get; private set; }

        public override void Load()
        {
            Instance = this;
            stats = new Hashtable();
            statsDesc = new Hashtable();
            // 加载配置文件
            LoadConfig();
            // Plugin startup logic
            Harmony.CreateAndPatchAll(typeof(GodMode));
            Harmony.CreateAndPatchAll(typeof(KillAura));
            Harmony.CreateAndPatchAll(typeof(SpellsModifier));
            Harmony.CreateAndPatchAll(typeof(StatCustomModifier));

            Log = base.Log;
            Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        }

        private void LoadConfig()
        {
            this.GodMode = Config.Bind("General", "GodMode", false, "上帝模式");
            this.KillAura = Config.Bind("General", "KillAura", false, "一击必杀");
            this.NoSpellCoolDown = Config.Bind("General", "NoSpellCoolDown", false, "技能无冷却");
            this.StatsModifier = Config.Bind("General", "StatsModifier", false, "属性修改");
            this.PickUpAll = Config.Bind("General", "PickUpAll", false, "全图吸取");
            this.KillAll = Config.Bind("General", "KillAll", false, "全图击杀");
            
            statsDesc.Add(StatType.Damage, "伤害");
            statsDesc.Add(StatType.Range, "技能范围");
            statsDesc.Add(StatType.FireRate, "技能射速");
            statsDesc.Add(StatType.Speed, "技能速度");
            statsDesc.Add(StatType.DamageTickRate, "伤害频率");
            statsDesc.Add(StatType.Size, "技能大小");
            statsDesc.Add(StatType.MovementSpeed, "移动速度");
            statsDesc.Add(StatType.MaxHealth, "最大血量");
            statsDesc.Add(StatType.Luck, "幸运值");
            statsDesc.Add(StatType.XPGain, "经验倍率");
            statsDesc.Add(StatType.PickupRadius, "拾取范围");
            statsDesc.Add(StatType.CriticalChance, "暴击率");
            statsDesc.Add(StatType.CriticalDamage, "暴击伤害");
            statsDesc.Add(StatType.Armor, "护甲");
            statsDesc.Add(StatType.Dodge, "闪避");
            statsDesc.Add(StatType.HealthRegeneration, "生命恢复");
            statsDesc.Add(StatType.Rerolls, "重掷");
            statsDesc.Add(StatType.ReviveSpeed, "重生速度");
            statsDesc.Add(StatType.Revives, "重生次数");
            statsDesc.Add(StatType.Projectiles, "Projectiles");
            statsDesc.Add(StatType.HealOnDodge, "闪避治疗");
            statsDesc.Add(StatType.HealOnLevelUp, "闪避升级");
            statsDesc.Add(StatType.DropChance, "掉落几率");
            statsDesc.Add(StatType.TerrainSpeedMultiplier, "地形速度倍率");
            statsDesc.Add(StatType.HitboxSizeMultiplier, "碰撞箱大小倍率");
            statsDesc.Add(StatType.ElementWeaknessMultiplier, "元素弱点倍率");
            statsDesc.Add(StatType.ElementStrengthMultiplier, "元素强度倍率");
            statsDesc.Add(StatType.HealingMultiplier, "治疗倍率");
            statsDesc.Add(StatType.XPGainOnDamageTaken, "受到伤害时获得的经验");
            statsDesc.Add(StatType.HealthPotionAmountMultiplier, "生命药水恢复倍率");

            foreach (StatType stat in Enum.GetValues(typeof(StatType)))
            {
                stats.Add(stat, Config.Bind("StatModifier", stat.ToString(), -1f, $"修改{statsDesc[stat]}属性的数值"));
            }

        }

        public override bool Unload()
        {
            // 确保最终保存
            Config.Save();
            Log.LogInfo("游戏退出，配置已保存");
            return false;
        }

    }
}
