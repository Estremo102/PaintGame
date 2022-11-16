using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    static int pauseLevel = 0;
    [SerializeField]
    private GameObject pauseMenu;

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
                    pauseLevel = 1;
                    pauseMenu.SetActive(true);
                    break;
                case 1:
                    pauseLevel = 0;
                    pauseMenu.SetActive(false);
                    break;
            }
        }
    }
}
