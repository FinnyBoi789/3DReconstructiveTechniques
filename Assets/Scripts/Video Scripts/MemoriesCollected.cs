using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MemoriesCollected : MonoBehaviour
{
    public static int memoriesCollected = 0;

    public TextMeshProUGUI memoriesCollectedScore;

    private void Update()
    {
        memoriesCollectedScore.text = "Memories collected: " + memoriesCollected.ToString();
    }
}
