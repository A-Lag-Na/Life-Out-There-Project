using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class TurnSystem : MonoBehaviour
{
    #region Variables
    public bool isPlayerTurn;
    public int playerTurnCount;
    public int enemyTurnCount;
    public bool areEnemiesDead = false;
    public GameObject turnBanner;
    public GameObject map;
    public TextMeshProUGUI turntext;

    private GameObject player;
    private GameObject spawnArea;
    private SpawnEnemy spawnAreaScript;
    private List<GameObject> enemies;
    private int enemiesEndedturn = 0;
    private int enemiesDeadCount = 0;

    private bool fadeOut = true, fadeIn = true;
    [SerializeField]
    private float fadeSpeed = .5f;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        isPlayerTurn = true;
        playerTurnCount = 1;
        enemyTurnCount = 0;

        player = GameObject.FindWithTag("Player");
      
        spawnArea = GameObject.Find("SpawnArea");
        if (spawnArea != null)
            spawnAreaScript = spawnArea.GetComponentInParent<SpawnEnemy>();

        enemies = spawnAreaScript.GetSpawnedEnemies();


        turntext.SetText("Player Turn");
        StartCoroutine(FadeINTurnBanner());
    }

    // Update is called once per frame

    void Update()
    {
        if (areEnemiesDead)
        {
            
        }
    }

    public void EndPlayerTurn()
    {
        isPlayerTurn = false;
        enemyTurnCount++;
        player.GetComponent<Player>().DiscardHand();

        turntext.SetText("Enemy Turn");
        StartCoroutine(FadeINTurnBanner());
    }

    public void AllEnemiesPlayed()
    {
        isPlayerTurn = true;
        playerTurnCount++;
        if (player.GetComponent<Player>().blockAmmount.text != "0")
        {
            player.GetComponent<Player>().RemovePlayerBlock();
        }
        player.GetComponent<Player>().ResetManaCount();
        player.GetComponent<Player>().NewHand();

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
            ///SceneManager.LoadScene("Game End"); 
            GameObject UI = GameObject.Find("UI");
            UI.SetActive(false);
            map.SetActive(true);
        }
    }
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
}
