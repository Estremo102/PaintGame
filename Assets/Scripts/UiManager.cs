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
    [SerializeField]
    private GameObjectPair keyBindings;
    [SerializeField]
    private GameObject saveLoad;
    [SerializeField]
    private GameObject diary;
    [SerializeField]
    private GameObject skills;
    [SerializeField]
    private GameObject equipment;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseLevel == PauseLevel.Pause)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        pauseLevel = PauseLevel.Pause;
        pauseMenu.SetActive(true);
        optionsBar.SetActive(false);
        soundOptionsBar.SetActive(false);
        saveLoad.SetActive(false);
        diary.SetActive(false);
        skills.SetActive(false);
        equipment.SetActive(false);
    }

    public void Resume()
    {
        pauseLevel = PauseLevel.Game;
        pauseMenu.SetActive(false);
        optionsBar.SetActive(false);
    }

    public void OpenOptions()
    {
        if (pauseLevel != PauseLevel.Pause)
        {
            if (pauseLevel == PauseLevel.Options || pauseLevel == PauseLevel.AdvancedOptions)
            {
                Pause();
                return;
            }
            Pause();
        }
        pauseLevel = PauseLevel.Options;
        optionsBar.SetActive(true);
        CloseAdvancedOptions();
    }

    public void SaveLoad() =>
        OpenClose(PauseLevel.SaveLoad, saveLoad);

    public void Diary() =>
        OpenClose(PauseLevel.Diary, diary);

    public void Skills() =>
        OpenClose(PauseLevel.Skills, skills);

    public void Equipment() =>
        OpenClose(PauseLevel.Equipment, equipment);

    private void OpenClose(PauseLevel openClose, GameObject gameObject)
    {
        if (pauseLevel == openClose)
        {
            Pause();
            return;
        }
        Pause();
        gameObject.SetActive(true);
        pauseLevel = openClose;
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
                    SetActiveKeyBindings(false);
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

    public void SetActiveKeyBindings(bool set)
    {
        keyBindings.first.SetActive(set);
        if (!set)
            keyBindings.second.SetActive(set);
    }

    public void SwapGamepadKeyboardAndMouse() =>
        keyBindings.SwapActiveObject();

    public enum PauseLevel
    {
        Game,
        Pause,
        Options,
        AdvancedOptions,
        SaveLoad,
        Diary,
        Skills,
        Equipment
    }
}
