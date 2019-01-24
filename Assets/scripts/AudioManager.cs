using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string clipName;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(0.5f, 1.5f)]
    public float pitch = 1f;

    private AudioSource source;

    public void SetSource(AudioSource _source)
    {
        source = _source;
        source.clip = clip;
    }

    public void Play()
    {
        if (!source.isPlaying)
        {
            source.pitch = Random.Range(1f, 1.3f);
            source.volume = volume;
            source.Play();
        }
        
    }

}


public class AudioManager : MonoBehaviour
{
    [SerializeField]
    Sound[] sounds;

    public static AudioManager instance;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else
        {
            Destroy(this.gameObject);
        }
        

        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].clipName);
            _go.transform.parent = this.gameObject.transform;
            sounds[i].SetSource(_go.AddComponent<AudioSource>());
        }
    }

    public void PlaySound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].clipName == _name)
            {
                sounds[i].Play();
                return;
            }
        }

        //no sound with name
        Debug.LogWarning("AudioManager could not find sound");

    }

}
