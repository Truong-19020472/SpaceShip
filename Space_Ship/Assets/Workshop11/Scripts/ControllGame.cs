using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllGame : MonoBehaviour
{
    public Dictionary<int, EnOrHero>  enemies= new Dictionary<int, EnOrHero>();
    public Dictionary<int, EnOrHero> heroes = new Dictionary<int, EnOrHero>();
    //public GameObject enemyPrefabs;
    //public GameObject hero;
    public GameObject fortress;
    /*// Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateEnemy());
    }

    IEnumerator CreateEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            GameObject newHero = SimplePool.Spawn(hero);
            newHero.transform.position = fortress.transform.position;
            GameObject newEnemy = SimplePool.Spawn(enemyPrefabs);
            newEnemy.transform.position = new Vector3(Random.Range(0, 9.0f), Random.Range(0, 9.0f), 0);
        }
    }*/
    [SerializeField] private EnOrHero mobPrefab;
    EnOrHero tempMob;
    
    private void Start()
    {
        StartCoroutine(AutoSpawnMobs());
    }
    IEnumerator AutoSpawnMobs()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            SpawnEnemies();
            SpawnHeroes();
        }
    }


    int currentMobIndex = 0;
    private void SpawnEnemies()
    {
        tempMob = SimplePool.Spawn(mobPrefab);
        currentMobIndex++;
        tempMob.SetData(currentMobIndex, true, this);
        tempMob.transform.position = new Vector3(Random.Range(0, 6f), Random.Range(-4.1f, 4.1f), 0);
        enemies.Add(currentMobIndex, tempMob);

        tempMob.name = "Mob_Enemy";
        Debug.Log(enemies[currentMobIndex].mobIndex);
    }
    private void SpawnHeroes()
    {
        tempMob = SimplePool.Spawn(mobPrefab);
        currentMobIndex++;
        tempMob.SetData(currentMobIndex, false, this);
        tempMob.transform.position = fortress.transform.position;
        heroes.Add(currentMobIndex, tempMob);
        tempMob.name = "Mob_Ally";
    }
}
