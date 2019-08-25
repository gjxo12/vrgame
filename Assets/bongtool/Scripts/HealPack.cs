using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealPack : MonoBehaviour {

    private GameObject player;
    private PlayerAttribute playerattribute;
    public Image HP_bar; 

	// Use this for initialization
	void Start () {
        playerattribute = player.GetComponent<PlayerAttribute>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Awake()
    {
       player = GameObject.FindGameObjectWithTag("player");
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject == player)
        {                     
            Destroy(this.gameObject);
            

            if (playerattribute.HP < 100)
            {
                playerattribute.HP += 100;
                HP_bar.fillAmount += 1.0f;

                if (playerattribute.HP >= 100)
                {
                    playerattribute.HP = 100;
                    HP_bar.fillAmount = 1.0f;
                }
            }
            if(playerattribute.HP >= 100)
            {
                playerattribute.HP = 100;
                HP_bar.fillAmount = 1.0f;
            }
            Debug.Log("체력회복");
        }

        PlayerAttribute.gethealpack = true;
    }
}
