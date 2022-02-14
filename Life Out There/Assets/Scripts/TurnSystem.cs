using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Effect
{
    public Effect(EffectType _type, int _amount)
    {
        type = _type;
        amount = _amount;
    }
    public enum EffectType
    {
        Attack,
        Block,
        Weak
    }

    public EffectType type;
    //public Enemy target;
    public int amount;

}

public class TurnSystem : MonoBehaviour
{
    //This is called a singleton, IIRC. It makes it so that only one turn system can be created, and this turn system can be accessed globally through TurnSystem.instance.
    public static TurnSystem instance;
    #region Variables
    public bool isPlayerTurn;
    public int playerTurnCount;
    public int enemyTurnCount;
    public bool areEnemiesDead = false;
    public bool isBossRoom = false;
    public GameObject turnBanner;
    public GameObject map;
    public TextMeshProUGUI turntext;

    private GameObject player;
    private Player playerScript;

    private GameObject spawnArea;
    private SpawnEnemy spawnAreaScript;

    private List<GameObject> enemies;
    //private List<Enemy> enemyScriptList;

    private int enemiesEndedturn = 0;
    private int enemiesDeadCount = 0;

    private bool fadeOut = true, fadeIn = true;
    [SerializeField]
    private float fadeSpeed = .5f;

    

    //Sets up the Singleton
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        isPlayerTurn = true;
        playerTurnCount = 1;
        enemyTurnCount = 0;

        player = GameObject.FindWithTag("Player");
        if(player != null)
        {
            playerScript = player.GetComponent<Player>();
        }
      
        spawnArea = GameObject.Find("SpawnArea");
        if (spawnArea != null)
            spawnAreaScript = spawnArea.GetComponentInParent<SpawnEnemy>();

        enemies = spawnAreaScript.GetSpawnedEnemies();
        if(enemies != null)
        {
            //for(int i = 0; i < enemies.Count; i++)
            //{
            //    enemyScriptList.Add(enemies[i].GetComponent<Enemy>());
            //}
        }
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].GetComponent<Enemy>().enemyRank == "Boss")
            {
                isBossRoom = true;
            }
        }

        turntext.SetText("Player Turn");
        StartCoroutine(FadeINTurnBanner());
    }
    public void EndPlayerTurn()
    {
        isPlayerTurn = false;
        enemyTurnCount++;
        playerScript.DiscardHand();

        turntext.SetText("Enemy Turn");
        StartCoroutine(FadeINTurnBanner());
    }

    public void AllEnemiesPlayed()
    {
        isPlayerTurn = true;
        playerTurnCount++;
        playerScript.ResetManaCount();
        playerScript.NewHand();

        turntext.SetText("Player Turn");
        StartCoroutine(FadeINTurnBanner());
    }

    //Come Back to this to fix enemy attacking twice
    public void EndEnemyTurn()
    {
        enemiesEndedturn++;
        if (enemiesEndedturn == enemies.Count)
        {
            enemiesEndedturn = 0;
            AllEnemiesPlayed();
        }
    }

    public void EnemyHasDied()
    {
        enemiesDeadCount++;
        if (enemiesDeadCount == enemies.Count)
        {
            enemiesDeadCount = 0;
            if (isBossRoom)
            {
                SceneManager.LoadScene("Game End");
            }
            else
            {
                GameObject UI = GameObject.Find("UI");
                UI.SetActive(false);
                map.SetActive(true);
            }
        }
    }
    #region TurnBanner
    public IEnumerator FadeOutTurnBanner()
   {

        while (turnBanner.GetComponent<Image>().color.a > 0 && turntext.color.a > 0)
        {
            yield return new WaitForEndOfFrame();

            Color objectColor = turnBanner.GetComponent<Image>().color;
            Color textColor = turntext.color;

            float objFadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);
            float textFadeAmount = textColor.a - (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, objFadeAmount);
            textColor = new Color(textColor.r, textColor.g, textColor.b, textFadeAmount);

            turnBanner.GetComponent<Image>().color = objectColor;
            turntext.color = textColor;
        }
        turnBanner.SetActive(false);
        yield return null;
    }

    public IEnumerator FadeINTurnBanner()
    {
        turnBanner.SetActive(true);

        yield return new WaitForEndOfFrame();

        while (turnBanner.GetComponent<Image>().color.a < 1 && turntext.color.a < 1)
        {
            Color objectColor = turnBanner.GetComponent<Image>().color;
            Color textColor = turntext.color;

            float objFadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);
            float textFadeAmount = textColor.a + (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, objFadeAmount);
            textColor = new Color(textColor.r, textColor.g, textColor.b, textFadeAmount);

            turnBanner.GetComponent<Image>().color = objectColor;
            turntext.color = textColor;

        }
      
        StartCoroutine(FadeOutTurnBanner());
        yield return null;

    }
    #endregion
    public void PlayCardHardcoded(ThisCard _card)
    {
        if (playerScript.GetManaCount() >= _card.cost)
        {
            if (_card.cardType == "Attack")
            {
                GameObject enemy = GameObject.FindWithTag("Enemy");
                Enemy enemyScript = enemy.GetComponent<Enemy>();
                if (_card.cardName == "Solar Reflection")
                {
                    enemyScript.AddWeakEffect(1);
                    playerScript.PlayerDealDamage();
                    enemyScript.TakeDamage(_card.thisCard.damage);
                }
                else
                {
                    ExplorerAttack e = new ExplorerAttack();
                    e.OnThisCardPlayed();
                }
                //if (isEnemyOn)
                //{
                //    enemyLight.SetActive(false);
                //    isEnemyOn = false;
                //}
            }
            else if (_card.cardType == "Skill")
            {
                playerScript.AddPlayerBlock(_card.thisCard.block);
                //if (isPlayerOn)
                //{
                //    playerLight.SetActive(false);
                //    isPlayerOn = false;
                //}
                
            }
            playerScript.PlayedMana(_card.cost);
            //Destroy(_cardObject);
            Destroy(_card.gameObject);
        }
        else
        {
            TurnSystem.instance.NotEnoughMana();
        }
    }

    public void ResolveEffect(Effect _effect)
    {
        switch (_effect.type)
        {
            
            case Effect.EffectType.Block:
                {
                    playerScript.AddPlayerBlock(_effect.amount);
                    break;
                }
            case Effect.EffectType.Attack:
                {
                    GameObject enemy = GameObject.FindWithTag("Enemy");
                    Enemy enemyScript = enemy.GetComponent<Enemy>();
                    playerScript.PlayerDealDamage();
                    enemyScript.TakeDamage(_effect.amount);
                    break;
                }
            case Effect.EffectType.Weak:
                {
                    GameObject enemy = GameObject.FindWithTag("Enemy");
                    Enemy enemyScript = enemy.GetComponent<Enemy>();
                    enemyScript.AddWeakEffect(_effect.amount);
                    break;
                }
        }
    }
    public void NotEnoughMana()
    {
        //Notify the player that they are lacking resources to play the selected card
    }    
}
