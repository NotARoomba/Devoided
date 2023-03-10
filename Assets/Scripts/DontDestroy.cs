using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public static DontDestroy Instance;
   private void Awake()
{
    // start of new code
    if (Instance != null)
    {
        Destroy(gameObject);
        return;
    }
    // end of new code

    Instance = this;
    DontDestroyOnLoad(gameObject);
}
}
