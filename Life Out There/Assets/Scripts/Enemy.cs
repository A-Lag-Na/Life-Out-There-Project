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
    bool isAttacking = false;
    private float blockDamageTransDelay = 1;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        isPlayerTurn = turnSystem.GetComponent<TurnSystem>().isPlayerTurn;
        SetMaxHealth(enemyMaxHealth);
        if (GetComponent<Animator>() != null)
            anim = GetComponent<Animator>();
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
               if(!isAttacking)
                 StartCoroutine("DealDamage");
            }
        }
        else
        {
            Destroy(healthSlider);
            Destroy(gameObject);
            turnSystem.GetComponent<TurnSystem>().isEnemyDead = true;
        }
    }

    IEnumerator DealDamage()
    {
        if (player.GetComponent<Player>().PlayerHasBlock() == true)
        {
            isAttacking = true;
            if (anim != null)
            {
                for (int i = 0; i < anim.parameterCount; i++)
                {
                    if (anim.GetParameter(i).name == "Attack")
                        anim.SetTrigger("Attack");
                }
            }
            
            //tell player theyre are taking damage to their block;
            player.GetComponent<Player>().BlockDamage(1);
            //Add in delay window between dealing damage to block before ending my turn
            yield return new WaitForSeconds(blockDamageTransDelay);
            //End your turn
            turnSystem.GetComponent<TurnSystem>().EndEnemyTurn();
            isAttacking = false;
        }
        else
        {
            isAttacking = true;

            if (anim != null)
            {
                for (int i = 0; i < anim.parameterCount; i++)
                {
                    if (anim.GetParameter(i).name == "Attack")
                        anim.SetTrigger("Attack");
                }

                player.GetComponent<Player>().PlayerTakeDamage(1);
                yield return new WaitForSeconds(blockDamageTransDelay);

                turnSystem.GetComponent<TurnSystem>().EndEnemyTurn();
                isAttacking = false;
            }
        }
    }




    public void TakeDamage(int attackDamage) 
    {
        if (anim != null)
        {
            for (int i = 0; i < anim.parameterCount; i++)
            {
                if (anim.GetParameter(i).name == "Take Damage")
                    anim.SetTrigger("Take Damage");
            }
        }
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


