using EXILED.ApiObjects;
using EXILED.Extensions;
using MEC;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Ragdolls
{
	public class EventHandlers
	{
		public Plugin plugin;
		public EventHandlers(Plugin plugin) => this.plugin = plugin;

		public System.Random random = new System.Random();
		public ReferenceHub hub = new ReferenceHub();

		public void OnRoundStart()
		{
			Timing.RunCoroutine(RoundStartHandle());
		}

		public IEnumerator<float> RoundStartHandle()
		{
			yield return Timing.WaitForSeconds(2f);
			List<ReferenceHub> players = Player.GetHubs(RoleType.ClassD).ToList();
			for (int i = 0; i < 1; i++)
			{
				hub = players[i];
			}

			foreach (Room room in Map.Rooms)
			{
				if (random.Next(100) < 15)
				{
					SpawnBodies(room.Position, GetRandRole(random.Next(2)), DamageTypes.None, "a Site Personnel");
				}
			}

			//staff time
			SpawnBodies(new Vector3(53.5f, 1019.5f, -44f), 4, DamageTypes.Grenade, "Build");
			SpawnBodies(new Vector3(49.5f, 1019.5f, -44f), 6, DamageTypes.Scp096, "Dexter908");
			SpawnBodies(new Vector3(49.5f, 1019.5f, -48f), 1, DamageTypes.Scp173, "HMS ");
			SpawnBodies(new Vector3(49.5f, 1019.5f, -40f), 12, DamageTypes.Scp173, "Zingen");
			SpawnBodies(new Vector3(53.5f, 1019.5f, -48f), 8, DamageTypes.Lure, "Puppet");
			SpawnBodies(new Vector3(57.5f, 1019.5f, -48f), 8, DamageTypes.Grenade, "Santy");
			SpawnBodies(new Vector3(57.5f, 1019.5f, -44f), 12, DamageTypes.Scp939, "Zippy");
			SpawnBodies(new Vector3(57.5f, 1019.5f, -40f), 6, DamageTypes.Grenade, "Fuzz");
			SpawnBodies(new Vector3(53.5f, 1019.5f, -40f), 1, DamageTypes.E11StandardRifle, "Eli");
		}

		public void SpawnBodies(Vector3 location, int role, DamageTypes.DamageType type, string name)
		{
			hub.gameObject.GetComponent<RagdollManager>().SpawnRagdoll(location + Vector3.up * 5f, Quaternion.identity, Vector3.zero, role, new PlayerStats.HitInfo(1000f, hub.characterClassManager.UserId, type, hub.queryProcessor.PlayerId), false, name, name, 0);
		}

		public int GetRandRole(int rand)
		{
			int role = rand == 1 ? 6 : 15;
			return role;
		}
	}
}