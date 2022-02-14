using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

//Player REALLY should be a prefab
public class Player : MonoBehaviour
{
    #region PlayerStats

    private int playerHealth = 50;
    [SerializeField] private int maxPlayerHealth = 50;

    [SerializeField] private int playerBlock = 0;
    [SerializeField] private int playerGold = 99;
    [SerializeField] private int playerMana = 2;
    [SerializeField] private int maxPlayerMana = 2;
    private bool hasBlock = false;
    bool isDead = false;

    public TextMeshProUGUI manaText;
    public GameObject handArea;
    public TextMeshProUGUI currentHealth;
    public TextMeshProUGUI maxHealth;
    public TextMeshProUGUI blockAmount;

    public GameObject Block;

    #endregion
    public Deck deck;
    private bool playerTurn = true;
    public bool restSite = false;
    List<GameObject> inHand = new List<GameObject>();
    List<c_Card> inDiscardPile = new List<c_Card>();

    List<c_Card> playerDeck = new List<c_Card>();
    private GameObject selectedCard = null;
    //GameObject[] syringes;
    private Animator anim;

    public GameObject cardPrefab;

        

    // Start is called before the first frame update
    void Start()
    {
        //syringes = new GameObject[3];
        playerDeck.Clear();
        inHand.Clear();
        if (!restSite)
        {
            playerDeck = deck.GetCards();
            //for (int i = 0; i < 5; i++)
            //{
            //    Debug.Log("Card:"+);
            //}
            playerHealth = PlayerPrefs.GetInt("PlayerCurrentHealth");
            currentHealth.SetText(PlayerPrefs.GetInt("PlayerCurrentHealth").ToString());
            maxHealth.SetText(maxPlayerHealth.ToString());

            for (int i = 0; i < 5; i++)
            {
                GameObject playerCard = Instantiate(cardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                playerCard.GetComponent<ThisCard>().thisId = playerDeck[i].id;
                playerCard.transform.SetParent(handArea.transform, false);
                inHand.Add(playerCard);
            }
        }
        if (GetComponent<Animator>() != null)
            anim = GetComponent<Animator>();

    }

    void Update()
    {
    }

    IEnumerator OnDeath()
    {
        if (!isDead)
        {
            isDead = true;
            if (anim != null)
            {
                for (int i = 0; i < anim.parameterCount; i++)
                {
                    if (anim.GetParameter(i).name == "Death")
                        anim.SetTrigger("Death");
                }
            }
        }
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Game End");
    }

    public void AddPlayerBlock(int block)
    {
        Block.SetActive(true);
        hasBlock = true;
        playerBlock += block;
        blockAmount.SetText(playerBlock.ToString());
    }


    public void RemovePlayerBlock()
    {
        Block.SetActive(false);
        hasBlock = false;
        playerBlock = 0;
        blockAmount.SetText(playerBlock.ToString());

    }
    public bool PlayerHasBlock()
    {
        return hasBlock;
    }

    public void BlockDamage(int damage)
    {
        if (anim != null)
        {
            for (int i = 0; i < anim.parameterCount; i++)
            {
                if (anim.GetParameter(i).name == "TakeDamage")
                    anim.SetTrigger("TakeDamage");
            }
        }

        if (playerBlock >= damage)
        {
            playerBlock -= damage;
            blockAmount.SetText(playerBlock.ToString());
        }
        else
        {
            damage -= playerBlock;
            playerBlock -= playerBlock;
            blockAmount.SetText(playerBlock.ToString());
            RemovePlayerBlock();
            PlayerTakeDamage(damage);
        }
       

    }
    public void UpdateHud()
    {
        currentHealth.SetText(playerHealth.ToString());
        maxHealth.SetText(maxPlayerHealth.ToString());
        manaText.SetText(playerMana.ToString() + " / " + maxPlayerMana.ToString());
    }
    public void PlayerTakeDamage(int damageAmount)
    {
        if (anim != null)
        {
            for (int i = 0; i < anim.parameterCount; i++)
            {
                if (anim.GetParameter(i).name == "TakeDamage")
                    anim.SetTrigger("TakeDamage");
            }
        }
        playerHealth -= damageAmount;
        PlayerPrefs.SetInt("PlayerCurrentHealth", playerHealth);
        if (playerHealth <= 0)
        {
            playerHealth = 0;
            StartCoroutine("OnDeath");
        }
    }
    //Runs player Attack animaiton
    public void PlayerDealDamage()
    {
        if (anim != null)
        {
            for (int i = 0; i < anim.parameterCount; i++)
            {
                if (anim.GetParameter(i).name == "AttackA")
                    anim.SetTrigger("AttackA");
            }
        }
    }

    public int GetManaCount()
    {
        return playerMana;
    }

    public void ResetManaCount()
    {
        playerMana = maxPlayerMana;
    }
    public void ResetHealth()
    {
        playerHealth = maxPlayerHealth;
        PlayerPrefs.SetInt("PlayerCurrentHealth", maxPlayerHealth);
        UpdateHud();
    }

    public void PlayedMana(int cost)
    {
        playerMana -= cost;
        UpdateHud();
    }

    public void DiscardHand()
    {
        foreach (Transform child in handArea.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        inHand.Clear();
    }

    public void NewHand()
    {
   
        deck.Shuffle();

        for (int i = 0; i < 5; i++)
        {
            GameObject playerCard = Instantiate(cardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            playerCard.GetComponent<ThisCard>().thisId = playerDeck[i].id;
            playerCard.transform.SetParent(handArea.transform, false);
            inHand.Add(playerCard);
        }
    }
    public void RemoveFromHand()
    {
        
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
