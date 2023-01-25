using System.Collections;
using UnityEngine;
using Assets.Scripts.Tower_Scripts.Base;

namespace Assets.Scripts.Tower_Scripts
{
    public class TowerRotation : IRotate
    {
        public GameObject towerobj;
        public Tower tower;
        public float rotationSpeed;
        public TowerRotation(GameObject towerobj, Tower tower, float rotationSpeed)
        {
            this.towerobj = towerobj;
            this.rotationSpeed = rotationSpeed;
            this.tower = tower;
        }
        public IEnumerator Rotate()
        {
            Quaternion lookRotation = Quaternion.LookRotation(tower._toPos - towerobj.transform.position);

            float time = 0;

            Quaternion initialRotation = towerobj.transform.rotation;
            while (time < 1)
            {
                towerobj.transform.rotation = Quaternion.Slerp(initialRotation, new Quaternion(0f, lookRotation.y, 0f, lookRotation.w), time);

                time += Time.fixedDeltaTime * rotationSpeed;

                yield return null;
            }
        }
    }
}