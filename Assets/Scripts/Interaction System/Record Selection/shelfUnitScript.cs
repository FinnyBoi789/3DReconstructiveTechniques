using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shelfUnitScript : MonoBehaviour
{
    public static int currentIndex = 0;
    public static string[] records = RecordSelector.recordNames;

    /*public static bool selectionActive = false;*/

    public static int currentRecordIndex = -1;

    /*void Update()
    {
        if (selectionActive)
        {
            *//*PickRecord();*//*
        }
    }*/

    /*public static void PickRecord()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentIndex++;
            if (currentIndex >= records.Length) currentIndex = 0;
            Debug.Log("Selected: " + records[currentIndex]);
            selectionActive = true;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentIndex--;
            if (currentIndex < 0) currentIndex = records.Length - 1;
            Debug.Log("Selected: " + records[currentIndex]);
            selectionActive = true;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("You picked: " + records[currentIndex]);
            // Put your record-playing logic here
        }
    }*/
}
