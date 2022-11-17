using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    static PauseLevel pauseLevel = PauseLevel.Game;
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject optionsBar;
    [SerializeField]
    private GameObject soundOptionsBar;

    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (pauseLevel)
            {
                case PauseLevel.Game:
                    Pause();
                    break;
                case PauseLevel.Pause:
                    Resume();
                    break;
                default:
                    SetMainPause();
                    break;
            }
        }
    }

    public void Pause()
    {
        pauseLevel = PauseLevel.Pause;
        pauseMenu.SetActive(true);
        optionsBar.SetActive(false);
        soundOptionsBar.SetActive(false);
    }

    public void Resume()
    {
        pauseLevel = PauseLevel.Game;
        pauseMenu.SetActive(false);
        optionsBar.SetActive(false);
    }

    public void SetMainPause()
    {
        pauseLevel = PauseLevel.Pause;
        optionsBar.SetActive(false);
        soundOptionsBar.SetActive(false);
    }

    public void OpenOptions()
    {
        if (pauseLevel == PauseLevel.Options || pauseLevel == PauseLevel.Sounds)
        {
            SetMainPause();
            return;
        }
        pauseLevel = PauseLevel.Pause;
        optionsBar.SetActive(true);
    }

    public void OpenOptions(string option)
    {
        switch(option.ToLower())
        {
            case "sound":
                if(pauseLevel== PauseLevel.Sounds)
                {
                    pauseLevel= PauseLevel.Options;
                    soundOptionsBar.SetActive(false);
                    break;
                }
                soundOptionsBar.SetActive(true);
                pauseLevel= PauseLevel.Sounds;
                break;
            default:
                Pause();
                OpenOptions();
                this.SendMessage($"Brak opcji {option}");
                break;
        }
    }

    public enum PauseLevel
    {
        Game,
        Pause,
        Options,
        Sounds
    }
}
