using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnEnemy : MonoBehaviour
{
    #region SpawnerStats
    #region SerializedFields


    //List of different enemies the spawner can choose to spawn.
    [SerializeField] private List<GameObject> enemies = null;

    #endregion

    #region Other

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
         int enemyCount = UnityEngine.Random.Range(1, 4);
        //int enemyCount = 3;
        GameObject enemyClone = null;

        for (int i = 0; i < enemyCount; i++)
        {
            enemyClone = Instantiate(enemies[0].gameObject, new Vector3(0, 0, 0), Quaternion.identity);
            enemyClone.transform.SetParent(gameObject.transform, false);
            //Adds the enemy to spawned enemies list
            spawnedEnemies.Add(enemyClone);
        }

    }
    #endregion
}
