using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour {

    public float bulletspeed = 30.0f;
    public int bulletdamage = 25;
    public GameObject Player;
    private GameObject monster;

    private Enemyscript enemyscript;
    
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        Firebullet();
	}
	
	// Update is called once per frame
	void Update () {    

    }

    private void Awake()
    {
        monster = GameObject.FindGameObjectWithTag("monster");     
       
    }

    void Firebullet()
    {
        rb.AddForce(transform.forward * bulletspeed);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == monster)
        {
            //enemyscript.monsterHP -= bulletdamage;
            Debug.Log("적중");
        }
    }



}
