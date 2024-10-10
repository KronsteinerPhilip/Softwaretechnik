using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    [SerializeField]
    private GameObject UI;
    private bool isCurrentlyPaused = false;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            togglePause();
        }
    }

    public void togglePause() 
    {
        if(!isCurrentlyPaused)
        {
            isCurrentlyPaused = true;
            UI.SetActive(isCurrentlyPaused);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            isCurrentlyPaused = false;
            UI.SetActive(isCurrentlyPaused);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public bool isPaused()
    {
        return isCurrentlyPaused;
    }
}
