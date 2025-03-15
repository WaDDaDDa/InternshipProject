using Unity.VisualScripting;
using UnityEngine;

public class TopDownEnemyController : TopDownController
{
    protected Transform ClosetTarget { get; private set; }

    protected override void Awake()
    {
        base.Awake();
    }

    protected virtual void Start()
    {
        ClosetTarget = GameManager.instance.player;
    }

    protected virtual void FixedUpdate()
    {

    }

    protected float DistanceToTarget()
    {
        return Vector3.Distance(transform.position, ClosetTarget.position);
    }

    protected Vector2 DirectionToTarget()
    {
        return (ClosetTarget.position - transform.position).normalized;
    }
}
