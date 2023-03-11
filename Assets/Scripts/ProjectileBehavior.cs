using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public float speed = 12;
    public int damage;
    private void Update()
    {
        transform.position += -transform.right * Time.deltaTime * speed;
        if (Vector3.Distance(Vector3.zero, transform.position) > 100) {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (gameObject != null) {
            if (collision.gameObject.name != "EmperorBoss") {
                if (collision.gameObject.name == "Player")
                    collision.gameObject.SendMessage("hitPlayer", damage);
                gameObject.GetComponentInChildren<Animator>().Play("ProjectileHit");
                speed = 0;
                StartCoroutine(death());
            }
        }
    }
    IEnumerator death() {
        yield return new WaitForSeconds(0.12f);
                Destroy(gameObject);
    }
}
