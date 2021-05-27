using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinningScript : MonoBehaviour
{
    GameObject[] nextGameObjects;
    bool pass = false;
    public int sceneNumber;
    public GameObject go;
    public Slider slider;
    public AudioClip aclip;
    public Text scoreText;
    private int scoreInt;
    private float scoreS;
    AudioSource aSource;
    // Use this for initialization
    void Start ()
    {
        aSource = GetComponent<AudioSource>();
        go = GameObject.FindGameObjectWithTag("Finish");
        nextGameObjects = GameObject.FindGameObjectsWithTag("NextStage");
        Hide();
	}
    public void Hide()
    {
        
        foreach(GameObject g in nextGameObjects)
        {
            g.SetActive(false);
        }
    }
    public void Show()
    {
        foreach (GameObject g in nextGameObjects)
        {
            g.SetActive(true);
        }
        
    }
    public void OnTriggerEnter2D()
    {
        slider.enabled = false;
        scoreInt = ScoreScript.score;
        scoreS = (float)scoreInt;
        scoreS *= 100f;
        aSource.PlayOneShot(aclip);
        pass = true;
        scoreText.text = scoreInt.ToString();
        Destroy(go.gameObject);
    }
    public void NewScene()
    {
        SceneManager.LoadScene(sceneNumber);
    }
    public void MainScene()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update ()
    {
        if(pass)
        {             
            Show();                     
        }	
	}
}
