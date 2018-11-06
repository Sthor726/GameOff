using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager0 : MonoBehaviour {

    public static DeckManager0 instance;
    void Awake()
    {
        instance = this;
    }

    public List<Card> ownedCards;
    public List<Card> currentDeck = new List<Card>(50);

    public Card[] starterCards;
    public Card[] starterDeck;

	// Use this for initialization
	void Start () {

        for (int i = 0; i < starterCards.Length; i++)
        {
            ownedCards.Add(starterCards[i]);
        }
        for (int i = 0; i < starterDeck.Length; i++)
        {
            currentDeck.Add(starterDeck[i]);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void AddCard()
    {

    }

    public void RemoveCard()
    {

    }



}
