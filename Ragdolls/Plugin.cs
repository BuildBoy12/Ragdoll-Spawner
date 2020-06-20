using System;
using EXILED;
using System.IO;
using System.Text;

namespace Ragdolls
{
	public class Plugin : EXILED.Plugin
	{
		public EventHandlers EventHandlers;

		public static string PluginDirectory;

		public override void OnEnable()
		{
			string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			PluginDirectory = Path.Combine(appData, "Plugins", "RagdollSpawner");
			if (!Directory.Exists(PluginDirectory))
				Directory.CreateDirectory(PluginDirectory);
			//if (!File.Exists(Path.Combine(PluginDirectory, "config.yml")))
				//File.WriteAllText(Path.Combine(PluginDirectory, "config.yml"), Encoding.UTF8.GetString(Resources.config));

			EventHandlers = new EventHandlers(this);
			
			Events.RoundStartEvent += EventHandlers.OnRoundStart;

			Log.Info($"Ragdoll Spawner Loaded.");
		}

		public override void OnDisable()
		{
			Events.RoundStartEvent -= EventHandlers.OnRoundStart;
			
			EventHandlers = null;
		}

		public override void OnReload()
		{
			
		}

		public override string getName { get; } = "RagdollSpawner";
	}
}