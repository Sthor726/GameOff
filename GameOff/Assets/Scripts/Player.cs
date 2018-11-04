using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public static Player instance;
    void Awake()
    {
        instance = this;
    }


    public float maxHealth = 100f;
    float currentHealth;
    public float maxEnergy = 10f;
    public float currentEnergy;

    public float energyPerSecond = 1.5f;
    public Text energyText;

    public Slider healthSlider;
    public Slider energySlider;

	// Use this for initialization
	void Start () {

        currentHealth = maxHealth;
        energySlider.value = currentEnergy / maxEnergy;
        healthSlider.value = currentHealth / maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
        if(currentEnergy < maxEnergy)
        {
            currentEnergy += energyPerSecond * Time.deltaTime;
            energyText.text = Mathf.Floor(currentEnergy).ToString();
            energySlider.value = currentEnergy / maxEnergy;
        }

	}

public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        healthSlider.value = currentHealth / maxHealth;
        if(currentHealth <= 0)
        {
            //Die();
        }
    }

}
