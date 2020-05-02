using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
before awake: 
private SoundScript m_soundScript = null; 

in Awake():
m_soundScript = GameObject.Find("Sound").GetComponent<SoundScript>();

anywhere:
call a function --> m_soundScript.PlaySound("knitting");
*/

public class SoundScript : MonoBehaviour
{
    public static SoundScript Instance;
    public AudioSource[] sources;
    /*["music", 
     * "knitting", 
     * "button_on", 
     * "button_off", 
     * "letter_open", 
     * "letter_close", 
     * "notfication",
     * "drawer_open",
     * "drawer_close"]*/

    private void Awake()
    {
        Instance = GameObject.Find("Sound").GetComponent<SoundScript>();
        sources[0].Play();
    }

    public void PlaySound(string source)
    {
        sources[FindIndex(source)].Play();
    }

    //for mute, call ChangeAllVolume(0f);
    public void ChangeAllVolume(float volume)
    {
        for (int i = 0; i < sources.Length; i++)
        {
            sources[i].volume = volume;
        }
    }
  /*  public void MuteAll()
    {
        for (int i = 0; i < sources.Length; i++)
        {
            sources[i].mute;
        }
    }*/

    public void ChangeSFXVolume(float volume)
    {
        for (int i = 1; i < sources.Length; i++)
        {
            sources[i].volume = volume;
        }
    }

    //for only music volume tweak: ChangeVolume("music", volume);
    public void ChangeVolume(string source, float volume)
    {
        sources[FindIndex(source)].volume = volume;
    }

    public int FindIndex(string name) {
        int i = 0;
        switch(name)
        {
            case "music":
                i = 0;
                break;
            case "knitting":
                i = 1;
                break;
            case "button_on":
                i = 2;
                break;
            case "button_off":
                i = 3;
                break;
            case "letter_open":
                i = 4;
                break;
            case "letter_close":
                i = 5;
                break;
            case "notification":
                i = 6;
                break;
            case "drawer_open":
                i = 7;
                break;
            case "drawer_close":
                i = 8;
                break;
            default:
                break;
        }
        return i;
    }
}
