using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

    public static EndGame instance;
    void Awake()
    {
        instance = this;
    }

    public GameObject panel;
    public Text title;
    public Text earnedText;
    public bool gameEnded;

    public GameObject helpPanel;

    public void OnGameEnded(bool won, float amount, bool ranOutOfCards)
    {
        panel.SetActive(true);
        gameEnded = true;
        if(won == true)
        {
            title.text = "You Won!";
            StartCoroutine(addCoin(amount));
            AudioManager.instance.PlaySound("WinGame");
        }
        else if(ranOutOfCards == false)
        {
            title.text = "You Lost";
            earnedText.text = "You ran out of Health";
            AudioManager.instance.PlaySound("LoseGame");
        }
        else
        {
            title.text = "You Lost";
            earnedText.text = "You ran out of Cards";
            AudioManager.instance.PlaySound("LoseGame");
        }
    }

    public IEnumerator addCoin(float amount)
    {
        amount -= (amount / 2) - Random.Range(0, 15);
        float amountEarned = 0;
        while(amountEarned < amount)
        {
            amountEarned++;
            DeckManager0.instance.coins++;
            earnedText.text = "You Earned $" + amountEarned;
            yield return new WaitForSeconds(0.05f);
        }
    }


    public void Rematch()
    {
        GameObject.Find("Canvas").GetComponent<Animator>().SetTrigger("ReloadScene");
    }
    public void Menu()
    {
        GameObject.Find("Canvas").GetComponent<Animator>().SetTrigger("ExitScene");
    }
    public void Quit()
    {
        Application.Quit();
    }

public void ExitScene()
    {
        SceneManager.LoadScene(1);

    }
    public void ExitSound()
    {
        AudioManager.instance.PlaySound("CardHit");
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(2);
    }

    public void OpenHelpPanel()
    {
        helpPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void CloseHelpPanel()
    {
        Time.timeScale = 1;
        helpPanel.SetActive(false);
    }
}
