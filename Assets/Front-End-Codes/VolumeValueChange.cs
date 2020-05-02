using UnityEngine;

public class VolumeValueChange : MonoBehaviour {

    // Reference to Audio Source component
    public static SoundScript Instance;

    // Music volume variable that will be modified
    // by dragging slider knob
    private float Volume = 1f;

	// Use this for initialization
	void Start () {

        // Assign Audio Source component to control it
        Instance = GameObject.Find("Sound").GetComponent<SoundScript>();
	}
	
	// Update is called once per frame
	void Update () {

        // Setting volume option of Audio Source to be equal to musicVolume
        
        Instance.sources[0].volume = Volume;
        
       /* SoundScript.Instance.ChangeVolume("music", Volume);*/
    
    }

    // Method that is called by slider game object
    // This method takes vol value passed by slider
    // and sets it as musicValue
    public void SetMusicVolume(float vol)
    {
        Volume = vol;
        SoundScript.Instance.ChangeVolume("music", Volume);
        
    }
    public void SetSFXVolume(float vol)
    {
        Volume = vol;
        SoundScript.Instance.ChangeSFXVolume(Volume);
        
    }
}
