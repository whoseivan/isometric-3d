using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Stamina : MonoBehaviour
{
    [Header("Stamina settings")]
    public float currentStamina = 100f;
    public float drainValue;
    public float recoveryValue;

    public Slider staminaSlider;

    private void Start()
    {
        staminaSlider.maxValue = 100;
        staminaSlider.value = currentStamina;
    }

    public void staminaDrain()
    {
        currentStamina -= drainValue * Time.deltaTime;
    }

    public void staminaRecovery()
    {
        currentStamina += recoveryValue * Time.deltaTime;
    }

    private void Update()
    {
        staminaSlider.value = currentStamina;

        if (currentStamina > 100)
            currentStamina = 100;
        if (currentStamina < 0)
            currentStamina = 0;
    }
}
