using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeLimit : MonoBehaviour {

    public static int timeMin;
    public static float timeSec;
    private int ts_zero = 0;
    public GameObject timelimit;

	// Use this for initialization
	void Start () {
        timeMin = 10;
        timeSec = 00.0f;       

        GetComponent<Outline>();
        
	}

    // Update is called once per frame
    void Update () {
        if(timeSec != 0)
        {
            timeSec -= Time.deltaTime;
            
            if(timeSec <= 0)
            {
                timeSec = 0;
            }

        }
        else if (timeSec == 0)
        {
            timeMin = timeMin - 1;
            timeSec = 60.0f;

            if (timeMin <= 0)
            {
                timeMin = 0;
            }
        }

        

        

        int tm = Mathf.FloorToInt(timeMin);
        int ts = Mathf.FloorToInt(timeSec);
        Text uiText = GetComponent<Text>();

        if (timeSec < 10)
        {
            uiText.text = "SOS " + tm.ToString() + ":" + "0" + ts.ToString();
        }
        else
        {
            uiText.text = "SOS " + tm.ToString() + ":" + ts.ToString();
        }

       
        



    }
}
