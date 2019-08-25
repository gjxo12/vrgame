using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class loadscene : MonoBehaviour {
    public float gazeTime = 2f;
    private float timer;
    private bool gazeAt;
    private BoxCollider myCollider;
    private Vector3 Orginalscale;
	// Use this for initialization
	void Start () {
		myCollider = GetComponent<BoxCollider>();
        Orginalscale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        if(gazeAt)
        {
            timer += Time.deltaTime;
            if(timer >= gazeTime)
            {
                Application.LoadLevel("game_main");
            }
        }
		
	}
    public void PointerEnter()
    {
        gazeAt = true;
        timer = 0f;
    }
    
    public void PointerExit()
    {
        gazeAt = false;
        timer = 0f;
    }

    public void PointerDown()
    {
        timer = 0f;
    }
}
