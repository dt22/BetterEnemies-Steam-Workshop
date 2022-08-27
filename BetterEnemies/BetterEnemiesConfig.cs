using PhoenixPoint.Modding;

namespace BetterEnemies
{
	/// <summary>
	/// ModConfig is mod settings that players can change from within the game.
	/// Config is only editable from players in main menu.
	/// Only one config can exist per mod assembly.
	/// Config is serialized on disk as json.
	/// </summary>
	public class BetterEnemiesConfig : ModConfig
	{
		//
		[ConfigField(text: "Same Turn Mind Control",
		description: "Mind Controlled Units Can Be Used The Same Turn They Are Mind Controlled, They No Longer Will Have To Wait 1 Turn")]
		public bool SameTurnMindControl = false;
		[ConfigField(text: "Double The Time AI Can Think",
		description: "Doubles The Maximum Time AI Has To Evaluate And Execute Actions")]
		public bool DoubleTheTimeAICanThink = false;
		[ConfigField(text: "Allow Adjusting Of Human Perception",
		description: "If Off Changes To Human Perception Will Not Apply")]
		public bool AdjustHumanPerception = true;
		[ConfigField(text: "Adjust Human Perception Amount",
		description: "Vanilla is 35")]
		public float Human_Soldier_Perception = 30;
	}
}
