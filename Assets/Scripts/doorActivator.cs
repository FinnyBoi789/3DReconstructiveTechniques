using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActivator : MonoBehaviour
{
    [SerializeField] private GameObject door; 
    private bool hasActivated;

    private void Update()
    {
        if (MemoriesCollected.memoriesCollected == 3 && !hasActivated)
        {
            door.SetActive(true);
            hasActivated = true;
        }
    }
}
