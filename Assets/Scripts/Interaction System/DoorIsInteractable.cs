using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DoorIsInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private string prompt;
    [SerializeField] private Image fade;
    [SerializeField] private TextMeshProUGUI text;

    private bool hasFaded = false;
    
    public string interactionPrompt => prompt;

    public static event Action OnInteracted;

    private void Start()
    {
        gameObject.SetActive(false);

        if (fade != null)
        {
            fade.canvasRenderer.SetAlpha(0f);
            text.canvasRenderer.SetAlpha(0f);
        }
    }

    public bool Interact(Interactor interactor)
    {
        Debug.Log("You have opened the door.");
        OnInteracted?.Invoke();
        EndGame();
        return true;
    }

    void EndGame()
    {
        if (fade != null && !hasFaded)
        {
            hasFaded = true;
            fade.CrossFadeAlpha(1f, 2f, false);
            Invoke("TheEnd", 6f);
            Invoke("QuitGame", 9f);
        }
    }

    void QuitGame()
    {
        Debug.Log("Game Over.");
        Application.Quit();
    }

    void TheEnd()
    {
        text.CrossFadeAlpha(1f, 2f, false);
    }
}
