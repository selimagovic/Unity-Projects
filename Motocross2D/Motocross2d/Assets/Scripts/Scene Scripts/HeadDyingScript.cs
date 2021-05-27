using UnityEngine;
using UnityEngine.SceneManagement;

public class HeadDyingScript : MonoBehaviour {
    GameObject[] gameObjects;
    private bool dead = false;
    void Start()
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
        if (col.tag == "Head")
        {
            dead = true;
        }        
    }
    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            Show();
        }
    }
}
