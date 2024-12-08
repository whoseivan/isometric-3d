using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public float playerHP = 100;
    public float armorValue = 50;

    public Slider sliderHP;
    public Slider sliderArmor;

    public AudioClip damageSound;
    public AudioClip medkitSound;
    public AudioClip armorRestoreSound;
    public AudioClip armorLoseSound;

    private AudioSource audioSource;

    void Start()
    {
        sliderHP.maxValue = 100;
        sliderArmor.maxValue = 100;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        sliderHP.value = playerHP;
        sliderArmor.value = armorValue;
    }

    public void ChangeHP(float hpPoints)
    {
        if (hpPoints < 0) // Это урон
        {
            if (armorValue > 0)
            {
                armorValue += hpPoints;
                audioSource.PlayOneShot(armorLoseSound);
            }
            else
            {
                playerHP += hpPoints;
                audioSource.PlayOneShot(damageSound);
            }
        }
        else
        {
            if (playerHP < 100)
            {
                playerHP += hpPoints;
                audioSource.PlayOneShot(medkitSound);
            }
            else
            {
                armorValue += hpPoints;
                audioSource.PlayOneShot(armorRestoreSound);
            }
        }
        if (armorValue > 100)
            armorValue = 100;
        if (playerHP > 100)
            playerHP = 100;
    }
}
