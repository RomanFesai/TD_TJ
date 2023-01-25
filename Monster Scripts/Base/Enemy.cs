using UnityEngine;

namespace Assets.Scripts.Monster_Scripts.Base
{
    public abstract class Enemy : MonoBehaviour
    {
        protected IMove _move;
        protected abstract void InitMoveBeh();

        public void SetMoveBeh(IMove move)
        {
            _move = move;
        }

        public void Move()
        {
            _move.Move();
        }
    }
}