using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Header("Audio Settings")]
    public AudioMixer audioMixer;  // Ссылка на AudioMixer для регулировки громкости
    public Slider volumeSlider;      // Слайдер для регулировки громкости

    [Header("Screen Settings")]
    public Toggle fullscreenToggle; // Переключатель для полноэкранного режима

    private void Start()
    {
        // Инициализируем слайдер громкости
        volumeSlider.onValueChanged.AddListener(SetVolume);
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 0.75f); // Установка значения по умолчанию

        // Инициализируем состояние полноэкранного режима
        fullscreenToggle.onValueChanged.AddListener(ToggleFullscreen);
        fullscreenToggle.isOn = PlayerPrefs.GetInt("Fullscreen", 1) == 1; // Установка значения по умолчанию
    }

    // Метод для установки громкости
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        PlayerPrefs.SetFloat("Volume", volume); // Сохраняем громкость
    }

    // Метод для переключения полноэкранного режима
    public void ToggleFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0); // Сохраняем состояние
    }

    // Метод для загрузки настроек при старте
    private void OnApplicationQuit()
    {
        PlayerPrefs.Save(); // Сохраняем настройки при выходе из приложения
    }
}
