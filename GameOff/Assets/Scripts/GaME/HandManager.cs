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
    public Card[] cardsInDeck;

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
        int amount = amountToFill - cardsInHand.Count;
        for (int i = 0; i < amount; i++)
        {
            int roll = Random.Range(0, cardsInDeck.Length);

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

    }


public void RefillHand()
    {

        if(Player.instance.currentEnergy >= 3)
        {
            Player.instance.currentEnergy -= 3;
            int amount = amountToFill - cardsInHand.Count;
            for (int i = 0; i < amount; i++)
            {
                int roll = Random.Range(0, cardsInDeck.Length);

                GameObject _cardObject = Instantiate(CardObject, transform.position, transform.rotation);
                cardsInHand.Add(_cardObject);
                _cardObject.GetComponent<CardObject>().card = cardsInDeck[roll];
                _cardObject.transform.SetParent(handTransform);
            }
        }
        
    }

}
