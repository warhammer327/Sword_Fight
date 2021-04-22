using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioManager audiosrc;

    // Update is called once per frame

    void Start()
    {
        audiosrc.PlayMusic();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void NowQuit()
    {
        Application.Quit();
    }

}
