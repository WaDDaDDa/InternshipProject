using System.Threading;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Follow: MonoBehaviour
{
    public RectTransform rect;
    public HealthSystem healthSystem;
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        healthSystem = GetComponentInParent<HealthSystem>();
        if (healthSystem != null)
        {
            Vector2 parentPosition = healthSystem.transform.position;
            rect.position = Camera.main.WorldToScreenPoint(parentPosition);
        }
    }

    private void FixedUpdate()
    {
        if (healthSystem != null)
        {
            Vector2 parentPosition = healthSystem.transform.position;
            rect.position = Camera.main.WorldToScreenPoint(parentPosition);
        }
    }
    private void OnEnable()
    {
        //rect.position = Camera.main.WorldToScreenPoint(transform.root.position);
        //Debug.Log("호출");
        //Debug.Log(transform.root);
    }
    public void SetPosition(Vector2 position)
    {
        rect.position = Camera.main.WorldToScreenPoint(position);
    }
}