using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public GameObject attackCard;
    public GameObject blockCard;
    List<GameObject> deck = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            AddCard(attackCard);
        }
        for (int i = 0; i < 5; i++)
        {
            AddCard(blockCard);
        }
        Shuffle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCard(GameObject _card)
    {
        deck.Add(_card);
    }

    public List<GameObject> GetCards()
    {
        return deck;
    }

    public void Shuffle()
    {
        GameObject temp;

        for (int i = 0; i < deck.Count; i++)
        {
            temp = deck[i];
            int randomIndex = UnityEngine.Random.Range(i, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }

}
