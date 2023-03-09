using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class YarnFunctions : MonoBehaviour {
    private FadeInScenes fader;

    // Drag and drop your Dialogue Runner into this variable.
    public DialogueRunner dialogueRunner;
    public GameObject clock;

    public void Awake() {
        fader = gameObject.GetComponent<FadeInScenes>();
        // Create a new command called 'camera_look', which looks at a target. 
        // Note how we're listing 'GameObject' as the parameter type.
        dialogueRunner.AddCommandHandler<bool>(
            "fade_camera",     // the name of the command
            fader.FadeToBlack // the method to run
        );
        dialogueRunner.AddCommandHandler<bool>(
            "show_clock",     // the name of the command
            ShowClock // the method to run
        );
    }
    private void ShowClock(bool isAnimated) {
        clock.transform.position = gameObject.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/2, 6));
        if (isAnimated) {
            clock.GetComponent<Animator>().SetTrigger("Animate");
            clock.GetComponent<Animator>().ResetTrigger("Idle");
        }     
        else {
            clock.GetComponent<Animator>().ResetTrigger("Animate");
            clock.GetComponent<Animator>().SetTrigger("Idle");
        }

        clock.SetActive(true);
        
    }
}