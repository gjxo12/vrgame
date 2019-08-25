using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Radio : MonoBehaviour
{
    public float gazeTime = 2f;
    private float timer;
    public bool gazeAt;
    private BoxCollider myCollider;

    public static bool pointenter;
    public static bool pointdown;                   //static으로 변수선언,몬스터 다수 참조

    AudioSource myAudio;
    public AudioClip radioSound;

    public GameObject bettery_img;


    // private Vector3 OriginalScale;

    // Use this for initialization
    void Start()
    {
        myCollider = GetComponent<BoxCollider>();
        myAudio = GetComponent<AudioSource>();
        //OriginalScale = transform.localScale;
    }

    void Awake()
    {
        gazeAt = false;
        pointenter = false;
        pointdown = false;
       

    }

    // Update is called once per frame
    void Update()
    {
        if (gazeAt == true)
        {
            timer += Time.deltaTime;

            if (timer >= gazeTime)
            {
                if(pointdown == true)
                {
                    ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
                }
               
                //monsterHP -= 20;
                //pointdown = true;
                timer = 0f;
            }
        }
        if(pointdown == true)
        {
            if(myCollider.GetComponent<BoxCollider>().enabled == false)
            {
                myCollider.GetComponent<BoxCollider>().enabled = true;
            }
        }
        if( pointdown == false)
        {
            myCollider.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void PointerEnter()
    {
        gazeAt = true;
        // transform.localScale = OriginalScale * 1.2f;
        timer = 0f;
        pointenter = true;

        myAudio.PlayOneShot(radioSound);
    }

    public void PointerExit()
    {
        gazeAt = false;
        timer = 0f;
        pointenter = false;

        if(myAudio.isPlaying)
        {
            myAudio.Stop();
        }

        //transform.localScale = OriginalScale;
    }

    public void PointerDown()
    {
        Debug.Log("WOW!");
        //gazeAt = false;
        timer = 0f;
        TimeLimit.timeMin -= 1;
        //myCollider.enabled = false;
        // gameObject.SetActive(false);
        pointdown = false;

        if(bettery_img.activeSelf == true)
        {
            bettery_img.SetActive(false);
        }
      


    }


}

