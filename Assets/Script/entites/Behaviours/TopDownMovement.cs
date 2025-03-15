using System;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private TopDownController controller;
    private CharacterStatHandler characterStatHandler;
    private Rigidbody2D movementRigidbody;

    private Vector2 movemnetDirection = Vector2.zero;

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
    }

    private void ApplyMovemnet(Vector2 direction)
    {
        direction = direction * characterStatHandler.CurrentStat.speed;
        movementRigidbody.linearVelocity = direction;
    }
}
