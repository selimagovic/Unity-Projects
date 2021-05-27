using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DyingScript : MonoBehaviour {

    GameObject[] gameObjects;
    public Slider slider;
    bool dead = false;
	// Use this for initialization
	void Start ()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("GameOver");
        Hide();
	}
    public void Hide()
    {
        foreach (GameObject g in gameObjects)
        {
            g.SetActive(false);
        }
    }

    public void Reload()
    {
        Scene scene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(scene.name);
    }
    public void Show()
    {
        foreach (GameObject g in gameObjects)
        { g.SetActive(true); }
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "GameController")
        {
            dead = true;
        }
    }
    public void SliderTime()
    {
        if (slider.value == 0)
            dead = true;
    }
    // Update is called once per frame
    void Update ()
    {
        SliderTime();
	    if(dead)
        {
            Show();       
        }
	}
}
