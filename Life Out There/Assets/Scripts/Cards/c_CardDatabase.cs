using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_CardDatabase : MonoBehaviour
{
    public static List<c_BaseCard> cardDatabase = new List<c_BaseCard>();

    void Awake()
    {
        LoadCardData();
    }

    public void LoadCardData()
    {
        cardDatabase.Clear();

        List<Dictionary<string, object>> data = CSVReader.Read("Card Database");
        for (var i = 0; i < data.Count; i++)
        {
            int cardId = int.Parse(data[i]["ID"].ToString(), System.Globalization.NumberStyles.Integer);
            int cardCost = int.Parse(data[i]["Cost"].ToString(), System.Globalization.NumberStyles.Integer);
            

            string cardName = data[i]["Name"].ToString();
            string cardType = data[i]["Type"].ToString();
            string cardDescription = data[i]["Description"].ToString();

            Sprite thisImage = Resources.Load<Sprite>(data[i]["Appearance"].ToString());

            string cardCharacter = data[i]["Character"].ToString();
            string cardRarity = data[i]["Rarity"].ToString();

            bool exhaust;
            if (data[i]["Exhaust"].ToString() == "TRUE")
                exhaust = true;
            else
                exhaust = false;

            bool upgrade;
            if (data[i]["Upgrade"].ToString() == "TRUE")
                upgrade = true;
            else
                upgrade = false;

            int damage = int.Parse(data[i]["Damage"].ToString(), System.Globalization.NumberStyles.Integer);
            int block = int.Parse(data[i]["Block"].ToString(), System.Globalization.NumberStyles.Integer);

            //Hard coded rarity, cause I changed it from a string to an int.
            AddCard(cardId, cardCost, cardName, cardType, cardDescription, thisImage, cardCharacter, cardRarity, exhaust, damage, block, upgrade);
        }
    }

    //These started throwing "ScriptableObject must be created with ScriptableObject.Instantiate()... so I just cut out the tempCard altogether.
    //void AddCard(int cardId, int cardCost, string cardName, string cardType, string cardDescription, Sprite thisImage, string cardCharacter, c_BaseCard.Rarity rarity, bool exhaust, int damage, int block, bool upgrade)
    //{
    //    cardDatabase.Add(new c_BaseCard(cardId, cardCost, cardName, cardType, cardDescription, thisImage, cardCharacter, rarity, exhaust, damage, block, upgrade));
    //}
    void AddCard(int cardId, int cardCost, string cardName, string cardType, string cardDescription, Sprite thisImage, string cardCharacter, string rarity, bool exhaust, int damage, int block, bool upgrade)
    {
        //c_BaseCard temp = ScriptableObject.CreateInstance<c_BaseCard>();
        //temp.id = cardId;
        //temp.cost = cardCost;
        //temp.cardName = cardName;
        //temp.type = cardType;
        //temp.description = cardDescription;
        //temp.thisImage = thisImage;
        //temp.character = cardCharacter;
        //temp.rarity = 0;
        //temp.exhaust = exhaust;
        //temp.damage = damage;
        //temp.block = block;
        //temp.upgraded = upgrade;
        cardDatabase.Add(new c_BaseCard(cardId, cardCost, cardName, cardType, cardDescription, thisImage, 0, 0, exhaust, damage, block, upgrade));
    }

    public static List<c_BaseCard> CreateExplorerStartDeck(List<c_BaseCard> deck)
    {
        for (int i = 0; i < cardDatabase.Count; i++)
        {
            if (cardDatabase[i].cardName == "Barrier" && !cardDatabase[i].upgraded)
            {
                for (int l = 0; l < 5; l++)
                {
                    deck.Add(cardDatabase[i]);
                }
            }
            //else if(cardDatabase[i].cardName == "Blast" && !cardDatabase[i].upgraded)
            //{
            //    for (int j = 0; j < 4; j++)
            //    {
            //        deck.Add(cardDatabase[i]);
            //    }
            //}
            else if(cardDatabase[i].cardName == "Solar Reflection" && !cardDatabase[i].upgraded)
            {
                deck.Add(cardDatabase[i]);
            }
            //Replaced Blast with this for testing purposes
            else if (cardDatabase[i].cardName == "Phalanx Formation" && !cardDatabase[i].upgraded)
            {
                for (int j = 0; j < 4; j++)
                {
                    deck.Add(cardDatabase[i]);
                }
            }
        }
        return deck;
    }
}
