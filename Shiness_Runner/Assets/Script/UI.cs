using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class UI : MonoBehaviour {

    public Text scoretext;
    public Text multiplier;
    public Slider extaz;
    public List<GameObject> players = new List<GameObject>();

    float score;
    bool extazcanwow = true;

    // Use this for initialization
    void Start () {
        RotateScoreLeft();
	}
	
	// Update is called once per frame
	void Update () {

        score = Mathf.Round(10 * Time.time * 1f) / 1f;

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
            extazcanwow = false;
        }else if(extaz.value < 100)
        {
            DOTween.Kill("ScaleUp");
            DOTween.Kill("ScaleDown");
            extazcanwow = true;
            extaz.transform.localScale = new Vector3(1, 1, 1);
        }

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
        scoretext.DOBlendableColor(Color.blue, 0.5f).OnComplete(ScoreRed);
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


    /*********************
    **PLAYER ANITMATIONS**
    *********************/

    //DEATH FEEDBACK (à appeler quand un joueur meurt)
    public void GoGrey(int playernumber) 
    {
        players[playernumber-1].GetComponentInChildren<Image>().DOBlendableColor(new Color32(0x54, 0x54, 0x54, 0xFF), 1f);
    }

    public void GoWhite(int playernumber)
    {
        players[playernumber - 1].GetComponentInChildren<Image>().DOBlendableColor(Color.white,1f);
    }

    public void HitShake(string playername)
    {
        switch (playername)
        {
            case "Character1":
                players[0].transform.DOShakePosition(0.5f, 2.5f, 10, 90, false, true);
                break;
            case "Character2":
                players[1].transform.DOShakePosition(0.5f, 2.5f, 10, 90, false, true);
                break;
            case "Character3":
                players[2].transform.DOShakePosition(0.5f, 2.5f, 10, 90, false, true);
                break;
        }
       
    }
}
