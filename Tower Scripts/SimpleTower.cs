using UnityEngine;
using UnityEditor;
using Assets.Scripts.Tower_Scripts;
using Assets.Scripts;

public class SimpleTower : Tower
{
    private SimpleTower tower;

    private void Start()
    {
        tower = GetComponent<SimpleTower>();
        InitBeh();
    }
    protected override void InitBeh()
    {
        SetShootBeh(new FollowShoot(tower, gameObject.transform.position));
    }
    private void FixedUpdate()
    {
        _shoot.Shoot();
    }

    private void OnDrawGizmos()
    {
        Handles.color = Color.green;
        Handles.DrawWireDisc(transform.position.Set(y: 0), new Vector3(0, 1, 0), m_range);
    }
}
