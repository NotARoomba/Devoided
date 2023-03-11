using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAttackBehavior : MonoBehaviour
{
    public int damage;
    void Start()
    {
        StartCoroutine(attack());
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
    }
    IEnumerator attack() {
        yield return new WaitForSeconds(1.1f);
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        foreach (Collider2D i in Physics2D.OverlapCircleAll(gameObject.transform.position, gameObject.GetComponent<CircleCollider2D>().radius)) {   
            if (i.gameObject.name == "Player")
                i.gameObject.SendMessage("hitPlayer", 10);
        }
        yield return new WaitForSeconds(1.15f);
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D  collider) {
          if (collider.gameObject.name == "Player")
                collider.gameObject.SendMessage("hitPlayer", 10);
        }
    }
