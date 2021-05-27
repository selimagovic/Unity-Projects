using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour 
{
	public Canvas exitMenu;
	public Canvas optionsMenu;
    public Canvas creditsMenu;
	public Button startButton;
	public Button optionsButton;
	public Button exitButton;
	public Button xButton;
    public Button creditsButton;
	// Use this for initialization
	void Start () 
	{
        Time.timeScale = 1;
        creditsMenu = creditsMenu.GetComponent<Canvas>();
		exitMenu = exitMenu.GetComponent<Canvas> ();
		optionsMenu = optionsMenu.GetComponent<Canvas> ();
		startButton = startButton.GetComponent<Button> ();
		optionsButton = optionsButton.GetComponent<Button> ();
		exitButton = exitButton.GetComponent<Button> ();
		xButton = xButton.GetComponent<Button> ();
        creditsButton = creditsButton.GetComponent<Button>();
        exitMenu.enabled = false;
		optionsMenu.enabled = false;
        creditsMenu.enabled = false;
	}
	public void xButtonPress()
	{
		exitMenu.enabled = false;
		optionsMenu.enabled = false;
		startButton.enabled= true;
		optionsButton.enabled = true;
		exitButton.enabled = true;
        creditsButton.enabled = true;
        creditsMenu.enabled = false;
	}
    void OnEnable()
    {

    }
    void OnDisable()
    {

    }
    void OnValidate()
    {

    }
	public void ExitPress()
	{
		exitMenu.enabled = true;
		optionsMenu.enabled = false;
		startButton.enabled=false;
		optionsButton.enabled = false;
		exitButton.enabled = false;
        creditsButton.enabled = false;
	}

	public void OptionsPress ()
	{
		exitMenu.enabled = false;
		optionsMenu.enabled = true;
		startButton.enabled=false;
		optionsButton.enabled = false;
        creditsMenu.enabled = false;
		exitButton.enabled = false;
        creditsButton.enabled = false;
	}
    public void CreditsPress()
    {
        exitMenu.enabled = false;
        optionsMenu.enabled = false;
        startButton.enabled = false;
        optionsButton.enabled = false;
        creditsMenu.enabled = true;
        exitButton.enabled = false;
        creditsButton.enabled = false;
    }

    public void StartLevel()
	{
		SceneManager.LoadScene (1);
	}

	public void NoPress()
	{
		exitMenu.enabled = false;
		startButton.enabled= true;
		optionsButton.enabled = true;
		exitButton.enabled = true;
	}

	public void QuitGame()
	{
		Application.Quit();
	}


}
