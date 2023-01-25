using UnityEngine;
using Assets.Scripts.Projectile_Scripts;
public class BallisticProjectile : Projectile
{
	private readonly float g = Physics.gravity.y;
	public float CalculateSpeed(float AngleInDegrees, Transform m_shootPoint, Vector3 _toPos)
    {
		Vector3 fromTo = m_shootPoint.transform.position - _toPos;
		Vector3 fromToXZ = new Vector3(fromTo.x, 0f, fromTo.z);

		float x = fromToXZ.magnitude;
		float y = fromTo.y;

		float AngleInRadians = AngleInDegrees * Mathf.PI / 180;

		return Mathf.Sqrt(Mathf.Abs((g * x * x) / (2 * (y - Mathf.Tan(AngleInRadians) * x) * Mathf.Pow(Mathf.Cos(AngleInRadians), 2))));
	}

    public override void ProjectileBeh()
    {
		Destroy(gameObject, 5f);
	}
}
