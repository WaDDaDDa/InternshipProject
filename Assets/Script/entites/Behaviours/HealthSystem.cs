using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float healthChangeDelay = 0.2f;

    private CharacterStatHandler statHandler;
    private float timeSinceLastChange = float.MaxValue;
    private bool isAttacked = false;

    public event Action OnDamage;
    public event Action OnHeal;
    public event Action OnDeath;
    public event Action OnInvincibilityEnd;

    public float currentHealth { get; private set; }
    public float maxHealth => statHandler.CurrentStat.maxHealth;

    private void Awake()
    {
        statHandler = GetComponent<CharacterStatHandler>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (isAttacked && timeSinceLastChange < healthChangeDelay)
        {
            timeSinceLastChange += Time.deltaTime;
            if (timeSinceLastChange > healthChangeDelay) 
            { 
                OnInvincibilityEnd?.Invoke();
                isAttacked = false;
            }
        }
    }

    public bool ChangeHealth(float change)
    {
        if (timeSinceLastChange < healthChangeDelay)
        {
            return false;
        }

        timeSinceLastChange = 0f;
        currentHealth += change;
        currentHealth = Mathf.Clamp(currentHealth, 0 ,maxHealth);

        if (currentHealth <= 0)
        {
            CallDeath();
            return true;
        }

        if(change >= 0)
        {
            OnHeal?.Invoke();
        }
        else
        {
            OnDamage?.Invoke();
            isAttacked = true;
        }

        return true;
    }

    private void CallDeath()
    {
        OnDeath?.Invoke();
    }
}
