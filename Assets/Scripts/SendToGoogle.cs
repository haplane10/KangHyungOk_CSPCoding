using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SendToGoogle : MonoBehaviour
{
    private string url = "https://docs.google.com/forms/u/1/d/e/1FAIpQLSc2Qr40jWdyUBtFJc0HIYSwnGQBcTPSnQp8lF-OMLkWvK2AKg/formResponse";

    private Report report;

    public void Send(Report _report)
    {
        report = _report;
        StartCoroutine(PostToGoogle());
    }

    IEnumerator PostToGoogle()
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.418765262", report.ID);
        form.AddField("entry.1715759344", report.Stage);
        form.AddField("entry.421502292", report.Solve);
        form.AddField("entry.790747918", report.Success);
        form.AddField("entry.1364689016", report.NextMove);

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
}

[System.Serializable]
public class Report
{
    public string ID;
    public string Stage;
    public string Solve;
    public string Success;
    public string NextMove;
}