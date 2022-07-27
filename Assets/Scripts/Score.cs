using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private GameObject score;
    [SerializeField] private GameObject highScore;

    public static int PinCount;
    public static Text scoreText;
    public static Text highScoreText;
    void Start()
    {
        scoreText = score.GetComponent<Text>();
        highScoreText = highScore.GetComponent<Text>();
        PinCount = 0;
        highScoreText.text = PlayerPrefs.GetInt("High Score").ToString();
    }
    void Update()
    {
        scoreText.text = PinCount.ToString();
    }
}
