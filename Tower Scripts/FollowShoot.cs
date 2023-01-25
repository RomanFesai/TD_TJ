using UnityEngine;
using Assets.Scripts.Tower_Scripts.Base;
using Object = UnityEngine.Object;

namespace Assets.Scripts.Tower_Scripts
{
    public class FollowShoot : IShoot
    {
		private Tower tower;
		private Vector3 towerPos;
		public FollowShoot(Tower tower, Vector3 towerPos)
        {
            this.tower = tower;
            this.towerPos = towerPos;
        }
        public void Shoot()
        {
			if (tower.m_projectilePrefab.name == "GuidedProjectile")
			{
				foreach (var monster in Spawner.monsters)
				{
					if (Vector3.Distance(towerPos, monster.transform.position) > tower.m_range)
						continue;

					if (!tower.canShoot)
						continue;

					// shot
					Object.Instantiate(tower.m_projectilePrefab, towerPos + Vector3.up * 1.5f, Quaternion.identity)
						.GetComponent<GuidedProjectile>().m_target = monster.gameObject;

					tower.m_lastShotTime = Time.time;
				}
			}
		}
    }
}