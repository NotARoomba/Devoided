using UnityEngine; 
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
 
public class LoadScene : MonoBehaviour {
 
public float fadeTime = 1f; // duration of the fade in seconds
    public string scene;
    public Sprite square;
    public void FadeToBlack()
    {
        // start the fading coroutine
        StartCoroutine(FadeToBlackCoroutine());
    }

    private IEnumerator FadeToBlackCoroutine()
{
    GameObject FadeScreen = new GameObject("FadeScreen",typeof(SpriteRenderer));
    FadeScreen.transform.position = new Vector3(0, 0, -4);
    FadeScreen.transform.localScale = new Vector3(Screen.width, Screen.height, 0);
    FadeScreen.GetComponent<SpriteRenderer>().sprite = square;
    // gradually increase the alpha value of the fade image to fully opaque
    float timer = 0f;
    while (timer < fadeTime)
    {
        float alpha = Mathf.Lerp(0f, 1f, timer / fadeTime);
        FadeScreen.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, alpha);
        timer += Time.deltaTime;
        yield return null;
    }

    // set the color of the fade image to fully opaque black
    FadeScreen.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 1f);

    // Load the next scene
    SceneManager.LoadScene(scene, LoadSceneMode.Single);
}
}