using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

#region OldCode
//public class c_BaseCard : ScriptableObject
//{
//    public int cardId;
//    public int cardCost;
//    public int damage;
//    public int block;

//    public string cardName;
//    public string cardType;
//    public string cardDescription;
//    public string cardCharacter;
//    public string cardRarity;

//    public bool exhaust;
//    public bool upgrade;

//    public Sprite thisImage;

//    public c_BaseCard(int CardId, int CardCost, string CardName, string CardType, string CardDescription, Sprite ThisImage, string CardCharacter, string CardRarity, bool Exhaust, int Damage, int Block, bool Upgrade)
//    {
//       cardId = CardId; 
//       cardCost = CardCost;
//       damage = Damage;
//       block = Block;

//       cardName = CardName;
//       cardType = CardType;
//       cardDescription = CardDescription;
//       cardCharacter = CardCharacter;
//       cardRarity = CardRarity;

//       exhaust = Exhaust;
//       upgrade = Upgrade;

//       thisImage = ThisImage;
//    } 

//    public c_BaseCard(c_BaseCard c)
//    {
//        cardId = c.cardId;
//        cardCost = c.cardCost;
//        damage = c.damage;
//        block = c.block;

//        cardName = c.cardName;
//        cardType = c.cardType;
//        cardDescription = c.cardDescription;
//        cardCharacter = c.cardCharacter;
//        cardRarity = c.cardRarity;

//        exhaust = c.exhaust;
//        upgrade = c.upgrade;

//        thisImage = c.thisImage;
//    }

//}
#endregion
public class c_BaseCard
{
    public enum Rarity
    {
        none,
        common,
        uncommon,
        rare
    }
    #region attributes
    #region basic stats
    public int id;
    public int cost;
    public int damage;
    public int selfDamage;
    public int block;
    public int heal;
    public int draw;
    public int discard;
    public int energyOnUse;
    public int shopPrice;

    //magicNumber is used as a generic int for other values, like amount of debuff/buff applied.
    public int magicNumber;
    #endregion

    #region meta
    //Type and rarity could really be a enum.
    public string cardName;
    public string type;
    public string description;
    public string character;
    //public string rarity;
    public Rarity rarity;
    public Sprite thisImage;
    //Tags are for things that effect all "Blast" cards, or all Basic Strikes/Defends, for example.
    public List<string> tags = new List<string>();
    #endregion

    #region keywords
    public bool exhaust;
    public bool selfRetain;
    public int[] multiDamage;
    protected bool isMultiDamage;
    #endregion

    #region upgrades
    public bool upgraded;
    public int timesUpgraded;
    #endregion

    #region unused StS Variables
    //public int costForTurn;
    //public int chargeCost;
    //public bool isCostModified;
    //public bool isCostModifiedForTurn;
    //public AbstractCard.CardColor color;
    //public bool isInnate;
    //public ArrayList<String> keywords;
    //public bool ignoreEnergyOnUse;
    //public bool isSeen;
    //public bool returnToHand;
    //public bool shuffleBackIntoDrawPile;
    //public bool isEthereal;
    //public AbstractCard.CardTarget target;
    //public bool isDamageModified;
    //public bool isBlockModified;
    //public bool isMagicNumberModified;
    //public int baseDamage;
    //public int baseBlock;
    //public int baseMagicNumber;
    //public int baseHeal;
    //public int baseDraw;
    //public int baseDiscard;
    //public bool upgradedCost;
    //public bool upgradedDamage;
    //public bool upgradedBlock;
    //public bool upgradedMagicNumber;
    //public bool purgeOnUse;
    //public bool exhaustOnUseOnce;
    //public bool exhaustOnFire;
    //public bool freeToPlayOnce;
    //public bool isInAutoplay;
    #endregion
    #endregion

    public c_BaseCard(int CardId, int CardCost, string CardName, string CardType, string CardDescription, Sprite ThisImage, string CardCharacter, string CardRarity, bool Exhaust, int Damage, int Block, bool Upgrade)
    {
        id = CardId;
        cost = CardCost;
        damage = Damage;
        block = Block;

        cardName = CardName;
        type = CardType;
        description = CardDescription;
        character = CardCharacter;
        //rarity = CardRarity;
        rarity = Rarity.none;

        exhaust = Exhaust;
        upgraded = Upgrade;

        thisImage = ThisImage;
    }
    public c_BaseCard(int CardId, int CardCost, string CardName, string CardType, string CardDescription, Sprite ThisImage, string CardCharacter, Rarity CardRarity, bool Exhaust, int Damage, int Block, bool Upgrade)
    {
        id = CardId;
        cost = CardCost;
        damage = Damage;
        block = Block;

        cardName = CardName;
        type = CardType;
        description = CardDescription;
        character = CardCharacter;
        rarity = CardRarity;

        exhaust = Exhaust;
        upgraded = Upgrade;

        thisImage = ThisImage;
    }

    public c_BaseCard(c_BaseCard c)
    {
        id = c.id;
        cost = c.cost;
        damage = c.damage;
        block = c.block;

        cardName = c.cardName;
        type = c.type;
        description = c.description;
        character = c.character;
        rarity = c.rarity;

        exhaust = c.exhaust;
        upgraded = c.upgraded;

        thisImage = c.thisImage;
    }
    public c_BaseCard(int _id, int _cost, string _name, string _type, string _description, Sprite _sprite, Rarity _rarity) 
    {
        id = _id;
        cost = _cost;
        cardName = _name;
        type = _type;
        description = _description;
        thisImage = _sprite;
        rarity = _rarity;
        
        character = "null";

        damage = -1;
        block = -1;
        heal = -1;
        draw = -1;
        discard = -1;
        energyOnUse = -1;
        shopPrice = -1;
        magicNumber = -1;

        exhaust = false;
        selfRetain = false;
        isMultiDamage = false;

        upgraded = false;
        timesUpgraded = 0;
    }

    public virtual void upgrade() { }

    public virtual void OnThisCardPlayed(GameObject _target) { }

    //I've looked into implementing an interface so as to re-use these triggers among multiple classes, but it seems genuinely more effective to just rewrite them.
    #region Triggers
    public virtual void OnCombatStart() { }
    public virtual void OnCombatEnd() { }
    public virtual void OnTurnStart(int _combatant) { }
    public virtual void OnTurnEnd(int _combatant) { }
    public virtual void OnUsesAttack(int _combatant) { }
    public virtual void OnIsAttacked(int _combatant) { }
    public virtual void OnDeath(int _combatant) { }
    public virtual void OnCardPlayed(c_BaseCard _card) { }
    public virtual void OnCardDiscarded(c_BaseCard _card) { }
    public virtual void OnCardExhausted(c_BaseCard _card) { }
    #endregion

}
