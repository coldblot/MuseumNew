using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonExpanding : MonoBehaviour,IDragHandler
{
    /// <summary>
    /// Animation which will allow to appear buttons and its lines
    /// </summary>
    Animation buttonExpandingAnim;

    /// <summary>
    /// Clip for disappearing buttons
    /// </summary>
    public AnimationClip clip;

    /// <summary>
    /// Button on which user which click
    /// </summary>
    Button buttonExpander;

    /// <summary>
    ///Button object on which animation button component is attached 
    /// </summary>
    public GameObject button;

    /// <summary>
    /// Check if user click on button and expand the buttons
    /// </summary>
    public static bool expandOrNot;

    /// <summary>
    /// Animation for overall panel where all circles float
    /// </summary>
    public Animation circleFloating;


    /// <summary>
    /// Panel Controller containes all its child gameobject
    /// </summary>
    public PanelController panelController;

    /// <summary>
    /// Capture the starting position of this object to reset later
    /// </summary>
    private Vector3[] startPos;

    /// <summary>
    /// When user disables the button then transition happens
    /// </summary>
    public GameObject transitionPanel;

    public CardPaymentParentButton buttonParent;

    /// <summary>
    /// First start the page
    /// </summary>
    private void Awake() => InitializeStage();

    private void ExpandingLogic()
    {
        if (!expandOrNot)
        {
            circleFloating.Stop();
            buttonExpandingAnim.Play();
            expandOrNot = true;
            Array.ForEach(panelController.allPayments,x=> { if (x.name != this.name) { x.SetActive(false); } });
       
        }
       else
        {
            buttonExpandingAnim.Play("Disappear");
            expandOrNot = false;
            StartCoroutine(BubbleRestart());
        }
    }
    /// <summary>
    /// Setup for starting stage
    /// </summary>
    private void InitializeStage()
    {
        startPos = new Vector3[panelController.allPayments.Length];
        for (int i = 0; i < startPos.Length; i++)
        {
            startPos[i] = panelController.allPayments[i].transform.localPosition;
        }
        transitionPanel.SetActive(false);
        buttonExpandingAnim = GetComponent<Animation>();
        buttonExpander = button.GetComponent<Button>();
        buttonExpandingAnim.AddClip(clip, "Disappear");
        buttonExpander.onClick.AddListener(() => ExpandingLogic());
    }
    /// <summary>
    /// Setup the bubbles position after user go back to last position
    /// </summary>
    /// <returns></returns>
    private IEnumerator BubbleRestart()
    {
        //yield return new WaitForSeconds(1);
        //this.transform.localPosition = startPos;
        transitionPanel.SetActive(true);
        for (int i = 0; i < startPos.Length; i++)
        {
            panelController.allPayments[i].transform.localPosition = startPos[i];
        }
        Array.ForEach(panelController.allPayments, x => { x.SetActive(true); });
        yield return new WaitForSeconds(2f);
        circleFloating.Play();
        transitionPanel.SetActive(false);
    }

    /// <summary>
    /// Functionality to drag the gameobject 
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {
        float xDelta = -(eventData.position.x / 6213.471f)+0.11f;
        float yDelta= (eventData.position.y / 6213.471f)-0.01f;

        this.GetComponent<RectTransform>().localPosition = new Vector3(this.GetComponent<RectTransform>().localPosition.x,yDelta, xDelta);

# if UNITY_EDITOR //Debug.Log(" y: " + yDelta + "x:" + -xDelta + " localPostion:" + this.GetComponent<RectTransform>().localPosition);
#endif
    }
}
