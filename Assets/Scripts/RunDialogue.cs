using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class RunDialogue : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public string dialogueToRun;
    public bool spacelvl;
    public bool spaceship;
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
        if(player != null && player.hasSun) {
            if (!dialogueRunner.IsDialogueRunning && !ending)
                dialogueRunner.StartDialogue("Mission_7");
            ending = true;
            gameObject.GetComponent<FadeInScenes>().scene = "Ending";
            gameObject.GetComponent<FadeInScenes>().fadeTime = 1;
        }
        else if (spacelvl && hasStarted) {
            if (!dialogueRunner.IsDialogueRunning) {
                gameObject.GetComponent<FadeInScenes>().FadeToBlack(true);
                spacelvl = false;
            }
        }
        else if (spaceship && hasStarted) {
            if (!dialogueRunner.IsDialogueRunning) {
                spacelvl = false;
            }
        }


    }
}
