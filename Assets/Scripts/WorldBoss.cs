using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class WorldBoss : MonoBehaviour
{
    public Player player;
    private CircleCollider2D wakeCollider;    
    private bool isAwake = false;
    private int health = 200;
    public WorldAttackBehavior projectilePrefab;
    public float delay = 4.0f;
    private bool canAttack = true;
    public Camera cam;
    public DialogueRunner dialogue;
    public bool isTalking = true;
    bool hasMiddle = false;
    public bool hasDeathTalked = false;
    public Sun sun;
    void Start()
    {
        wakeCollider = gameObject.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (wakeCollider.IsTouching(player.gameObject.GetComponent<PolygonCollider2D>()) && !isAwake) {
            StartCoroutine(wakeUp());
        } 
        if (health <= 100 && !hasMiddle) {
            isTalking = dialogue.IsDialogueRunning;
            dialogue.StartDialogue("MiddleFight");
            hasMiddle = true;
        }
        if (health <= 0 && !hasDeathTalked && !dialogue.IsDialogueRunning) {
            isTalking = dialogue.IsDialogueRunning;
            dialogue.StartDialogue("WorldDeath");
            gameObject.GetComponent<Animator>().SetTrigger("Dead");
            sun.gameObject.SetActive(true);
            hasDeathTalked = true;
        }
        if (isAwake) {
            if (canAttack && !dialogue.IsDialogueRunning) {
                StartCoroutine(AttackAfterTime(delay));
            }
        }
    }
    void Attack() {
        canAttack = true;
        Vector3 screenPos = getRandomScreenPos();
        Instantiate(projectilePrefab, screenPos, transform.rotation);
        gameObject.GetComponent<Animator>().ResetTrigger("Attack");
    }
     IEnumerator AttackAfterTime(float time) {
     canAttack = false;
     yield return new WaitForSeconds(time);
    gameObject.GetComponent<Animator>().SetTrigger("Attack");
 }
    void takeDamage(int damage) {
    health -= damage;
 gameObject.GetComponent<Animator>().SetTrigger("Hit");
 StartCoroutine(flashColor(new Color(1, 0, 0, 0.7f)));
    }
    IEnumerator flashColor(Color color) {
        gameObject.GetComponent<SpriteRenderer>().material.color = color;
        yield return new WaitForSeconds(0.15f);
        gameObject.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, 1);
        gameObject.GetComponent<Animator>().ResetTrigger("Hit");
    }
    IEnumerator wakeUp() {
        gameObject.GetComponent<Animator>().SetTrigger("Awake");
        yield return new WaitForSeconds(5);
        gameObject.GetComponent<Animator>().SetTrigger("Idle");
        isAwake = true;
        gameObject.GetComponent<CircleCollider2D>().radius = 0;
    }
    Vector3 getRandomScreenPos() {
        Vector3 pos = Vector3.zero;
        pos.x = (Screen.width / 2);
        pos.y = Screen.height * 1.5f;
        return cam.ScreenToWorldPoint(pos);
    }
    public void startDialogue() {
        if (!dialogue.IsDialogueRunning)
            dialogue.StartDialogue("WorldFight");
    }
}
