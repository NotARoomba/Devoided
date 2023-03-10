using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class YarnFunctions : MonoBehaviour {
    private FadeInScenes fader;

    // Drag and drop your Dialogue Runner into this variable.
    public DialogueRunner dialogueRunner;
    public GameObject clock;
    private bool animated = false;
    public Sprite[] cardSprites;


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
        dialogueRunner.AddCommandHandler<int>(
            "give_card",     // the name of the command
            GiveCard // the method to run
        );
        dialogueRunner.AddCommandHandler(
            "give_sword",     // the name of the command
            GiveSword // the method to run
        );
        dialogueRunner.AddCommandHandler<bool>(
            "can_jump",     // the name of the command
            CanJump // the method to run
        );

    }
    private void ShowClock(bool isAnimated) {
        animated = isAnimated;
        clock.SetActive(true);
        
    }
    void Update() {
        clock.transform.position = gameObject.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/2, 6));
        clock.GetComponent<Animator>().SetBool("Animate", animated);
    }
    void GiveCard(int card) {
        clock.transform.parent.GetComponentInChildren<Inventory>().setSlot("Card", cardSprites[card], card);
    }
    void GiveSword() {
        clock.transform.parent.GetComponentInChildren<Player>().hasSword = true;
    }
    [YarnCommand("emperor_delay")]
    static void EmperorDelay(GameObject target, bool delay) {
        if (target == null) {
            Debug.Log("Cant find the Emperor!");
        }
        target.GetComponent<EmperorBoss>().isTalking = delay;
    }
    void CanJump(bool jump) {
        clock.transform.parent.GetComponentInChildren<Player>().canJump = jump;
    }
}