using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMake : MonoBehaviour {

    public GameObject Waypoint1;
    public GameObject monster;

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
        if(other.gameObject == player)
        {
            Destroy(this.gameObject);
            Instantiate(monster, Waypoint1.transform.position,Waypoint1.transform.rotation);
            Debug.Log("놀랐지");

            PlayerAttribute.monsterzen = true;
        }
    }
}
