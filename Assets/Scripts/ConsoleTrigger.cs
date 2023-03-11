using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ConsoleTrigger : MonoBehaviour
{   
    public DialogueRunner dialogue;

   void OnTriggerEnter2D(Collider2D collider) {
          if (collider.gameObject.name == "Player")
            dialogue.StartDialogue("NeonCity");
                
    }
}
