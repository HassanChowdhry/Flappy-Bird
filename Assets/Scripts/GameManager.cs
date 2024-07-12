using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public Player player;
    public Text scoreText;
    public GameObject gameOverPanel;
    public GameObject button;
    private int score;

    void Awake() {
        Application.targetFrameRate = 60;
        Pause();
    }

    public void Play() {
        score = 0;
        scoreText.text = score.ToString();

        button.SetActive(false);
        gameOverPanel.SetActive(false);
        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();
        foreach (Pipes pipe in pipes) {
            Destroy(pipe.gameObject);
        }
    }
    public void Pause() {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void GameOver() {
       gameOverPanel.SetActive(true);
       button.SetActive(true);

       Pause();
    }
    
    public void IncreaseScore() {
        score++;
        scoreText.text = score.ToString();
    }
}
