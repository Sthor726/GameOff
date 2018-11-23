using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Tools : MonoBehaviour {

    [MenuItem("Tools/Reset PlayerPrefs")]
    public static void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
