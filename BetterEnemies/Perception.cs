﻿using Base.AI.Defs;
using Base.Core;
using Base.Defs;
using Base.Entities.Abilities;
using Base.Entities.Effects;
using Base.Entities.Statuses;
using Base.Levels;
using Base.UI;
using Base.Utils.Maths;
using PhoenixPoint.Common.Core;
using PhoenixPoint.Common.Entities.GameTags;
using PhoenixPoint.Common.Entities.GameTagsTypes;
using PhoenixPoint.Common.UI;
using PhoenixPoint.Geoscape.Entities.DifficultySystem;
using PhoenixPoint.Geoscape.Events.Eventus;
using PhoenixPoint.Tactical;
using PhoenixPoint.Tactical.AI;
using PhoenixPoint.Tactical.AI.Actions;
using PhoenixPoint.Tactical.AI.Considerations;
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
	internal class Perception
	{
		private static readonly DefRepository Repo = BetterEnemiesMain.Repo;
		private static readonly SharedData Shared = BetterEnemiesMain.Shared;		
		public static void Change_Perception()
		{
			BetterEnemiesConfig Config = (BetterEnemiesConfig)BetterEnemiesMain.Main.Config;
			TacticalPerceptionDef tacticalPerceptionDef = Repo.GetAllDefs<TacticalPerceptionDef>().FirstOrDefault(a => a.name.Equals("Soldier_PerceptionDef"));

			if (Config.AdjustHumanPerception == true)
            {
				tacticalPerceptionDef.PerceptionRange = Config.Human_Soldier_Perception;
			}
					
			BodyPartAspectDef bodyPartAspectDef = Repo.GetAllDefs<BodyPartAspectDef>().FirstOrDefault(a => a.name.Equals("E_BodyPartAspect [SY_Sniper_Helmet_BodyPartDef]"));
			bodyPartAspectDef.Perception = 4f;
			BodyPartAspectDef bodyPartAspectDef2 = Repo.GetAllDefs<BodyPartAspectDef>().FirstOrDefault(a => a.name.Equals("E_BodyPartAspect [AN_Assault_Helmet_BodyPartDef]"));
			bodyPartAspectDef2.Perception = 2f;
			BodyPartAspectDef bodyPartAspectDef3 = Repo.GetAllDefs<BodyPartAspectDef>().FirstOrDefault(a => a.name.Equals("E_BodyPartAspect [AN_Berserker_Helmet_BodyPartDef]"));
			bodyPartAspectDef3.Perception = 5f;
			bodyPartAspectDef3.WillPower = 2f;
			BodyPartAspectDef bodyPartAspectDef4 = Repo.GetAllDefs<BodyPartAspectDef>().FirstOrDefault(a => a.name.Equals("E_BodyPartAspect [AN_Berserker_Helmet_Viking_BodyPartDef]"));
			bodyPartAspectDef4.WillPower = 2f;
			BodyPartAspectDef bodyPartAspectDef5 = Repo.GetAllDefs<BodyPartAspectDef>().FirstOrDefault(a => a.name.Equals("E_BodyPartAspect [AN_Priest_Legs_ItemDef]"));
			bodyPartAspectDef5.Perception = 2f;
			BodyPartAspectDef bodyPartAspectDef6 = Repo.GetAllDefs<BodyPartAspectDef>().FirstOrDefault(a => a.name.Equals("E_BodyPartAspect [AN_Priest_Torso_BodyPartDef]"));
			bodyPartAspectDef6.Perception = 4f;
			BodyPartAspectDef bodyPartAspectDef7 = Repo.GetAllDefs<BodyPartAspectDef>().FirstOrDefault(a => a.name.Equals("E_BodyPartAspect [NJ_Heavy_Helmet_BodyPartDef]"));
			bodyPartAspectDef7.Perception = -2f;
			BodyPartAspectDef bodyPartAspectDef8 = Repo.GetAllDefs<BodyPartAspectDef>().FirstOrDefault(a => a.name.Equals("E_BodyPartAspect [PX_Sniper_Helmet_BodyPartDef]"));
			bodyPartAspectDef8.Perception = 3f;
			BodyPartAspectDef bodyPartAspectDef9 = Repo.GetAllDefs<BodyPartAspectDef>().FirstOrDefault(a => a.name.Equals("E_BodyPartAspect [SY_Shinobi_BIO_Helmet_BodyPartDef]"));
			bodyPartAspectDef9.Perception = 3f;
			BodyPartAspectDef bodyPartAspectDef10 = Repo.GetAllDefs<BodyPartAspectDef>().FirstOrDefault(a => a.name.Equals("E_BodyPartAspect [NJ_Sniper_Helmet_BodyPartDef]"));
			bodyPartAspectDef10.Perception = 4f;
			BodyPartAspectDef bodyPartAspectDef11 = Repo.GetAllDefs<BodyPartAspectDef>().FirstOrDefault(a => a.name.Equals("E_BodyPartAspect [PX_Heavy_Helmet_BodyPartDef]"));
			bodyPartAspectDef11.Perception = 0f;
			BodyPartAspectDef bodyPartAspectDef12 = Repo.GetAllDefs<BodyPartAspectDef>().FirstOrDefault(a => a.name.Equals("E_BodyPartAspect [IN_Heavy_Helmet_BodyPartDef]"));
			bodyPartAspectDef12.Perception = -2f;
			BodyPartAspectDef bodyPartAspectDef13 = Repo.GetAllDefs<BodyPartAspectDef>().FirstOrDefault(a => a.name.Equals("E_BodyPartAspect [AN_Berserker_Watcher_Helmet_BodyPartDef]"));
			bodyPartAspectDef13.Perception = 8f;
			BodyPartAspectDef bodyPartAspectDef14 = Repo.GetAllDefs<BodyPartAspectDef>().FirstOrDefault(a => a.name.Equals("E_BodyPartAspect [SY_Infiltrator_Helmet_BodyPartDef]"));
			bodyPartAspectDef14.Perception = 5f;
			TacticalItemDef styxHelmet = Repo.GetAllDefs<TacticalItemDef>().FirstOrDefault(a => a.name.Equals("SY_Infiltrator_Helmet_BodyPartDef"));
			styxHelmet.BodyPartAspectDef.Perception = 5f;
			BodyPartAspectDef bodyPartAspectDef15 = Repo.GetAllDefs<BodyPartAspectDef>().FirstOrDefault(a => a.name.Equals("E_BodyPartAspect [AN_Berserker_Watcher_Torso_BodyPartDef]"));
			bodyPartAspectDef15.Perception = 3f;
			BodyPartAspectDef bodyPartAspectDef16 = Repo.GetAllDefs<BodyPartAspectDef>().FirstOrDefault(a => a.name.Equals("E_BodyPartAspect [NJ_Exo_BIO_Helmet_BodyPartDef]"));
			bodyPartAspectDef16.Perception = 3f;
		}
	}
}
