using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class NPC : MonoBehaviour
{
    public Player player;
    private GameObject speechBubble;
    private CircleCollider2D speechCollider;
    public DialogueRunner dialogueRunner;
    bool hasTalked = false;
    void Start()
    {   
        speechBubble = GameObject.Find(gameObject.name + "/SpeechBubble");
        speechBubble.SetActive(false);
        speechCollider = gameObject.GetComponent<CircleCollider2D>();
    }
    void Update()
    {
        if (speechCollider.IsTouching(player.GetComponent<PolygonCollider2D>())) {
            speechBubble.SetActive(true);
            player.canDialogue = true;
        } else {
            speechBubble.SetActive(false);
            player.canDialogue = false;
        }
    }
    void startDialogue() {
        if (!hasTalked)
            dialogueRunner.StartDialogue("The_Magician");
        else {
            dialogueRunner.StartDialogue("Mission_2");
        }
        
    }
}
