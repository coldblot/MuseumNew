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

    public string[] paymentNames;

    public PaymentInfo[] infos;


    private void Awake()
    {
        FetchPaymentSubChilds();
        AssignPaymentNames();
  
    }
    private void AssignPaymentNames()
    {
        paymentNames = new string[buttons.Length];
        for (int i = 0; i < paymentNames.Length; i++)
        {
            paymentNames[i] = buttons[i].name;
        }
    }
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
    private void AssignButtonHistory(int index,string btnName,string payment)
    {
        Array.ForEach(buttons, x =>
        {
            if (x.name == payment)
            {
                if (btnName == "History")
                {
                    x.buttons[0].title.text = "History";
                    x.buttons[0].brief.text = infos[index].History;
                }
                else if (btnName == "Pros&Cons")
                {

                    x.buttons[1].title.text = "Pros&Cons";
                    x.buttons[1].brief.text = infos[index].WhatisUPI;
                }
                else if (btnName == "DifferentPlatform")
                {
                    x.buttons[2].title.text = "DifferentPlatform";
                    x.buttons[2].brief.text = infos[index].Advantages;
                }
                else if (btnName == "HowItWorks")
                {
                    x.buttons[3].title.text = "HowItWorks";
                    x.buttons[3].brief.text = infos[index].Howitworks;
                }
                else if (btnName == "WhatIsRupay")
                {
                    x.buttons[4].title.text = "WhatIsRupay";
                    x.buttons[4].brief.text = infos[index].Easeofaccess;
                }
            }
        });
    }
    private void Start()
    {
        systems = JSONInterpretor.json;
        infos =new PaymentInfo[] {systems.UPI,systems.BHIM,systems.RuPay, systems.UPI, systems.RuPay , systems.RuPay, systems.RuPay };
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
