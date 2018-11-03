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

	// Use this for initialization
	void Start () {

        dmgText.text = card.damage.ToString();
        costText.text = card.cost.ToString();
        healthText.text = card.maxHealth.ToString();
        nameText.text = card.cardName;
        descriptionText.text = card.ability.ToString();

	}
	
    void OnClick()
    {
        //instantiate card in game
        Destroy(gameObject);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
