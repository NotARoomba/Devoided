using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBoss : MonoBehaviour
{
    private int health = 100;
    public Player player;
    public ProjectileBehavior projectilePrefab;
    public float delay = 4;
    private bool canAttack = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
            StartCoroutine(death());
        }
        if (canAttack) {
            StartCoroutine(AttackAfterTime(delay));
        }
    }
    void Attack() {
        canAttack = true;
        Instantiate(projectilePrefab, player.gameObject.transform.position, transform.rotation);
        gameObject.GetComponent<Animator>().ResetTrigger("Attack");
    }
     IEnumerator AttackAfterTime(float time) {
     canAttack = false;
     yield return new WaitForSeconds(time);
    gameObject.GetComponent<Animator>().SetTrigger("Attack");
 }
 void takeDamage(int damage) {
    health -= damage;
 }
 IEnumerator death() {
    gameObject.GetComponent<Animator>().Play("Death");
    yield return new WaitForSeconds(4);
    StartCoroutine(player.upgradeSword());
    Destroy(gameObject);
 }
}