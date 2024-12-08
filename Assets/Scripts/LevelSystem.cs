using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSystem : MonoBehaviour
{
    public Slider ExperienceSlider;
    public TMP_Text levelText;
    public GameObject nextLevelPanel;

    private int currentLevel = 1;
    private int currentExperience = 0;
    private int experienceToNextLevel = 100;

    void Start()
    {
        ExperienceSlider.maxValue = 100;
        levelText.text = currentLevel.ToString();
        nextLevelPanel.SetActive(false);
    }

    private void FixedUpdate()
    {
        ExperienceSlider.value = currentExperience;
    }

    public void GetExperince(int points)
    {
        currentExperience += points;

        if (currentExperience >= experienceToNextLevel)
        {
            currentExperience = currentExperience - experienceToNextLevel;
            currentLevel += 1;
            levelText.text = currentLevel.ToString();
            ExperienceSlider.value = currentExperience;
            nextLevelPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
