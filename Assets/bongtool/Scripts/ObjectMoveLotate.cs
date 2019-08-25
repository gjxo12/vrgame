using UnityEngine;
using System.Collections;

public class ObjectMoveLotate : MonoBehaviour
{

    public GameObject mainCameraObject;
    public GameObject cubeObject;
    Vector3 CameraDistance;
    float TimeDeltas = 0.0f;

    void Start()
    {
        CameraDistance = cubeObject.transform.localPosition - mainCameraObject.transform.localPosition;
        mainCameraObject.transform.localPosition.Set(CameraDistance.x,CameraDistance.y*3.0f,CameraDistance.z*3.0f);

    }

    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            TimeDeltas += 1.0f;
            cubeObject.transform.position = new Vector3(0.0f, 0.0f, 1.0f * TimeDeltas * Time.deltaTime);

        }

        if(Input.GetKey(KeyCode.DownArrow))
        {
            TimeDeltas += 1.0f;
            cubeObject.transform.position = new Vector3(0.0f, 0.0f, -(1.0f * TimeDeltas * Time.deltaTime));
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            TimeDeltas += 1.0f;
            cubeObject.transform.localRotation = new Quaternion(0.0f, 0.1f*TimeDeltas,0.0f,1.0f);
            cubeObject.transform.Rotate(mainCameraObject.transform.localRotation.eulerAngles);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            TimeDeltas += 1.0f;
            cubeObject.transform.localRotation = new Quaternion(0.0f, -(0.1f * TimeDeltas), 0.0f, 1.0f);
            cubeObject.transform.Rotate(mainCameraObject.transform.localRotation.eulerAngles);
        }
    }
}
