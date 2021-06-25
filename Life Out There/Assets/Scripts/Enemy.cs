using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private int enemyHealth = 6;
    public GameObject turnSystem;
    bool isPlayerTurn;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        isPlayerTurn = turnSystem.GetComponent<TurnSystem>().isPlayerTurn;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth > 0)
        {
            if (!isPlayerTurn)
            {
                player.GetComponent<Player>().PlayerTakeDamage(1);
                turnSystem.GetComponent<TurnSystem>().EndEnemyTurn();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int attackDamage) 
    {
        enemyHealth -= attackDamage;
    }


}
