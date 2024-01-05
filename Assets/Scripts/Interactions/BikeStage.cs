using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeStage : MonoBehaviour, IInteractables
{
    [SerializeField] string _prompt;
    public string InteractionPrompt => _prompt;
    public bool Interact(Interactions interactor)
    {
        _prompt = "Harley Davidson \n Color : Rust Brown \n Engine : 500CC \n Price : 600k";
        return true;
    }
}
