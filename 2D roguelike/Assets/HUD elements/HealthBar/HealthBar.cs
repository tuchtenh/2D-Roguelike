using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public TextMeshProUGUI hp;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        UpdateHealthDisplay();
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        UpdateHealthDisplay();
    }

    public void UpdateHealthDisplay()
    {
        hp.text = slider.value + "/" + slider.maxValue;
    }
}
