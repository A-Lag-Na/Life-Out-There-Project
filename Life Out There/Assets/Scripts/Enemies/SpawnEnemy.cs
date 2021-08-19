using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

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
    private List<Enemy> enemiesClone;
    private int pointsClone;
  

    //Tracks number of externally spawned enemies
    public int remainingChildren;

    //List of enemies spawned by the spawner.
    public List<GameObject> spawnedEnemies;
    #endregion
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        switch (roomType)
        {
            case "MinorEnemy":
               
                break;
            case "EliteEnemy":
               
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

    // Update is called once per frame
    void Update()
    {
        
    }
    #region Getters and Setters 
    public void SetRoomType(Map.NodeType nodeType)
    {
        switch (nodeType)
        {
            case Map.NodeType.MinorEnemy:
                roomType = "MinorEnemy";
                break;
            case Map.NodeType.EliteEnemy:
                roomType = "EliteEnemy";
                break;
            case Map.NodeType.RestSite:
                roomType = "RestSite";
                break;
            case Map.NodeType.Treasure:
                roomType = "Treasure";
                break;
            case Map.NodeType.Store:
                roomType = "Store";
                break;
            case Map.NodeType.Boss:
                roomType = "Boss";
                break;
            case Map.NodeType.Mystery:
                roomType = "Mystery";
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
            enemyClone = Instantiate(enemiesClone[enemyCount].gameObject, transform.position, Quaternion.identity);
            //Adds the enemy to spawned enemies list
            spawnedEnemies.Add(enemyClone);
        }

    }
    #endregion
}
