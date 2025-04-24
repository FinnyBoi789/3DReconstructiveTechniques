using UnityEngine;
using UnityEngine.UI;

public class RecordSound : MonoBehaviour
{
    public string[] recordNames = RecordSelector.recordNames;
    public AudioClip[] audioClips;

    public AudioSource source;
    private bool hasSelected;

    public static RecordSound instance;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (source == null)
        {
            source = GetComponent<AudioSource>();
        }
        
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("You selected: " + RecordSelector.recordNames[RecordSelector.currentIndex]);
            hasSelected = true;

            Interactor.isSelectingRecord = false;
            RecordSelector.selectionActive = false;

            source.clip = audioClips[RecordSelector.currentIndex];
            source.loop = true;
            source.Play();
        }

        if (!Interactor.isSelectingRecord && !hasSelected)
        {
            StopAudio();
            return;
        }

        
    }

    public void PlayCurrentSong()
    {
        if (audioClips.Length > RecordSelector.currentIndex)
        {
            Debug.Log("Now Playing: " + audioClips[RecordSelector.currentIndex].name);
            source.clip = audioClips[RecordSelector.currentIndex];
            source.loop = false;
            source.Play();
        }
    }

    void StopAudio()
    {
        source.Stop();
    }
}