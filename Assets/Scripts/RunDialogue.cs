using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class RunDialogue : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public string dialogueToRun;
    public bool hasStarted = false;
    public bool spaceship = false;
    public bool ending;

    public Player player;
    public void startDialogue() {
    if(player != null && player.hasSun && spaceship) {
        ending = true;
        gameObject.GetComponent<FadeInScenes>().scene = "Ending";
        gameObject.GetComponent<FadeInScenes>().fadeTime = 1;
        if (!dialogueRunner.IsDialogueRunning) {
            dialogueRunner.StartDialogue("Mission_7");

        }
    }
    if(!dialogueRunner.IsDialogueRunning && !hasStarted) {
        dialogueRunner.StartDialogue(dialogueToRun);
        hasStarted = true;
    }
    }
}
