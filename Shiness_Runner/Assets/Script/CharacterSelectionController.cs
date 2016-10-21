using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class CharacterSelectionController : MonoBehaviour {

    private Image[] charImages;

    private Text currentPlayerText;

	// Use this for initialization
	void Start () {
        charImages = new Image[3];

        charImages[0] = transform.FindChild("Char1").GetComponent<Image>();
        charImages[1] = transform.FindChild("Char2").GetComponent<Image>();
        charImages[2] = transform.FindChild("Char3").GetComponent<Image>();

        currentPlayerText = transform.FindChild("CurrentPlayer/Text").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void HighlightCharacter(bool highlight, int index)
    {
        if (highlight)
        {
            if(index >= 0 && index < 3)
            {
                charImages[index].GetComponent<Outline>().effectColor = new Color(1f, 1f, 0f, 0.75f);
            }
        }
        else
        {
            if (index >= 0 && index < 3)
            {
                charImages[index].GetComponent<Outline>().effectColor = new Color(0f, 0f, 0f, 0.75f);
            }
        }
    }

    public void SetCurrentPlayerText(string text)
    {
        currentPlayerText.text = text;
    }

    public void GoGrey(int playernumber)
    {
        charImages[playernumber].DOBlendableColor(new Color32(0x54, 0x54, 0x54, 0xFF), 1f);
    }

    public void GoWhite(int playernumber)
    {
        charImages[playernumber].GetComponentInChildren<Image>().DOBlendableColor(Color.white, 1f);
    }
}
