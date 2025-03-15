using System;
using UnityEngine;

public class TopDownController : MonoBehaviour
{

    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action<AttackSO> OnAttackEvent;

    protected bool IsAttacking { get; set; }
    private float timeSinceLastAttack = float.MaxValue;
    private Rigidbody2D rb;
    protected CharacterStatHandler stats {get; private set;}

    virtual protected void Awake()
    {
        stats = GetComponent<CharacterStatHandler>();
        rb = GetComponent<Rigidbody2D>();
    }

private void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        if (rb == null || rb.linearVelocity.magnitude > 0)
        {
            return;
        }

        if (timeSinceLastAttack <= stats.CurrentStat.attackSO.delay)
        {
            timeSinceLastAttack += Time.deltaTime;
        }
        else if (timeSinceLastAttack > stats.CurrentStat.attackSO.delay)
        {
            timeSinceLastAttack = 0f;
            CallAttackEvent(stats.CurrentStat.attackSO);
        }
        
    }


    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }
    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
    private void CallAttackEvent(AttackSO attackSO)
    {
        OnAttackEvent?.Invoke(attackSO);
    }
}
