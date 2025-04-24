using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NintendoSwitch : MonoBehaviour, IInteractable
{
    [SerializeField] private string prompt;
    [SerializeField] private GameObject nintendoSwitch;
    [SerializeField] private GameObject nintendoSwitchParent;

    public string interactionPrompt => prompt;

    public static event Action OnInteracted;

    public bool Interact(Interactor interactor)
    {
        Debug.Log("You have interacted with the nintendo switch.");
        OnInteracted?.Invoke();
        return true;
    }
}