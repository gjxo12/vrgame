using UnityEngine;
using System.Collections;

public class reticle_code : MonoBehaviour
{

    private float rotate = 0.0f;
    private Camera CameraFacing;

    private Vector3 OriginalScale;

    // Use this for initialization
    void Start()
    {
        GameObject gameMainCamera = GameObject.FindWithTag("MainCamera");
        if (gameMainCamera != null)
        {
            CameraFacing = gameMainCamera.GetComponent<Camera>();
        }
        if (gameMainCamera == null)
        {
            Debug.Log("Cannot find 'MainCamera' !!!");
        }
        OriginalScale = transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        float distance;

        if (Physics.Raycast(new Ray(CameraFacing.transform.position, CameraFacing.transform.rotation * Vector3.forward), out hit))
        {
            distance = hit.distance;

        }
        else
        {
            distance = CameraFacing.farClipPlane * 0.95f;
        }
        transform.position = CameraFacing.transform.position + CameraFacing.transform.rotation * Vector3.forward * distance;
        transform.LookAt(CameraFacing.transform.position);
        transform.Rotate(0.0f, 180.0f, rotate);
        transform.localScale = OriginalScale * distance;

    }
}
