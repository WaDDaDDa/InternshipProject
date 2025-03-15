using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public string monsterID = "M0001";

    void Start()
    {
        MonsterSO monster = Resources.Load<MonsterSO>($"Monsters/{monsterID}");
        if (monster != null)
        {
            Debug.Log($"몬스터 {monster.Name} 소환됨! HP: {monster.MaxHP}");
        }
        else
        {
            Debug.LogError("몬스터 데이터를 찾을 수 없습니다!");
        }
    }
}
