using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ThisCard : MonoBehaviour
{
    public c_Card thisCard;
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

    public GameObject cardHighlight;
    private GameObject enemyLight;
    private GameObject playerLight;

    private GameObject player;
    private Player playerScript;
    private GameObject enemy;
    private Enemy enemyScript;

    // Start is called before the first frame update
    public void Start()
    {
        thisCard = c_CardDatabase.cardDatabase[thisId];

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

        thisCard = c_CardDatabase.cardDatabase[thisId];
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
        if (Input.GetMouseButtonDown(1) && isSelected)
        {
            enemy = GameObject.FindWithTag("Enemy");
            
            TurnSystem.instance.PlayCardHardcoded(this);
            //gameObject.SetActive(false);
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
