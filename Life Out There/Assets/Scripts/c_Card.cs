using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class c_Card : ScriptableObject
{
    public int cardId;
    public int cardCost;
    public int damage;
    public int block;

    public string cardName;
    public string cardType;
    public string cardDescription;
    public string cardCharacter;
    public string cardRarity;

    public bool exhaust;
    public bool upgrade;

    public Sprite thisImage;

    public c_Card(int CardId, int CardCost, string CardName, string CardType, string CardDescription, Sprite ThisImage, string CardCharacter, string CardRarity, bool Exhaust, int Damage, int Block, bool Upgrade)
    {
       cardId = CardId; 
       cardCost = CardCost;
       damage = Damage;
       block = Block;

       cardName = CardName;
       cardType = CardType;
       cardDescription = CardDescription;
       cardCharacter = CardCharacter;
       cardRarity = CardRarity;

       exhaust = Exhaust;
       upgrade = Upgrade;

       thisImage = ThisImage;
    } 
    
    public c_Card(c_Card c)
    {
        cardId = c.cardId;
        cardCost = c.cardCost;
        damage = c.damage;
        block = c.block;

        cardName = c.cardName;
        cardType = c.cardType;
        cardDescription = c.cardDescription;
        cardCharacter = c.cardCharacter;
        cardRarity = c.cardRarity;

        exhaust = c.exhaust;
        upgrade = c.upgrade;

        thisImage = c.thisImage;
    }

}
