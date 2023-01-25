using UnityEngine;
using Assets.Scripts.Tower_Scripts.Base;

namespace Assets.Scripts.Tower_Scripts
{
    public abstract class Tower : MonoBehaviour
    {
		[Header("Tower Parameters")]
		public GameObject m_projectilePrefab;
		public float m_shootInterval = 0.5f;
		public float m_range = 10f;
		[HideInInspector]
		public float m_lastShotTime = -0.5f;
		public bool canShoot => m_lastShotTime + m_shootInterval < Time.time;
		[HideInInspector]
		public float BallisticSpeed = 1f;
        private Coroutine coroutine;
        [HideInInspector]
        public Vector3 _toPos;

        [HideInInspector]
        public Vector3 rotPos;

        protected IShoot _shoot;
        protected IRotate _rotate;
        protected abstract void InitBeh();

        public void SetShootBeh(IShoot shoot)
        {
            _shoot = shoot;
        }

        public void SetRotateBeh(IRotate rotate)
        {
            _rotate = rotate;
        } 

        public void Shoot()
        {
            _shoot.Shoot();
        }

        public void Rotate()
        {
            if (coroutine != null)
                StopCoroutine(coroutine);
            coroutine = StartCoroutine(_rotate.Rotate());
        }
    }
}