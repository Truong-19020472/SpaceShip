using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnOrHero : MonoBehaviour
{
    //private GameObject hero;

    /* // Update is called once per frame
     private void Start()
     {
         hero = GameObject.FindGameObjectWithTag("hero");
     }
     void Update()
     {
         FindHero();
     }
     public void FindHero()
     {
         if (Vector3.Distance(transform.position, hero.transform.position) > 5f)
         {
             transform.position = Vector3.Lerp(transform.position, hero.transform.position, Time.deltaTime);
         }
     }*/

    [SerializeField] private SpriteRenderer spriteRenderer;
    public int mobIndex { get; private set; }
    bool isEnemy;
    /*public GameObject prefabEnemy;
    public GameObject prefabHeroes;*/
    ControllGame controller;
    EnOrHero target;
    [SerializeField] private Sprite enemy, ally;
    // Set enemy / ally
    public void SetData(int MobIndex, bool IsEnemy, ControllGame Controller)
    {
        if (IsEnemy)
        {
            spriteRenderer.sprite = enemy;
        }
        else
        {
            spriteRenderer.sprite = ally;
        }
        mobIndex = MobIndex;
        isEnemy = IsEnemy;
        controller = Controller;
        currentHP = healthPoint;
    }

    private void Update()
    {
        if (target != null && target.gameObject.activeSelf == true)
        {
            if (GetSqrDistance(transform, target.transform) > 1)
            {
                AimTarget();
            }
            else
            {
                AttackTarget();
            }
            return;
        }
        SeekTarget();
    }

    private void SeekTarget()
    {
        Debug.Log(mobIndex);
        float sqrDistance = 10000f; // = 100^2
        float minDistance = 10000f;
        int minDistanceIndex = -1; // lưu index của mob gần nhất
        if (isEnemy)
        {
            foreach (var mob in controller.heroes.Values)
            {
                sqrDistance = GetSqrDistance(transform, mob.transform);
                if (minDistance > sqrDistance)
                {
                    minDistance = sqrDistance;
                    minDistanceIndex = mob.mobIndex;
                }
            }
            if (minDistanceIndex > -1)
            {
                target = controller.heroes[minDistanceIndex];
            }
        }
        else
        {
            foreach (var mob in controller.enemies.Values)
            {
                sqrDistance = GetSqrDistance(transform, mob.transform);
                if (minDistance > sqrDistance)
                {
                    minDistance = sqrDistance;
                    minDistanceIndex = mob.mobIndex;
                }
            }
            if (minDistanceIndex > -1)
            {
                target = controller.enemies[minDistanceIndex];
            }
        }
    }

    [Header("Move Stats")]
    [Tooltip("Vận tốc di chuyển của mob khi đuổi theo đối phương")]
    [SerializeField] private float velocity;
    private void AimTarget()
    {
        transform.position += GetDirection(target.transform) * velocity * Time.deltaTime;
    }

    private float attackTimer;
    [SerializeField] private float attackCooldown = 1;
    private void AttackTarget()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackCooldown)
        {
            attackTimer -= attackCooldown;
            target.TakeDamage();
        }
    }

    // trả về square distance giữa 2 object
    private float GetSqrDistance(Transform transformA, Transform transformB)
    {
        return (transformA.position - transformB.position).sqrMagnitude;
    }

    private Vector3 GetDirection(Transform targetTransform)
    {
        return (targetTransform.position - transform.position).normalized;
    }

    [Header("Mob Stats")]
    [SerializeField] private int healthPoint = 100;
    [SerializeField] private int damage = 25;
    private int currentHP;
    public void TakeDamage()
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            SimplePool.Despawn(gameObject);
            if (isEnemy)
            {
                controller.enemies.Remove(mobIndex);
            }
            else
            {
                controller.heroes.Remove(mobIndex);
            }
        }
    }
}
