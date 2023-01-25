using UnityEngine;
using UnityEditor;
using Assets.Scripts;
using Assets.Scripts.Tower_Scripts;

public class CannonTower : Tower {

    public enum TowerType
    {
        cannonTower,
        BallisticTower
    }

    public TowerType m_towerType;
	public Transform m_shootPoint;
	public bool TargetTracking = false;
	public float rotationSpeed;
	public float AngleInDegrees = 0f;

	private PreemtivePredict predict;
	private CannonTower tower;

	private void Start()
    {
		tower = GetComponent<CannonTower>();
        predict = GetComponent<PreemtivePredict>();
		InitBeh();
	}
	protected override void InitBeh()
	{
		if(m_towerType == TowerType.cannonTower)
			SetShootBeh(new CannonShoot(tower, transform.position, predict, m_shootPoint, TargetTracking));
		else
			SetShootBeh(new BallisticShoot(tower, transform.position, predict, m_shootPoint, TargetTracking, AngleInDegrees, _toPos));
		SetRotateBeh(new TowerRotation(gameObject, tower, rotationSpeed));
	}

	void FixedUpdate ()
	{
		if (m_projectilePrefab != null || m_shootPoint != null)
		{
			Shoot();
		}
	}

    private void OnDrawGizmos()
	{
		Handles.color = Color.green;
		Handles.DrawWireDisc(transform.position.Set(y: 0), new Vector3(0, 1, 0), m_range);
		Gizmos.color = Color.red;
		Gizmos.DrawLine(m_shootPoint.position, _toPos);
		Gizmos.DrawWireSphere(_toPos, 1f);
	}
}
