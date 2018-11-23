using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour {

	public void OnClick()
    {
        CrateManager.instance.OpenCrate(gameObject);
        {

        }
    }
}
