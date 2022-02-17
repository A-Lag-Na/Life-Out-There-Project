using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Deck : MonoBehaviour
{
    public static List<c_BaseCard> deck = new List<c_BaseCard>();

    public GameObject cardInDeck;
    public GameObject cardInDeck1;
    public GameObject cardInDeck2;
    public GameObject cardInDeck3;

    public TextMeshProUGUI deckCount;

    // Start is called before the first frame update
    void Awake()
    {
        deck.Clear();
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

    public void AddCard(c_BaseCard _card)
    {
        deck.Add(_card);
    }

    public List<c_BaseCard> GetCards()
    {
        return deck;
    }

    public void Shuffle()
    {
        c_BaseCard temp;

        for (int i = 0; i < deck.Count; i++)
        {
            temp = deck[i];
            int randomIndex = UnityEngine.Random.Range(i, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }
    
}
