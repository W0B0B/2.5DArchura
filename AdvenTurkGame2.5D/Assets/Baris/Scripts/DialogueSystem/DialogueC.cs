using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
[System.Serializable]
public class DialogueClass
{

    public string Dialogue;
    public bool IsEnd;
    public bool IsQuestion;
    [Header("ANSWERS")]
    public List<AnswerClass> Answers=new List<AnswerClass>();
    [Header("EVENTS")]
    public UnityEvent StartDialogueEvent;
    public UnityEvent EndDialogueEvent;
}
[System.Serializable]
public class AnswerClass
{
    public string Answer;
    public UnityEvent AnswerEvent;
    public int JumpDIndex;
}
