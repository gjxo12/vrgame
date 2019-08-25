using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour {

    [Header("LoginPanel")]
    public InputField IDInputField;
    public InputField PassInputField;

    [Header("CreatAccountPanel")]
    public InputField New_IDInputField;
    public InputField New_PassInputField;
    public GameObject CreatAccountPanel;

    public string LoginUrl;
    public string CreatUrl;

    // Use this for initialization
    void Start () {

        LoginUrl = "saramanda758.cafe24.com/Login.php";
        CreatUrl = "saramanda758.cafe24.com/CreateAccount.php";

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoginBtn()
    {
        StartCoroutine(LoginCo());
    }

    IEnumerator LoginCo()
    {
        Debug.Log(IDInputField.text);
        Debug.Log(PassInputField.text);

        WWWForm form = new WWWForm();
        form.AddField("Input_user", IDInputField.text);
        form.AddField("Input_pass", PassInputField.text);

        WWW webRequest = new WWW(LoginUrl, form);
        yield return webRequest;

        if ((!string.IsNullOrEmpty(webRequest.error)))
        {
            print("Erro downloading : " + webRequest.error);

        }
        else
            Debug.Log(webRequest.text);
    }

    public void OpenCreatAccountBtn()
    {
        CreatAccountPanel.SetActive(true);
       // StartCoroutine(LoginCo());
    }
 

    public void CreatAccountBtn()
    {
        StartCoroutine(CreatCo());
    }

    IEnumerator CreatCo()
    {
      

        WWWForm form = new WWWForm();
        form.AddField("Input_user", New_IDInputField.text);
        form.AddField("Input_pass", New_PassInputField.text);
        form.AddField("Input_Info", "안녕하세요 뉴비입니다.");

        WWW webRequest = new WWW(CreatUrl, form);
        yield return webRequest;

        if ((!string.IsNullOrEmpty(webRequest.error)))
        {
            print("Erro downloading : " + webRequest.error);

        }
        else
            Debug.Log(webRequest.text);

    }

}
