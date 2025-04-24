using UnityEngine;
using UnityEngine.UI;

public class RecordSelector : MonoBehaviour
{
    public static string[] recordNames = { "Romance - Fontaines D.C.", "Siamese Dream - Smashing Pumpkins", "For The First Time - Black Country New Road" };
    public Image[] recordImages;

    public static bool selectionActive;

    public static int currentIndex = 0;

    void Update()
    {
        if (!Interactor.isSelectingRecord)
        {
            HideAllImages();
            return;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentIndex = (currentIndex - 1 + recordNames.Length) % recordNames.Length;
            DisplayCurrentRecord();
            RecordSound.instance.PlayCurrentSong();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            currentIndex = (currentIndex + 1) % recordNames.Length;
            DisplayCurrentRecord();
            RecordSound.instance.PlayCurrentSong(); 
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("You selected: " + recordNames[currentIndex]);
            Interactor.isSelectingRecord = false;
            selectionActive = true;
            HideAllImages();
        }
    }
    void DisplayCurrentRecord()
    {
        Debug.Log("Current record: " + recordNames[currentIndex]);

        for (int i = 0; i < recordImages.Length; i++)
        {
            recordImages[i].enabled = (i == currentIndex);
        }
    }

    void HideAllImages()
    {
        foreach (var img in recordImages)
        {
            img.enabled = false;
        }
    }
}