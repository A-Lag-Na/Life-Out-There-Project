using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    public static List<c_Card> deck = new List<c_Card>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            AddCard(c_CardDatabase.cardList[0]);
        }
        for (int i = 0; i < 5; i++)
        {
            AddCard(c_CardDatabase.cardList[1]);
        }

        Shuffle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCard(c_Card _card)
    {
        deck.Add(_card);
    }

    public List<c_Card> GetCards()
    {
        return deck;
    }

    public void Shuffle()
    {
        c_Card temp;

        for (int i = 0; i < deck.Count; i++)
        {
            temp = deck[i];
            int randomIndex = UnityEngine.Random.Range(i, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }
}
