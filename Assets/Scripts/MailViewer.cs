using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class MailViewer : MonoBehaviour
{
    const string send_mail_for_unity = "https://vr-desktop.herokuapp.com/top/send_mail_for_unity";
    const string fetch_gmail = "https://vr-desktop.herokuapp.com/top/fetch_gmail";

    bool gotMail;
    TextMesh textMesh;

    // Use this for initialization
    void Start ()
    {
        textMesh = GetComponent<TextMesh>();
        textMesh.text = "";
    }
	
	// Update is called once per frame
	void Update ()
    {
        StartCoroutine(CheckMail());

        if (gotMail)
        {
            //StartCoroutine(GetMail());
            GetMailTest();
            gotMail = false;
        }
    }

    void GetMailTest()
    {
        Mail mail;
        mail = new Mail();
        mail.subject = "件名";
        mail.date = "2017/09/17";
        mail.from = "hogehoge@example.com";
        mail.to = "fugafuga@example.com";
        mail.text = "メールです";
        textMesh.text = mail.ToString();
    }

    IEnumerator GetMail()
    {
        Mail mail;
        UnityWebRequest request = UnityWebRequest.Get(fetch_gmail);

        // リクエスト送信
        yield return request.Send();

        if (request.isError)
        {
            Debug.Log(request.error);
        }
        else
        {
            if (request.responseCode == 200)
            {
                mail = Mail.FromJSON(request.downloadHandler.text);
                textMesh.text = mail.ToString();
            }
        }
    }

    IEnumerator CheckMail()
    {
        UnityWebRequest request = UnityWebRequest.Get(send_mail_for_unity);

        // リクエスト送信
        yield return request.Send();

        if (request.isError)
        {
            Debug.Log(request.error);
        }
        else
        {
            if (request.responseCode == 200)
            {
                gotMail = true;
            }
        }
    }
}
