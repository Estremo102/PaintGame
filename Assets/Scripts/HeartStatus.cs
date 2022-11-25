using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HeartStatus : MonoBehaviour
{
    [SerializeField]
    private Sprite heart, halfHeart, missedHeart;
    private UnityEngine.UI.Image image;
    [SerializeField]
    [Range(0,2)]
    private int heartValue;
    public void Start()
    {
        image = this.GetComponent<UnityEngine.UI.Image>();
        Refresh();
    }

    private void Refresh()
    {
        switch (heartValue)
        {
            case 0:
                image.sprite = missedHeart;
                break;
            case 1:
                image.sprite = halfHeart;
                break;
            case 2:
                image.sprite = heart;
                break;
        }
    }


    public int Damage(int damage = 1)
    {
        if (damage > heartValue)
        {
            damage -= heartValue;
            heartValue = 0;
            Refresh();
            return damage;
        }
        heartValue -= damage;
        Refresh();
        return 0;
    }

    public int Health(int health = 1)
    {
        throw new NotImplementedException();
    }
}
