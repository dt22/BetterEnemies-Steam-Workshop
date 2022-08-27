﻿using Base.AI;
using Base.AI.Defs;
using Base.Core;
using Base.Defs;
using Base.Entities.Abilities;
using Base.Entities.Effects;
using Base.Entities.Effects.ApplicationConditions;
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
    internal class AIActionDefs
    {
        private static readonly DefRepository Repo = BetterEnemiesMain.Repo;
        private static readonly SharedData Shared = BetterEnemiesMain.Shared;
        public static void Apply_AIActionDefs()
        {
            Clone_PsychicScreamAI();
            //Create_BigBoomsAI();
            Clone_InstillFrenzyAI();
            Add_NewAIActionDefs();   
        }
        public static void Clone_PsychicScreamAI()
        {
            ApplyEffectAbilityDef MindCrush = Repo.GetAllDefs<ApplyEffectAbilityDef>().FirstOrDefault(p => p.name.Equals("MindCrush_AbilityDef"));           

            string Name = "MoveAndDoMindCrush_AIActionDef";
            AIActionMoveAndExecuteAbilityDef source = Repo.GetAllDefs<AIActionMoveAndExecuteAbilityDef>().FirstOrDefault(p => p.name.Equals("MoveAndDoPsychicScream_AIActionDef"));
            AIActionMoveAndExecuteAbilityDef MindCrushAI = Helper.CreateDefFromClone(
                source,
                "45A50BBB-02A2-4CF7-A6A8-28D8DA8C7250",
                Name);
            MindCrushAI.EarlyExitConsiderations[1].Consideration = Helper.CreateDefFromClone(
                source.EarlyExitConsiderations[1].Consideration,
                "C5054388-18F5-4AD6-BB30-85C27749ECD7",
                "MindCrushAbilityEnabled_AIConsiderationDef");
            MindCrushAI.Evaluations[0].Considerations[0].Consideration = Helper.CreateDefFromClone(
                source.Evaluations[0].Considerations[0].Consideration,
                "88464571-E231-4D3E-9F86-F18A759FA9EA",
                "MindCrushProximityToTargets_AIConsiderationDef");
            MindCrushAI.Evaluations[0].Considerations[1].Consideration = Helper.CreateDefFromClone(
                source.Evaluations[0].Considerations[1].Consideration,
                "53546688-659F-4550-927A-2A0EBA143E3D",
                "MindCrushNumberOfEnemiesInRange_AIConsiderationDef");
            MindCrushAI.Evaluations[0].Considerations[2].Consideration = Helper.CreateDefFromClone(
                source.Evaluations[0].Considerations[2].Consideration,
                "BC9C2BA8-9D13-4503-AE19-DF91B7278321",
                "WillpointsLeftAfterMindCrush_AIConsiderationDef");

            MindCrushAI.Weight = 999;
            MindCrushAI.AbilityToExecute = MindCrush;
            AIAbilityDisabledStateConsiderationDef EarlyExitConsideration1 = (AIAbilityDisabledStateConsiderationDef)MindCrushAI.EarlyExitConsiderations[1].Consideration;
            EarlyExitConsideration1.Ability = MindCrush;
            AIProximityToEnemiesConsiderationDef Consideration1 = (AIProximityToEnemiesConsiderationDef)MindCrushAI.Evaluations[0].Considerations[0].Consideration;
            Consideration1.MaxRange = 10;
            AINumberOfEnemiesInRangeConsiderationDef Consideration2 = (AINumberOfEnemiesInRangeConsiderationDef)MindCrushAI.Evaluations[0].Considerations[1].Consideration;
            Consideration2.MaxEnemies = 5;
            Consideration2.MaxRange = 10;
            AIWillpointsLeftAfterAbilityConsiderationDef Consideration3 = (AIWillpointsLeftAfterAbilityConsiderationDef)MindCrushAI.Evaluations[0].Considerations[2].Consideration;
            Consideration3.Ability = MindCrush;
        }
        public static void Create_BigBoomsAI()
        {
            ApplyStatusAbilityDef BigBooms = Repo.GetAllDefs<ApplyStatusAbilityDef>().FirstOrDefault(p => p.name.Equals("BigBooms_AbilityDef"));

            string Name = "MoveAndDoBigBooms_AIActionDef";
            AIActionMoveAndExecuteAbilityDef source = Repo.GetAllDefs<AIActionMoveAndExecuteAbilityDef>().FirstOrDefault(p => p.name.Equals("MoveAndQuickAim_AIActionDef"));
            AIActionMoveAndAttackDef source2 = Repo.GetAllDefs<AIActionMoveAndAttackDef>().FirstOrDefault(p => p.name.Equals("Queen_MoveAndLaunchProjectiles_AIActionDef"));
            AIActionMoveAndExecuteAbilityDef BigBoomsAI = Helper.CreateDefFromClone(
                source,
                "CC80DE93-F64B-416C-B219-3FFD16322B97",
                Name);
            BigBoomsAI.EarlyExitConsiderations[1].Consideration = Helper.CreateDefFromClone(
                source.EarlyExitConsiderations[1].Consideration,
                "6C67BCF1-3811-4A16-820F-B717A46F037E",
                "BigBoomsAbilityEnabled_AIConsiderationDef");
            BigBoomsAI.EarlyExitConsiderations[2].Consideration = Helper.CreateDefFromClone(
                source2.EarlyExitConsiderations[1].Consideration as AICanUseEquipmentConsiderationDef,
                "EE5BD779-FBFF-4EE3-BBA8-E9495695B2A8",
                "BigBoomsCanUseWeapons_AIConsiderationDef");
            BigBoomsAI.Evaluations[0].TargetGeneratorDef = Helper.CreateDefFromClone(
                source2.Evaluations[0].TargetGeneratorDef,
                "E37868AA-DB27-4764-9349-EF20C8B41277",
                "BigBoomsExplosiveWeapon_AITargetGeneratorDef");
            BigBoomsAI.Evaluations[1].Considerations[0].Consideration = Helper.CreateDefFromClone(
                source.Evaluations[1].Considerations[0].Consideration,
                "FA3E60DF-E33B-4697-802E-CF6B5A4E63CF",
                "EnoughActionPointsToShootAfterBigBooms_AIConsiderationDef");
            AIAttackPositionConsiderationDef AttackPosition  = Helper.CreateDefFromClone(
                source2.Evaluations[2].Considerations[0].Consideration as AIAttackPositionConsiderationDef,
                "CF63B6E1-7415-4185-ACB2-43A607058789",
                "BigBoomsAttackPosition_AIConsiderationDef");           
            BigBoomsAI.Evaluations[2].Considerations[0].Consideration = Helper.CreateDefFromClone(
                source.Evaluations[2].Considerations[0].Consideration,
                "B310EDC4-87DF-4FFD-848B-BA935541C537",
                "WillpointsLeftAfterBigBooms_AIConsiderationDef");

            BigBoomsAI.Weight = 999;
            BigBoomsAI.AbilityToExecute = BigBooms;           
            
            AIAbilityDisabledStateConsiderationDef EarlyExitConsideration1 = (AIAbilityDisabledStateConsiderationDef)BigBoomsAI.EarlyExitConsiderations[1].Consideration;
            EarlyExitConsideration1.Ability = BigBooms;                                            
            AIEnoughActionPointsForAbilityConsiderationDef Consideration1 = (AIEnoughActionPointsForAbilityConsiderationDef)BigBoomsAI.Evaluations[1].Considerations[0].Consideration;
            Consideration1.ChangeAbilitiesCostStatusDef = Repo.GetAllDefs<ChangeAbilitiesCostStatusDef>().FirstOrDefault(p => p.name.Equals("E_ReduceExplosiveAbilitiesCost [BigBooms_AbilityDef]"));
            AIWillpointsLeftAfterAbilityConsiderationDef Consideration2 = (AIWillpointsLeftAfterAbilityConsiderationDef)BigBoomsAI.Evaluations[2].Considerations[0].Consideration;
            Consideration2.Ability = BigBooms;
            
            BigBoomsAI.Evaluations[1].Considerations[1].Consideration = AttackPosition;

            BigBoomsAI.Evaluations = new AITargetEvaluation[]
            {
                BigBoomsAI.Evaluations[0],
                BigBoomsAI.Evaluations[1],
                BigBoomsAI.Evaluations[2],
                //new AITargetEvaluation()
                //{
                //    TargetGeneratorDef = source2.Evaluations[2].TargetGeneratorDef,
                //    FallbackTargetGeneratorDef = null,
                //    TopScoresToConsiderPerc = source2.Evaluations[2].TopScoresToConsiderPerc,
                //    MaxNumberOfTargetsPerc = source2.Evaluations[2].MaxNumberOfTargetsPerc,
                //    MinNumberOfTargets = source2.Evaluations[2].MinNumberOfTargets,
                //    MinNumberOfTargetsPerc = source2.Evaluations[2].MaxNumberOfTargetsPerc, 
                //    Considerations = new AIAdjustedConsideration[]
                //    {
                //       new AIAdjustedConsideration()
                //       {
                //           Consideration = AttackPosition,
                //       },
                //    },
                //},
            };           
        }
        public static void Clone_InstillFrenzyAI()
        {
            ApplyStatusAbilityDef ElectricReinforcement = Repo.GetAllDefs<ApplyStatusAbilityDef>().FirstOrDefault(p => p.name.Equals("ElectricReinforcement_AbilityDef"));

            string Name = "ElectricReinforcement_AIActionDef";
            AIActionExecuteAbilityDef source = Repo.GetAllDefs<AIActionExecuteAbilityDef>().FirstOrDefault(p => p.name.Equals("InstilFrenzy_AIActionDef"));
            AIActionExecuteAbilityDef ElectricReinforcementAI = Helper.CreateDefFromClone(
                source,
                "A8211067-3261-4AF6-B459-8E3C468965AD",
                Name);
            ElectricReinforcementAI.EarlyExitConsiderations[1].Consideration = Helper.CreateDefFromClone(
                source.EarlyExitConsiderations[1].Consideration,
                "051874DC-67D7-4656-A823-C896B1A80F2B",
                "ElectricReinforcementEnabled_AIConsiderationDef");
            ElectricReinforcementAI.Evaluations[0].Considerations[0].Consideration = Helper.CreateDefFromClone(
                source.Evaluations[0].Considerations[0].Consideration,
                "8ACA689A-C0CB-490F-B243-BC5598CD7F7A",
                "ElectricReinforcementNumberOfTargets_AIConsiderationDef");

            ElectricReinforcementAI.Weight = 999;
            ElectricReinforcementAI.AbilityDefs[0] = ElectricReinforcement;
            AIAbilityDisabledStateConsiderationDef EarlyExitConsideration1 = (AIAbilityDisabledStateConsiderationDef)ElectricReinforcementAI.EarlyExitConsiderations[1].Consideration;
            EarlyExitConsideration1.Ability = ElectricReinforcement;
            AIAbilityNumberOfTargetsConsiderationDef Consideration1 = (AIAbilityNumberOfTargetsConsiderationDef)ElectricReinforcementAI.Evaluations[0].Considerations[0].Consideration;
            Consideration1.Ability = ElectricReinforcement;          
        }
        public static void Add_NewAIActionDefs()
        {
            AIActionsTemplateDef DefaultAIActionsTemplateDef = Repo.GetAllDefs<AIActionsTemplateDef>().FirstOrDefault(p => p.name.Equals("AIActionsTemplateDef"));

            DefaultAIActionsTemplateDef.ActionDefs = new AIActionDef[]
            {
                DefaultAIActionsTemplateDef.ActionDefs[0],
                DefaultAIActionsTemplateDef.ActionDefs[1],
                DefaultAIActionsTemplateDef.ActionDefs[2],
                DefaultAIActionsTemplateDef.ActionDefs[3],
                DefaultAIActionsTemplateDef.ActionDefs[4],
                DefaultAIActionsTemplateDef.ActionDefs[5],
                DefaultAIActionsTemplateDef.ActionDefs[6],
                DefaultAIActionsTemplateDef.ActionDefs[7],
                DefaultAIActionsTemplateDef.ActionDefs[8],
                DefaultAIActionsTemplateDef.ActionDefs[9],
                DefaultAIActionsTemplateDef.ActionDefs[10],
                DefaultAIActionsTemplateDef.ActionDefs[11],
                DefaultAIActionsTemplateDef.ActionDefs[12],
                DefaultAIActionsTemplateDef.ActionDefs[13],
                DefaultAIActionsTemplateDef.ActionDefs[14],
                DefaultAIActionsTemplateDef.ActionDefs[15],
                DefaultAIActionsTemplateDef.ActionDefs[16],
                DefaultAIActionsTemplateDef.ActionDefs[17],
                DefaultAIActionsTemplateDef.ActionDefs[18],
                DefaultAIActionsTemplateDef.ActionDefs[19],
                DefaultAIActionsTemplateDef.ActionDefs[20],
                DefaultAIActionsTemplateDef.ActionDefs[21],
                DefaultAIActionsTemplateDef.ActionDefs[22],
                DefaultAIActionsTemplateDef.ActionDefs[23],
                DefaultAIActionsTemplateDef.ActionDefs[25],
                DefaultAIActionsTemplateDef.ActionDefs[25],
                DefaultAIActionsTemplateDef.ActionDefs[26],
                Repo.GetAllDefs<AIActionMoveAndExecuteAbilityDef>().FirstOrDefault(p => p.name.Equals("MoveAndDoMindCrush_AIActionDef")),
                //Repo.GetAllDefs<AIActionMoveAndExecuteAbilityDef>().FirstOrDefault(p => p.name.Equals("MoveAndDoBigBooms_AIActionDef")),
                Repo.GetAllDefs<AIActionExecuteAbilityDef>().FirstOrDefault(p => p.name.Equals("ElectricReinforcement_AIActionDef")),
            };
        }
    }
}
