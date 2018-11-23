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

    public Animator shakeAnim;

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
    public Slider energySlider;

    public float currentEnergy;
    public float maxEnergy = 10f;

    bool filledFront;

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
            currentEnergy += .9f * Time.deltaTime;
            energySlider.value = currentEnergy / maxEnergy;
        }

        if(currentEnergy >= selectedCard.cost)
        {
            PlaceCard();
        }

        if(frontCard == null && cardsOnBench.Count > 0 && filledFront == false)
        {
            filledFront = true;
            StartCoroutine(MissingFront());

        }

        for (int i = 0; i < cardsOnBench.Count; i++)
        {
            if (cardsOnBench[i] == null)
            {
                cardsOnBench.Remove(cardsOnBench[i]);
            }
        }

	}

public void TakeDamage(float amount)
    {
        if(EndGame.instance.gameEnded == false)
        {
            if (AudioManager.instance != null)
            {
                shakeAnim.SetTrigger("Shake");
                AudioManager.instance.PlaySound("Hit");
            }
            currentHealth -= amount;
            healthSlider.value = currentHealth / maxHealth;
            if (currentHealth <= 0)
            {
                EndGame.instance.OnGameEnded(true, 50f, false);
            }
        }
        
    }

    void PlaceCard()
    {
        
        if (cardsOnBench.Count < 5)
            {
                currentEnergy -= selectedCard.cost;

                GameObject _cardObject = Instantiate(cardObject, transform.position, transform.rotation);
                _cardObject.transform.SetParent(benchTransform);
                cardsOnBench.Add(_cardObject.GetComponent<EnemyCard>());
                _cardObject.GetComponent<EnemyCard>().card = selectedCard;

                int roll = Random.Range(0, deck.Length);
                selectedCard = deck[roll];


            }
            else
            {
            return;
        }
    }

    IEnumerator MissingFront()
    {
        yield return new WaitForSeconds(3f);

        for (int i = 0; i < cardsOnBench.Count; i++)
        {
            if (cardsOnBench[i].card.ability == Ability.DirectAttack)
            {
                FillFront(cardsOnBench[i]);

                yield break;
            }

            if (cardsOnBench[i].card.ability != Ability.BoostEnergy)
            {
                FillFront(cardsOnBench[i]);

                yield break;
            }


        }

        int _roll = Random.Range(0, cardsOnBench.Count);
        FillFront(cardsOnBench[_roll]);


    }

    void FillFront(EnemyCard benchedCard)
    {

      

        GameObject _cardObject = Instantiate(cardObject, transform.position, transform.rotation);
        _cardObject.transform.SetParent(frontTransform);
        _cardObject.GetComponent<EnemyCard>().isFront = true;
        frontCard = _cardObject.GetComponent<EnemyCard>();

        _cardObject.GetComponent<EnemyCard>().card = benchedCard.card;
        _cardObject.GetComponent<EnemyCard>().currentHealth = benchedCard.currentHealth;
        if(benchedCard != null)
        Destroy(benchedCard.gameObject);
        filledFront = false;
    }

}
