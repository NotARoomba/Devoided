using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour
{
    public GameObject button;
    Image buttonImage;
    public Sprite normal;
    public Sprite pushed;
    // Start is called before the first frame update
    public void Start()
    {
       buttonImage = button.GetComponent<Image>();
       buttonImage.sprite = normal;
        
    }

    // Update is called once per frame
    public void Update()
    {
        
    }
    public void OnButtonPress()
    {
        buttonImage.sprite = pushed;
    }
    public void OnButtonRelease()
    {
        buttonImage.sprite = normal;
        doStuff();
    }
    public virtual void doStuff() { }
}
