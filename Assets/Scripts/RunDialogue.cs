using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class RunDialogue : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public string dialogueToRun;
    public bool spacelvl;
    public bool hasStarted;
    public void startDialogue() {
        dialogueRunner.StartDialogue(dialogueToRun);
        hasStarted = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (spacelvl && hasStarted) {
            if (!dialogueRunner.IsDialogueRunning) {
                gameObject.GetComponent<LoadScene>().FadeToBlack();
                spacelvl = false;
            }
        }
    }
}
