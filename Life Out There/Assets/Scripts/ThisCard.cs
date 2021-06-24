using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
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

    // Start is called before the first frame update
    void Start()
    {
        thisCard = c_CardDatabase.cardList[thisId];
    }

    // Update is called once per frame
    void Update()
    {
        thisCard = c_CardDatabase.cardList[thisId];
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


    }
}
