using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {

    public AudioSource audioSource;
    public Canvas canvas;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            canvas.gameObject.GetComponent<Animator>().SetTrigger("ExitScene");
        }


	}

    public void TextEffect()
    {
        audioSource.Play();
 
    }
   public void StartMusic()
    {
        GameObject.Find("Music").GetComponent<AudioSource>().Play();
    }
    public void ExitScene()
    {
        SceneManager.LoadScene(1);
    }

}
