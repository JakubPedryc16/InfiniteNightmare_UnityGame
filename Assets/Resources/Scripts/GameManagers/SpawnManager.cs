using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float timeAfterWave;

    public int waveNum = 0;
    int enemyToSpawn;
    int enemiesLeft;
    float _cooldown;

    [System.Serializable]
    public class EnemyKinds
    {
        public int type = 0;
        public float spawnChance = 0f;
    }

    [System.Serializable]
    public class Wave
    {
        public EnemyKinds[] enemies;
        public int amount = 0;
        public float cooldown = 0f;
        public bool bossWave = false;
        public int bossType;
    }

    public Wave[] waves;

    void Start()
    {
        enemiesLeft = waves[waveNum].amount;
    }

    void Update()
    {


        _cooldown -= Time.deltaTime;


        if (waveNum + 1 <= waves.Length)
        {
            if (waves[waveNum].bossWave == false)
            {
                if (_cooldown <= 0f && enemiesLeft > 0 && waves[waveNum].bossWave == false)
                {
                    float x = 0;
                    float chance = Random.Range(1, 101);
                    for (int i = 0; i < waves[waveNum].enemies.Length; i++)
                    {
                        x += waves[waveNum].enemies[i].spawnChance;
                        if (chance <= x)
                        {
                            enemyToSpawn = waves[waveNum].enemies[i].type;
                            break;
                        }
                    }


                    float position = Random.Range(-5.2f, 5.2f);
                    GameObject enemy = UnityEngine.Resources.Load<GameObject>("Prefabs/Enemies/Enemy" + enemyToSpawn);
                    enemy.transform.position = new Vector3(10.36f, position);
                    Instantiate(enemy);
                    enemiesLeft--;
                    _cooldown = waves[waveNum].cooldown;
                }
            }

            else if (enemiesLeft > 0 && _cooldown <= 0f)
            {

                float position = Random.Range(-3.9f, 3.9f);
                GameObject boss = UnityEngine.Resources.Load<GameObject>("Prefabs/Bosses/Boss" + waves[waveNum].bossType);
                boss.transform.position = new Vector3(8.7f, position);
                Instantiate(boss);
                enemiesLeft--;
            }
            if (enemiesLeft <= 0)
            {
                GameObject[] enemiesLeftOnBoard;
                GameObject[] bossesOnTheBoard;
                enemiesLeftOnBoard = GameObject.FindGameObjectsWithTag("enemy");
                bossesOnTheBoard = GameObject.FindGameObjectsWithTag("boss");

                if (enemiesLeftOnBoard.Length == 0 && bossesOnTheBoard.Length == 0)
                {

                    if (waveNum + 1 >=  waves.Length)
                    {
                        GameObject.Find("GameMaster").GetComponent<GameMaster>().YouWin();
                    }
                    else if (waveNum + 1 < waves.Length)   
                    {
                        waveNum++;
                        enemiesLeft = waves[waveNum].amount;
                    }

                }
            }
        }
    }
}
