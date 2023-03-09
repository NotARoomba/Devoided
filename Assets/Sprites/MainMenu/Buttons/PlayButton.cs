using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MainMenuButton
{

    public override void doStuff() {
        gameObject.GetComponent<FadeInScenes>().FadeToBlack(true);
    }
}
