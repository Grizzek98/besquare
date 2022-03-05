using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitching : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(2);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LevelSelectionScreen()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }



    // Levels
    public void Level01()
    {
        SceneManager.LoadScene(2);
    }

    public void Level02()
    {
        SceneManager.LoadScene(3);
    }

    public void Level03()
    {
        SceneManager.LoadScene(4);
    }

}
