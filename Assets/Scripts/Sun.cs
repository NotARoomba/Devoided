using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Sun : MonoBehaviour
{
    public  Animator sunAnimator;
    public DialogueRunner dialogue;
    void OnTriggerEnter2D(Collider2D collider) {
          if (collider.gameObject.name == "Player" && !dialogue.IsDialogueRunning) {
            dialogue.StartDialogue("Mission_6");
          }  
    }
    public void ChangeSun() {
        sunAnimator.SetTrigger("Card");
    }
}
