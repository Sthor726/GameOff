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

    public GameObject gameCard;
    Transform bench;
    Transform front;


	// Use this for initialization
	void Start () {

        dmgText.text = card.damage.ToString();
        costText.text = card.cost.ToString();
        healthText.text = card.maxHealth.ToString();
        nameText.text = card.cardName;
        descriptionText.text = "Ability: " + card.ability.ToString();
        image.sprite = card.icon;

        front = GameObject.Find("Front").transform;
        bench = GameObject.Find("Bench").transform;
	}
	
    public void OnClick()
    {
        if(Player.instance.currentEnergy >= card.cost && HandManager.instance.cardInFront == null)
        {
            Player.instance.currentEnergy -= card.cost;
            GameObject _gameCard = Instantiate(gameCard, transform.position, transform.rotation);
            _gameCard.GetComponent<InGameCard>().card = card;
            _gameCard.transform.SetParent(front);
            HandManager.instance.cardInFront = _gameCard.GetComponent<InGameCard>();
            _gameCard.GetComponent<InGameCard>().isFront = true;
            Destroy(gameObject);
        }
        else if(Player.instance.currentEnergy >= card.cost && HandManager.instance.cardsInBench < 5)
        {

            Player.instance.currentEnergy -= card.cost;
            HandManager.instance.cardsInBench++;
            GameObject _gameCard = Instantiate(gameCard, transform.position, transform.rotation);
            _gameCard.GetComponent<InGameCard>().card = card;
            _gameCard.transform.SetParent(bench);
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
