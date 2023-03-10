using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class RunDialogue : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public string dialogueToRun;
    public bool hasStarted;
    public bool ending;

    public Player player;
    public void startDialogue() {
    if(!dialogueRunner.IsDialogueRunning) {
        dialogueRunner.StartDialogue(dialogueToRun);
        hasStarted = true;
    }
    }
    // Update is called once per frame
    void Update()
    {
        if(player != null && ending) {
            if (!dialogueRunner.IsDialogueRunning && player.hasSun) {
                dialogueRunner.StartDialogue("Mission_7");
            ending = true;
            gameObject.GetComponent<FadeInScenes>().scene = "Ending";
            gameObject.GetComponent<FadeInScenes>().fadeTime = 1;

            }
        }

    }
}
