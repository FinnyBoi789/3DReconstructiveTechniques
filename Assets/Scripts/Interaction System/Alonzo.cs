using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Alonzo : MonoBehaviour, IInteractable
{
    [SerializeField] private string prompt;
    [SerializeField] private GameObject alonzo;
    [SerializeField] private GameObject alonzoParent;

    public string interactionPrompt => prompt;

    public static event Action OnInteracted;

    public bool Interact(Interactor interactor)
    {
        Debug.Log("You have interacted with alonzo.");
        OnInteracted?.Invoke();
        return true;
    }
}