using UnityEngine;
using Assets.Scripts.Projectile_Scripts;
public class GuidedProjectile : Projectile {

	public GameObject m_target;
	public float m_speed = 0.2f;

	void FixedUpdate () {
		ProjectileBeh();
	}
	public override void ProjectileBeh()
    {
		if (m_target == null)
		{
			Destroy(gameObject);
			return;
		}

		var translation = m_target.transform.position - transform.position;
		if (translation.magnitude > m_speed)
		{
			translation = translation.normalized * m_speed;
		}
		transform.Translate(translation);
	}

}
