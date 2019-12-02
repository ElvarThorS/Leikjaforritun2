using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayScene1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void PlayScene2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
