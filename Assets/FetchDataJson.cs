using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FetchDataJson : MonoBehaviour
{
    public PaymentSystems systems;


    private void Start()
    {
        systems = JSONInterpretor.json;
    }
}
