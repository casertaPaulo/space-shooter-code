using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Update()
    {
        if (ScoreController.instance != null)
        {
            scoreText.text =  "Score: " + ScoreController.instance.score.ToString();
        }
    }
}
