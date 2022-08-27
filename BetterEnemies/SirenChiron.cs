﻿using Base.Core;
using Base.Defs;
using Base.Entities.Abilities;
using Base.Entities.Effects;
using Base.Entities.Statuses;
using Base.Levels;
using Base.UI;
using Base.Utils.Maths;
using PhoenixPoint.Common.Core;
using PhoenixPoint.Common.Entities;
using PhoenixPoint.Common.Entities.Characters;
using PhoenixPoint.Common.Entities.GameTags;
using PhoenixPoint.Common.Entities.GameTagsTypes;
using PhoenixPoint.Common.UI;
using PhoenixPoint.Geoscape.Entities.DifficultySystem;
using PhoenixPoint.Geoscape.Entities.Research;
using PhoenixPoint.Geoscape.Events.Eventus;
using PhoenixPoint.Tactical;
using PhoenixPoint.Tactical.AI;
using PhoenixPoint.Tactical.AI.Actions;
using PhoenixPoint.Tactical.AI.Considerations;
using PhoenixPoint.Tactical.AI.TargetGenerators;
using PhoenixPoint.Tactical.Entities;
using PhoenixPoint.Tactical.Entities.Abilities;
using PhoenixPoint.Tactical.Entities.Animations;
using PhoenixPoint.Tactical.Entities.DamageKeywords;
using PhoenixPoint.Tactical.Entities.Effects;
using PhoenixPoint.Tactical.Entities.Effects.DamageTypes;
using PhoenixPoint.Tactical.Entities.Equipments;
using PhoenixPoint.Tactical.Entities.Statuses;
using PhoenixPoint.Tactical.Entities.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BetterEnemies
{
    internal class SirenChiron
    {
        private static readonly DefRepository Repo = BetterEnemiesMain.Repo;
        private static readonly SharedData Shared = BetterEnemiesMain.Shared;
        public static void Chnage_SirenChiron()
        {

            TacticalItemDef sirenLegsHeavy = Repo.GetAllDefs<TacticalItemDef>().FirstOrDefault(a => a.name.Equals("Siren_Legs_Heavy_BodyPartDef"));
            TacticalItemDef sirenLegsAgile = Repo.GetAllDefs<TacticalItemDef>().FirstOrDefault(a => a.name.Equals("Siren_Legs_Agile_BodyPartDef"));
            TacticalItemDef sirenLegsOrichalcum = Repo.GetAllDefs<TacticalItemDef>().FirstOrDefault(a => a.name.Equals("Siren_Legs_Orichalcum_BodyPartDef"));
            TacticalItemDef sirenScremingHead = Repo.GetAllDefs<TacticalItemDef>().FirstOrDefault(a => a.name.Equals("Siren_Head_Screamer_BodyPartDef"));
            PsychicScreamAbilityDef sirenPsychicScream = Repo.GetAllDefs<PsychicScreamAbilityDef>().FirstOrDefault(a => a.name.Equals("Siren_PsychicScream_AbilityDef"));
            MindControlAbilityDef sirenMC = Repo.GetAllDefs<MindControlAbilityDef>().FirstOrDefault(a => a.name.Equals("Priest_MindControl_AbilityDef"));
            TacCharacterDef sirenBanshee = Repo.GetAllDefs<TacCharacterDef>().FirstOrDefault(a => a.name.Equals("Siren3_InjectorBuffer_AlienMutationVariationDef"));
            TacCharacterDef sirenHarbinger = Repo.GetAllDefs<TacCharacterDef>().FirstOrDefault(a => a.name.Equals("Siren4_SlasherBuffer_AlienMutationVariationDef"));
            TacticalPerceptionDef sirenPerception = Repo.GetAllDefs<TacticalPerceptionDef>().FirstOrDefault(a => a.name.Equals("Siren_PerceptionDef"));
            TacCharacterDef sirenArmis = Repo.GetAllDefs<TacCharacterDef>().FirstOrDefault(a => a.name.Equals("Siren5_Orichalcum_AlienMutationVariationDef"));
            WeaponDef sirenInjectorArms = Repo.GetAllDefs<WeaponDef>().FirstOrDefault(a => a.name.Equals("Siren_Arms_Injector_WeaponDef"));
            TacticalItemDef sirenArmisHead = Repo.GetAllDefs<TacticalItemDef>().FirstOrDefault(a => a.name.Equals("Siren_Head_Orichalcum_BodyPartDef"));
            WeaponDef sirenAcidTorso = Repo.GetAllDefs<WeaponDef>().FirstOrDefault(a => a.name.Equals("Siren_Torso_AcidSpitter_WeaponDef"));
            WeaponDef sirenArmisAcidTorso = Repo.GetAllDefs<WeaponDef>().FirstOrDefault(a => a.name.Equals("Siren_Torso_Orichalcum_WeaponDef"));
            ShootAbilityDef AcidSpray = Repo.GetAllDefs<ShootAbilityDef>().FirstOrDefault(a => a.name.Equals("Siren_SpitAcid_AbilityDef"));

            WeaponDef chironBlastMortar = Repo.GetAllDefs<WeaponDef>().FirstOrDefault(a => a.name.Equals("Chiron_Abdomen_Mortar_WeaponDef"));
            WeaponDef chironCristalMortar = Repo.GetAllDefs<WeaponDef>().FirstOrDefault(a => a.name.Equals("Chiron_Abdomen_Crystal_Mortar_WeaponDef"));
            WeaponDef chironAcidMortar = Repo.GetAllDefs<WeaponDef>().FirstOrDefault(a => a.name.Equals("Chiron_Abdomen_Acid_Mortar_WeaponDef"));
            WeaponDef chironFireWormMortar = Repo.GetAllDefs<WeaponDef>().FirstOrDefault(a => a.name.Equals("Chiron_Abdomen_FireWorm_Launcher_WeaponDef"));
            WeaponDef chironAcidWormMortar = Repo.GetAllDefs<WeaponDef>().FirstOrDefault(a => a.name.Equals("Chiron_Abdomen_AcidWorm_Launcher_WeaponDef"));
            WeaponDef chironPoisonWormMortar = Repo.GetAllDefs<WeaponDef>().FirstOrDefault(a => a.name.Equals("Chiron_Abdomen_PoisonWorm_Launcher_WeaponDef"));
            TacCharacterDef chironFireHeavy = Repo.GetAllDefs<TacCharacterDef>().FirstOrDefault(a => a.name.Equals("Chiron2_FireWormHeavy_AlienMutationVariationDef"));
            TacCharacterDef chironPoisonHeavy = Repo.GetAllDefs<TacCharacterDef>().FirstOrDefault(a => a.name.Equals("Chiron4_PoisonWormHeavy_AlienMutationVariationDef"));
            TacCharacterDef chironAcidHeavy = Repo.GetAllDefs<TacCharacterDef>().FirstOrDefault(a => a.name.Equals("Chiron6_AcidWormHeavy_AlienMutationVariationDef"));
            TacCharacterDef chironGooHeavy = Repo.GetAllDefs<TacCharacterDef>().FirstOrDefault(a => a.name.Equals("Chiron8_GooHeavy_AlienMutationVariationDef"));

            sirenPerception.PerceptionRange = 38;
            sirenBanshee.Data.Will = 14;
            sirenBanshee.Data.BodypartItems[0] = sirenScremingHead;
            sirenBanshee.Data.Speed += 5;
            sirenInjectorArms.DamagePayload.DamageKeywords[2].Value = 10;
            sirenLegsAgile.Armor = 30;
            sirenPsychicScream.ActionPointCost = 0.25f;
            sirenPsychicScream.UsesPerTurn = 1;
            sirenAcidTorso.APToUsePerc = 25;
            sirenArmisAcidTorso.APToUsePerc = 25;
            AcidSpray.UsesPerTurn = 1;

            sirenBanshee.Data.Abilites = new TacticalAbilityDef[]
            {
                //Repo.GetAllDefs<TacticalAbilityDef>().FirstOrDefault(a => a.name.Equals("Siren_PsychicScream_AbilityDef")),
                Repo.GetAllDefs<TacticalAbilityDef>().FirstOrDefault(a => a.name.Equals("Thief_AbilityDef")),
                Repo.GetAllDefs<TacticalAbilityDef>().FirstOrDefault(a => a.name.Equals("StealthSpecialist_AbilityDef"))
            };
            sirenHarbinger.Data.Abilites = new TacticalAbilityDef[]
            {
                Repo.GetAllDefs<TacticalAbilityDef>().FirstOrDefault(a => a.name.Equals("CloseQuarters_AbilityDef")),
            };
            sirenArmis.Data.Abilites = new TacticalAbilityDef[]
            {
                sirenArmis.Data.Abilites[0],
                Repo.GetAllDefs<TacticalAbilityDef>().FirstOrDefault(a => a.name.Equals("IgnorePain_AbilityDef")),
            };

            sirenArmisHead.Abilities = new AbilityDef[]
            {
                sirenArmisHead.Abilities[0],
            };

            //foreach(TacCharacterDef character in Repo.GetAllDefs<TacCharacterDef>().Where(a => a.name.Contains("Siren")))
           // {
           //     character.Data.Abilites.AddToArray(sirenMC);
           // }

            chironFireHeavy.Data.Speed = 8;
            chironPoisonHeavy.Data.Speed = 8;
            chironAcidHeavy.Data.Speed = 8;
            chironGooHeavy.Data.Speed = 8;
            chironAcidMortar.DamagePayload.DamageKeywords[0].Value = 20;
            chironAcidMortar.ChargesMax = 18;
            chironFireWormMortar.DamagePayload.ProjectilesPerShot = 3;    // 3
            chironFireWormMortar.ChargesMax = 18;    // 15            
            chironAcidWormMortar.DamagePayload.ProjectilesPerShot = 3;    // 3
            chironAcidWormMortar.ChargesMax = 18;    // 15            
            chironPoisonWormMortar.DamagePayload.ProjectilesPerShot = 3;    // 3
            chironPoisonWormMortar.ChargesMax = 18;    // 15            
            chironBlastMortar.DamagePayload.ProjectilesPerShot = 3;    // 3
            chironBlastMortar.ChargesMax = 18;   // 12           
            chironCristalMortar.DamagePayload.ProjectilesPerShot = 3;    // 3
            chironCristalMortar.ChargesMax = 30;    // 12

           // chironPoisonHeavy.Data.Abilites = new TacticalAbilityDef[]
           // {
           //     Repo.GetAllDefs<TacticalAbilityDef>().FirstOrDefault(a => a.name.Equals("Acheron_CoPoison_AbilityDef")),
           // };
           // 
           // chironAcidHeavy.Data.Abilites = new TacticalAbilityDef[]
           // {
           //     Repo.GetAllDefs<TacticalAbilityDef>().FirstOrDefault(a => a.name.Equals("Acheron_CoShred_AbilityDef")),
           // };
           //
           // chironFireHeavy.Data.Abilites = new TacticalAbilityDef[]
           // {
           //     Repo.GetAllDefs<TacticalAbilityDef>().FirstOrDefault(a => a.name.Equals("FireWard2_AbilityDef")),
           // };
           //
           // chironGooHeavy.Data.Abilites = new TacticalAbilityDef[]
           // {
           //     Repo.GetAllDefs<TacticalAbilityDef>().FirstOrDefault(a => a.name.Equals("Aura_LivingCrystal_AbilityDef")),
           // };
            
            foreach (WeaponDef ChironWormLauncher in Repo.GetAllDefs<WeaponDef>().Where(a => a.name.Contains("Chiron_Abdomen_") && a.name.Contains("Worm_Launcher_WeaponDef")))
            {
                ChironWormLauncher.DamagePayload.DamageKeywords[1].Value = 240;
            }
        }
        
    }
}
