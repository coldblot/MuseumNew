using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CsvReader : MonoBehaviour
{
    Image image;
    void Start()
    {
        StartCoroutine(WebsRequest());
    }
    IEnumerator WebsRequest()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://sheets.googleapis.com/v4/spreadsheets/1yqZrL9t_pn7TcvRqqx0jDf-pQ-IstRTmuyfOf9FVnVc/values/Museum?key=AIzaSyCgKZNPagWnByV9HTAm9YM_ivtTrhEGicQ");

        yield return www.SendWebRequest();
        if(www.result==UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Offline");
        }
        else
        {
            string json = www.downloadHandler.text;
            var o = JSON.Parse(json);
            Debug.Log(o[2][0][1][1]);
        }

    }
}
