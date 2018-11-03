using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject {

    public string cardName = "Card Name";

    public float damage;
    public float maxHealth;
    public float cost;

    public Sprite icon;

    public Ability ability = 0;

}
public enum Ability { None, BoostEnergy,}