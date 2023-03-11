using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldAttackBehavior : MonoBehaviour
{
    public int damage;
    public int speed;
    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.up * Time.deltaTime * speed;
        StartCoroutine(Death());
    }
    IEnumerator Death() {
        yield return new WaitForSeconds(15);
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D  collider) {
          if (collider.gameObject.name == "Player")
                collider.gameObject.SendMessage("hitPlayer", 10);
    }
}
