using UnityEngine;
using System.Collections;
public class AutoWalk : MonoBehaviour
{
    public Transform target;
    private bool isWalking;
   // public Rigidbody rigid;
   // public int speed;
   

    void awake()
    {
       // rigid = GetComponent<Rigidbody>();
    }

    
    void FixedUpdate()
    {
        if (GvrViewer.Instance.Triggered)
        {
            isWalking = !isWalking;
        }
        if (isWalking)
        {
            Vector3 direction = new Vector3(target.transform.forward.x, 0, target.transform.forward.z).normalized * 1 * Time.deltaTime;
            Quaternion rotation = Quaternion.Euler(new Vector3(0, -transform.rotation.eulerAngles.y, 0));
            transform.Translate(rotation*direction);
           // rigid.MovePosition(transform.position + direction );
            
        }
    }
}
