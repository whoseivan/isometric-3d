using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public float staminaValue = 100;
    public Slider staminaSlider;

    public float drainValue = 30;
    public float recoveryValue = 15;

    public void staminaDrain()
    {
        staminaValue -= drainValue * Time.deltaTime;
    }

    public void staminaRecovery()
    {
        staminaValue += recoveryValue * Time.deltaTime;
    }

    private void Start()
    {
        staminaSlider.maxValue = staminaValue;
    }

    private void Update()
    {
        if (staminaValue < 0)
            staminaValue = 0;

        if (staminaValue > 100)
            staminaValue = 100;

        staminaSlider.value = staminaValue;
    }
}
