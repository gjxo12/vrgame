using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fire : MonoBehaviour {

    
    private GameObject monster;   
    private Monster enemy;
    Animator animator;
    AudioSource gunShot;
    
    public ParticleSystem fire;
    bool isShot;

    public float Firespeed = 1.0f;
    private float delaytime = 0f;

    public static int bullet = 10;
    public Image bullet_bar;


    // Use this for initialization
    void Start () {        

        animator = GetComponent<Animator>();
        gunShot = GetComponent<AudioSource>();
       // enemy = monster.GetComponent<Enemyscript>();
             
    }

    void Awake()
    {
        monster = GameObject.FindGameObjectWithTag("monster");
    }
	
	// Update is called once per frame
	void Update () {
        delaytime += Time.deltaTime;
        if (Firespeed <= delaytime && Monster.pointdown == true )
        {           
            Shot();                                
        }
        else
        {
            animator.SetBool("isShot", false);
            isShot = false;
        }

        if (Firespeed <= delaytime && Monster_Skeleton.pointdown == true)
        {
            Shot();
        }
        else
        {
            animator.SetBool("isShot", false);
            isShot = false;
        }


    }
    void Shot()
    {
        animator.SetBool("isShot", true);
        if(fire)
        {
            if(fire.isPlaying == true)
            {
                fire.Stop();
                fire.Clear();
            }
            else
            {
                fire.Play();
            }
        }       
        gunShot.Play();
        //Instantiate(bullet, Spawnpoint.transform.position,Spawnpoint.transform.rotation);
       
        
        Monster.pointdown = false;
        Monster_Skeleton.pointdown = false;
        delaytime = 0f;
        bullet -= 1;
        bullet_bar.fillAmount -= 0.1f;
    }
}
