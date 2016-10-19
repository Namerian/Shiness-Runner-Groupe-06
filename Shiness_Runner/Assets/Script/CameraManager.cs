using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour
{
	//private GameObject camera;

    
	public float speed = 0.0f;

	private Vector3 _rotateTo;
	private Vector3 currentAxis;
	private Vector3 _moveTo;
	private Vector3 currentPosition;

	private bool isTransitioning;
	private Vector3 transitionSourcePosition;
	private Vector3 transitionTargetPosition;
	private Vector3 transitionSourceRotation;
	private Vector3 transitionTargetRotation;
	private float transitionSourceSize;
	private float transitionTargetSize;
	private float transitionTime;
	private float transitionTimer;

	private bool isMoving;

	void Start ()
	{
		//camera = GameObject.Find ("MainCamera");
	}

	void Update ()
	{
		if (isMoving) {
			//Camera.main.transform.position += Time.deltaTime * new Vector3 (speed, 0, 0);
		}

		if (isTransitioning) {
			if (transitionTimer >= transitionTime) {
				isTransitioning = false;
			}

			transitionTimer += Time.deltaTime;
			float _transitionProgress = transitionTimer / transitionTime;

			//###############################
			//move
			float _mX = Mathf.SmoothStep (transitionSourcePosition.x, transitionTargetPosition.x, _transitionProgress);
			float _mY = Mathf.SmoothStep (transitionSourcePosition.y, transitionTargetPosition.y, _transitionProgress);
			float _mZ = Mathf.SmoothStep (transitionSourcePosition.z, transitionTargetPosition.z, _transitionProgress);

			Camera.main.transform.localPosition = new Vector3 (_mX, _mY, _mZ);
				
			//Camera.main.transform.localPosition = Vector3.Lerp (transitionSourcePosition, transitionTargetPosition, _transitionProgress);
			//Camera.main.transform.localPosition = transitionTargetPosition;

			//###############################
			//rotate
			float _rX = Mathf.SmoothStep (transitionSourceRotation.x, transitionTargetRotation.x, _transitionProgress);
			float _rY = Mathf.SmoothStep (transitionSourceRotation.y, transitionTargetRotation.y, _transitionProgress);
			float _rZ = Mathf.SmoothStep (transitionSourceRotation.z, transitionTargetRotation.z, _transitionProgress);

			Camera.main.transform.localEulerAngles = new Vector3 (_rX, _rY, _rZ);

			//Camera.main.transform.localEulerAngles = Vector3.Lerp (transitionSourceRotation, transitionTargetRotation, _transitionProgress);
			//Camera.main.transform.localEulerAngles = transitionTargetRotation;

			//###############################
			//resize

			Camera.main.orthographicSize = Mathf.SmoothStep (transitionSourceSize, transitionTargetSize, _transitionProgress);


			//float _sizeDiff = transitionTargetSize - transitionSourceSize;
			//Camera.main.orthographicSize = transitionSourceSize + (_sizeDiff * _transitionProgress);

			//###############################

			//end
			/*if (transitionTimer >= transitionTime) {
				isTransitioning = false;
			}*/


			/*currentAxis = Vector3.Lerp(currentAxis, _rotateTo, Time.deltaTime * speed);
            transform.eulerAngles = currentAxis;
            if (currentAxis == _moveTo)
            {
                isTransitioning = false;
            }*/
		}
	}

	public void StartTransition (Vector3 targetPosition, Vector3 targetRotation, float targetSize, float time)
	{
		if (isTransitioning) {
			return;
		}

		isTransitioning = true;

		transitionSourcePosition = this.transform.localPosition;
		transitionTargetPosition = targetPosition;

		transitionSourceRotation = this.transform.localRotation.eulerAngles;
		transitionTargetRotation = targetRotation;

		transitionSourceSize = Camera.main.orthographicSize;
		transitionTargetSize = targetSize;

		transitionTime = time;
		transitionTimer = 0f;

		//camera.transform.position = new Vector3(xPosition, camera.transform.position.y, camera.transform.position.z);
	}

	public void StartMoving ()
	{
		isMoving = true;
	}

	public void StopMoving ()
	{
		isMoving = false;
	}

	public void Slide ()
	{

	}
}
