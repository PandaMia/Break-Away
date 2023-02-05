using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameOverScreen gameOverScreen;
    public VictoryScreen victoryScreen;

    public void GameOver(string message)
    {
        gameOverScreen.Setup(message);
    }

    public void Victory(string message)
    {
        victoryScreen.Setup(message);
    }
}
