using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class MailViewer : MonoBehaviour
{
    const string domain = "172.31.6.95:3000";
    const string send_mail_for_unity = "http://" + domain + "/top/send_mail_for_unity";
    //const string fetch_gmail = "https://vr-desktop.herokuapp.com/top/fetch_gmail";
    const string new_mail_arrive = "http://" + domain + "/top/new_mail_arrive";

    bool gotMail;
    TextMesh textMesh;

    float time = 10.0f;
    bool flag = false;

    float restTime = 10.0f;

    // Use this for initialization
    void Start ()
    {
        textMesh = GetComponent<TextMesh>();
        textMesh.text = "";
    }
	
	// Update is called once per frame
	void Update ()
    {
        time += Time.deltaTime;

        if (time >= 10.0f)
        {
            StartCoroutine(GetMail());
            //StartCoroutine(CheckMail());
            time = 0.0f;
        }

        restTime -= Time.deltaTime;

        if(restTime <= 0.0f)
        {
            textMesh.text = "";
        }

        /*
        if(time >= 5.0f && !flag)
        {
            gotMail = true;
            flag = true;
        }
        */

        if (gotMail)
        {
            //StartCoroutine(GetMail());
            //GetMailTest();
            gotMail = false;
        }
    }

    void GetMailTest()
    {
        Mail mail;
        mail = new Mail();
        mail.subject = "件名";
        mail.date = "2017/09/17";
        mail.from = "hoge@test.com";
        mail.to = "fuga@test.com";
        mail.text = "メールです";
        textMesh.text = mail.ToString();
        Debug.Log(mail.ToString());
    }

    IEnumerator GetMail()
    {
        Mail mail;
        UnityWebRequest request = UnityWebRequest.Get(send_mail_for_unity);

        // リクエスト送信
        yield return request.Send();

        if (request.isError)
        {
            Debug.Log("Error:" + request.error);
        }
        else
        {
            Debug.Log("Result:" + request.downloadHandler.text);
            if (request.downloadHandler.text != "sended")
            {
                mail = Mail.FromJSON(request.downloadHandler.text);
                textMesh.text = mail.ToString();
                restTime = 10.0f;
            }
        }
    }

    IEnumerator CheckMail()
    {
        UnityWebRequest request = UnityWebRequest.Get(new_mail_arrive);

        // リクエスト送信
        yield return request.Send();

        if (request.isError)
        {
            Debug.Log("Error:" + request.error);
        }
        else
        {
            gotMail = (request.downloadHandler.text == "exist");
            Debug.Log("Result_chechmail:" + request.downloadHandler.text);
        }
    }
}
