using UnityEngine;
using Assets.Scripts;
using Assets.Scripts.Projectile_Scripts;
public class CannonProjectile : Projectile
{
	public float m_speed = 0.5f;

	private CannonTower Tower;
	private float elapsedTime;
	private Vector3 centerPoint;
	private Vector3 startRelCenter;
	private Vector3 endRelCenter;

	private void Start()
	{
		Tower = GameObject.Find("Cannon_L2").GetComponent<CannonTower>();
	}

	void FixedUpdate() {
		ProjectileBeh();
	}

	public override void ProjectileBeh()
	{
		if (Tower == null || Tower.m_towerType != CannonTower.TowerType.cannonTower)
			return;

        GetCenter(Vector3.up);

		var _Time = ((Tower.m_shootPoint.transform.position - Tower._toPos).Set(y: 0).magnitude / m_speed) * Time.fixedDeltaTime;
        elapsedTime += Time.fixedDeltaTime;
        var prc = elapsedTime / _Time;
        transform.position = Vector3.Slerp(startRelCenter, endRelCenter, prc);
        transform.position += centerPoint;
        Destroy(gameObject, 0.5f);
    }

	private void GetCenter(Vector3 direction)
    {
		centerPoint = (Tower.m_shootPoint.transform.position + Tower._toPos) * 0.5f;
		centerPoint -= direction;
		centerPoint.y = -4.5f;
        startRelCenter = Tower.m_shootPoint.transform.position - centerPoint;
		endRelCenter = Tower._toPos - centerPoint;
	}
}
