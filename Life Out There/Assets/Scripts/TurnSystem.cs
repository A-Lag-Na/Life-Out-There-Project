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


    [SerializeField] private int playerMana = 2;
    [SerializeField] private int maxPlayerMana = 2;

    public TextMeshProUGUI currentMana;
    public TextMeshProUGUI maxMana;

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
    void Update()
    {
        currentMana.SetText(playerMana.ToString());
        maxMana.SetText(maxPlayerMana.ToString());
    }

    public void EndPlayerTurn()
    {
        isPlayerTurn = false;
        enemyTurnCount++;
        player.GetComponent<Player>().RemovePlayerBlock();
    }

    public void EndEnemyTurn()
    {
        isPlayerTurn = true;
        playerTurnCount++;

        playerMana = maxPlayerMana;
    }
}
