﻿using System.Collections;
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
	void Update () {
        if(isFront == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Attack();
            }
        }
        
        if(card.ability == Ability.BoostEnergy)
        {
            if(Player.instance.currentEnergy < Player.instance.maxEnergy - 0.1f)
            {
                Player.instance.currentEnergy += (0.7f * Time.deltaTime);
            }

        }
        


	}

public void Attack()
    {
        if(card.ability == Ability.DirectAttack)
        {
            EnemyAI.instance.TakeDamage(card.damage);
        }
        else if(card.ability == Ability.BenchAttack)
        {
            for (int i = 0; i < EnemyAI.instance.cardsOnBench.Count; i++)
            {
                EnemyAI.instance.cardsOnBench[i].TakeDamage(card.damage);
            }
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
        }
    }

}
