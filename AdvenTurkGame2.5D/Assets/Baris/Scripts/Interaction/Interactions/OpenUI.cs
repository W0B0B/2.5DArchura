using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUI : Interactable
{
    [SerializeField] GameObject interaction_Button;
    public override void Interact()
    {
        
        if (interaction_Button.gameObject.activeInHierarchy==true)
        {
            interaction_Button.SetActive(false);    
        }
        else
        {
            interaction_Button.SetActive(true);
        }
    }
}
