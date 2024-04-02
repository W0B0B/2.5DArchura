using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{
    [SerializeField] List<DialogueClass> dialogues=new List<DialogueClass>();
    public static event Action<List<DialogueClass>> OnDialogue;
    public void Talk()
    {
        OnDialogue?.Invoke(dialogues);
    }
}
