using UnityEngine;
using Object = UnityEngine.Object;
using Assets.Scripts.Tower_Scripts.Base;

namespace Assets.Scripts.Tower_Scripts
{
    public class CannonShoot : IShoot
    {
		private Tower tower;
		private Vector3 towerPos;
		private PreemtivePredict predict;
        private Transform m_shootPoint;
        private bool TargetTracking;

        public CannonShoot(Tower tower, Vector3 towerPos, PreemtivePredict predict, Transform m_shootPoint, bool targetTracking)
        {
            this.tower = tower;
            this.towerPos = towerPos;
            this.predict = predict;
            this.m_shootPoint = m_shootPoint;
            TargetTracking = targetTracking;
        }
        public void Shoot()
        {
			if (tower.m_projectilePrefab.name == "CannonProjectile")
			{
				foreach (var monster in Spawner.monsters)
				{
					if (Vector3.Distance(towerPos, monster.transform.position) > tower.m_range)
						continue;

					if (TargetTracking)
						tower._toPos = predict.PredictPreemtive(m_shootPoint, monster, tower.m_projectilePrefab.GetComponent<CannonProjectile>().m_speed);

					if (!tower.canShoot)
						continue;

					if (!TargetTracking)
						tower._toPos = predict.PredictPreemtive(m_shootPoint, monster, tower.m_projectilePrefab.GetComponent<CannonProjectile>().m_speed);

					tower.Rotate();

                    // shot
                    Object.Instantiate(tower.m_projectilePrefab, m_shootPoint.position, m_shootPoint.rotation);

					tower.m_lastShotTime = Time.time;
				}
			}
		}
    }
}