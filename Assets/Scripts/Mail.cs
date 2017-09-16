using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mail
{
    public string subject;
    public string date;
    public string from;
    public string to;
    public string text;

    public static Mail FromJSON(string json)
    {
        return JsonUtility.FromJson<Mail>(json);
    }

    public override string ToString()
    {
        string text = "";
        text += "Title: " + subject + "\n";
        text += "From:  " + from + "\n";
        text += "To:    " + to + "\n";
        text += "Body:\n" + text + "\n";
        return text;
    }
}
