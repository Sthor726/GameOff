using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyAI : MonoBehaviour {

    public static EnemyAI instance;
    void Awake()
    {
        instance = this;
    }

    public Card[] deck;
    public List<EnemyCard> cardsOnBench;
    public EnemyCard frontCard;

    public GameObject cardObject;

    public Card selectedCard;

    public Transform benchTransform;
    public Transform frontTransform;

    public float maxHealth = 100f;
    float currentHealth;
    public Slider healthSlider;

    public float currentEnergy;
    public float maxEnergy = 10f;


	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
        healthSlider.value = currentHealth / maxHealth;

        int roll = Random.Range(0, deck.Length);
        selectedCard = deck[roll];

    }
	
	// Update is called once per frame
	void Update () {
		
        if(currentEnergy < maxEnergy)
        {
            currentEnergy += 1 * Time.deltaTime;
        }

        if(currentEnergy >= selectedCard.cost)
        {
            PlaceCard();
        }

        if(frontCard == null && cardsOnBench.Count > 1)
        {
            FillFront(cardsOnBench[0].card);
        }

	}

public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        healthSlider.value = currentHealth / maxHealth;
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void PlaceCard()
    {
        
        if(cardsOnBench.Count < 4)
        {
            currentEnergy -= selectedCard.cost;

            GameObject _cardObject = Instantiate(cardObject, transform.position, transform.rotation);
            _cardObject.transform.SetParent(benchTransform);
            cardsOnBench.Add(_cardObject.GetComponent<EnemyCard>());
            _cardObject.GetComponent<EnemyCard>().card = selectedCard;

            int roll = Random.Range(0, deck.Length);
            selectedCard = deck[roll];

            
        }
    }

    void FillFront(Card benchedCard)
    {

        GameObject _cardObject = Instantiate(cardObject, transform.position, transform.rotation);
        _cardObject.transform.SetParent(frontTransform);
        _cardObject.GetComponent<EnemyCard>().isFront = true;
        frontCard = _cardObject.GetComponent<EnemyCard>();

        _cardObject.GetComponent<EnemyCard>().card = benchedCard;
        cardsOnBench.Remove(cardsOnBench[0]);
        Destroy(cardsOnBench[0].gameObject);
    }

}
