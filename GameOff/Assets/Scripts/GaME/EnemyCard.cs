using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCard : MonoBehaviour {


    public Card card;

    float maxHealth;
    public float currentHealth;

    public Text healthText;
    public Text costText;
    public Text atkText;
    public Image icon;
    public Text Name;
    public Text description;


    float timer;
    public float maxTimer;

    public bool isFront;

    Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GameObject.Find("EnemyFront").GetComponent<Animator>();

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
    void Update()
    {
        if (isFront == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Attack();
            }
        }

        if (card.ability == Ability.BoostEnergy)
        {
            if (EnemyAI.instance.currentEnergy < EnemyAI.instance.maxEnergy - 0.1f)
            {
                EnemyAI.instance.currentEnergy += (0.4f * Time.deltaTime);
            }

        }



    }

    public void Attack()
    {
        anim.SetTrigger("Attack");

        foreach (InGameCard gameCard in HandManager.instance.cardsInBench)
        {
            if(gameCard.card.ability == Ability.Shield)
            {
                gameCard.TakeDamage(card.damage);
                timer = maxTimer;
                return;
            }
        }
        
        if (card.ability == Ability.DirectAttack)
        {
            
            Player.instance.TakeDamage(card.damage);
        }
        else if (card.ability == Ability.BenchAttack)
        {
            for (int i = 0; i < HandManager.instance.cardsInBench.Count; i++)
            {
                HandManager.instance.cardsInBench[i].TakeDamage(card.damage);
            }
            if(HandManager.instance.cardInFront != null)
            {
                HandManager.instance.cardInFront.TakeDamage(card.damage);
            }
        }
        else if (HandManager.instance.cardInFront == null)
        {
            Player.instance.TakeDamage(card.damage);
        }
        else
        {
            HandManager.instance.cardInFront.GetComponent<InGameCard>().TakeDamage(card.damage);
        }

        timer = maxTimer;
    }

    public void TakeDamage(float amount)
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlaySound("CardHit");
        }
        currentHealth -= amount;
        if(healthText != null )
        healthText.text = Mathf.Floor(currentHealth).ToString();
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }


}

