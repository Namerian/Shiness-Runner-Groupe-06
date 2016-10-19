using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class UI : MonoBehaviour {

    public Text scoretext;
    public Text multiplier;
    public Slider extaz;
    public Image player1;
    public Image player2;
    public Image player3;

    float score;
    bool extazcanwow = true;

    // Use this for initialization
    void Start () {
        RotateScoreLeft();
        //ScoreRed();	
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


    //SCORE ANIMATIONS
    void RotateScoreLeft()
    {
        scoretext.transform.DOLocalRotate(new Vector3(0, 0, 3), 2f).SetId("RotateLeft").SetEase(Ease.Linear).OnComplete(RotateScoreRight);
    }

    void RotateScoreRight()
    {
        scoretext.transform.DOLocalRotate(new Vector3(0, 0, -3), 2f).SetId("RotateRight").SetEase(Ease.Linear).OnComplete(RotateScoreLeft);
    }



    //SLIDER ANITMATIONS
    void ScaleSliderUp()
    {
        extaz.transform.DOScale(1.05f, 0.75f).SetId("ScaleUp").SetEase(Ease.Linear).OnComplete(ScaleSliderDown);
    }

    void ScaleSliderDown()
    {
        extaz.transform.DOScale(0.95f, 0.75f).SetId("ScaleDown").SetEase(Ease.Linear).OnComplete(ScaleSliderUp);
    }


    //SCORE ANIMATION
    /*void ScoreRed()
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
    }*/

}
