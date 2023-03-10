using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class TeleportPlayer : MonoBehaviour
{
    public DialogueRunner dialogue;
    public GameObject Camera;
    void OnTriggerEnter2D(Collider2D collider) {
          if (collider.gameObject.name == "Player" && !dialogue.IsDialogueRunning) {
           Camera.GetComponent<FadeInScenes>().FadeToBlack(true);
          }  
    }
}
