using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Record : MonoBehaviour, IInteractable
{
    [SerializeField] private string prompt;
    [SerializeField] private GameObject shelfUnit;

    public string interactionPrompt => prompt;

    public bool Interact(Interactor interactor)
    {
        Debug.Log("You can now pick a record.");
        Interactor.isSelectingRecord = true;
        return true;
    }
}