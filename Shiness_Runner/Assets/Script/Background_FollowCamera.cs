using UnityEngine;
using System.Collections;

public class Background_FollowCamera : MonoBehaviour {

	public GameObject cameraToFollow;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = new Vector3(cameraToFollow.transform.position.x, transform.position.y, transform.position.z);
	
	}
}
