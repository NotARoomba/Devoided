using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MainMenuButton
{

    public override void doStuff() {
        SceneManager.LoadScene("Space", LoadSceneMode.Single);
    }
}
