using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SimpleJSON;
using System.IO;

using System.Xml.Serialization;

#region Data Came from json file
[System.Serializable]
public class PaymentInfo
{
    public string History;
    public string WhatisUPI;
    public string Advantages;
    public string Howitworks;
    public string Easeofaccess;
}
[System.Serializable]
public class PaymentSystems
{
    public PaymentInfo UPI;
    public PaymentInfo RuPay;
    public PaymentInfo BHIM;
}
#endregion

public class JSONInterpretor : MonoBehaviour
{
    public static PaymentSystems json;

    private void Awake()=> JsonFileRead(Application.dataPath + "/JSONFiles/InformationFile.txt");

    /// <summary>
    /// Read the data from json file
    /// </summary>
    /// <param name="path"></param>
    private void JsonFileRead(string path)
    {
        if (File.Exists(path))
        {
            string data = File.ReadAllText(path);
            JSONNode node = JSON.Parse(data);
            json = JsonUtility.FromJson<PaymentSystems>(node.ToString());
            Debug.Log(json.BHIM.Easeofaccess);
        }
    }

    /// <summary>
    /// If we need to use xml file instead of json version 
    /// </summary>
    /// <param name="path"></param>
    private void XmlFileRead(string path)
    {
        PaymentSystems system = new PaymentSystems()
        {
            UPI = new PaymentInfo() { History = "asdasd", WhatisUPI = "xcv", Howitworks = "scxvxcv", Advantages = "asdasczxcz", Easeofaccess = "zxczxcz" },
        };
        if (File.Exists(path))
        {
            XmlSerializer xml = new XmlSerializer(typeof(PaymentSystems));
            using (StreamReader reader = new StreamReader(path))
            {
                PaymentSystems o=(PaymentSystems)xml.Deserialize(reader);
                Debug.LogError(o.UPI.Advantages);
            }
    
        }
    }
}
