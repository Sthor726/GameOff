using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameCard : MonoBehaviour {

    public Card card;

    float maxHealth;
    float currentHealth;

    public Text healthText;
    public Text costText;
    public Text atkText;
    public Image icon;
    public Text Name;
    public Text description;


    float timer;
    public float maxTimer;

    public bool isFront;


	// Use this for initialization
	void Start () {
        maxTimer = card.attackTimer;
        timer = maxTimer;
        maxHealth = card.maxHealth;
        currentHealth = maxHealth;
        healthText.text = currentHealth.ToString();

        costText.text = Mathf.Floor(card.cost).ToString();
        atkText.text = Mathf.Floor(card.damage).ToString();
        description.text = card.description;
        Name.text = card.cardName;
        icon.sprite = card.icon;
    }

    // Update is called once per frame
    void Update() {

        if (card.ability == Ability.BoostEnergy)
        {
            timer -= Time.deltaTime;
        }
        
        if (card.ability == Ability.BoostEnergy && timer <= 0)
        {
            if (Player.instance.currentEnergy < Player.instance.maxEnergy - 2f)
            {
                Player.instance.currentEnergy += 1.5f;
                timer = maxTimer;
            }

        }

        if (isFront == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
               
                
                
                    Attack();
                
                
            }
        }
        
        
        


	}

public void Attack()
    {
        if (card.ability == Ability.DirectAttack)
        {
            EnemyAI.instance.TakeDamage(card.damage);
        }
        else if(card.ability == Ability.BenchAttack)
        {
            foreach(EnemyCard enemyCard in EnemyAI.instance.cardsOnBench)
            {
                if(enemyCard != null)
                enemyCard.TakeDamage(card.damage);
            }
            if (EnemyAI.instance.frontCard != null)
                EnemyAI.instance.frontCard.TakeDamage(card.damage);
        } else if(EnemyAI.instance.frontCard == null)
        {
            EnemyAI.instance.TakeDamage(card.damage);
        }
        else
        {
            EnemyAI.instance.frontCard.GetComponent<EnemyCard>().TakeDamage(card.damage);
        }

        timer = maxTimer;

    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        healthText.text = Mathf.Floor(currentHealth).ToString();
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        HandManager.instance.cardsInBench.Remove(this);
        Destroy(gameObject);
    }

    public void OnClick()
    {
        if (HandManager.instance.cardInFront == null && isFront == false)
        {
            transform.SetParent(HandManager.instance.front);
            isFront = true;
            HandManager.instance.cardInFront = this;
            HandManager.instance.cardsInBench.Remove(this);
        }
        else if (HandManager.instance.cardsInBench.Count < 5 && isFront == true)
        {
            transform.SetParent(HandManager.instance.bench);
            isFront = false;
            HandManager.instance.cardInFront = null;
        }
    }

}
