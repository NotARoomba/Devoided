using UnityEngine; 
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
 
public class LoadScene : MonoBehaviour {
 
public float fadeTime = 1f; // duration of the fade in seconds
    public SpriteRenderer fadeImage; // reference to an Image component that covers the screen
    public string scene;

    private void Start()
    {
        // set the color of the fade image to black and fully transparent
        fadeImage.color = new Color(0f, 0f, 0f, 0f);
    }

    public void FadeToBlack()
    {
        // start the fading coroutine
        StartCoroutine(FadeToBlackCoroutine());
    }

    private IEnumerator FadeToBlackCoroutine()
{
    // gradually increase the alpha value of the fade image to fully opaque
    float timer = 0f;
    while (timer < fadeTime)
    {
        float alpha = Mathf.Lerp(0f, 1f, timer / fadeTime);
        fadeImage.color = new Color(0f, 0f, 0f, alpha);
        timer += Time.deltaTime;
        yield return null;
    }

    // set the color of the fade image to fully opaque black
    fadeImage.color = new Color(0f, 0f, 0f, 1f);

    // Load the next scene
    SceneManager.LoadScene(scene, LoadSceneMode.Single);
}
}