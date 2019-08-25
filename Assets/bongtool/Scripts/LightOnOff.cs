using UnityEngine;
using System.Collections;

public class LightOnOff : MonoBehaviour {
    public GameObject light;
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("good");
            if(light.activeSelf == true)
            {
                light.SetActive(false);
                Debug.Log("off");

            }
            else if(light.activeSelf == false)
            {
                light.SetActive(true);
                Debug.Log("On");
            }
            
        }
	
	}
}
