using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MainMenuButton
{
    public override void doStuff()
    {
        Application.Quit();
    }
}
