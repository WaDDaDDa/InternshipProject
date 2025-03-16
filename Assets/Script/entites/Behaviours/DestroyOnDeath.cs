
using System;
using UnityEngine;

public class DestroyOnDeath : MonoBehaviour
{
    private HealthSystem healthSystem;
    private Rigidbody2D rb;

    private void Start()
    {
        healthSystem = GetComponent<HealthSystem>();
        rb = GetComponent<Rigidbody2D>();
        healthSystem.OnDeath += OnDeath;
    }

    private void OnDeath()
    {
        rb.linearVelocity = Vector2.zero;
/*        foreach(SpriteRenderer render in GetComponentsInChildren<SpriteRenderer>())
        {
            Color color = render.color;
            color.a = 0.3f;
            render.color = color;
        }

        foreach(Behaviour behaviour in GetComponentsInChildren<Behaviour>())
        {
            behaviour.enabled = false;
        }*/

        gameObject.SetActive(false);
        healthSystem.ResetHealth();
    }
}
