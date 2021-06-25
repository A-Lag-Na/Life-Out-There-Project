using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private int enemyHealth = 12;
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
            isPlayerTurn = turnSystem.GetComponent<TurnSystem>().isPlayerTurn;

            if (!isPlayerTurn)
            {
                if (player.GetComponent<Player>().PlayerHasBlock() == false)
                {
                    player.GetComponent<Player>().PlayerTakeDamage(1);
                    turnSystem.GetComponent<TurnSystem>().EndEnemyTurn();
                }
                else
                {
                    player.GetComponent<Player>().BlockDamage(1);
                    turnSystem.GetComponent<TurnSystem>().EndEnemyTurn();
                }
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
