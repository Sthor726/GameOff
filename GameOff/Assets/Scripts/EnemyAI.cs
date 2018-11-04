using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public static EnemyAI instance;
    void Awake()
    {
        instance = this;
    }

    public Card[] deck;
    public List<InGameCard> cardsOnBench;
    public CardObject frontCard;

    Transform benchTransform;
    Transform frontTransform;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
