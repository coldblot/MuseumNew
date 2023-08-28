using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARFoundationManager : MonoBehaviour
{
 ARTrackedImageManager trackedManager;
    private void Awake()
    {
        trackedManager = FindObjectOfType<ARTrackedImageManager>();
    }
    private void OnEnable()
    {
        trackedManager.trackedImagesChanged += OnImageChanged;
    }
    private void OnDisable()
    {
        trackedManager.trackedImagesChanged -= OnImageChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs obj)
    {
        foreach (var item in obj.added)
        {
            Debug.Log(item.name);
        }
    }
}
