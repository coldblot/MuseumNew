using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PanelController : MonoBehaviour
{
    [HideInInspector]public GameObject[] allPayments;

    public AllPaymentButtons[] buttons;

    public PaymentSystems systems;

    public PaymentInfo[] infos;

    /// <summary>
    /// Very first frame of the unity before start
    /// </summary>
    private void Awake()
    {
        FetchPaymentSubChilds();
    }

    /// <summary>
    /// first frame of the unity when object initialize
    /// </summary>
    private void Start() => InitliazeObjects();

    private void AssignEvents()
    {

        for (int i = 0; i < buttons.Length; i++)
        {
            int s = i;
            for (int k = 0; k < buttons[i].buttons.Length; k++)
            {
                int m = k;
                buttons[s].buttons[k].button.onClick.AddListener(() => AssignButtonHistory(s,buttons[s].buttons[m].name,buttons[s].name));
            }   
        }
    }

    /// <summary>
    /// Assigning all the buttons under the payment 
    /// </summary>
    /// <param name="index">Check the infos gameobject for the index</param>
    /// <param name="btnName">name of buttons under payment buttons</param>
    /// <param name="payment">name of the payments which user is going to see</param>
    private void AssignButtonHistory(int index,string btnName,string payment)
    {
        Array.ForEach(buttons, x =>
        {
            if (x.name == payment)
            {
                switch (btnName)
                {
                    case "History":
                        x.buttons[0].title.text = "History";
                        x.buttons[0].brief.text = infos[index].History;
                        break;
                    case "What":
                        x.buttons[1].title.text = "What";
                        x.buttons[1].brief.text = infos[index].What;
                        break;
                    case "Advantages":
                        x.buttons[2].title.text = "Advantages";
                        x.buttons[2].brief.text = infos[index].Advantages;
                        break;
                    case "How it Works":
                        x.buttons[3].title.text = "How it works";
                        x.buttons[3].brief.text = infos[index].Howitworks;
                        break;
                    case "Ease of access":
                        x.buttons[4].title.text = "Ease of access";
                        x.buttons[4].brief.text = infos[index].Easeofaccess;
                        break;

                }
            }
        });
    }

    /// <summary>
    /// Initialize all the gameobjects 
    /// </summary>
    private void InitliazeObjects()
    {
        systems = JSONInterpretor.json;
        infos = new PaymentInfo[] { systems.DigitialRupee, systems.NACH, systems.BHIM, systems.UPI, systems.AdharPay, systems.RuPay, systems.IMPS, systems.PlasticMoney };
        AssignEvents();
    }
    private void FetchPaymentSubChilds()
    {
        allPayments = new GameObject[this.transform.childCount];

        for (int i = 0; i < allPayments.Length; i++)
        {
            allPayments[i] = this.transform.GetChild(i).gameObject;
        }
    }
}
#region Buttons&TextBox division
[System.Serializable]
public class AllPaymentButtons {

    public string name;
    public ButtonParent[] buttons = new ButtonParent[5];
}
[System.Serializable]
public class ButtonParent
{
    public string name;
    public Button button;
    public TextMeshProUGUI title;
    public TextMeshProUGUI brief;
}
#endregion
