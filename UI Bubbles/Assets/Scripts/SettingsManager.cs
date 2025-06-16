using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Header("UI Sliders")]
    public Slider soundSlider;
    public Slider musicSlider;

    private const string SoundPrefKey = "SoundVolume";
    private const string MusicPrefKey = "MusicVolume";

    void Start()
    {
        float savedSound = PlayerPrefs.GetFloat(SoundPrefKey, 1f);
        float savedMusic = PlayerPrefs.GetFloat(MusicPrefKey, 1f);

        if (soundSlider != null)
            soundSlider.value = savedSound;
        else
            Debug.LogWarning("Sound slider не призначено в інспекторі!");

        if (musicSlider != null)
            musicSlider.value = savedMusic;
        else
            Debug.LogWarning("Music slider не призначено в інспекторі!");
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat(SoundPrefKey, soundSlider.value);
        PlayerPrefs.SetFloat(MusicPrefKey, musicSlider.value);
        PlayerPrefs.Save();
    }
}
