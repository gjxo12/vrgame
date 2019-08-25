using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {

   

    [Header("PlayerNameInput")]
    public InputField PlayerNameInputField;
    public GameObject RankBox;
    public GameObject RankBoxExtBtn;
    public Text RankNameText;
    public Text RankRecordText;
    public Text RankRankText;

    public string Rank_registUrl;
    public string Rank_nameUrl;
    public string Rank_recordUrl;
    public string Rank_rankUrl;

    public float score_float;
    public string record;

    // Use this for initialization
    void Start () {

        Rank_registUrl = "saramanda758.cafe24.com/Rank_regist.php";
        Rank_nameUrl = "saramanda758.cafe24.com/Rank_name.php";
        Rank_recordUrl = "saramanda758.cafe24.com/Rank_record.php";
        Rank_rankUrl = "saramanda758.cafe24.com/Rank_rank.php";

        score_float = PlayerAttribute.score;
        record = score_float.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void Restart()
    {       
        Application.LoadLevel("game_main");
       
    }

    public void Regist()
    {
        StartCoroutine(RegistCo());
    }

    IEnumerator RegistCo()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", PlayerNameInputField.text);
        form.AddField("record", record);
        form.AddField("rank", "");

        WWW webRequest = new WWW(Rank_registUrl, form);
        yield return webRequest;

        if((!string.IsNullOrEmpty(webRequest.error)))
        {
            print("Error downloading : " + webRequest.error);
        }
        else
        {
            Debug.Log(webRequest.text);
        }
    }

    public void RankLoadBtn()
    {
        RankBox.SetActive(true);
        RankBoxExtBtn.SetActive(true);
        StartCoroutine(RankLoad());
    }

    IEnumerator RankLoad()
    {
        WWWForm form = new WWWForm();
        form.AddField("name","");
        form.AddField("record","");
        form.AddField("rank", "");
        WWW webRequest = new WWW(Rank_nameUrl, form);
        yield return webRequest;

        RankNameText.text = webRequest.text;

        WWWForm form2 = new WWWForm();
        form2.AddField("name", "");
        form2.AddField("record", "");
        form2.AddField("rank", "");
        WWW webRequest2 = new WWW(Rank_recordUrl, form2);
        yield return webRequest2;

        RankRecordText.text = webRequest2.text;

        WWWForm form3 = new WWWForm();
        form3.AddField("name", "");
        form3.AddField("record", "");
        form3.AddField("rank", "");
        WWW webRequest3 = new WWW(Rank_rankUrl, form3);
        yield return webRequest3;

        RankRankText.text = webRequest3.text;

    }

    public void RankBoxExt()
    {
        if(RankBox.activeSelf == true)
        {
            RankBox.SetActive(false);
            RankBoxExtBtn.SetActive(false);
        }
    }
}
