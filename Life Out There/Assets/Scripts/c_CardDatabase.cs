using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_CardDatabase : MonoBehaviour
{
    public c_Card blankCard = null;
    public static List<c_Card> cardDatabase = new List<c_Card>();

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

            int damage = int.Parse(data[i]["Damage"].ToString(), System.Globalization.NumberStyles.Integer);



            AddCard(cardId, cardCost, cardName, cardType, cardDescription, thisImage, cardCharacter, cardRarity, exhaust, damage);
        }
    }

    void AddCard(int cardId, int cardCost, string cardName, string cardType, string cardDescription, Sprite thisImage, string cardCharacter, string cardRarity, bool exhaust, int damage)
    {
        c_Card tempCard = new c_Card(cardId, cardCost, cardName, cardType, cardDescription, thisImage, cardCharacter, cardRarity, exhaust, damage);

        cardDatabase.Add(tempCard);
    }

    public static List<c_Card> CreateExplorerStartDeck(List<c_Card> deck)
    {
        for (int i = 0; i < cardDatabase.Count; i++)
        {
            if (cardDatabase[i].cardName == "Barrier" && !cardDatabase[i].cardName.Contains("+"))
            {
                for (int l = 0; l < 5; l++)
                {
                    deck.Add(cardDatabase[i]);
                }
            }
            else if(cardDatabase[i].cardName == "Blast" && !cardDatabase[i].cardName.Contains("+"))
            {
                for (int j = 0; j < 4; j++)
                {
                    deck.Add(cardDatabase[i]);
                }
            }
            else if(cardDatabase[i].cardName == "Solar Reflection" && !cardDatabase[i].cardName.Contains("+"))
            {
                deck.Add(cardDatabase[i]);
            }
        }

        return deck;
    }
}
