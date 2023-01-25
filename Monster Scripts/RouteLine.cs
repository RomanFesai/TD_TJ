using UnityEngine;

namespace Assets.Scripts
{
    public class RouteLine : MonoBehaviour
    {
        [SerializeField] private Spawner spawner;
        [SerializeField] private Transform destroyer;

        private Vector3 startPos;
        private Vector3 endPos;

        protected void Awake() => Recalculate();
        private void OnValidate() => Recalculate();

        private void Recalculate()
        {
            startPos = spawner.transform.position;
            endPos = destroyer.position;
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(startPos.Set(y: 0), endPos.Set(y: 0));
        }
    }
}