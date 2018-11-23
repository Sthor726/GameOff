using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeckManager0 : MonoBehaviour {

    public static DeckManager0 instance;
    public List<Card> ownedCards;
    public List<Card> currentDeck = new List<Card>(50);


    public List<int> cardsInDeckIndex;
    [SerializeField]
    public int cardsInDeckAmount;

    public List<int> ownedCardsIndex;
    [SerializeField]
    public int ownedCardsAmount;

    public Card[] allCards;
    public List<Card> newCards;

    public int coins = 50;
    public int maxCardsInDeck = 50;
    int firstRun = 0;

    void Awake()
    {

        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        for (int i = 0; i < allCards.Length; i++)
        {
            newCards.Add(allCards[i]);
        }

        firstRun = PlayerPrefs.GetInt("firstSavedRun");
        if (firstRun == 0)
        {
            PlayerPrefs.SetInt("firstSavedRun", firstRun + 1);

            currentDeck.Clear();
            cardsInDeckAmount = 0;
            cardsInDeckIndex.Clear();
            ownedCards.Clear();
            cardsInDeckIndex.Clear();
            cardsInDeckAmount = 0;
            for (int i = 0; i < 2; i++)
            {
                CrateManager.instance.AddCrate();
            }

        }
        else
        {
            LoadInfo();

            //run a welcome back sequence
        }


    }

   




	// Use this for initialization
	void Start () {

        
        SaveGame();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteAll();
        }
	}


    public void AddCard(Card card)
    {
        ownedCards.Add(card);
        ownedCardsAmount++;
        ownedCardsIndex.Add(card.index);
      DeckMaker.instance.AddCard(card);
        newCards.Remove(card);
    }



    public void SaveGame()
    {
        for (int i = 0; i < cardsInDeckIndex.Count; i++)
        {
            PlayerPrefs.SetInt("cardsInDeckIndexP" + i, cardsInDeckIndex[i]);
        }
        for (int i = 0; i < ownedCardsIndex.Count; i++)
        {
            PlayerPrefs.SetInt("ownedCardsIndexP" + i, ownedCardsIndex[i]);
        }
        PlayerPrefs.SetInt("cardsInDeckAmount", cardsInDeckAmount);
        PlayerPrefs.SetInt("ownedCardsAmount", ownedCardsAmount);

        PlayerPrefs.SetInt("coins", coins);


    }

    public void LoadInfo()
    {

        cardsInDeckAmount = PlayerPrefs.GetInt("cardsInDeckAmount");
        ownedCardsAmount = PlayerPrefs.GetInt("ownedCardsAmount");

        coins = PlayerPrefs.GetInt("coins");
        for (int i = 0; i < PlayerPrefs.GetInt("ownedCardsAmount"); i++)
        {
            ownedCardsIndex.Add(PlayerPrefs.GetInt("ownedCardsIndexP" + i));
        }
        for (int i = 0; i < PlayerPrefs.GetInt("cardsInDeckAmount"); i++)
        {
            cardsInDeckIndex.Add(PlayerPrefs.GetInt("cardsInDeckIndexP" + i));

        }

        for (int i = 0; i < ownedCardsIndex.Count; i++)
        {
            for (int z = 0; z < allCards.Length; z++)
            {
                if (allCards[z].index == ownedCardsIndex[i])
                {
                    ownedCards.Add(allCards[z]);
                }
        }
        }
        for (int i = 0; i < cardsInDeckIndex.Count; i++)
        {
            for (int z = 0; z < allCards.Length; z++)
            {
                if (allCards[z].index == cardsInDeckIndex[i])
                {
                    currentDeck.Add(allCards[z]);
                }
            }
        }

        
    }
    

}
