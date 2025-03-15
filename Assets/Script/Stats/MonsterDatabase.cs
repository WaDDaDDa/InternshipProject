using UnityEngine;
using System.Collections.Generic;

public class MonsterDatabase : MonoBehaviour
{
    public static MonsterDatabase Instance;
    public List<MonsterData> monsters = new List<MonsterData>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            LoadMonsterData();
        }
    }

    private void LoadMonsterData()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("Monster"); // 파일 이름에서 확장자 제외
        if (jsonFile != null)
        {
            MonsterDataList dataList = JsonUtility.FromJson<MonsterDataList>(jsonFile.text);
            monsters = dataList.Monster;
        }
        else
        {
            Debug.LogError("Monster JSON 파일을 찾을 수 없습니다!");
        }
    }

    public MonsterData GetMonsterByID(string id)
    {
        return monsters.Find(m => m.MonsterID == id);
    }
}
