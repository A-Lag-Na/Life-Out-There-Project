using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    #region PlayerStats

    [SerializeField] private int playerHealth = 2;
    [SerializeField] private int maxPlayerHealth = 2;

    [SerializeField] private int playerBlock = 0;
    [SerializeField] private int playerGold = 99;
    public GameObject handArea;
    public TextMeshProUGUI currentHealth;
    public TextMeshProUGUI maxHealth;

    #endregion
    public Deck deck;
    private bool playerTurn = true;
    List<GameObject> inHand = new List<GameObject>();
    List<c_Card> inDiscardPile = new List<c_Card>();

    List<c_Card> playerDeck = new List<c_Card>();
    private GameObject selectedCard = null;
    //GameObject[] syringes;

    public GameObject cardPrefab;

        

    // Start is called before the first frame update
    void Start()
    {
        //syringes = new GameObject[3];

        playerDeck = deck.GetCards();
        //for (int i = 0; i < 5; i++)
        //{
        //    Debug.Log("Card:"+);
        //}
        currentHealth.SetText(playerHealth.ToString());
        maxHealth.SetText(maxPlayerHealth.ToString());



        for (int i = 0; i < 5; i++)
        {
            GameObject playerCard =  Instantiate(cardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            playerCard.GetComponent<ThisCard>().thisId = playerDeck[i].cardId;
            playerCard.transform.SetParent(handArea.transform, false);
            inHand.Add(playerCard);
        }
    }

    public void AddPlayerBlock(c_Card blockCard)
    {
        playerBlock += 5;
    }


    public void RemovePlayerBlock()
    {
        playerBlock = 0 ;
    }

    public void PlayerTakeDamage(int damageAmmount)
    {
        playerHealth -= damageAmmount;
    }


    #region Gold
    public void AddCoins(int amountOfCoins)
    {
        playerGold += amountOfCoins;
    }

    public int GetCoins()
    {
        return playerGold;
    }

    public void SetCoins(int _coins)
    {
        playerGold = _coins;
    }
    #endregion

    

}
