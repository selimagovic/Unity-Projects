using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[RequireComponent(typeof(Image))]
public class ScreenFader : MonoBehaviour
{

  public Image image;
  public float fadeSpeed = 1.5f;          // Speed that the screen fades to and from black.


  private bool sceneStarting = true;      // Whether or not the scene is still fading in.


  void Awake()
  {
    // Set the texture so that it is the the size of the screen and covers it.
    image = GetComponent<Image>();
  }


  void Update()
  {
    // If the scene is starting...
    if (sceneStarting)
      // ... call the StartScene function.
      StartScene();
  }


  void FadeToClear()
  {
    // Lerp the colour of the texture between itself and transparent.
    image.color = Color.Lerp(image.color, Color.clear, fadeSpeed * Time.deltaTime);
  }


  void FadeToBlack()
  {
    // Lerp the colour of the texture between itself and black.
    image.color = Color.Lerp(image.color, Color.black, fadeSpeed * Time.deltaTime);
  }


  void StartScene()
  {
    // Fade the texture to clear.
    FadeToClear();

    // If the texture is almost clear...
    if (image.color.a <= 0.05f)
    {
      // ... set the colour to clear and disable the UI.Image.
      image.color = Color.clear;
      image.enabled = false;

      // The scene is no longer starting.
      sceneStarting = false;
    }
  }


  public void EndScene()
  {
    // Make sure the texture is enabled.
    image.enabled = true;

    // Start fading towards black.
    FadeToBlack();

    // If the screen is almost black...
    if (image.color.a >= 0.95f)
      // ... reload the level.
      SceneManager.LoadScene("first");
  }
}