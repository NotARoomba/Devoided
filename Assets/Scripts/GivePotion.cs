using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class GivePotion : MonoBehaviour
{
    public DialogueRunner dialogue;
    public Sprite potionSprite;

   void OnTriggerEnter2D(Collider2D collider) {
          if (collider.gameObject.name == "Player") {
            dialogue.StartDialogue("NeonCity");
            collider.gameObject.GetComponent<Player>().GetComponentInChildren<Inventory>().setSlot("Potion", potionSprite, 0);

          }
                
    }
}
