using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    //FEEDBACK QUAND POINTER EST SUR LE BOUTON
    public void OverButton(string buttonname)
    {
        switch (buttonname)
        {
            case "Retry":
                GetComponent<Text>().color = new Color(0f, 0f, 0f);
                GetComponent<Outline>().effectColor = new Color(1f, 1f, 1f, 0.75f);
                break;

            case "Quit":
                GetComponent<Text>().color = new Color(0f, 0f, 0f);
                GetComponent<Outline>().effectColor = new Color(1f, 1f, 1f, 0.75f);
                break;
        }
    }

    //FEEDBACK QUAND POINTER QUITE LE BOUTON
    public void ExitButton(string buttonname)
    {
        switch (buttonname)
        {
            case "Retry":
                GetComponent<Text>().color = new Color(1f, 1f, 1f);
                GetComponent<Outline>().effectColor = new Color(0f, 0f, 0f, 0.75f);
                break;

            case "Quit":
                GetComponent<Text>().color = new Color(1f, 1f, 1f);
                GetComponent<Outline>().effectColor = new Color(0f, 0f, 0f, 0.75f);
                break;
        }
    }

    //FONCTION QUAND CLIC BOUTON
    public void ClicButton(string buttonname)
    {
        switch (buttonname)
        {
            case "Retry":
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                break;

            case "Quit":
                Application.Quit();
                break;
        }
    }
}
