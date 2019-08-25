using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerAttribute : MonoBehaviour {

    public float Radius = 1.0f;
    public float HP = 100;
    public static float score = 1000;
     
    public Image HP_bar;
    public Image bullet_bar;
    public GameObject bettery;
    
    
    private Monster monster;

    AudioSource myaudio;

    public AudioClip screamSound;
    public AudioClip woundSound;
    public AudioClip reloadSound;
    public AudioClip healSound;
    public AudioClip monsterzenSound;

    private float bloodtime = 1.0f;
    private float bloodtimer = 0.0f;

    private float woundtime = 10.0f;
    private float woundtimer = 0.0f;

    public static bool getbullet;
    public static bool gethealpack;
    public static bool monsterzen;
    public static bool getbettery;

    public GameObject need_aid;
    private float need_aid_time = 2.0f;
    private float need_aid_timer = 0.0f;

   
	// Use this for initialization
	void Start () {

        myaudio = GetComponent<AudioSource>();
                  
    }
	
    void Awake()
    {
        getbullet = false;
        gethealpack = false;
        monsterzen = false;
        getbettery = false;
    }
	// Update is called once per frame
	void Update () {

        woundtimer += Time.deltaTime;
        
        if (Monster.monsterAttack == true)
        {         
            myaudio.PlayOneShot(screamSound);
            //blood.SetActive(true);
            Monster.monsterAttack = false;
           
        }

        if (Monster_Skeleton.monsterAttack == true)
        {
            myaudio.PlayOneShot(screamSound);
            //blood.SetActive(true);
            Monster_Skeleton.monsterAttack = false;

        }

        

        if (woundtime <= woundtimer)
        {
            HP -= 10;
            HP_bar.fillAmount -= 0.1f;
            woundtimer = 0;

            myaudio.PlayOneShot(woundSound);

            need_aid.SetActive(true);
            
        }

        if(need_aid.activeSelf == true)
        {
            need_aid_timer += Time.deltaTime;

            if(need_aid_timer >= 2.0f)
            {
                need_aid.SetActive(false);
                need_aid_timer = 0.0f;
            }
        }

        if(getbullet == true)
        {
            Get_Bullet();
        }

        if(gethealpack == true)
        {
            Get_HealPack();
        }

        if(monsterzen == true)
        {
            MonsterZen();
        }

        if(getbettery == true)
        {
            Get_Bettery();
            bettery.SetActive(true);
        }

        if(HP <= 0)
        {
            Application.LoadLevel("game_gameover");            
        }
        else
        {
            score -= Time.deltaTime;
        }

       

        /*if(blood.activeSelf == true)
        {
            bloodtimer += Time.deltaTime;
            if(bloodtimer >= bloodtime)
            {
                blood.SetActive(false);
                bloodtimer = 0;
              
            }
        }
       */
        
    }

    void Get_Bullet()
    {
        myaudio.PlayOneShot(reloadSound);
        getbullet = false;
    }

    void Get_HealPack()
    {
        myaudio.PlayOneShot(healSound);
        gethealpack = false;
    }

    void Get_Bettery()
    {
        getbettery = false;
    }

    void MonsterZen()
    {
        myaudio.PlayOneShot(monsterzenSound);
        monsterzen = false;
    }

    void Need_Aid()
    {
        need_aid.SetActive(true);
        need_aid_timer = 0.0f;
    }



}
