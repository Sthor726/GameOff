using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardShop : MonoBehaviour {

    public Text cardName;
    public Text descriptionName;
    public Text healthText;
    public Text costText;
    public Text atkText;
    public Image icon;

    public int cost;

    public List<Card> cardsToBuy;
    [SerializeField]
    Card currentCard;
    [SerializeField]
    int currentCardInt = 0;

	// Use this for initialization
	void Start () {
        currentCard = cardsToBuy[0];
        UpdateUI();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NextCard()
    {
        if(currentCardInt < cardsToBuy.Count - 1)
        {
            currentCardInt++;
            currentCard = cardsToBuy[currentCardInt];
        }
        else
        {
            currentCardInt = 0;
            currentCard = cardsToBuy[currentCardInt];
        }
        UpdateUI();

    }
    public void PreviousCard()
    {
        if(currentCardInt > 0)
        {
            currentCardInt--;
            currentCard = cardsToBuy[currentCardInt];
        }
        else
        {
            currentCardInt = cardsToBuy.Count - 1;
            currentCard = cardsToBuy[currentCardInt];
        }
        UpdateUI();
    }
    

    void UpdateUI()
    {
        cardName.text = currentCard.cardName;
        descriptionName.text = currentCard.description;
        healthText.text = currentCard.maxHealth.ToString();
        costText.text = currentCard.cost.ToString();
        atkText.text = currentCard.damage.ToString();
        icon.sprite = currentCard.icon;
}

}
