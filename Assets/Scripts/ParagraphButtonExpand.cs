using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParagraphButtonExpand : MonoBehaviour
{
    [HideInInspector]public Animation paragraphExpandAnim;
    
    /// <summary>
    /// Button which triggers the expanding
    /// </summary>
    private Button expandButton;

    /// <summary>
    /// To check if paragraph panel is in full size or not
    /// </summary>
    [HideInInspector]public bool expandOrNot;


    private void Awake()
    {
        paragraphExpandAnim = GetComponent<Animation>();
        expandButton = GetComponent<Button>();
        expandButton.onClick.AddListener(() => ExpandLogic());
    }

    /// <summary>
    /// Paragraph box expand aniamtion trigger
    /// </summary>
    private void ExpandLogic()
    {
        if (!expandOrNot)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
            paragraphExpandAnim.Play();
            expandButton.interactable = false;
            expandOrNot = true;
        }
        CardPaymentParentButton.checkForButton = true;
    }
}
