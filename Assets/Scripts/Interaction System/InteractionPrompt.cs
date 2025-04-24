using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionPrompt : MonoBehaviour
{
    private Camera mainCam;
    [SerializeField] private GameObject UIPanel;
    [SerializeField] private TextMeshProUGUI _promptText;
    
    public bool isDisplayed = false;
     
    private void Start()
    {
        mainCam = Camera.main;
        UIPanel.SetActive(false);
    }

    private void LateUpdate()
    {
        var rotation = mainCam.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up); 
    }

    public void SetupMethod(string promptText)
    {
        _promptText.text = promptText;
        UIPanel.SetActive(true);
        isDisplayed = true;
    }

    public void Close()
    {
        UIPanel.SetActive(false);
        isDisplayed = false;
    }
}
