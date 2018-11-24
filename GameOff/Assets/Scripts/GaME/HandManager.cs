using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour {

    public static HandManager instance;
    void Awake()
    {
        instance = this;
    }

    public List<GameObject> cardsInHand;
    public List<Card> cardsInDeck;

    public int amountToFill;

    public GameObject CardObject;
    public Transform handTransform;

    public List<InGameCard> cardsInBench;
    [HideInInspector]
    public InGameCard cardInFront;

    public Transform front;
    public Transform bench;

	// Use this for initialization
	void Start () {

        if(DeckManager0.instance != null)
        {
            for (int i = 0; i < DeckManager0.instance.currentDeck.Count; i++)
            {
                cardsInDeck.Add(DeckManager0.instance.currentDeck[i]);
            }
        }

        int amount = 0;
        if (cardsInDeck.Count >= 5)
        {
            amount = amountToFill - cardsInHand.Count;
        }
        else if (cardsInDeck.Count > 0)
        {
            amount = cardsInDeck.Count;
        }
        for (int i = 0; i < amount; i++)
        {
            int roll = Random.Range(0, cardsInDeck.Count);

            GameObject _cardObject = Instantiate(CardObject, transform.position, transform.rotation);
            cardsInHand.Add(_cardObject);
            _cardObject.GetComponent<CardObject>().card = cardsInDeck[roll];
            _cardObject.transform.SetParent(handTransform);
        }
    }
	

	// Update is called once per frame
	void Update () { 

        for (int i = 0; i < cardsInHand.Count; i++)
        {
            if(cardsInHand[i] == null)
            {
                cardsInHand.Remove(cardsInHand[i]);
            }
        }
        if(cardsInBench.Count <= 0 && cardInFront == null && cardsInDeck.Count <= 0)
        {
            EndGame.instance.OnGameEnded(false, 0, true);
        }
    }


public void RefillHand()
    {
        if(EndGame.instance.gameEnded == false)
        {
            if (Player.instance.currentEnergy >= 3)
            {
                int amount;
                Player.instance.currentEnergy -= 3;
                if (cardsInDeck.Count >= 5)
                {
                    amount = amountToFill - cardsInHand.Count;
                }
                else if (cardsInDeck.Count > 0)
                {
                    amount = cardsInDeck.Count;
                }
                else
                {
                    amount = 0;
                   
                }

                for (int i = 0; i < amount; i++)
                {
                    int roll = Random.Range(0, cardsInDeck.Count);

                    GameObject _cardObject = Instantiate(CardObject, transform.position, transform.rotation);
                    cardsInHand.Add(_cardObject);
                    _cardObject.GetComponent<CardObject>().card = cardsInDeck[roll];
                    _cardObject.transform.SetParent(handTransform);
                    cardsInDeck.Remove(_cardObject.GetComponent<CardObject>().card);
                }
            }
        }
       
        
    }

}
