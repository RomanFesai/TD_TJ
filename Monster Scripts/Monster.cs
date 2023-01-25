using UnityEngine;
using Assets.Scripts.Monster_Scripts.Base;
using Assets.Scripts.Monster_Scripts;

public class Monster : Enemy {

	public GameObject m_moveTarget;
	public float m_speed = 0.1f;
	public int m_maxHP = 30;
	const float m_reachDistance = 0.3f;
	public int m_hp;

	void Start() {
		m_hp = m_maxHP;
		InitMoveBeh();
	}
    protected override void InitMoveBeh()
    {
		SetMoveBeh(new LinearMove(gameObject, m_moveTarget, m_speed, m_reachDistance));
    }

    void FixedUpdate () 
	{
		Move();
	}
}
