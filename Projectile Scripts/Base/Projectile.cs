using UnityEngine;

namespace Assets.Scripts.Projectile_Scripts
{
    public abstract class Projectile : MonoBehaviour
    {
        [SerializeField] protected int m_damage = 10;

		void OnTriggerEnter(Collider other)
		{
			var monster = other.gameObject.GetComponent<Monster>();
			if (monster == null)
				return;

			monster.m_hp -= m_damage;
			if (monster.m_hp <= 0)
			{
				Spawner.monsters.Remove(monster);
				Destroy(monster.gameObject);
			}
			Destroy(gameObject);
			Debug.Log("Hit!!!!");
		}

		public abstract void ProjectileBeh();
	}
}