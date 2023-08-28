using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSwitcher : MonoBehaviour
{
    public GameObject transition;

    public GameObject allPaymentCards;

    public static bool startRoutine=true;

    // Update is called once per frame
    void Update()
    {
        if (TrackManager.cardPutOn && startRoutine)
        {    
            StartCoroutine(StartTransition(allPaymentCards,false));
            startRoutine = false;
        }
        else if(!TrackManager.cardPutOn && !startRoutine)
        {
            StartCoroutine(StartTransition(allPaymentCards, true));
            startRoutine = true;
        }
    }
    private IEnumerator StartTransition(GameObject active, bool on)
    {
        transition.SetActive(true);
        active.SetActive(on);
        yield return new WaitForSeconds(1f);
        transition.SetActive(false);
    }
}
