using UnityEngine;

public class PreemtivePredict : MonoBehaviour
{
    Vector3 m_targetPos;
	Vector3 PreemtivePos;
	float distanceFromTowerToMonster;
	private Vector3 GizmosPos;
	
    public Vector3 PredictPreemtive(Transform shootPoint, Monster monster, float speed)
	{
		m_targetPos = monster.transform.position;
		PreemtivePos = monster.transform.position;
		distanceFromTowerToMonster = Vector3.Distance(shootPoint.position, m_targetPos);
		PreemtivePos.x = m_targetPos.x - monster.m_speed * distanceFromTowerToMonster / speed;
		GizmosPos = PreemtivePos;

		return GizmosPos;
	}
}
