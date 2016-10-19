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

    public float score;

    // Use this for initialization
    void Start () {
        RotateScoreLeft();
	
	}
	
	// Update is called once per frame
	void Update () {

        score = Mathf.Round(10 * Time.time * 1f) / 1f; ;
        scoretext.text = "" + score;

       

    }

    void RotateScoreLeft()
    {
        scoretext.transform.DOLocalRotate(new Vector3(0, 0, 4), 1.5f).SetId("RotateLeft").SetEase(Ease.InOutCubic).OnComplete(RotateScoreRight);
    }

    void RotateScoreRight()
    {
        scoretext.transform.DOLocalRotate(new Vector3(0, 0, -4), 1.5f).SetId("RotateRight").SetEase(Ease.InOutCubic).OnComplete(RotateScoreLeft);
    }
}
