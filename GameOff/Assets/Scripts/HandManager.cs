using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour {

    public List<GameObject> cardsInHand;
    public Card[] cardsInDeck;

    public int amountToFill;

    public GameObject CardObject;
    Transform handTransform;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


public void RefillHand()
    {
        int amount = amountToFill - cardsInHand.Count;
        for (int i = 0; i < amount; i++)
        {
            int roll = Random.Range(0, cardsInDeck.Length);

            GameObject _cardObject = Instantiate(CardObject, transform.position, transform.rotation);
            _cardObject.GetComponent<CardObject>().card = cardsInDeck[roll];
            _cardObject.transform.SetParent(handTransform);
        }
    }

}
