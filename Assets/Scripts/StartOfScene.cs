using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartOfScene : MonoBehaviour
{
    public float fadeTime = 1f; // duration of the fade in seconds
    public Sprite square;
    void Awake() {
        StartCoroutine(FadeFromBlack());
        
    }
    public void FadeToBlack()
    {
        // start the fading coroutine
    }

    private IEnumerator FadeFromBlack()
{
    GameObject FadeScreen = new GameObject("FadeScreen",typeof(SpriteRenderer));
    FadeScreen.transform.position = new Vector3(0, 0, -4);
    FadeScreen.transform.localScale = new Vector3(Screen.width, Screen.height, 0);
    FadeScreen.GetComponent<SpriteRenderer>().sprite = square;
    FadeScreen.GetComponent<SpriteRenderer>().sortingOrder = 5;
    // gradually increase the alpha value of the fade image to fully opaque
    float timer = 0f;
    while (timer < fadeTime)
    {
        float alpha = Mathf.Lerp(1f, 0f, timer / fadeTime);
        FadeScreen.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, alpha);
        timer += Time.deltaTime;
        yield return null;
    }

    // set the color of the fade image to fully opaque black
    FadeScreen.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0f);
    gameObject.GetComponent<RunDialogue>().startDialogue();
}   
    // Update is called once per frame
    void Update()
    {
        
    }
}
