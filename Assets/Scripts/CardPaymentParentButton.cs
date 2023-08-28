using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPaymentParentButton : MonoBehaviour
{
    public ParagraphButtonExpand[] childParagraph;
    public int index = 0;
    public static bool checkForButton;

    private void Awake()
    {
        childParagraph = new ParagraphButtonExpand[this.transform.childCount];
        for (int i = 0; i < childParagraph.Length; i++)
        {
            childParagraph[i] = this.transform.GetChild(i).GetComponent<ParagraphButtonExpand>();
        }
    }
    private void Update()
    {
        if (checkForButton)
            CheckForExpandButton();
    }
    private void CheckForExpandButton()
    {
       
        for (int i = 0; i < childParagraph.Length; i++)
        {
            if (childParagraph[i].expandOrNot)
            {
                childParagraph[i].expandOrNot = false;
                continue;
            }
            else
            {
                childParagraph[i].paragraphExpandAnim.Stop();
                childParagraph[i].transform.GetChild(0).gameObject.SetActive(false);
                childParagraph[i].GetComponent<Button>().interactable = true;
            }
        }
        checkForButton = false;
    }

    /// <summary>
    ///When button active not true then all panels should be close 
    /// </summary>
    private void OnDisable()
    {
        DisableParagraphPanel();
    }
    public void DisableParagraphPanel() => Array.ForEach(childParagraph, x => x.transform.GetChild(0).gameObject.SetActive(false));
}
