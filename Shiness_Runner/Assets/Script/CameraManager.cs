using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour
{
	private bool isTransitioning;
	private Vector3 transitionSourcePosition;
	private Vector3 transitionTargetPosition;
	private Vector3 transitionSourceRotation;
	private Vector3 transitionTargetRotation;
	private float transitionSourceSize;
	private float transitionTargetSize;
	private float transitionTime;
	private float transitionTimer;

	void Start ()
	{
	}

	void Update ()
	{
		if (isTransitioning) {
			if (transitionTimer > transitionTime) {
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

			//###############################
			//rotate
			float _rX = Mathf.SmoothStep (transitionSourceRotation.x, transitionTargetRotation.x, _transitionProgress);
			float _rY = Mathf.SmoothStep (transitionSourceRotation.y, transitionTargetRotation.y, _transitionProgress);
			float _rZ = Mathf.SmoothStep (transitionSourceRotation.z, transitionTargetRotation.z, _transitionProgress);

			Camera.main.transform.localEulerAngles = new Vector3 (_rX, _rY, _rZ);

			//###############################
			//resize

			Camera.main.orthographicSize = Mathf.SmoothStep (transitionSourceSize, transitionTargetSize, _transitionProgress);
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
	}
}
