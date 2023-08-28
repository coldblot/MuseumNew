using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public enum CardSelection { None,UPI,RUPAY };
public class PaymentSelectionCard : MonoBehaviour
{
    public ButtonInformation[] paymentInformationButton;
    public GameObject[] panelExpands;

    private bool active;

    public CardSelection cardSelection;

    public PaymentSystems json;

    private void Awake()
    {
        FetchItems();
        TurnOffPanels();
        AssignEvents();
    }
    private void Start()
    {
        json = JSONInterpretor.json;
        PaymentInformationPass();
        InformationSetText();
    }
    private void FetchItems()
    {
        panelExpands = new GameObject[paymentInformationButton.Length];

        for (int i = 0; i < panelExpands.Length; i++)
        {
            panelExpands[i] = paymentInformationButton[i].btn.transform.Find("PanelExpand").gameObject;
            paymentInformationButton[i].briefScroll = FindChild(panelExpands[i].transform.GetChild(1)).GetComponent<TextMeshProUGUI>();
            paymentInformationButton[i].title = panelExpands[i].transform.Find("Panel").Find("Title").GetComponent<TextMeshProUGUI>();
        }
        //Debug.LogError(panelExpands[1].transform.Find("Panel").Find("Title").name);
    }

    //Recurssively check for the child till the end 
    private Transform FindChild(Transform child)
    {
        if (child.childCount==0)
        {
            return child;
        }
        Transform subChild =child.GetChild(0);
        return FindChild(subChild);
    }
    private void TurnOffPanels()
    {
        Array.ForEach(panelExpands, x => x.SetActive(false));
    }
    private void AssignEvents()
    {
        for (int i = 0; i < paymentInformationButton.Length; i++)
        {
            int j = i;
            paymentInformationButton[j].btn.onClick.AddListener(() => AssignFunction(j));
        }
    }
    private void AssignFunction(int index)
    {
        int k = index;
        if (active)
        {
            panelExpands[k].SetActive(false);
            active = false;
            return;
        }
        Array.ForEach(panelExpands, x => { if (x != panelExpands[k]) { x.SetActive(false); } else { x.SetActive(true); active = true; 
                } });
    }
    private void PaymentInformationPass()
    {
        switch (cardSelection)
        {
            case CardSelection.RUPAY:
                this.paymentInformationButton[0].information = json.RuPay.History;
                this.paymentInformationButton[1].information = json.RuPay.What;
                this.paymentInformationButton[2].information = json.RuPay.Advantages;
                this.paymentInformationButton[3].information = json.RuPay.Howitworks;
                this.paymentInformationButton[4].information = json.RuPay.Easeofaccess;
                break;
            case CardSelection.UPI:
                this.paymentInformationButton[0].information = json.UPI.History;
                this.paymentInformationButton[1].information = json.UPI.What;
                this.paymentInformationButton[2].information = json.UPI.Advantages;
                this.paymentInformationButton[3].information = json.UPI.Howitworks;
                this.paymentInformationButton[4].information = json.UPI.Easeofaccess;
                break;
            default:
                this.paymentInformationButton[0].information = String.Empty;
                this.paymentInformationButton[2].information = String.Empty;
                this.paymentInformationButton[3].information = String.Empty;
                this.paymentInformationButton[4].information = String.Empty;
                this.paymentInformationButton[1].information = String.Empty;
                break;

        }

    }
    private void InformationSetText()
    {
        for (int i = 0; i < paymentInformationButton.Length; i++)
        {
            paymentInformationButton[i].title.text = paymentInformationButton[i].buttonName;
          
            paymentInformationButton[i].briefScroll.text = paymentInformationButton[i].information;
            //Debug.LogError("title"+ paymentInformationButton[i].title.text+"brief"+ paymentInformationButton[i].briefScroll.text);
        }
    }
}

[System.Serializable]
public class ButtonInformation {
    public string buttonName;
    public Button btn;
    public string information;

    public TextMeshProUGUI title;
    public TextMeshProUGUI briefScroll;
}