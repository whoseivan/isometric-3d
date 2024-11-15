using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Header("Audio Settings")]
    public AudioMixer audioMixer;  // ������ �� AudioMixer ��� ����������� ���������
    public Slider volumeSlider;      // ������� ��� ����������� ���������

    [Header("Screen Settings")]
    public Toggle fullscreenToggle; // ������������� ��� �������������� ������

    private void Start()
    {
        // �������������� ������� ���������
        volumeSlider.onValueChanged.AddListener(SetVolume);
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 0.75f); // ��������� �������� �� ���������

        // �������������� ��������� �������������� ������
        fullscreenToggle.onValueChanged.AddListener(ToggleFullscreen);
        fullscreenToggle.isOn = PlayerPrefs.GetInt("Fullscreen", 1) == 1; // ��������� �������� �� ���������
    }

    // ����� ��� ��������� ���������
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        PlayerPrefs.SetFloat("Volume", volume); // ��������� ���������
    }

    // ����� ��� ������������ �������������� ������
    public void ToggleFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0); // ��������� ���������
    }

    // ����� ��� �������� �������� ��� ������
    private void OnApplicationQuit()
    {
        PlayerPrefs.Save(); // ��������� ��������� ��� ������ �� ����������
    }
}
