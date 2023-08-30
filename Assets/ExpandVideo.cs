using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ExpandVideo : MonoBehaviour
{
    public Button expand;
    public Button shrink;

    public Animation animationToPlay;

    public VideoPlayer player;

    public GameObject videoPanel;

    public PaymentSelectionCard selectionController;

    public GameObject videoScreenIn, videoScreenOut;

    private void Awake()
    {
        expand.onClick.AddListener(()=> ExpandButton());
        shrink.onClick.AddListener(() => ShrinkButton());
        player.clip = selectionController.clipToPlay;
    }

    private void ExpandButton()
    {
        shrink.gameObject.SetActive(true);
        expand.gameObject.SetActive(false);
        AnimationClip panelExpand= animationToPlay.GetClip("PanelExpandVideo");
        animationToPlay.Play("PanelExpandVideo");
        videoPanel.SetActive(true);
        
    }
    private void ShrinkButton()
    {
        shrink.gameObject.SetActive(false);
        expand.gameObject.SetActive(true);
        animationToPlay.Play("PanelShrinkVideo");
        player.Stop();

        videoScreenIn.SetActive(true);
        videoScreenOut.SetActive(false);
    }
    private void OnDisable()
    {
        shrink.gameObject.SetActive(false);
        expand.gameObject.SetActive(true);
        videoScreenIn.SetActive(true);
        videoScreenOut.SetActive(false);
    }
    private void OnEnable()
    {
        videoScreenIn.SetActive(true);
        videoScreenOut.SetActive(false);
    }
}
