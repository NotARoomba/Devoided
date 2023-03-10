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
    public Sun sun;


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
        dialogueRunner.AddCommandHandler("change_sun", ChangeSun);
        dialogueRunner.AddCommandHandler("show_cards", showCards);
        dialogueRunner.AddCommandHandler("player_ending", playerEnding);

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
        Sprite[] cardSprites = clock.transform.parent.GetComponentInChildren<Inventory>().sprites;
        clock.transform.parent.GetComponentInChildren<Inventory>().setSlot("Card", cardSprites[card], card-1<0?0:card-1);
        switch (card)
        {
            case 1:
                clock.transform.parent.GetComponentInChildren<Player>().hasMagician = true;
                break;
            case 2:
               clock.transform.parent.GetComponentInChildren<Player>().hasEmperor = true;
                break;
            case 3:
                clock.transform.parent.GetComponentInChildren<Player>().hasDeath = true;
                break;
            case 4:
                clock.transform.parent.GetComponentInChildren<Player>().hasWorld = true;
                break;
            case 5:
                clock.transform.parent.GetComponentInChildren<Player>().hasSun = true;
                break;
            case 6:
                clock.transform.parent.GetComponentInChildren<Player>().hasFool = true;
                break;
        }
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
    [YarnCommand("death_delay")]
    static void DeathDelay(GameObject target, bool delay) {
        if (target == null) {
            Debug.Log("Cant find Death lol!");
        }
        target.GetComponent<DeathBoss>().isTalking = delay;
    }
    void CanJump(bool jump) {
        clock.transform.parent.GetComponentInChildren<Player>().canJump = jump;
    }
    void ChangeSun() {
        sun.ChangeSun();
    }
    void showCards() {
        clock.transform.parent.GetComponentInChildren<Player>().showCards();
    }
    void playerEnding() {
        clock.transform.parent.GetComponentInChildren<Player>().hasSword = false;
        clock.transform.parent.GetComponentInChildren<Player>().in2D = true;
        clock.transform.parent.GetComponentInChildren<RectTransform>().gameObject.SetActive(false);
    }
}