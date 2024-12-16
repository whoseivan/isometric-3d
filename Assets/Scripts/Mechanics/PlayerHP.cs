using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public float playerHP = 100;
    public float armorValue = 50;

    [Header ("Slider Elements")]
    public Slider sliderHP;
    public Slider sliderArmor;


    [Header("Audio Elements")]
    public AudioClip damageSound;
    public AudioClip medkitSound;
    public AudioClip armorRestoreSound;
    public AudioClip armorLoseSound;
    private AudioSource audioSource;

    [Header("UI Elements")]
    public GameObject losePanel;

    void Start()
    {
        Time.timeScale = 1;

        sliderHP.maxValue = 100;
        sliderArmor.maxValue = 100;
        audioSource = GetComponent<AudioSource>();
        losePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
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

        if (playerHP <= 0)
        {
            GetComponent<Shooting>().enabled = false;
            losePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
