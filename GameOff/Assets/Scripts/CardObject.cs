using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardObject : MonoBehaviour {

    public Card card;

    public Text dmgText; 
    public Text costText; 
    public Text healthText; 
    public Text nameText; 
    public Text descriptionText;

    public Image image;

	// Use this for initialization
	void Start () {

        dmgText.text = card.damage.ToString();
        costText.text = card.cost.ToString();
        healthText.text = card.maxHealth.ToString();
        nameText.text = card.cardName;
        descriptionText.text = "Ability: " + card.ability.ToString();
        image.sprite = card.icon;
	}
	
    public void OnClick()
    {
        if(Player.instance.currentEnergy >= card.cost)
        {

            Player.instance.currentEnergy -= card.cost;

            //instantiate card in game
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Not Enough Energy");
        }

        
    }

	// Update is called once per frame
	void Update () {
		
	}
}
