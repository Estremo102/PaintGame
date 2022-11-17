using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderPercent : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI percent;

    private void OnEnable()
    {
        UpdatePercent();
    }

    public void UpdatePercent()
    {
        int percent = System.Convert.ToInt32(GetComponent<Slider>().value * 100);
        this.percent.text = $"{percent}%";
    }
}
