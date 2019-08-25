
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class SceneChangeMT2 : MonoBehaviour
{
    public float gazeTime = 2f;
    private float timer;
    private bool gazeAt;
    private BoxCollider myCollider;
    private Vector3 OriginalScale;

    // Use this for initialization
    void Start()
    {
        myCollider = GetComponent<BoxCollider>();
        OriginalScale = transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        if (gazeAt)
        {
            timer += Time.deltaTime;

            if (timer >= gazeTime)
            {
                ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
                Application.LoadLevel("test2");
                timer = 0f;
            }
        }

    }

    public void PointerEnter()
    {
        gazeAt = true;
        transform.localScale = OriginalScale * 1.2f;
        timer = 0f;
    }

    public void PointerExit()
    {
        gazeAt = false;
        timer = 0f;
        transform.localScale = OriginalScale;
    }

    public void PointerDown()
    {
        Debug.Log("WOW!");
        timer = 0f;
        myCollider.enabled = false;
        gameObject.SetActive(false);
    }
}