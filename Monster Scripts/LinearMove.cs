using UnityEngine;
using Assets.Scripts.Monster_Scripts.Base;
using Object = UnityEngine.Object;

namespace Assets.Scripts.Monster_Scripts
{
    public class LinearMove : IMove
    {
        private GameObject m_monster;
        private GameObject m_moveTarget;
        private float m_speed;
        private readonly float m_reachDistance;
       
        public LinearMove(GameObject monster, GameObject moveTarget, float speed, float reachDistance)
        {
            m_moveTarget = moveTarget;
            m_speed = speed;
            m_reachDistance = reachDistance;
            m_monster = monster;
        }

        public void Move()
        {
            if (m_moveTarget == null)
                return;

            if (Vector3.Distance(m_monster.transform.position, m_moveTarget.transform.position) <= m_reachDistance)
            {
                Spawner.monsters.Remove(m_monster.GetComponent<Monster>());
                Object.Destroy(m_monster);
                return;
            }

            var translation = m_moveTarget.transform.position - m_monster.transform.position;
            if (translation.magnitude > m_speed)
            {
                translation = translation.normalized * m_speed;
            }
            m_monster.transform.Translate(translation);
        }
    }
}