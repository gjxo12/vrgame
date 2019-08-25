using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletBox : MonoBehaviour {

    private GameObject player;
    public Image bullet_bar;

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
            if (Fire.bullet < 10)
            {
                Fire.bullet += 5;
                bullet_bar.fillAmount += 0.5f;

                if (Fire.bullet >= 10)
                {
                    Fire.bullet = 10;
                    bullet_bar.fillAmount += 1.0f;
                }
            }

            PlayerAttribute.getbullet = true;
        }

        
    }
  }

