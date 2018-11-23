using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckBuilderCard : MonoBehaviour {

    public Text cardName;
    public Text cardDescription;
    public Text healthTxt;
    public Text costTxt;
    public Text AttackTxt;
    public Image icon;
    public Card card;

    public Text amountText;

    public int currentVal = 0;
    public int maxVal = 4;

    void Start()
    {
        cardName.text = card.cardName;
        cardDescription.text = card.description;
        healthTxt.text = card.maxHealth.ToString();
        costTxt.text = card.cost.ToString();
        AttackTxt.text = card.damage.ToString();
        icon.sprite = card.icon;

        amountText.text = currentVal + " / " + maxVal;
    }

    public void Add()
    {
        DeckMaker.instance.AddCardToDeck(this);
        amountText.text = currentVal + " / " + maxVal;

    }
    public void Subtract()
    {
        DeckMaker.instance.RemoveCardFromDeck(this);
        amountText.text = currentVal + " / " + maxVal;

    }

}
