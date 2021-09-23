using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ThisCard : MonoBehaviour
{
    public static c_Card thisCard;
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
    private bool isplayerOn = false;
    private bool isenemyOn = false;

    public GameObject cardHighlight;
    private GameObject enemyLight;
    private GameObject playerLight;

    private GameObject player;
    private GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        thisCard = c_CardDatabase.cardDatabase[thisId];

        player = GameObject.FindWithTag("Player");

        enemy = GameObject.FindWithTag("Enemy");

       
    }

    // Update is called once per frame
    void Update()
    {
        thisCard = c_CardDatabase.cardDatabase[thisId];
        id = thisCard.cardId;
        cost = thisCard.cardCost;
        cardName = thisCard.cardName;
        cardType = thisCard.cardType;
        cardDescription = thisCard.cardDescription;

        thisSprite = thisCard.thisImage;

        nameText.SetText(cardName);
        costText.SetText(cost.ToString());
        typeText.SetText(cardType);
        descText.SetText(cardDescription);

        thatImage.sprite = thisSprite;

        if (Input.GetMouseButtonDown(1) && isSelected)
        {
          
            if (player.GetComponent<Player>().GetManaCount() >= cost)
            {
                if (thisCard.cardType == "Attack")
                {
                    if(thisCard.cardName == "Solar Reflection")
                    {
                        enemy.GetComponent<Enemy>().AddWeakEffect(1);
                    }
                    player.GetComponent<Player>().PlayerDealDamage();
                    enemy.GetComponent<Enemy>().TakeDamage(thisCard.damage);
                    if (isenemyOn)
                    {
                        enemyLight.SetActive(false);
                        isenemyOn = false;
                    }
                    player.GetComponent<Player>().PlayedMana(cost);
                    Destroy(gameObject);

                }
                else if (thisCard.cardType == "Skill")
                {
                    player.GetComponent<Player>().AddPlayerBlock(thisCard);
                    if (isplayerOn)
                    {
                        playerLight.SetActive(false);
                        isplayerOn = false;
                    }
                    player.GetComponent<Player>().PlayedMana(cost);
                    Destroy(gameObject);
                }
            }
        }
        enemy = GameObject.FindWithTag("Enemy");
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
               isenemyOn = true;
              //Debug.Log("This object is <" + cardName + "> and its highlight is <" + enemyLight.name + ">");
            }
            else if (cardType == "Skill")
            {
                playerLight = player.transform.GetChild(0).gameObject;
                playerLight.SetActive(true);
                isplayerOn = true;
                //Debug.Log("This object is <" + cardName + "> and its highlight is <" + playerLight.name + ">");
            }

        }
        else
        {
            isSelected = false;
            cardHighlight.SetActive(false);
            transform.position = new Vector2(transform.position.x, transform.position.y - 50);

            if (isplayerOn)
            {
                playerLight.SetActive(false);
                isplayerOn = false;
            }
            else if (isenemyOn)
            {
                enemyLight.SetActive(false);
                isenemyOn = false;
            }
            //Debug.Log("This object is de-selected and its position is <" + transform.position + ">");
        }

        
    }
}
