using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask interactableMask;
    [SerializeField] private InteractionPrompt interactionPrompt;
    public static bool isSelectingRecord = false;
    private InteractionParticleSystem currentParticleSystem = null;

    private readonly Collider[] colliders = new Collider[3];
    [SerializeField] private int numFound;

    private IInteractable interactable;

    private void Update()
    {
        numFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionPointRadius, colliders, interactableMask);

        if (numFound > 0)
        {
            interactable = colliders[0].GetComponent<IInteractable>();
            currentParticleSystem = colliders[0].GetComponent<InteractionParticleSystem>();

            if (interactable != null)
            {
                if (!interactionPrompt.isDisplayed)
                {
                    interactionPrompt.SetupMethod(interactable.interactionPrompt);
                }

                if (currentParticleSystem != null)
                {
                    currentParticleSystem.PlayParticles();
                }

                if (Input.GetKeyDown(KeyCode.E) && !isSelectingRecord)
                {
                    interactable.Interact(this);
                }
            }
            else
            {
                if (interactionPrompt.isDisplayed)
                {
                    interactionPrompt.Close();
                }

                if (currentParticleSystem != null)
                {
                    currentParticleSystem.StopParticles();
                    currentParticleSystem = null;
                }
            }
        }
        else
        {
            if (interactionPrompt.isDisplayed)
            {
                interactionPrompt.Close();
            }

            if (currentParticleSystem != null)
            {
                currentParticleSystem.StopParticles();
                currentParticleSystem = null;
            }

            interactable = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionPointRadius);
    }
}