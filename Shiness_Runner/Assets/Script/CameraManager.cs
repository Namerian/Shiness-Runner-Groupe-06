using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

    GameObject _camera;
    
    

    public float speed = 0.0f;
    private Vector3 _rotateTo;
    public Vector3 currentAxis;
    private Vector3 _moveTo;
    public Vector3 currentPosition;
    bool _transitioning;

    void Start()
    {
        _camera = GameObject.Find("MainCamera");
    }

    void Update()
    {
        _camera.transform.position += Time.deltaTime * new Vector3(speed, 0, 0);
        if(_transitioning == true) {
            currentAxis = Vector3.Lerp(currentAxis, _rotateTo, Time.deltaTime * speed);
            transform.eulerAngles = currentAxis;
            if(currentAxis == _moveTo)
            {
                _transitioning = false;
            }
        }
    }

    void SetTransition(float xPosition, float xAxis)
    {
        _transitioning = true;
        _camera.transform.position = new Vector3(xPosition, _camera.transform.position.y, _camera.transform.position.z);
    }

    void StartCamera()
    {
        speed = 15.0f;
    }

    void StopCamera()
    {
        speed = 0.0f;
    }
}
