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
        string str = "";
        str += "Title: " + subject + "\n";
        str += "From:  " + from + "\n";
        str += "To:    " + to + "\n";
        str += "\n" + text + "\n";
        return str;
    }
}
