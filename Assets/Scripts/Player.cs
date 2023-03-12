using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using DigitalRuby.SoundManagerNamespace;

public class Player : MonoBehaviour
{
    public float speed = 3.0f;
    private Vector3 last;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public SwordBehavior weapon;
    public bool in2D = false;
    public int health = 100; 
    public int maxHealth = 100;
    public bool canDialogue;
    public bool hasSword = false;
    private bool jumpBlocked;
    public bool canJump;
    public bool hasFlower = false;
    public bool hasDeath = false;
    public bool hasSun = false;
    public bool hasWorld = false;
    public bool swordUpgrade = false;
    public bool hasEmperor = false;
    public bool hasMagician = false;
    public bool hasFool = false;
    public HealthBar healthBar;
    public Inventory inventory;
    public GameObject cards;
    public DialogueRunner dialogue;
    void Start() {
        health = PlayerVars.Instance.health;
        hasSword = PlayerVars.Instance.hasSword;
        hasFlower = PlayerVars.Instance.hasFlower;
        hasEmperor = PlayerVars.Instance.hasEmperor;
        hasMagician = PlayerVars.Instance.hasMagician;
        swordUpgrade = PlayerVars.Instance.swordUpgrade;
        hasDeath = PlayerVars.Instance.hasDeath;
        hasSun = PlayerVars.Instance.hasSun;
        hasWorld = PlayerVars.Instance.hasWorld;
        hasFool = PlayerVars.Instance.hasFool;
        weapon.isSword = swordUpgrade;
        healthBar.SetHealth(health);
    }
     void Update () {
        if (health <= 0) {
            Debug.Log("PLAYER DEAD");
        }
        PlayerVars.Instance.SetPlayerVariables(health, hasSword, hasFlower, hasMagician, hasEmperor, swordUpgrade, hasDeath, hasSun, hasWorld, hasFool);
         Vector3 pos = Vector3.zero;
         weapon.gameObject.SetActive(hasSword);
        if (in2D) {
            gameObject.GetComponentInParent<Rigidbody2D>().gravityScale = 1;
        }
        if (Input.GetKey("left shift")) {
            speed = 5f;
        } else {
            speed = 3f;
        }
        if (!dialogue.IsDialogueRunning) {
         if (Input.GetKey ("w") && !in2D) {
             pos.y += speed * Time.deltaTime;
         }
         else if (Input.GetKey ("s") && !in2D ) {
             pos.y -= speed * Time.deltaTime;
         }
         else if (Input.GetKey ("d") ) {
             pos.x += speed * Time.deltaTime;
         }
         else if (Input.GetKey ("a")) {
             pos.x -= speed * Time.deltaTime;
         } 
        //  if (Input.GetKey("e")) {
        //     if (canDialogue) {
        //         foreach (Collider2D i in Physics2D.OverlapCircleAll(gameObject.transform.position, 0.2f)) {   
        //     if (i.gameObject.tag == "Talkable")
        //         i.gameObject.SendMessage("startDialogue");
        // }
        //     }
        //  }
        }
         if (in2D) {
            if (Input.GetKey("space") && canJump) {
                
                if (gameObject.GetComponentInParent<Rigidbody2D>().velocity.y < 0 && gameObject.GetComponentInParent<Rigidbody2D>().velocity.y > -1) {
                    jump();
                }
            }
        }
            if(Input.GetMouseButton(0) && hasSword) {
                MusicPlayer.Instance.PlaySound(13);
                weapon.attack();         
           }
         transform.position += pos;
         transform.rotation = Quaternion.identity;
         last = Vector3.Normalize(pos);
     }
     void LateUpdate() {
            if (animator != null && animator.isActiveAndEnabled) {
            animator.SetFloat("XInput", last.x);
            animator.SetFloat("YInput", last.y);
            if (last.x != 0 )
                weapon.changeSide(last.x);
            if (last != Vector3.zero)
                animator.SetTrigger("Moving");
            else {
                animator.Play("Idle");
                animator.ResetTrigger("Moving");
            }
        }
    }
    public void jump() {
        if (jumpBlocked)
            return;
        jumpBlocked = true;
        gameObject.GetComponentInParent<Rigidbody2D>().AddForce(new Vector2(0, speed * 3.5f), ForceMode2D.Impulse);

        StartCoroutine(delayAttack());
    }
    IEnumerator delayAttack() {
        yield return new WaitForSeconds(1);
        jumpBlocked = false;
    }
    public void hitPlayer(int damage) {
        MusicPlayer.Instance.PlaySound(6);
        health -= damage; 
        healthBar.SetHealth(health);
        StartCoroutine(flashColor(new Color(1, 0, 0, 0.7f)));
    }
    IEnumerator flashColor(Color color) {
        spriteRenderer.material.color = color;
        yield return new WaitForSeconds(0.15f);
        spriteRenderer.material.color = new Color(1, 1, 1, 1);
    }
    public IEnumerator upgradeSword() {
        weapon.isSword = true;
        swordUpgrade = true;
        weapon.weaponAnimator.Play("SwordUpgrade");
        yield return new WaitForSeconds(2.8f);
    }
    public void showCards() {
        cards.SetActive(true);
    }
}
