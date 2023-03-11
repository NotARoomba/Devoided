using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public Vector3 cameraPos;
    public Sprite playerSprite;
    void Start() {

    }
    // Update is called once per frame
    void lateUpdate () {
        transform.position = player.transform.position + cameraPos + new Vector3(playerSprite.texture.width, playerSprite.texture.height, 0);
    }
}
