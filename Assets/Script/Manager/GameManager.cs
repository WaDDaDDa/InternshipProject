using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private string playerTag;

    public ObjectPool objectPool {  get; private set; }
    public Transform player { get; private set; }

    private void Awake()
    {
        if(instance != null) Destroy(gameObject);
        instance = this;

        player = GameObject.FindGameObjectWithTag(playerTag).transform;
        objectPool = GetComponent<ObjectPool>();
    }
}
