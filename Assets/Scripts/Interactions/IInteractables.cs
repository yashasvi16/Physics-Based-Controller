using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public interface IInteractables
{
    public string InteractionPrompt { get; }
    public bool Interact(Interactions interaction);
    

    //public bool Interact(Interactor interactor);
}
