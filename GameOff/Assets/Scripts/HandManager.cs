using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour {

    public List<GameObject> cardsInHand;
    public Card[] cardsInDeck;

    public int amountToFill;

    public GameObject CardObject;
    public Transform handTransform;

	// Use this for initialization
	void Start () {
        RefillHand();
	}
	
	// Update is called once per frame
	void Update () {
		if(cardsInHand.Count <= 0)
        {
            RefillHand();
        }

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
