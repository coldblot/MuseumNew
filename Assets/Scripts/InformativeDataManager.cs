using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformativeDataManager : MonoBehaviour
{
    public Transform[] photoInfo;
    public IInformation information;
    private void Awake()
    {
        photoInfo = new Transform[this.transform.childCount];
        for (int i = 0; i < photoInfo.Length; i++)
        {
            photoInfo[i] = this.transform.GetChild(i).GetChild(0).transform;
        }
      
    }
    private void Start()
    {
        informationManager manager = new informationManager(information);
        manager.InformationInitliaze();
    }
}
