using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeckMaker : MonoBehaviour {

    public static DeckMaker instance;
    void Awake()
    {
        instance = this;
    }

    public GameObject deckPanel;

    public Transform contentTransform;
    public GameObject cardObject;

    public List<GameObject> cardObjects;


    public Text cardsInDeckText;

	// Use this for initialization
	void Start () {
        foreach (Card card in DeckManager0.instance.ownedCards)
        {
            AddCard(card);

            DeckManager0.instance.newCards.Remove(card);
        }
        cardsInDeckText.text = DeckManager0.instance.cardsInDeckAmount + " / " + DeckManager0.instance.maxCardsInDeck;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void AddCard(Card card)
    {
        GameObject _cardObject = Instantiate(cardObject);
        _cardObject.transform.SetParent(contentTransform);
        _cardObject.GetComponent<DeckBuilderCard>().card = card;
        cardObjects.Add(_cardObject);
    }
    public void AddCardToDeck(DeckBuilderCard cardObj)
    {
        if(DeckManager0.instance.cardsInDeckAmount < DeckManager0.instance.maxCardsInDeck && cardObj.currentVal < cardObj.maxVal)
        {
            AudioManager.instance.PlaySound("AddCard");
            cardObj.currentVal++;
            DeckManager0.instance.currentDeck.Add(cardObj.card);
            DeckManager0.instance.cardsInDeckIndex.Add(cardObj.card.index);
            DeckManager0.instance.cardsInDeckAmount++;
            cardsInDeckText.text = DeckManager0.instance.cardsInDeckAmount + " / " + DeckManager0.instance.maxCardsInDeck;
        }
    }
    public void RemoveCardFromDeck(DeckBuilderCard cardObj)
    {
        if(cardObj.currentVal > 0)
        {
            AudioManager.instance.PlaySound("AddCard");
            cardObj.currentVal--;
            DeckManager0.instance.currentDeck.Remove(cardObj.card);
            DeckManager0.instance.cardsInDeckIndex.Remove(cardObj.card.index);
            DeckManager0.instance.cardsInDeckAmount--;
            cardsInDeckText.text = DeckManager0.instance.cardsInDeckAmount + " / " + DeckManager0.instance.maxCardsInDeck;
        }
    }
    public void OpenPanel()
    {
        AudioManager.instance.PlaySound("ButtonClick");
        deckPanel.SetActive(true);
        cardsInDeckText.text = DeckManager0.instance.cardsInDeckAmount + " / " + DeckManager0.instance.maxCardsInDeck;
        for (int i = 0; i < cardObjects.Count; i++)
        {
            cardObjects[i].GetComponent<DeckBuilderCard>().currentVal = PlayerPrefs.GetInt("currentVal" + i);
            cardObjects[i].GetComponent<DeckBuilderCard>().amountText.text = cardObjects[i].GetComponent<DeckBuilderCard>().currentVal + " / " + cardObjects[i].GetComponent<DeckBuilderCard>().maxVal;
        }
    }
    public void Exit()
    {
        AudioManager.instance.PlaySound("ButtonClick");
        DeckManager0.instance.SaveGame();
        for (int i = 0; i < cardObjects.Count; i++)
        {
            PlayerPrefs.SetInt("currentVal" + i, cardObjects[i].GetComponent<DeckBuilderCard>().currentVal);
        }
        deckPanel.SetActive(false);
    }
    public void ExitScene()
    {
        SceneManager.LoadScene(2);
    }
    public void ExitSound()
    {
        AudioManager.instance.PlaySound("CardHit");
    }

}
