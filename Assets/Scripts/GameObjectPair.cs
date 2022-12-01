using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameObjectPair : IGameObjectPair
{
    public GameObject first;
    public GameObject second;

    public void SwapActiveObject()
    {
        bool f = first.active;
        first.SetActive(second.active);
        second.SetActive(f);
    }
}

public interface IGameObjectPair
{
    public void SwapActiveObject();
}