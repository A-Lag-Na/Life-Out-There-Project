using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ThisCard : MonoBehaviour
{
    public c_BaseCard thisCard;
    public int thisId;

    public int id;
    public int cost;

    public string cardName;
    public string cardType;
    public string cardDescription;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI typeText;
    public TextMeshProUGUI descText;

    public Sprite thisSprite;
    public Image thatImage;

    private bool isSelected = false;
    private bool isPlayerOn = false;
    private bool isEnemyOn = false;

    //Enemy and playerLight can probably be managed through turnsystem, and card highlight can probably be on c_BaseCard and be enabled/disabled through TurnSystem.
    public GameObject cardHighlight;
    private GameObject enemyLight;
    private GameObject playerLight;

    private GameObject player;
    private Player playerScript;
    private GameObject enemy;
    private Enemy enemyScript;


    //TODO: Move card selection to its own script, or manage card selection through TurnSystem.
    //The actual on-play function will be called through c_BaseCard.OnThisCardPlayed() (which is a virtual function overridden by each card.

    // Start is called before the first frame update
    public void Start()
    {
        if(thisId > 0)
        {
            thisCard = c_CardDatabase.cardDatabase[thisId];
        }
        else
        {
            thisCard = new Blast();
        }

        player = GameObject.FindWithTag("Player");
        if(player != null)
        {
            playerScript = player.GetComponent<Player>();
        }

        enemy = GameObject.FindWithTag("Enemy");
        if (enemy != null)
        {
            enemyScript = enemy.GetComponent<Enemy>();
        }
        id = thisCard.id;
        cost = thisCard.cost;
        cardName = thisCard.cardName;
        cardType = thisCard.type;
        cardDescription = thisCard.description;
        
        thisSprite = thisCard.thisImage;
        
        nameText.SetText(cardName);
        costText.SetText(cost.ToString());
        typeText.SetText(cardType);
        descText.SetText(cardDescription);
        
        thatImage.sprite = thisSprite;
    }

    // Update is called once per frame
    public void Update()
    {
        //There's probably a better way to track this, like maybe a coroutine to detect mouse click after a card is selected, so as to move code out of the Update function.
        //For now though this is fine.
        if (isSelected && (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3)))
        {
            if(Input.GetMouseButtonDown(1))
            {
                enemy = GameObject.FindWithTag("Enemy");
            }
            else if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                enemy = GameObject.FindGameObjectsWithTag("Enemy")[0];
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                enemy = GameObject.FindGameObjectsWithTag("Enemy")[1];
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                enemy = GameObject.FindGameObjectsWithTag("Enemy")[2];
            }
            if(enemy == null)
            {
                Debug.LogError("Tried to play a card on a null target. Source: ThisCard.cs Update()");
            }
            TurnSystem.instance.PlayCardHardcoded(this, enemy);
        }
    }
    public void Selection()
    {
        if (isSelected == false)
        {

            isSelected = true;
            transform.position = new Vector2(transform.position.x, transform.position.y + 50);
            cardHighlight.SetActive(true);
            //Debug.Log("This object is selected and its position is <" + transform.position + ">");

            if (cardType == "Attack")
            {
               enemyLight = enemy.transform.GetChild(0).gameObject;
               enemyLight.SetActive(true);
               isEnemyOn = true;
              //Debug.Log("This object is <" + cardName + "> and its highlight is <" + enemyLight.name + ">");
            }
            else if (cardType == "Skill")
            {
                playerLight = player.transform.GetChild(0).gameObject;
                playerLight.SetActive(true);
                isPlayerOn = true;
                //Debug.Log("This object is <" + cardName + "> and its highlight is <" + playerLight.name + ">");
            }

        }
        else
        {
            isSelected = false;
            cardHighlight.SetActive(false);
            transform.position = new Vector2(transform.position.x, transform.position.y - 50);

            if (isPlayerOn)
            {
                playerLight.SetActive(false);
                isPlayerOn = false;
            }
            else if (isEnemyOn)
            {
                enemyLight.SetActive(false);
                isEnemyOn = false;
            }
            //Debug.Log("This object is de-selected and its position is <" + transform.position + ">");
        }
    }
}
