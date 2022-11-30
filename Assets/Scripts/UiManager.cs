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
    [SerializeField]
    private GameObject gameplayOptionsBar;
    [SerializeField]
    private GameObject controlsOptionsBar;
    [SerializeField]
    private GameObject graphicOptionsBar;

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
        if (pauseLevel != PauseLevel.Pause)
        {
            SetMainPause();
            return;
        }
        pauseLevel = PauseLevel.Pause;
        optionsBar.SetActive(true);
        CloseAdvancedOptions();
    }

    private void CloseAdvancedOptions()
    {

        soundOptionsBar.SetActive(false);
        gameplayOptionsBar.SetActive(false);
        controlsOptionsBar.SetActive(false);
        graphicOptionsBar.SetActive(false);
    }

    public void OpenOptions(string option)
    {
        if ((soundOptionsBar.active && option != "sound") ||
           (gameplayOptionsBar.active && option != "gameplay") ||
           (controlsOptionsBar.active && option != "controls") ||
           (graphicOptionsBar.active && option != "graphic"))
            pauseLevel = PauseLevel.Options;
        CloseAdvancedOptions();
        if (pauseLevel == PauseLevel.AdvancedOptions)
            pauseLevel = PauseLevel.Options;
        else
        {
            switch (option.ToLower())
            {
                case "sound":
                    soundOptionsBar.SetActive(true);
                    break;
                case "gameplay":
                    gameplayOptionsBar.SetActive(true);
                    break;
                case "controls":
                    controlsOptionsBar.SetActive(true);
                    break;
                case "graphic":
                    graphicOptionsBar.SetActive(true);
                    break;
                default:
                    Pause();
                    OpenOptions();
                    this.SendMessage($"Brak opcji {option}");
                    break;
            }
            pauseLevel = PauseLevel.AdvancedOptions;
        }
    }

    public enum PauseLevel
    {
        Game,
        Pause,
        Options,
        AdvancedOptions
    }
}
