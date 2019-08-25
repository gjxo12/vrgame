using UnityEngine;
using System.Collections;

public class VRLookWalk : MonoBehaviour {

    public Transform vrCamera;
    public float toggleAngle = 30.0f;
    public float speed;
    public static bool moveForward;
    private CharacterController cc;
   
    private Enemyscript enemy;
    private GvrReticle reticle;

    AudioSource footsound;


    // Use this for initialization
    void Start () {
        cc = GetComponent<CharacterController>();     
        footsound = GetComponent<AudioSource>();       
    }

    void Awake()
    {
        moveForward = true;       
    }
	
	// Update is called once per frame
	void Update () {

        if(GvrReticle.fg == true)
        {
            moveForward = false;
          
        }
        else
        {
            moveForward = true;
            
        }


        if (moveForward)
        {
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
            cc.SimpleMove(forward * 2);
            

        }
        
        
	}


}
