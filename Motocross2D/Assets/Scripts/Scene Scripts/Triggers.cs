using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Triggers : MonoBehaviour
{
    public Slider slider;
    public int value;
    GameObject[] gameObjects;
    void Start()
    {
        slider.enabled = false;
        gameObjects = GameObject.FindGameObjectsWithTag("GameOver");
    }

    void OnTriggerEnter2D()
    {
        slider.enabled = true;
        slider.value = value;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value -= Time.deltaTime;
    }
    void OnTriggerExit2D()
    {
        slider.enabled = false;
    }
}
