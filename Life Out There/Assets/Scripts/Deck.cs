using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Deck : MonoBehaviour
{
    public static List<c_Card> deck = new List<c_Card>();

    public GameObject cardInDeck;
    public GameObject cardInDeck1;
    public GameObject cardInDeck2;
    public GameObject cardInDeck3;

    public TextMeshProUGUI deckCount;

    // Start is called before the first frame update
    void Awake()
    {
       deck =  c_CardDatabase.CreateExplorerStartDeck(deck);
        Shuffle();
    }

    // Update is called once per frame
    void Update()
    {
        deckCount.SetText(deck.Count.ToString());

        if (deck.Count < 30)
            cardInDeck3.SetActive(false);
        if (deck.Count < 20)
            cardInDeck2.SetActive(false);
        if (deck.Count < 10)
            cardInDeck1.SetActive(false);
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
