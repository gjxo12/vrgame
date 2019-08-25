using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour {

    private GameObject player;

    // Use this for initialization
    void Start () {
		
	}

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        Radio.pointdown = true;
        PlayerAttribute.getbettery = true;
    }
}
