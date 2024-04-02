using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCollor : Interactable
{
    public override void Interact()
    {
        GetComponent<SpriteRenderer>().color=Color.blue;
    }
}
