using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurnSystem : MonoBehaviour
{
    public bool isPlayerTurn;
    public int playerTurnCount;
    public int enemyTurnCount;



    private GameObject player;
    private GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        isPlayerTurn = true;
        playerTurnCount = 1;
        enemyTurnCount = 0;

        player = GameObject.FindWithTag("Player");

        enemy = GameObject.FindWithTag("Enemy");
    }

    // Update is called once per frame
  

    public void EndPlayerTurn()
    {
        isPlayerTurn = false;
        enemyTurnCount++;
        player.GetComponent<Player>().DiscardHand();
    }

    public void EndEnemyTurn()
    {
        isPlayerTurn = true;
        playerTurnCount++;
        if (player.GetComponent<Player>().blockAmmount.text != "0")
        {
            player.GetComponent<Player>().RemovePlayerBlock();
        }
        player.GetComponent<Player>().ResetManaCount();
        player.GetComponent<Player>().NewHand();
    }
}
