using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{

    public Slider playerHealthSlider;
    public TextMeshProUGUI healthText;

    public void SetPlayerMaxHealth(int health)
    {
        playerHealthSlider.maxValue = health;
        UpdatPlayereHealthDisplay();
    }

    public void SetPlayerHealth(int health)
    {
        playerHealthSlider.value = health;
        playerHealthSlider.value = Mathf.Clamp(health, 0, playerHealthSlider.maxValue);
        UpdatPlayereHealthDisplay();

    }

    void UpdatPlayereHealthDisplay()
    {
        healthText.text = playerHealthSlider.value.ToString() + "/" + playerHealthSlider.maxValue.ToString();
    }
}
