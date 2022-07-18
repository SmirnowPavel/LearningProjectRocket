using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static bool PlaySound 
    { 
        get 
        {
            return PlayerPrefs.GetInt("sound") == 0;
        }
        private set
        {
            PlayerPrefs.SetInt("sound", value ? 0 : 1);
        }
    }

    public static bool PlayMusic
    {
        get
        {
            return PlayerPrefs.GetInt("music") == 0;
        }
        private set
        {
            PlayerPrefs.SetInt("music", value ? 0 : 1);
        }
    }

    [SerializeField] AudioSource _buttonSound;

    public static SoundManager Instance;

    private void Awake()
    {
        Instance = this;
        AddButtonSound();
        ApplySounds();
    }

    public void SwitchSoundPlaying()
    {
        PlaySound = !PlaySound;
        ApplySounds();
    }

    public void SwitchMusicPlaying()
    {
        PlayMusic = !PlayMusic;
        ApplySounds();
    }

    void ApplySounds()
    {
        var music = FindObjectsOfType<AudioSource>();
        foreach(var m in music)
        {
            if(m.tag == "Sound")
            {
                m.mute = !PlaySound;
            }
            else
            {
                m.mute = !PlayMusic;
            }
        }
    }

    void AddButtonSound()
    {
        var buttons = FindObjectsOfType<Button>();
        var buttonSound = Instantiate(_buttonSound) as AudioSource;
        foreach(var button in buttons)
        {
            if(button.tag != "Power")
            {
                button.onClick.AddListener(buttonSound.Play);
            }
        }
    }

}
