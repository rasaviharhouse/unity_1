using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public Text restartText;
    public Button restartButton;

    void Start()
    {
        // Hide the death message and restart button initially
        restartText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

    public void ShowRestartMessage()
    {
        // Display the death message
        restartText.gameObject.SetActive(true);
        restartText.text = "Game Over!";

        // Display the restart button and listen for its click event
        restartButton.gameObject.SetActive(true);
        restartButton.onClick.AddListener(RestartGame);
    }

    public void RestartGame()
    {
        // Reload the current scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
