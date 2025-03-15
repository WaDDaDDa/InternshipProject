using UnityEngine;

[CreateAssetMenu(fileName = "MonsterSO", menuName = "GameData/Monster")]
public class MonsterSO : ScriptableObject
{
    public string MonsterID;
    public string Name;
    public string Description;
    public int Attack;
    public float AttackMul;
    public int MaxHP;
    public float MaxHPMul;
    public int AttackRange;
    public float AttackRangeMul;
    public float AttackSpeed;
    public float MoveSpeed;
    public int MinExp;
    public int MaxExp;
    public string DropItem;
}
