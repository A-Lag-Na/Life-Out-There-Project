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

    public Sprite thisImage;

    public c_Card(int CardId, int CardCost, string CardName, string CardType, string CardDesc, Sprite ThisImage )
    {
       cardId = CardId; 
       cardCost = CardCost;
       cardName = CardName;
       cardType = CardType;
       cardDescription = CardDesc;
        
       thisImage = ThisImage;
    }  
}
