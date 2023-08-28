using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackManager : MonoBehaviour
{
    public  DefaultObserverEventHandler handlerImageTargetOne;
    public DefaultObserverEventHandler handlerImageTargetTwo;
    public Text text;
    private bool found1,found2;
    public GameObject circleExpander;
    GameObject circleExpanderSpawn, circleExpanderSpawn2;
    public Transform panel;

    private void Awake()
    {
        handlerImageTargetOne.OnTargetFound.AddListener(OnTargetFound1);
        handlerImageTargetOne.OnTargetLost.AddListener(OnTargetLost1);
        handlerImageTargetTwo.OnTargetFound.AddListener(OnTargetFound2);
        handlerImageTargetTwo.OnTargetLost.AddListener(OnTargetLost2);
    }

    private void OnTargetLost2()
    {
        found2 = false;
        Destroy(circleExpanderSpawn2);
    }

    private void OnTargetFound2()
    {
        found2 = true;
        circleExpanderSpawn2 = Instantiate(circleExpander, Camera.main.WorldToScreenPoint(handlerImageTargetTwo.transform.position), Quaternion.identity);
        circleExpanderSpawn2.transform.SetParent(panel, false);
    }

    private void OnTargetLost1()
    {
        found1 = false;
        Destroy(circleExpanderSpawn);
    }

    private void OnTargetFound1()
    {
        found1 = true;

        circleExpanderSpawn = Instantiate(circleExpander, Camera.main.WorldToScreenPoint(handlerImageTargetOne.transform.position),Quaternion.identity);
        circleExpanderSpawn.transform.SetParent(panel,false);
    }
    private void Update()
    {
        if(found1)
        {
            Vector3 tempPos = Camera.main.WorldToScreenPoint(handlerImageTargetOne.transform.position);
            circleExpanderSpawn.transform.position = new Vector3(tempPos.x,tempPos.y,tempPos.z);
        }
       if(found2)
        {
            circleExpanderSpawn2.transform.position = Camera.main.WorldToScreenPoint(handlerImageTargetTwo.transform.position);
        }
    }
}
