using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class c_Card : ScriptableObject
{
    public int cardId;
    public int cardCost;

    public string cardName;
    public string cardType;
    public string cardDescription;
    public string cardCharacter;
    public string cardRarity;

    public bool exhaust;

    public Sprite thisImage;

    public c_Card(int CardId, int CardCost, string CardName, string CardType, string CardDescription, Sprite ThisImage, string CardCharacter, string CardRarity, bool Exhaust)
    {
       cardId = CardId; 
       cardCost = CardCost;
       cardName = CardName;
       cardType = CardType;
       cardDescription = CardDescription;
       cardCharacter = CardCharacter;
       cardRarity = CardRarity;

       exhaust = Exhaust;

       thisImage = ThisImage;
    } 
    
    public c_Card(c_Card c)
    {
        cardId = c.cardId;
        cardCost = c.cardCost;

        cardName = c.cardName;
        cardType = c.cardType;
        cardDescription = c.cardDescription;
        cardCharacter = c.cardCharacter;
        cardRarity = c.cardRarity;

        exhaust = c.exhaust;

        thisImage = c.thisImage;
    }

}
