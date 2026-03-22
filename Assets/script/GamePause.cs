using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    public static GamePause instance;
    private bool isPause = false;
    public GameObject pausePanel;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {  
            SwitchPause();
        }
    }

    private void SwitchPause()
    {
        isPause = !isPause;
        if (isPause)
        {
            Time.timeScale = 0;
            AudioListener.pause = true;

            if(pausePanel != null)
            {
                pausePanel.SetActive(true);
            }

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1;
            AudioListener.pause = false;

            if (pausePanel != null)
            {
                pausePanel.SetActive(false);
            }

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
