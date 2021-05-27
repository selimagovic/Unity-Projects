using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text scoreText;

    public static int score = 0;
    void Update()
    {
        scoreText.text = score.ToString();
    }

}
