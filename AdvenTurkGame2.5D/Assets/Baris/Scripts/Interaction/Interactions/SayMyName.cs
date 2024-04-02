using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SayMyName : Interactable
{
    public override void Interact()
    {
        Debug.Log(gameObject.name);
    }
}
