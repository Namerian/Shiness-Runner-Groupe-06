using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour
{
    private GameObject camera;

    public float speed = 0.0f;

    private Vector3 _rotateTo;
    private Vector3 currentAxis;
    private Vector3 _moveTo;
    private Vector3 currentPosition;

    bool isTransitioning;


    bool isMoving;

    void Start()
    {
        camera = GameObject.Find("MainCamera");
    }

    void Update()
    {
        if (isMoving)
        {
            Camera.main.transform.position += Time.deltaTime * new Vector3(speed, 0, 0);
        }

        



        if (isTransitioning == true)
        {
            currentAxis = Vector3.Lerp(currentAxis, _rotateTo, Time.deltaTime * speed);
            transform.eulerAngles = currentAxis;
            if (currentAxis == _moveTo)
            {
                isTransitioning = false;
            }
        }
    }

    public void SetTransition(float xPosition, float xAxis)
    {
        isTransitioning = true;
        camera.transform.position = new Vector3(xPosition, camera.transform.position.y, camera.transform.position.z);
    }

    public void StartMoving()
    {
        isMoving = true;
    }

    public void StopMoving()
    {
        isMoving = false;
    }
}
