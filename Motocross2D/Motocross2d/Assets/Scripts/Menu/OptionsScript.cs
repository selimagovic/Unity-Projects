using UnityEngine;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour {

    public GameObject music;

    public void MusicToggle_Changed(bool mute)
    {
        music.SetActive(mute);
    }
	// Use this for initialization
	void Start ()
    {
        music = GameObject.FindGameObjectWithTag("Finish");	
	}	
}
