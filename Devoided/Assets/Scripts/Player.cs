using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Player : MonoBehaviour
{
    public bool isMale;
    public float speed = 3.0f;
    private Vector3 last;
    private Animator animator;
    public RuntimeAnimatorController MaleAnimation;
    public RuntimeAnimatorController FemaleAnimation;
    private SpriteRenderer spriteRenderer;
    public SwordBehavior weapon;
    public bool inBattle = false;
    private int health = 5;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (isMale) {
            animator.runtimeAnimatorController = MaleAnimation;
        } else {
           animator.runtimeAnimatorController = FemaleAnimation;
        }
    }
     void Update () {
         Vector3 pos = Vector3.zero;
        if (inBattle) {
            gameObject.GetComponentInParent<Rigidbody2D>().gravityScale = 1;
        }
        if (Input.GetKey("left shift")) {
            speed = 5f;
        } else {
            speed = 3f;
        }
         if (Input.GetKey ("w") && !inBattle) {
             pos.y += speed * Time.deltaTime;
         }
         else if (Input.GetKey ("s") && !inBattle ) {
             pos.y -= speed * Time.deltaTime;
         }
         else if (Input.GetKey ("d") ) {
             pos.x += speed * Time.deltaTime;
         }
         else if (Input.GetKey ("a")) {
             pos.x -= speed * Time.deltaTime;
         } 
         //if (inBattle) {
            // if (Input.GetKey("space")) {
            //     if (gameObject.GetComponentInParent<Rigidbody2D>().velocity.y != 0) {
            //         gameObject.GetComponentInParent<Rigidbody2D>().AddForce(new Vector2(0, speed * Time.deltaTime));
            //     }
            // }
            if(Input.GetMouseButton(0)) {
                weapon.attack();         
          //  }
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
    public void hitPlayer(int damage) {
        health -= damage; 
        StartCoroutine(flashColor(new Color(1, 0, 0, 0.7f)));
    }
    IEnumerator flashColor(Color color) {
        spriteRenderer.material.color = color;
        yield return new WaitForSeconds(0.15f);
        spriteRenderer.material.color = new Color(1, 1, 1, 1);
    }
}
