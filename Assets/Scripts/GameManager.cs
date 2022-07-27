using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Rotator rotator;
    [SerializeField] private PinSpawner spawner;
    [SerializeField] private GameObject endGamePanel;
    [SerializeField] private Text endGameScore;
    [SerializeField] private Text endGameHighScore;
    
    private Animator rotatorAnimator;
    private bool gameHasEnded = false;

    public static bool gameStarted=false;
    public static GameObject tapToPlay;
    private void Start()
    {
        endGamePanel.SetActive(false);
        tapToPlay = GameObject.Find("TapToPlay");
        rotatorAnimator = rotator.GetComponent<Animator>();
        StartCoroutine(WaitForGameStart());
    }
    private void Update()
    {
        if ((Input.GetButtonDown("Fire1")) && (gameHasEnded))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private IEnumerator WaitForGameStart() {
        yield return new WaitForSeconds(2);
        gameStarted = true;
    }
    public void EndGame()
    {
        if (gameHasEnded)
            return;
        rotator.enabled = false;
        spawner.enabled = false;
        gameHasEnded = true;
        rotatorAnimator.SetBool("isBlackScreen", true);
        endGamePanel.SetActive(true);
        endGameScore.text = "Score: " + Score.PinCount.ToString();
        Score.scoreText.enabled = false;
        int highScore = PlayerPrefs.GetInt("High Score");
        if (Score.PinCount > highScore)
        {
            highScore = Score.PinCount;
            PlayerPrefs.SetInt("High Score", highScore);
        }
        endGameHighScore.text = "High Score: " + highScore;
        GameManager.tapToPlay.SetActive(true);
    }
}
