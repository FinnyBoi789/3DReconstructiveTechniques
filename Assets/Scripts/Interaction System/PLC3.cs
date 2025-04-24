using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PLC3 : MonoBehaviour, IInteractable
{
    [SerializeField] private string prompt;
    [SerializeField] private GameObject filmCamera;
    [SerializeField] private GameObject filmCameraParent;

    public static event Action OnInteracted;

    public string interactionPrompt => prompt;

    public bool Interact(Interactor interactor)
    {
        Debug.Log("You have interacted with the camera.");
        OnInteracted?.Invoke();
        if (filmCamera != null && filmCameraParent != null)
        {
            filmCameraParent.transform.position = new Vector3(100, 100, 100);
        }
        return true;
    }
}