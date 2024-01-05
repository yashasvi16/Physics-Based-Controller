using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactions : MonoBehaviour
{
    [SerializeField] Transform colliderPoint;
    [SerializeField] Transform interactionPoint;
    [SerializeField] LayerMask interactionLayer;
    [SerializeField] float interactionRadius = 0.5f;
    [SerializeField] InteractionPromptUI _interactionPromptUI;

    private readonly Collider[] colliders = new Collider[3];
    [SerializeField] int numCount;

    private IInteractables _interactables;
    private void Update()
    {
        //numCount = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionRadius, colliders, interactionLayer);

        //if (numCount > 0)
        //{
        //    IInteractables itr = colliders[0].GetComponent<IInteractables>();
        //    Debug.Log(gameObject.GetComponent<IInteractables>());
        //    if (itr != null && Keyboard.current.eKey.wasPressedThisFrame)
        //    {
        //        itr.Interact(this);
        //    }
        //}
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionRadius);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Hello Buddy Enter");

        if (other.gameObject.GetComponent<IInteractables>() != null)
        {
            var itr = other.gameObject.GetComponent<IInteractables>();
            
            if(!_interactionPromptUI.isDisplayed)
            {
                _interactionPromptUI.SetUp(itr.InteractionPrompt);

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("Hello Buddy Exit");

        if (other.gameObject.GetComponent<IInteractables>() != null)
        {
            var itr = other.gameObject.GetComponent<IInteractables>();

            if (_interactionPromptUI.isDisplayed)
            {
                _interactionPromptUI.Close();
            }
        }
    }
}
