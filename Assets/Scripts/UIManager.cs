using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void LoadNextScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartMenu() 
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Exhibition");
    }

    public void CreateBoard()
    {
        SceneManager.LoadScene("Leaderboard");
    }

    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.name);
    }

    public void QuitGame() {
        Application.Quit();
    }
}