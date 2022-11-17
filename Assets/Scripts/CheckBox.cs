using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBox : MonoBehaviour
{
    [SerializeField]
    private bool state;
    [SerializeField]
    private GameObject cross;

    void Start()
    {
        cross.SetActive(state);
    }

    public void Switch()
    {
        state = !state;
        cross.SetActive(state);
    }
}
