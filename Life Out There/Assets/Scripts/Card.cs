using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;


[CreateAssetMenu]
public class Card : ScriptableObject
{

    public string cardName;

    public string cardType;

    public string cardDescription;

    public int cardCost;
    //public int cardAttackValue;
    //public int cardBlockValue;
    //public int cardStatusValue;

    //private bool isAttackCard;
    //private bool isBlockCard;
    //private bool isStatusCard;
    public Sprite artwork;



}
