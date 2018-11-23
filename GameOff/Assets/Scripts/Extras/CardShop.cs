using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CardShop : MonoBehaviour {

    public GameObject warningPanel;

    public Text coinsText;
    public GameObject optionsPanel;

    public int costBasicCrate;
    public int costMagicCrate;

    DeckManager0 deckManager;

	// Use this for initialization
	void Start () {
        deckManager = GameObject.Find("GameManager").GetComponent<DeckManager0>();

        coinsText.text = "$" + deckManager.coins.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	
   }

    public void BuyBasic()
    {
        deckManager = GameObject.Find("GameManager").GetComponent<DeckManager0>();
        if (CrateManager.instance.totalCrates < 2 && DeckManager0.instance.coins >= costBasicCrate)
        {
            DeckManager0.instance.coins -= costBasicCrate;
            CrateManager.instance.AddCrate();
            AudioManager.instance.PlaySound("BuyCrate");

            coinsText.text = "$" + deckManager.coins.ToString();
        }
    }


    public void Play()
    {
        AudioManager.instance.PlaySound("ButtonClick");
        if (DeckManager0.instance.cardsInDeckAmount <= 0)
        {
            warningPanel.SetActive(true);
        }
        else
        {
            GameObject.Find("Canvas").GetComponent<Animator>().SetTrigger("ExitScene");
            
            
        }
     
    }
    public void CloseWarningPanel()
    {
        AudioManager.instance.PlaySound("ButtonClick");
        warningPanel.SetActive(false);
    }
    public void Options()
    {
        AudioManager.instance.PlaySound("ButtonClick");
        optionsPanel.SetActive(true);
    }
    public void OptionsClose()
    {
        AudioManager.instance.PlaySound("ButtonClick");
        optionsPanel.SetActive(false);
    }



}
