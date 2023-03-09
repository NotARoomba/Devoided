using UnityEngine; 
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
 
public class FadeInScenes : MonoBehaviour {
 
public float fadeTime = 1f; // duration of the fade in seconds
    public string scene;
    public Sprite square;
    private GameObject FadeScreen;
    public void FadeToBlack(bool shouldSwitch)
    {
        // start the fading coroutine
        StartCoroutine(FadeToBlackCoroutine(shouldSwitch));
    }
    

void Awake() {
        FadeScreen = new GameObject("FadeScreen",typeof(SpriteRenderer));
    FadeScreen.transform.position = new Vector3(0, 0, -4);
    FadeScreen.transform.localScale = new Vector3(Screen.width, Screen.height, 0);
    FadeScreen.GetComponent<SpriteRenderer>().sprite = square;
    FadeScreen.GetComponent<SpriteRenderer>().sortingOrder = 5;
        StartCoroutine(FadeFromBlack());
    }
    private IEnumerator FadeToBlackCoroutine(bool shouldSwitch)
{
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
    if (scene != "" && shouldSwitch) {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
    private IEnumerator FadeFromBlack()
{
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
    if (gameObject.GetComponent<RunDialogue>() != null)
        gameObject.GetComponent<RunDialogue>().startDialogue();
}   
}