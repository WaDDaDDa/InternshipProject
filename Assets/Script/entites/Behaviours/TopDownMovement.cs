using System;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private TopDownController controller;
    private CharacterStatHandler characterStatHandler;
    private Rigidbody2D movementRigidbody;

    private Vector2 movemnetDirection = Vector2.zero;
    private Vector2 knockBack = Vector2.zero;
    private float knockBackDuration = 0.0f;

    private void Awake()
    {
        controller = GetComponent<TopDownController>();
        movementRigidbody = GetComponent<Rigidbody2D>();
        characterStatHandler = GetComponent<CharacterStatHandler>();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 direction)
    {
        movemnetDirection = direction;
    }

    private void FixedUpdate()
    {
        ApplyMovemnet(movemnetDirection);
        if(knockBackDuration > 0.0f)
        {
            knockBackDuration -= Time.fixedDeltaTime;
        }
    }
    public void ApplyKnockBack(Transform other, float power, float duration)
    {
        knockBackDuration = duration;
        knockBack = -(other.position - transform.position).normalized * power;
    }

    private void ApplyMovemnet(Vector2 direction)
    {
        direction = direction * characterStatHandler.CurrentStat.speed;

        if (knockBackDuration > 0.0f)
        {
            direction *= knockBack;
        }

        movementRigidbody.linearVelocity = direction;
    }

}
