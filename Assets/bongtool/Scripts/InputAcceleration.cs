using UnityEngine;
using System.Collections;

public class InputAcceleration : MonoBehaviour
{
    public float speed = 10.0F;
    void Update()
    {
        Vector3 dir = Vector3.zero;
        dir.x = Input.acceleration.x;
        dir.y = Input.acceleration.z;
        
        if (dir.sqrMagnitude > 1)
            dir.Normalize();

        dir *= Time.deltaTime;
        transform.Translate(dir * speed);
    }
}