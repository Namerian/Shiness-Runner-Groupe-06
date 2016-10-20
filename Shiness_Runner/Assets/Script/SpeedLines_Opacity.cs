using UnityEngine;
using System.Collections;

public class SpeedLines_Opacity : MonoBehaviour {

	public float opacityTransitionTime;
	private float alphaSpeedLines;


	//##########################################################################


	IEnumerator IncreaseOpacity ()
	{
		
		for (float f = 0f; f < opacityTransitionTime; f = f + Time.deltaTime)
		{
			alphaSpeedLines = 1*f;
			gameObject.GetComponent<SpriteRenderer> ().color = new Color(1, 1, 1, 0 + alphaSpeedLines);
			yield return null;
		}
			
	}


	//##########################################################################


	IEnumerator DecreaseOpacity ()
	{
		for (float f = 0f; f < opacityTransitionTime; f = f + Time.deltaTime)
		{
			alphaSpeedLines = 1*f;
			gameObject.GetComponent<SpriteRenderer> ().color = new Color(1, 1, 1, 1 - alphaSpeedLines);
			yield return null;
		}

	}


	//##########################################################################


	void RemoveSpeedLines ()
	{
		StartCoroutine("DecreaseOpacity");
		gameObject.GetComponent<MeshRenderer>().enabled = !gameObject.GetComponent<MeshRenderer>().enabled;
	}

	void AddSpeedLines ()
	{
		StartCoroutine("IncreaseOpacity");
		gameObject.GetComponent<MeshRenderer>().enabled = gameObject.GetComponent<MeshRenderer>().enabled;
	}


	//##########################################################################
}
