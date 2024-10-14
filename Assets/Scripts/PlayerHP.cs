using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public Slider HPslider;

    private int HP = 100;

    private void Start()
    {
        HPslider.maxValue = 100;
    }

    private void Update()
    {
        HPslider.value = HP;

        if (HP > 100)
            HP = 100;
        if (HP < 0)
            HP = 0;
    }

    public void getDamage(int damagePoints)
    {
        HP -= damagePoints;
    }

    public void getRecovery(int recoveryPoints)
    {
        HP += recoveryPoints;
    }
}
