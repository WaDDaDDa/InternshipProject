using UnityEngine;
using System.IO;

public class MonsterSOGenerator : MonoBehaviour
{
    [ContextMenu("Generate Monster SOs")]
    public void GenerateMonsterSOs()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("monsterData");
        if (jsonFile == null)
        {
            Debug.LogError("Monster JSON 파일을 찾을 수 없습니다!");
            return;
        }

        MonsterDataList dataList = JsonUtility.FromJson<MonsterDataList>(jsonFile.text);

        foreach (var monster in dataList.Monster)
        {
            MonsterSO monsterSO = ScriptableObject.CreateInstance<MonsterSO>();

            monsterSO.MonsterID = monster.MonsterID;
            monsterSO.Name = monster.Name;
            monsterSO.Description = monster.Description;
            monsterSO.Attack = monster.Attack;
            monsterSO.AttackMul = monster.AttackMul;
            monsterSO.MaxHP = monster.MaxHP;
            monsterSO.MaxHPMul = monster.MaxHPMul;
            monsterSO.AttackRange = monster.AttackRange;
            monsterSO.AttackRangeMul = monster.AttackRangeMul;
            monsterSO.AttackSpeed = monster.AttackSpeed;
            monsterSO.MoveSpeed = monster.MoveSpeed;
            monsterSO.MinExp = monster.MinExp;
            monsterSO.MaxExp = monster.MaxExp;
            monsterSO.DropItem = monster.DropItem;

            string path = $"Assets/Resources/Monsters/{monster.MonsterID}.asset";
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            UnityEditor.AssetDatabase.CreateAsset(monsterSO, path);
        }

        UnityEditor.AssetDatabase.SaveAssets();
        UnityEditor.AssetDatabase.Refresh();

        Debug.Log("Monster ScriptableObjects 생성 완료!");
    }
}
