using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnMouseEnter(string buttonname)
    {
        switch (buttonname)
        {
            case "TryAgain":
                Debug.Log("fok");
                break;
        }
    }
}
