using UnityEngine;
using Assets.Scripts.Tower_Scripts.Base;
using Object = UnityEngine.Object;

namespace Assets.Scripts.Tower_Scripts
{
    public class BallisticShoot : IShoot
    {
		private Tower tower;
		private Vector3 towerPos;
		private PreemtivePredict predict;
		private Transform m_shootPoint;
		private bool TargetTracking;
		private float AngleInDegrees;
		private Vector3 _toPos;

		public BallisticShoot(Tower tower, Vector3 towerPos, PreemtivePredict predict, Transform m_shootPoint, bool targetTracking, float angleInDegrees, Vector3 _toPos)
        {
            this.tower = tower;
            this.towerPos = towerPos;
            this.predict = predict;
            this.m_shootPoint = m_shootPoint;
            TargetTracking = targetTracking;
            AngleInDegrees = angleInDegrees;
			this._toPos = _toPos;
        }

        public void Shoot()
        {
			if (tower.m_projectilePrefab.name == "BallisticProjectile")
			{
				transformCannon();
				foreach (var monster in Spawner.monsters)
				{
					if (Vector3.Distance(towerPos, monster.transform.position) > tower.m_range)
						continue;

					if (TargetTracking)
						tower._toPos = predict.PredictPreemtive(m_shootPoint, monster, tower.BallisticSpeed);

					if (!tower.canShoot)
						continue;

					if (!TargetTracking)
						tower._toPos = predict.PredictPreemtive(m_shootPoint, monster, tower.BallisticSpeed);

					tower.Rotate();

					var newBullet = Object.Instantiate(tower.m_projectilePrefab, m_shootPoint.position, Quaternion.identity);
					tower.BallisticSpeed = newBullet.GetComponent<BallisticProjectile>().CalculateSpeed(AngleInDegrees, m_shootPoint, _toPos);
					newBullet.GetComponent<Rigidbody>().velocity = m_shootPoint.forward * tower.BallisticSpeed;
					newBullet.GetComponent<BallisticProjectile>().ProjectileBeh();

					tower.m_lastShotTime = Time.time;
				}
			}
		}
		private void transformCannon()
        {
			GameObject cannonhub = GameObject.Find("Cannon_Hub_L2");
			var cannon = cannonhub.transform.GetChild(0).gameObject;
			cannon.transform.localEulerAngles = new Vector3(-AngleInDegrees, 0f, 0f);
			m_shootPoint.localEulerAngles = new Vector3(-AngleInDegrees, 0f, 0f);
		}
    }
}