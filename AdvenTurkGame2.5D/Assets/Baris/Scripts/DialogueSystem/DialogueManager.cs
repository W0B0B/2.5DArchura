using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DialogueManager : MonoBehaviour
{

    [Header("TextBox")]
    [SerializeField] GameObject textBox;


    [Header("Dialogue Text Property")]
    [SerializeField] TMP_Text dialogueText;
    [SerializeField] float textSpeed;


    [Header("Buttons")]
    [SerializeField] List<Button> buttons=new List<Button>();
    [SerializeField] List<TMP_Text> m_buttonText=new List<TMP_Text>(); 

    
    int currentDialogueIndex;
    bool isOptionSelected;
    int selectedAnswer;
    List<DialogueClass> _receivedDialogues;
    private void OnEnable() {
        DialogueHolder.OnDialogue+=DialogueReceiver;
    }
    private void OnDisable() {
        DialogueHolder.OnDialogue-=DialogueReceiver;
    }


    private void DialogueReceiver(List<DialogueClass> list)
    {
        _receivedDialogues=list;        
        StartCoroutine(PlayDialogue());
    }


    private IEnumerator PlayDialogue()
    {
        textBox.SetActive(true);
        while (currentDialogueIndex<_receivedDialogues.Count)
        {
            DialogueClass line=_receivedDialogues[currentDialogueIndex];
            
            if (line.IsQuestion==true)
            {
                yield return StartCoroutine(TypeText(line.Dialogue));
                for (int i = 0; i < line.Answers.Count; i++)
                {
                    m_buttonText[i].text=line.Answers[i].Answer;
                    buttons[i].gameObject.SetActive(true);
                    int index=i;
                    buttons[i].onClick.AddListener(()=>
                    {
                        Debug.Log(index);
                        HandleOptionSelected(line.Answers[index].JumpDIndex);
                    });    
                }
                yield return new WaitUntil(()=>isOptionSelected==true);
            }
            else
            {
                yield return StartCoroutine(TypeText(line.Dialogue));
            }
        }
    }
    void DisableButton()
    {
        foreach (var item in buttons)
        {
            item.gameObject.SetActive(false);
        }
    }
    void HandleOptionSelected(int jumpIndex)
    {
        isOptionSelected=true;
        DisableButton();
        currentDialogueIndex=jumpIndex;

    }
    private IEnumerator TypeText(string text)
    {
        dialogueText.text="";

        foreach (char letter in text.ToCharArray())
        {
            dialogueText.text+=letter;
            yield return new WaitForSeconds(textSpeed);
        }
        isOptionSelected=false;
        if (_receivedDialogues[currentDialogueIndex].IsQuestion==false)
        {
            yield return new WaitUntil(()=>Input.GetMouseButtonDown(0));
        }
        if (_receivedDialogues[currentDialogueIndex].IsEnd)
        {
            DialogueStop();
        }
    }

    private void DialogueStop()
    {
        StopAllCoroutines();
        textBox.SetActive(false);
        currentDialogueIndex=0;
    }
}
