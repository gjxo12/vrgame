using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotate2 : MonoBehaviour
{

    public float degreePerSeconds = 3.0f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float speed = degreePerSeconds * Time.deltaTime;
        transform.Rotate(Vector3.up * speed);

    }
}
