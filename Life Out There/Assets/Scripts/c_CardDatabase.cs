using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_CardDatabase : MonoBehaviour
{
    public static List<c_Card> cardList = new List<c_Card>();
   
    void Awake()
    {
        
        // int CardId, int CardCost, string CardName, string CardType, string CardDesc
        cardList.Add(new c_Card(0, 1, "Blast", "Attack", "Damage 6", Resources.Load<Sprite>("BlastArt")));
        cardList.Add(new c_Card(1, 1, "Barrier", "Skill", "Block 5", Resources.Load<Sprite>("BarrierArt")));
        UnityEngine.Debug.Log("I am running");
    }
}
