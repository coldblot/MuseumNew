using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System.IO;
using System.Xml.Serialization;
using System;

#region Data Came from json/xml file

/// <summary>
/// Creating a class for deserialize the data
/// </summary>
[System.Serializable]
public class PaymentInfo
{
    public string History;
    public string What;
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
    public PaymentInfo NACH;
    public PaymentInfo IMPS;
    public PaymentInfo DigitialRupee;
    public PaymentInfo PlasticMoney;
    public PaymentInfo AdharPay;
    public CryptoCurrency CryptoCurrency;
}
[System.Serializable]
public class CryptoCurrency
{
    public string History;
    public string What;
    public string Advantages;
    public string Disadvantage;
}
#endregion

public class JSONInterpretor : MonoBehaviour
{
    /// <summary>
    /// Creating a static variable of payments systems so that any object can access data
    /// </summary>
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
            try  //Check if data is parsing properly from json file
            {
                string data = File.ReadAllText(path);
                JSONNode node = JSON.Parse(data);
                json = JsonUtility.FromJson<PaymentSystems>(node.ToString());
            }
            catch
            {
                Debug.LogError("There is some problem with JSON file!");
            }
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
            UPI = new PaymentInfo() { History = "asdasd", What = "xcv", Howitworks = "scxvxcv", Advantages = "asdasczxcz", Easeofaccess = "zxczxcz" },
        };
        if (File.Exists(path))
        {
            try  //Check if data is parsing properly from xml file
            {
                XmlSerializer xml = new XmlSerializer(typeof(PaymentSystems));
                using (StreamReader reader = new StreamReader(path))
                {
                    PaymentSystems o = (PaymentSystems)xml.Deserialize(reader);
                    Debug.LogError(o.UPI.Advantages);
                }
            }
            catch
            {
                Debug.LogError("There is some problem with XML file!");
            }
        }
    }
}
