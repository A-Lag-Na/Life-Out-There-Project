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
   public string enemyRank = "Common";
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
    public bool isColliderOn = false;
    bool hasWeak = false;
    #endregion


    #region Components
    //is it the enemies turn
    //TurnSystem is accessed through TurnSystem.instance now.

    //Show the player how much health is left
    public GameObject healthSlider;
    //Show the player how much health is in a numerical way
    public TextMeshProUGUI health;
    public TextMeshProUGUI damage;

    private BoxCollider2D enemyCollider;

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
      
        //
        isPlayerTurn = TurnSystem.instance.isPlayerTurn;

        health = healthSlider.GetComponentInChildren<TextMeshProUGUI>();

        SetMaxHealth(enemyMaxHealth);
        
        if (GetComponent<Animator>() != null)
            anim = GetComponent<Animator>();

        if (GetComponent<BoxCollider2D>() != null)
            enemyCollider = GetComponent<BoxCollider2D>();

        if(damage != null)
        {
            UpdateDamageText();
        }
        if(health != null)
        {
            SetHealth(enemyHealth);
            SetMaxHealth(enemyMaxHealth);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth > 0)
        {
            isPlayerTurn = TurnSystem.instance.isPlayerTurn;
            if (!isPlayerTurn)
            {    
               if(!isAttacking)
                 StartCoroutine("DealDamage");
            }
        }
    }
    #region Getters and Setters
    public void SetHealth(int _health)
    {
        //UI only needs to be updated after game state changes, not every frame.
        health.SetText(enemyHealth.ToString() + " / " + enemyMaxHealth.ToString());
        healthSlider.GetComponent<Slider>().value = _health;
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
        yield return new WaitForSeconds(1);
        Destroy(healthSlider);
        Destroy(gameObject);
        TurnSystem.instance.EnemyHasDied();
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
            player.GetComponent<Player>().BlockDamage(enemyDamage);
            //Add in delay window between dealing damage to block before ending my turn
            yield return new WaitForSeconds(blockDamageTransDelay);
            //End your turn
            isAttacking = false;
            if (hasWeak)
             RemoveWeakEffect(1);

            TurnSystem.instance.EndEnemyTurn();
          
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

                player.GetComponent<Player>().PlayerTakeDamage(enemyDamage);
                yield return new WaitForSeconds(blockDamageTransDelay);
                isAttacking = false;
                if (hasWeak)
                    RemoveWeakEffect(1);

                TurnSystem.instance.EndEnemyTurn();
                
            }
        }
        //isAttacking = false;
        yield return null;
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
        //We only need to check for death after enemy takes damage, so I moved the death check here. -P
        if (enemyHealth < 1)
        {
            enemyHealth = 0;
            StartCoroutine("OnDeath");
        }
    }

    public void AddWeakEffect(int weakAmount)
    {
        enemyDamage -= weakAmount;
        hasWeak = true;
        UpdateDamageText();
    }
    public void RemoveWeakEffect(int weakAmount)
    {
        enemyDamage += weakAmount;
        UpdateDamageText();
    }
    public void UpdateDamageText()
    {
        damage.SetText(enemyDamage.ToString());
    }
    #endregion
}


