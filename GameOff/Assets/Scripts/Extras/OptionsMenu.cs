using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour {

    public AudioMixer audioMixer;
    public AudioMixer musicMixer;



    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("SoundVol", volume);
    }

    public void SetMusic(float volume)
    {
        musicMixer.SetFloat("MusicVol", volume);
    }
}
