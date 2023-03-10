using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVars : MonoBehaviour
{
    public int health = 100;
    public bool hasSword = false;
    public bool hasFlower = false;
    public bool hasDeath = false;
    public bool hasSun = false;
    public bool hasWorld = false;
    public bool swordUpgrade = false;
    public bool hasEmperor = false;
    public bool hasMagician = false;
    public bool hasFool = false;

    public static PlayerVars Instance;
   private void Awake()
{
    if (Instance != null) {
        Destroy(gameObject);
        return;
    }
    Instance = this;
    DontDestroyOnLoad(gameObject);
}
public void SetPlayerVariables(int hp, bool hs, bool hf, bool hm, bool he, bool su, bool hd, bool hsun, bool hw, bool hsf)
    {
        health = hp;
        hasSword = hs;
        hasFlower = hf;
        hasMagician = hm;
        hasEmperor = he;
        swordUpgrade = su;
        hasDeath = hd;
        hasSun = hsun;
        hasWorld = hw;
        hasFool = hsf;
        return;
    }
}
