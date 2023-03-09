using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class RunDialogue : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public string dialogueToRun;
    public void startDialogue() {
        dialogueRunner.StartDialogue(dialogueToRun);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
