using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class YarnFunctions : MonoBehaviour {
    private FadeInScenes fader;

    // Drag and drop your Dialogue Runner into this variable.
    public DialogueRunner dialogueRunner;

    public void Awake() {
        fader = gameObject.GetComponent<FadeInScenes>();
        // Create a new command called 'camera_look', which looks at a target. 
        // Note how we're listing 'GameObject' as the parameter type.
        dialogueRunner.AddCommandHandler<bool>(
            "fade_camera",     // the name of the command
            fader.FadeToBlack // the method to run
        );
    }
}