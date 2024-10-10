using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    SceneManager sm = new SceneManager();

    public void OnPressedPlay()
    {
        SceneManager.LoadScene("Billiard");
    }

    public void OnPressedQuit()
    {
        Application.Quit();
    }

    public void OnPressedMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
