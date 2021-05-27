using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
public class PauseUI : MonoBehaviour
{
    GameObject[] pauseObjects;
    GameObject[] gameOverObjects;
    public GameObject rain;
    public static int deger = 1;
    
    void Awake()
    {
        deger = 1;
        Time.timeScale = 1;
    }
	// Use this for initialization
	void Start ()
    {
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        HideOnPause();	
	}

    static Worker workerObject = workerObject = new Worker();
    Thread workerThread = new Thread(workerObject.DoWork);

    public void Resume()
    {
        HideOnPause();
        workerThread = new Thread(workerObject.DoWork);
        workerThread.Start();
    }

    public void Reload()
    {
        Scene scene = SceneManager.GetActiveScene();
        
        SceneManager.LoadScene(scene.name);
    }
    //hides objects show in tag
    public void HideOnPause()
    {
        foreach (GameObject g in pauseObjects)
        { g.SetActive(false); }
    }
    public void ShowOnPause()
    {
        foreach (GameObject g in pauseObjects)
        { g.SetActive(true); }
    }
    // Update is called once per frame

    public void MainScene()
    {
        SceneManager.LoadScene(0);
    }
    void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale == 1)
            {
                deger = 0;
                
                ShowOnPause();
            }
            else if(Time.timeScale == 0)
            {
                HideOnPause();
                workerThread = new Thread(workerObject.DoWork);
                workerThread.Start();
            }
        }
        Time.timeScale = deger;
    }    
}

internal class Worker
{
    public void DoWork()
    {
        Thread.Sleep(1000);
        PauseUI.deger = 1;
    }
}