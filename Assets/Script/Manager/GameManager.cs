using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private string playerTag;

    public ObjectPool objectPool {  get; private set; }
    public Transform player { get; private set; }
    private float spawnDelay = 1.0f;

    private void Awake()
    {
        if(instance != null) Destroy(gameObject);
        instance = this;

        player = GameObject.FindGameObjectWithTag(playerTag).transform;
        objectPool = GetComponent<ObjectPool>();
    }

    private void Update()
    {
        spawnDelay -= Time.deltaTime;
        if(spawnDelay <= 0)
        {
            GameObject obj = instance.objectPool.SpawnFromPoolMonster("Skeleton");
            spawnDelay = 2.0f;
        }
    }

}
