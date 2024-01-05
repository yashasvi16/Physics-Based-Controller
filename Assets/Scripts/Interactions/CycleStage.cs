using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleStage : MonoBehaviour, IInteractables
{
    [SerializeField] string _prompt;
    public string InteractionPrompt => _prompt;
    public bool Interact(Interactions interactor)
    {
        Debug.Log("Color : Metallic Black");
        Debug.Log("Engine : Not Available");
        Debug.Log("Price : 20k");
        return true;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("Cycle Stage 1");

    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        Debug.Log("Did it");
    //    }
    //}
}
