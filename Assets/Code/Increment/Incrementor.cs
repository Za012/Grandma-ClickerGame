using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public enum IncrementType
{
    Tap, Idle
}
public class Incrementor : MonoBehaviour
{
    private static Incrementor Instance;
    private const float STANDARDINCREMENT = 1f;
    private const float idleDelay = 0.4f;
    public Button grandmaButton;

    private SoundScript m_soundScript = null;

    private void Awake()
    {
        Instance = GameObject.Find("Incrementor").GetComponent<Incrementor>();
        grandmaButton = GameObject.Find("Button_Grandma").GetComponent<Button>();

        m_soundScript = GameObject.Find("Sound").GetComponent<SoundScript>();
    }

    private void Start()
    {
        // TODO: Will be changed into getting the item that was previously selected by user
        Debug.Log("Init Incrementor");
        Debug.Log("Last Login: " + SaveFile.GetInstance().CoreConfig.TimeWhenQuit.ToString());

        if (SaveFile.GetInstance().CoreConfig.TimeWhenQuit != null)
        {
            TimeSpan diff = DateTime.Now - SaveFile.GetInstance().CoreConfig.TimeWhenQuit;
            int missedIterations = (int)(diff.TotalSeconds / idleDelay);
            Debug.Log("Missed Iterations: " + missedIterations);
            if (missedIterations > 10000000)
            {
                missedIterations = 10000000;
            }
            for (int i = 0; i < missedIterations; i++)
            {
                SaveFile.GetInstance().CoreConfig.currentItem.Increment(STANDARDINCREMENT * SaveFile.GetInstance().CoreConfig.player.GetIdleMultiplier());
            }
        }
        grandmaButton.onClick.AddListener(TapIncrement);
        InvokeRepeating("AutoIncrement", idleDelay / 2, idleDelay / 2);  //0.2s delay, repeat every 0.2s
    }

    private Incrementor() { }
    public static Incrementor GetInstance()
    {
        return Instance;
    }

    private void AutoIncrement()
    {
        SaveFile.GetInstance().CoreConfig.currentItem.Increment(STANDARDINCREMENT * SaveFile.GetInstance().CoreConfig.player.GetIdleMultiplier());
    }

    public void TapIncrement()
    {
        m_soundScript.PlaySound("knitting");
        SaveFile.GetInstance().CoreConfig.currentItem.Increment(STANDARDINCREMENT * SaveFile.GetInstance().CoreConfig.player.GetTapMultiplier());
    }
}
