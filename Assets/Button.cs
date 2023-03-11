using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public GameObject button;
    public Image buttonImage;
    public Sprite normal;
    public Sprite pushed;
    // Start is called before the first frame update
    void Start()
    {
       buttonImage = button.GetComponent<Image>();
       buttonImage.sprite = normal;
        
    }
    void OnButtonClick()
    {
        buttonImage.sprite = pushed;
    }
}
