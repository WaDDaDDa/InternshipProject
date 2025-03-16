using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfoType
    {
        Exp,
        Level,
        kill,
        Time,
        Health
    }
    private HealthSystem healthSystem;

    public InfoType type;
    Text myText;
    Slider mySlider;

    private void Awake()
    {
        myText = GetComponent<Text>();
        mySlider = GetComponent<Slider>();

    }

    private void Start()
    {
        healthSystem = GetComponent<HealthSystem>();

        if (healthSystem == null)
        {
            healthSystem = GetComponentInParent<HealthSystem>(); // 부모에서 찾아보기
        }

        if (healthSystem == null)
        {
            Debug.LogError($"{gameObject.name}에서 HealthSystem을 찾을 수 없습니다!", this);
        }
    }

    private void LateUpdate()
    {
        switch (type)
        {
            case InfoType.Exp:
                break;
            case InfoType.Level:
                break;
            case InfoType.kill:
                break;
            case InfoType.Time:
                break;
            case InfoType.Health:
                float curHealth = healthSystem.currentHealth;
                float maxHealth = healthSystem.maxHealth;
                mySlider.value = curHealth / maxHealth;
                break;
            default:
                break;
        }
    }
}
