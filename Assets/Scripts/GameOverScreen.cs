using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text messageText;
    public MusicManager musicManager;
    private bool music = false;

    public void Setup(string message)
    {
        if (!music)
        {
            musicManager.GameOverMusic();
            music = true;
        }
        gameObject.SetActive(true);
        messageText.text = message;
    }

     public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
