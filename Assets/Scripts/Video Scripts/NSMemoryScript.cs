using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Video;

public class NSMemoryScript : MonoBehaviour
{
    [SerializeField] private GameObject cameraMemory;
    [SerializeField] private VideoPlayer videoPlayer;

    void Start()
    {
        HideVideo();
        NintendoSwitch.OnInteracted += PlayVideo;
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += OnVideoFinished;
        }
    }

    void OnDestroy()
    {
        NintendoSwitch.OnInteracted -= PlayVideo;
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
        if (cameraMemory != null && videoPlayer != null)
        {
            cameraMemory.SetActive(true);
            videoPlayer.Play();
        }
    }

    void HideVideo()
    {
        if (cameraMemory != null)
        {
            cameraMemory.SetActive(false);
        }
        if (videoPlayer != null)
        {
            videoPlayer.Stop();
        }
    }
}