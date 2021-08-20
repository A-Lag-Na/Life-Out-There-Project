using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnEnemy : MonoBehaviour
{
    #region SpawnerStats
    #region SerializedFields

    //Whether the spawner can spawn or not.
    [SerializeField] private bool spawnEnabled = true;
    [SerializeField] GameObject spawnpoint;
    [SerializeField] string roomType;
    [SerializeField] private bool isAreaCleared = false;
    public bool clearCheck = false;

    //List of different enemies the spawner can choose to spawn.
    [SerializeField] private List<GameObject> enemies = null;

    #endregion

    #region Other


    //Tracks number of externally spawned enemies
    public int remainingChildren;

    //List of enemies spawned by the spawner.
    public List<GameObject> spawnedEnemies;
    #endregion
    #endregion

    void Awake()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        SetRoomType(sceneName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region Getters and Setters 
    public void SetRoomType(string roomType)
    {

        switch (roomType)
        {
            case "Minor Enemy":
                RunMinorEnemyRoom();
                break;
            case "Elite Enemy":

                break;
            case "RestSite":

                break;
            case "Treasure":

                break;
            case "Store":

                break;
            case "Boss":

                break;
            case "Mystery":

                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    public List<GameObject> GetSpawnedEnemies()
    {
        return spawnedEnemies;
    }
    #endregion
    #region Room Functions
    public void RunMinorEnemyRoom()
    {
        int enemyCount = UnityEngine.Random.Range(1, 3);
        GameObject enemyClone = null;

        for (int i = 0; i < enemyCount; i++)
        {
            enemyClone = Instantiate(enemies[0].gameObject, transform.position, Quaternion.identity);
            enemyClone.transform.parent = gameObject.transform;
            //Adds the enemy to spawned enemies list
            spawnedEnemies.Add(enemyClone);
        }

    }
    #endregion
}
