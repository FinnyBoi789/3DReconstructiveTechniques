using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Video;

public class AlonzoMemoryScript : MonoBehaviour
{
    [SerializeField] private GameObject alonzoMemory;
    [SerializeField] private VideoPlayer videoPlayer;

    void Start()
    {
        HideVideo();
        Alonzo.OnInteracted += PlayVideo;
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += OnVideoFinished;
        }
    }

    void OnDestroy()
    {
        Alonzo.OnInteracted -= PlayVideo;
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached -= OnVideoFinished;
        }
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        MemoriesCollected.memoriesCollected += 1;
        HideVideo();
    }

    void PlayVideo()
    {
        if (alonzoMemory != null && videoPlayer != null)
        {
            alonzoMemory.SetActive(true);
            videoPlayer.Play();
        }
    }

    void HideVideo()
    {
        if (alonzoMemory != null)
        {
            alonzoMemory.SetActive(false);
        }
        if (videoPlayer != null)
        {
            videoPlayer.Stop();
        }
    }
}