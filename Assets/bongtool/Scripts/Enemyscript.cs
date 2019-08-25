using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class Enemyscript : MonoBehaviour {
    public float gazeTime = 2f;
    private float timer;
    public bool gazeAt;
    private BoxCollider myCollider;

    public static bool pointenter;
    public static bool pointdown;                   //static으로 변수선언,몬스터 다수 참조

   
   // private Vector3 OriginalScale;

    // Use this for initialization
    void Start() {
        myCollider = GetComponent<BoxCollider>();
        //OriginalScale = transform.localScale;
    }

    void Awake()
    {
        gazeAt = false;
        pointenter = false;
        pointdown = false;
     
    }

    // Update is called once per frame
    void Update() {
        if (gazeAt==true)
        {
            timer += Time.deltaTime;

            if (timer >= gazeTime)
            {
                ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
                //monsterHP -= 20;
                //pointdown = true;
                timer = 0f;
            }
        }
    }

    public void PointerEnter()
    {       
        gazeAt = true;
       // transform.localScale = OriginalScale * 1.2f;
        timer = 0f;
        pointenter = true;
    }

    public void PointerExit()
    {
        gazeAt = false;
        timer = 0f;
        pointenter = false;
        //transform.localScale = OriginalScale;
    }

    public void PointerDown()
    {
        Debug.Log("WOW!");
        //gazeAt = false;
        timer = 0f;
        
        //myCollider.enabled = false;
        // gameObject.SetActive(false);
        pointdown = true;
    }

 
}

