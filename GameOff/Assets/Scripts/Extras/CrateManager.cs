using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrateManager : MonoBehaviour {

    public static CrateManager instance;
    void Awake()
    {
        instance = this;
    }

    public Animator anim;
    public GameObject panel;

    GameObject currentCrate;

    bool panelOpen;

    public int maxItemCount = 3;
    int currentItemsRemaining;

    public int totalCrates = 2;

    public GameObject cratePrefab;
    public Transform panelTransform;


    #region cardVar

    public Text health;
    public Text cost;
    public Text atk;
    public Text cardName;
    public Text description;
    public Image icon;

    #endregion


    // Use this for initialization
    void Start () {
        currentItemsRemaining = maxItemCount;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && DeckManager0.instance.newCards.Count <= 0 && panelOpen == true)
        {
            Destroy(currentCrate);
            panel.SetActive(false);
            panelOpen = false;
            currentItemsRemaining = maxItemCount;
            AudioManager.instance.PlaySound("CollectItem");
        }
        else if (Input.GetMouseButtonDown(0) && currentItemsRemaining > 0 && panelOpen == true)
        {
            anim.SetTrigger("OnClick");
            currentItemsRemaining--;


            int roll = Random.Range(0, DeckManager0.instance.newCards.Count);
            health.text = DeckManager0.instance.newCards[roll].maxHealth.ToString();
            cost.text = DeckManager0.instance.newCards[roll].cost.ToString();
            atk.text = DeckManager0.instance.newCards[roll].damage.ToString();
            cardName.text = DeckManager0.instance.newCards[roll].cardName.ToString();
            description.text = DeckManager0.instance.newCards[roll].description.ToString();
            icon.sprite = DeckManager0.instance.newCards[roll].icon;
            AudioManager.instance.PlaySound("CollectItem");

            DeckManager0.instance.AddCard(DeckManager0.instance.newCards[roll]);
        }
        else if(Input.GetMouseButtonDown(0) && panelOpen == true)
        {
            Destroy(currentCrate);
            panel.SetActive(false);
            panelOpen = false;
            currentItemsRemaining = maxItemCount;
            AudioManager.instance.PlaySound("CollectItem");
        }
	}

    public void OpenCrate(GameObject crate)
    {
        totalCrates--;

        panel.SetActive(true);
        currentCrate = crate;

        panelOpen = true;
        anim.SetTrigger("Open");
        currentItemsRemaining--;

        int roll = Random.Range(0, DeckManager0.instance.newCards.Count);

        health.text = DeckManager0.instance.newCards[roll].maxHealth.ToString();
        cost.text = DeckManager0.instance.newCards[roll].cost.ToString();
        atk.text = DeckManager0.instance.newCards[roll].damage.ToString();
        cardName.text = DeckManager0.instance.newCards[roll].cardName.ToString();
        description.text = DeckManager0.instance.newCards[roll].description.ToString();
        icon.sprite = DeckManager0.instance.newCards[roll].icon;

        AudioManager.instance.PlaySound("OpenCrate");
        DeckManager0.instance.AddCard(DeckManager0.instance.newCards[roll]);

    }

    public void AddCrate()
    {
         GameObject _crate = Instantiate(cratePrefab);
        _crate.transform.SetParent(panelTransform);
        totalCrates++;
    }



}
