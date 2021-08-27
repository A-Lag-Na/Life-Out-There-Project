using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    #region Variable
    #region Stats
    //How much the enemy is worth to the spawner, and how much experience it grants on kill.
    [SerializeField] private string enemyRank = "Common";
    //How much damage it takes to kill the enemy 
    [SerializeField] private int enemyHealth = 25;
    //How much Health the enemy had at the beginning of combat
    [SerializeField] private int enemyMaxHealth = 25;
    //How much damage does the enemy deal
    [SerializeField] private int enemyDamage = 6;

    //Condition Immunities 
    bool isWeak;

    //Enemy AI needs to know
    public bool isPlayerTurn;
    public bool isAttacking = false;
    public bool isDead = false;
    #endregion


    #region Components
    //is it the enemies turn
    private GameObject turnSystem;
    //Show the player how much health is left
    public GameObject healthSlider;
    //Show the player how much health is in a numerical way
    public TextMeshProUGUI health;
    
    //The Player
    private GameObject player;
    private Player playerScript;

    private float blockDamageTransDelay = 1;
    private Animator anim;
    #endregion
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (player != null)
            playerScript = player.GetComponentInParent<Player>();
      
        turnSystem = GameObject.Find("TurnSystem");
        if (turnSystem != null)
            isPlayerTurn = turnSystem.GetComponent<TurnSystem>().isPlayerTurn;

        health = healthSlider.GetComponentInChildren<TextMeshProUGUI>();

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
            
            StartCoroutine("OnDeath");
        }
    }
    #region Getters and Setters
    public void SetHealth(int health)
    {
        healthSlider.GetComponent<Slider>().value = health;
    }
    public void SetMaxHealth(int maxHealth)
    {
        healthSlider.GetComponent<Slider>().maxValue = maxHealth;
        healthSlider.GetComponent<Slider>().value = maxHealth;
    }
    #endregion
    #region EnemyFunctions

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
        Destroy(healthSlider);
        Destroy(gameObject);
        turnSystem.GetComponent<TurnSystem>().EnemyHasDied();
    }

    IEnumerator DealDamage()
    {
        isAttacking = true;
        if (player.GetComponent<Player>().PlayerHasBlock() == true)
        {
           
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
          
        }
        else
        {
           
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
                
            }
        }
        isAttacking = false;

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

    #endregion
}


