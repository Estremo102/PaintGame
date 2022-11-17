using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    static int pauseLevel = 0;
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject optionsBar;

    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (pauseLevel)
            {
                case 0:
                    Pause();
                    break;
                case 1:
                    Resume();
                    break;
                case 2:
                    Back();
                    break;
            }
        }
    }

    public void Pause()
    {
        pauseLevel = 1;
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        pauseLevel = 0;
        pauseMenu.SetActive(false);
    }

    public void Back()
    {
        pauseLevel = 1;
        optionsBar.SetActive(false);
    }

    public void OpenOptions()
    {
        if (pauseLevel > 1)
        {
            Back();
            return;
        }
        pauseLevel = 2;
        optionsBar.SetActive(true);
    }
}
