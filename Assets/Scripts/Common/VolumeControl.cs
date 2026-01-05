using UnityEngine;
using UnityEngine.UI;

public class AudioVolumeController : MonoBehaviour
{
    [Header("Sliders")]
    public Slider masterSlider;
    public Slider musicSlider;

    AudioSource[] musicSources;

    void Start()
    {
        // Cache music sources once
        musicSources = GetMusicSources();

        // Initialize volumes
        SetMasterVolume(masterSlider.value);
        SetMusicVolume(musicSlider.value);

        // Listen to slider changes
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
    }

    void SetMasterVolume(float value)
    {
        AudioListener.volume = value;
    }

    void SetMusicVolume(float value)
    {
        foreach (AudioSource a in musicSources)
        {
            if (a != null)
                a.volume = value;
        }
    }

    AudioSource[] GetMusicSources()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        AudioSource[] sources = new AudioSource[objs.Length];

        for (int i = 0; i < objs.Length; i++)
            sources[i] = objs[i].GetComponent<AudioSource>();

        return sources;
    }
}
