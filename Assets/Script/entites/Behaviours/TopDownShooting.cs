using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Random = UnityEngine.Random;

public class TopDownShooting : MonoBehaviour
{
    private TopDownController controller;

    [SerializeField] private Transform projectileSpawnPosition;
    private Vector2 aimDirection = Vector2.right;

    public GameObject tsetPrefab;

    private void Awake()
    {
        controller = GetComponent<TopDownController>();
    }

    private void Start()
    {
        controller.OnAttackEvent += OnShoot;
        controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 direction)
    {
        aimDirection = direction;
    }

    private void OnShoot(AttackSO attackSO)
    {
        RangedAttackSO rangedAttackSO = attackSO as RangedAttackSO;
        float projectilesAngleSpace = rangedAttackSO.multipleProjectilesAngle;
        int numberOfProjectilesPerShot = rangedAttackSO.numberofProjectilesPerShot;

        float minAngle = -(numberOfProjectilesPerShot / 2f) * projectilesAngleSpace + 0.5f * rangedAttackSO.multipleProjectilesAngle;
        for (int i = 0; i < numberOfProjectilesPerShot; i++)
        {
            float angle = minAngle + projectilesAngleSpace * i;
            float randomSpread = Random.Range(-rangedAttackSO.spread, rangedAttackSO.spread);
            angle += randomSpread;
            CreateProjectile(rangedAttackSO, angle);
        }
    }

    private void CreateProjectile(RangedAttackSO rangedAttackSO, float angle)
    {
        GameObject obj = Instantiate(tsetPrefab);
        obj.transform.position = projectileSpawnPosition.position;
        ProjectileController attackController = obj.GetComponent<ProjectileController>();
        attackController.InitializeAttack(RotateVector2(aimDirection, angle), rangedAttackSO);
    }

    private static Vector2 RotateVector2(Vector2 vector, float angle)
    {
        return Quaternion.Euler(0f, 0f, angle) * vector;
    }
}
