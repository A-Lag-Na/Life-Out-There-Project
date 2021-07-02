using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{

    [SerializeField] private int enemyHealth = 12;
    [SerializeField] private int enemyMaxHealth = 12;
    public GameObject turnSystem;
    public GameObject healthSlider;
    public TextMeshProUGUI health;

    bool isPlayerTurn;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        isPlayerTurn = turnSystem.GetComponent<TurnSystem>().isPlayerTurn;
        SetMaxHealth(enemyMaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        health.SetText(enemyHealth.ToString() + " / " + enemyMaxHealth.ToString());

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
            Destroy(healthSlider);
            Destroy(gameObject);
            turnSystem.GetComponent<TurnSystem>().isEnemyDead = true;
        }
    }

    public void TakeDamage(int attackDamage) 
    {
        enemyHealth -= attackDamage;
        SetHealth(enemyHealth);
    }

    public void SetHealth(int health)
    {
        healthSlider.GetComponent<Slider>().value = health;
    }
    public void SetMaxHealth(int maxHealth)
    {
        healthSlider.GetComponent<Slider>().maxValue = maxHealth;
        healthSlider.GetComponent<Slider>().value = maxHealth;
    }
}


