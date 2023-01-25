using UnityEngine;
using System.Collections.Generic;
public class Spawner : MonoBehaviour {

	public float m_interval = 3;
	private float m_lastSpawn = -1;

	public GameObject m_moveTarget;
	public Monster MonsterPrefab;
	public static List<Monster> monsters = new List<Monster>();

	void FixedUpdate () {
		SpawnMonster();
	}

	void SpawnMonster()
    {
		if (Time.time > m_lastSpawn + m_interval)
		{
			var newMonster = Instantiate(MonsterPrefab, transform.position, Quaternion.identity);
			newMonster.m_moveTarget = m_moveTarget;
			monsters.Add(newMonster);
			m_lastSpawn = Time.time;
		}
	}
}
