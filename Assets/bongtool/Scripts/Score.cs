using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Score : MonoBehaviour {

    public static float score = 1000;

	// Use this for initialization
	void Start () {
		
	}
    
    void Awake()
    {

        DontDestroyOnLoad(this);
        
    }
	// Update is called once per frame
	void Update () {

        score -= Time.deltaTime;
        
		
	}
}
