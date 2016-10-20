using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class UI : MonoBehaviour {

    public Text scoretext;
    public Text multiplier;
    public Slider extaz;
    public List<GameObject> players = new List<GameObject>();
    public List<Sprite> playersImage = new List<Sprite>();
    public List<GameObject> ranks = new List<GameObject>();
    public GameObject QuitButton;
    public GameObject RetryButton;
    private GameManager gameManager;

	public Sprite frameNotFull;
	public Sprite frameFull;
	public GameObject referenceToExtazFrame;

    float score;
    bool extazcanwow = true;

    // Use this for initialization
    void Start () {
        RotateScoreLeft();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {

        ScorePlayer();
        multiplier.text = "x" + gameManager.scoreMultiplier;
        score = Mathf.Round(gameManager.GetPlayerInfo(0).score) + Mathf.Round(gameManager.GetPlayerInfo(1).score) + Mathf.Round(gameManager.GetPlayerInfo(2).score);

        if(score < 10)
            scoretext.text = "00000" + score;
        else if(score >= 10 && score < 100)
            scoretext.text = "0000" + score;
        else if (score >= 100 && score < 1000)
            scoretext.text = "000" + score;
        else if (score >= 1000 && score < 10000)
            scoretext.text = "00" + score;
        else if (score >= 10000 && score < 100000)
            scoretext.text = "0" + score;
        else if (score >= 100000 && score < 1000000)
            scoretext.text = "0" + score;

        if (extaz.value >= 100 && extazcanwow == true)
        {
            ScaleSliderUp();
			frameFullAnimation ();
            extazcanwow = false;
        }else if(extaz.value < 100)
        {
            DOTween.Kill("ScaleUp");
            DOTween.Kill("ScaleDown");
            extazcanwow = true;
            extaz.transform.localScale = new Vector3(1, 1, 1);
        }

        if (gameManager.GetPlayerInfo(0).score > gameManager.GetPlayerInfo(1).score && gameManager.GetPlayerInfo(0).score > gameManager.GetPlayerInfo(2).score)
            ScaleProfileUp("Character1");
        else if (gameManager.GetPlayerInfo(1).score > gameManager.GetPlayerInfo(0).score && gameManager.GetPlayerInfo(1).score > gameManager.GetPlayerInfo(2).score)
            ScaleProfileUp("Character2");
        else if (gameManager.GetPlayerInfo(2).score > gameManager.GetPlayerInfo(0).score && gameManager.GetPlayerInfo(2).score > gameManager.GetPlayerInfo(1).score)
            ScaleProfileUp("Character3");

    }


    /*********************
    **SCORE ANITMATIONS**
    *********************/

    //ROTATION EFFECT
    void RotateScoreLeft()
    {
        scoretext.transform.DOLocalRotate(new Vector3(0, 0, 3), 2f).SetId("RotateLeft").SetEase(Ease.Linear).OnComplete(RotateScoreRight);
    }

    void RotateScoreRight()
    {
        scoretext.transform.DOLocalRotate(new Vector3(0, 0, -3), 2f).SetId("RotateRight").SetEase(Ease.Linear).OnComplete(RotateScoreLeft);
    }


    //RAINBOW EFFECT (à appeler quand on passe en mode Extaz par exemple)
    public void ScoreRed()
    {
        scoretext.DOBlendableColor(Color.red, 0.5f).OnComplete(ScoreYellow);
    }

    void ScoreYellow()
    {
        scoretext.DOBlendableColor(Color.yellow, 0.5f).OnComplete(ScoreGreen);
    }

    void ScoreGreen()
    {
        scoretext.DOBlendableColor(Color.green, 0.5f).OnComplete(ScoreBlue);
    }

    void ScoreBlue()
    {
        scoretext.DOBlendableColor(Color.cyan, 0.5f).OnComplete(ScoreRed);
    }


    /*********************
    **SLIDER ANITMATIONS**
    *********************/

    //BREATH EFFECT (à appeler quand la barre d'Extaz est à son maximum)
    public void ScaleSliderUp()
    {
        extaz.transform.DOScale(1.10f, 0.75f).SetId("ScaleUp").SetEase(Ease.Linear).OnComplete(ScaleSliderDown);
    }

    void ScaleSliderDown()
    {
        extaz.transform.DOScale(1f, 0.75f).SetId("ScaleDown").SetEase(Ease.Linear).OnComplete(ScaleSliderUp);
    }

	public IEnumerator frameFullAnimation()
	{
		referenceToExtazFrame.GetComponent<Image>().sprite = frameFull;
		yield return null;
	}

    /*********************
    **PLAYER ANITMATIONS**
    *********************/

    //DEATH FEEDBACK (à appeler quand un joueur meurt)
    public void GoGrey(int playernumber) 
    {
        players[playernumber].GetComponentInChildren<Image>().DOBlendableColor(new Color32(0x54, 0x54, 0x54, 0xFF), 1f);
    }

    //REVIVE FEEDBACK (à appeler quand un joueur est revive)
    public void GoWhite(int playernumber)
    {
        players[playernumber].GetComponentInChildren<Image>().DOBlendableColor(Color.white,1f);
    }

    //HIT FEEDBACK (à appeler quand le joueur est hit)
    public void HitShake(string playername)
    {
        switch (playername)
        {
            case "Character1":
                if(gameManager.GetPlayerInfo(0).isDead == false)
                    players[0].transform.FindChild("profile").DOShakePosition(0.5f, 5f, 18, 90, false, true);
                break;
            case "Character2":
                if (gameManager.GetPlayerInfo(1).isDead == false)
                    players[1].transform.FindChild("profile").DOShakePosition(0.5f, 5f, 18, 90, false, true);
                break;
            case "Character3":
                if (gameManager.GetPlayerInfo(2).isDead == false)
                    players[2].transform.FindChild("profile").DOShakePosition(0.5f, 5f, 18, 90, false, true);
                break;
        }       
    }

    //MVP FEEDBACK (à appeler en update pour distinguer le joueur qui a le meilleur score)
    public void ScaleProfileUp(string playername)
    {
        switch (playername)
        {
            case "Character1":
                players[0].transform.FindChild("profile").DOScale(new Vector3(1.25f, 1.25f, 1), 1f).SetId("UpProfile");
                players[1].transform.FindChild("profile").DOScale(new Vector3(1f, 1f, 1), 1f).SetId("DownProfile");
                players[2].transform.FindChild("profile").DOScale(new Vector3(1f, 1f, 1), 1f).SetId("DownProfile");
                break;
            case "Character2":
                players[1].transform.FindChild("profile").DOScale(new Vector3(1.25f, 1.25f, 1), 1f).SetId("UpProfile"); ;
                players[0].transform.FindChild("profile").DOScale(new Vector3(1f, 1f, 1), 1f).SetId("DownProfile");
                players[2].transform.FindChild("profile").DOScale(new Vector3(1f, 1f, 1), 1f).SetId("DownProfile");
                break;
            case "Character3":
                players[2].transform.FindChild("profile").DOScale(new Vector3(1.25f, 1.25f, 1), 1f).SetId("UpProfile"); ;
                players[1].transform.FindChild("profile").DOScale(new Vector3(1f, 1f, 1), 1f).SetId("DownProfile");
                players[3].transform.FindChild("profile").DOScale(new Vector3(1f, 1f, 1), 1f).SetId("DownProfile");
                break;
        }
    }

    public void ScorePlayer()
    {
        players[0].transform.FindChild("score").GetComponent<Text>().text = "" + Mathf.Round(gameManager.GetPlayerInfo(0).score);
        players[1].transform.FindChild("score").GetComponent<Text>().text = "" + Mathf.Round(gameManager.GetPlayerInfo(1).score);
        players[2].transform.FindChild("score").GetComponent<Text>().text = "" + Mathf.Round(gameManager.GetPlayerInfo(2).score);
    }

    /************
    **GAME OVER**
    ************/

    //FEEDBACK QUAND POINTER EST SUR LE BOUTON
    public void OverButton(string buttonname)
    {
        switch (buttonname)
        {
            case "Retry":
                RetryButton.GetComponent<Text>().color = new Color(0f, 0f, 0f);
                RetryButton.GetComponent<Outline>().effectColor = new Color(1f, 1f, 1f, 0.75f);
                break;

            case "Quit":
                QuitButton.GetComponent<Text>().color = new Color(0f, 0f, 0f);
                QuitButton.GetComponent<Outline>().effectColor = new Color(1f, 1f, 1f, 0.75f);
                break;
        }
    }

    //FEEDBACK QUAND POINTER QUITE LE BOUTON
    public void ExitButton(string buttonname)
    {
        switch (buttonname)
        {
            case "Retry":
                RetryButton.GetComponent<Text>().color = new Color(1f, 1f, 1f);
                RetryButton.GetComponent<Outline>().effectColor = new Color(0f, 0f, 0f, 0.75f);
                break;

            case "Quit":
                QuitButton.GetComponent<Text>().color = new Color(1f, 1f, 1f);
                QuitButton.GetComponent<Outline>().effectColor = new Color(0f, 0f, 0f, 0.75f);
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

    /************
    **GAME OVER**
    ************/

    public void Ranking()
    {
        if (gameManager.GetPlayerInfo(0).score > gameManager.GetPlayerInfo(1).score && gameManager.GetPlayerInfo(0).score > gameManager.GetPlayerInfo(2).score)
        {
            ranks[0].GetComponent<Image>().sprite = playersImage[0];
            ranks[0].transform.FindChild("score").GetComponent<Text>().text = "" + gameManager.GetPlayerInfo(0).score;

            if (gameManager.GetPlayerInfo(1).score > gameManager.GetPlayerInfo(2).score)
            {
                ranks[1].GetComponent<Image>().sprite = playersImage[1];
                ranks[1].transform.FindChild("score").GetComponent<Text>().text = "" + gameManager.GetPlayerInfo(1).score;
                ranks[2].GetComponent<Image>().sprite = playersImage[2];
                ranks[2].transform.FindChild("score").GetComponent<Text>().text = "" + gameManager.GetPlayerInfo(2).score;
            }
            else if (gameManager.GetPlayerInfo(1).score < gameManager.GetPlayerInfo(2).score)
            {
                ranks[1].GetComponent<Image>().sprite = playersImage[2];
                ranks[1].transform.FindChild("score").GetComponent<Text>().text = "" + gameManager.GetPlayerInfo(2).score;
                ranks[2].GetComponent<Image>().sprite = playersImage[1];
                ranks[2].transform.FindChild("score").GetComponent<Text>().text = "" + gameManager.GetPlayerInfo(1).score;
            }
        }
        else if (gameManager.GetPlayerInfo(1).score > gameManager.GetPlayerInfo(0).score && gameManager.GetPlayerInfo(1).score > gameManager.GetPlayerInfo(2).score)
        {
            ranks[0].GetComponent<Image>().sprite = playersImage[1];
            ranks[0].transform.FindChild("score").GetComponent<Text>().text = "" + gameManager.GetPlayerInfo(1).score;

            if (gameManager.GetPlayerInfo(0).score > gameManager.GetPlayerInfo(2).score)
            {
                ranks[1].GetComponent<Image>().sprite = playersImage[0];
                ranks[1].transform.FindChild("score").GetComponent<Text>().text = "" + gameManager.GetPlayerInfo(0).score;
                ranks[2].GetComponent<Image>().sprite = playersImage[2];
                ranks[2].transform.FindChild("score").GetComponent<Text>().text = "" + gameManager.GetPlayerInfo(2).score;
            }
            else if (gameManager.GetPlayerInfo(0).score < gameManager.GetPlayerInfo(2).score)
            {
                ranks[1].GetComponent<Image>().sprite = playersImage[2];
                ranks[1].transform.FindChild("score").GetComponent<Text>().text = "" + gameManager.GetPlayerInfo(2).score;
                ranks[2].GetComponent<Image>().sprite = playersImage[0];
                ranks[2].transform.FindChild("score").GetComponent<Text>().text = "" + gameManager.GetPlayerInfo(0).score;
            }
        }
        else if (gameManager.GetPlayerInfo(2).score > gameManager.GetPlayerInfo(0).score && gameManager.GetPlayerInfo(2).score > gameManager.GetPlayerInfo(1).score)
        {
            ranks[0].GetComponent<Image>().sprite = playersImage[2];
            ranks[0].transform.FindChild("score").GetComponent<Text>().text = "" + gameManager.GetPlayerInfo(2).score;

            if (gameManager.GetPlayerInfo(0).score > gameManager.GetPlayerInfo(1).score)
            {
                ranks[1].GetComponent<Image>().sprite = playersImage[0];
                ranks[1].transform.FindChild("score").GetComponent<Text>().text = "" + gameManager.GetPlayerInfo(0).score;
                ranks[2].GetComponent<Image>().sprite = playersImage[1];
                ranks[2].transform.FindChild("score").GetComponent<Text>().text = "" + gameManager.GetPlayerInfo(1).score;
            }
            else if (gameManager.GetPlayerInfo(0).score < gameManager.GetPlayerInfo(1).score)
            {
                ranks[1].GetComponent<Image>().sprite = playersImage[1];
                ranks[1].transform.FindChild("score").GetComponent<Text>().text = "" + gameManager.GetPlayerInfo(1).score;
                ranks[2].GetComponent<Image>().sprite = playersImage[0];
                ranks[2].transform.FindChild("score").GetComponent<Text>().text = "" + gameManager.GetPlayerInfo(0).score;
            }
        }
    }
}
