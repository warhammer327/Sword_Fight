using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void GotoStartMenu()
    {
        SceneManager.LoadScene("StartScreen");
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NowQuit()
    {
        Application.Quit();
    } 
}
