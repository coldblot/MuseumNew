using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class TrackManager : MonoBehaviour
{
    public  DefaultObserverEventHandler upiTarget;
    public DefaultObserverEventHandler rupayTarget;
    public Text text;
    public GameObject circleExpander;
    GameObject circleExpanderSpawn, circleExpanderSpawn2;
    public Transform panel;

    public static TrackManager instance = null;

    public static bool cardPutOn = false;

    private bool[] foundCard = new bool[2];

    public List<DefaultObserverEventHandler> objectsFound = new List<DefaultObserverEventHandler>();
    
    private void Awake()
    {
        upiTarget.OnTargetFound.AddListener(OnTargetFound1);
        upiTarget.OnTargetLost.AddListener(OnTargetLost1);
        rupayTarget.OnTargetFound.AddListener(OnTargetFound2);
        rupayTarget.OnTargetLost.AddListener(OnTargetLost2);
    }

    private void OnTargetLost2()
    {
        foundCard[1] = false;
        Destroy(circleExpanderSpawn2);
        objectsFound.Remove(rupayTarget);
    }

    private void OnTargetFound2()
    {
        foundCard[1] =  true;
        PaymentSelectionCard selectionCard = circleExpander.GetComponent<PaymentSelectionCard>();
        selectionCard.cardSelection = CardSelection.RUPAY;
        circleExpanderSpawn2 = Instantiate(circleExpander, Camera.main.WorldToScreenPoint(rupayTarget.transform.position), panel.transform.rotation);
        circleExpanderSpawn2.transform.SetParent(panel, false);
        circleExpanderSpawn2.transform.SetSiblingIndex(1);
        ScreenSwitcher.startRoutine = true;
        objectsFound.Add(rupayTarget);
    }

    private void OnTargetLost1()
    {
        foundCard[0] = false;
        Destroy(circleExpanderSpawn);
        objectsFound.Remove(upiTarget);
    }

    private void OnTargetFound1()
    {
        foundCard[0] = true;

        PaymentSelectionCard selectionCard = circleExpander.GetComponent<PaymentSelectionCard>();
        selectionCard.cardSelection = CardSelection.UPI;
        circleExpanderSpawn = Instantiate(circleExpander, Camera.main.WorldToScreenPoint(upiTarget.transform.position),panel.transform.rotation);
        circleExpanderSpawn.transform.SetParent(panel,false);
        circleExpanderSpawn.transform.SetSiblingIndex(1);
        ScreenSwitcher.startRoutine = true;
        objectsFound.Add(upiTarget);
    }
    private void Update()
    {
        if (foundCard[0])
        {
            Vector3 tempPos = Camera.main.WorldToScreenPoint(upiTarget.transform.position);
            circleExpanderSpawn.transform.position = new Vector3(tempPos.x,tempPos.y,tempPos.z);
        }
       if (foundCard[1])
        {
            circleExpanderSpawn2.transform.position = Camera.main.WorldToScreenPoint(rupayTarget.transform.position);
        }
        CheckForCard();
    }

    /// <summary>
    /// Check if card is on the table
    /// </summary>
    private void CheckForCard()
    {
        bool check = false;
        for (int i = 0; i < foundCard.Length; i++)
        {
            if (foundCard[i])
            {
                check = true;
            }
        }
        cardPutOn = check;
    }
}
