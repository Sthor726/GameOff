using UnityEngine;
using UnityEngine.Audio;
[System.Serializable]
public class Sound
{
    public AudioMixerGroup mixerGroup;
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float vol = 0.7f;
    [Range(0.5f, 1.5f)]
    public float pitch = 1f;

    private AudioSource source;

    public void SetSource(AudioSource _source)
    {
        source = _source;
        source.outputAudioMixerGroup = mixerGroup;
        source.clip = clip;
    }

    public void Play()
    {
        source.pitch = pitch;
        source.volume = vol;
        source.Play();
    }

}


public class AudioManager : MonoBehaviour
{

    #region Singleton
    public static AudioManager instance;
    void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField]
    Sound[] sounds;

    void Start()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].name);
            _go.transform.SetParent(this.transform);
            sounds[i].SetSource(_go.AddComponent<AudioSource>());
        }
    }

    public void PlaySound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                sounds[i].Play();
                return;
            }
        }

        Debug.LogWarning("AudioManager... sound not found");
    }

}
