using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScript : MonoBehaviour
{
    [SerializeField] private Light directionalLight;
    [SerializeField] private Color warmLightColor;
    [SerializeField] private ParticleSystem sakura;
    private Color originalColor;

    void Start()
    {
        originalColor = directionalLight.color;
        sakura.Stop();
    }

    private bool hasPlayedParticles = false;

    private void Update()
    {
        if (MemoriesCollected.memoriesCollected == 3 && !hasPlayedParticles)
        {
            directionalLight.color = warmLightColor;
            sakura.Play();
            hasPlayedParticles = true;
        }
    }
}
