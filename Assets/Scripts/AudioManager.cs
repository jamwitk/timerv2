using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private bool _isPlaying;
    public Sounds[] sounds;
    public static AudioManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        foreach (var s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("Track");
    }

    public void Play(string nameM)
    {
        
        var s = Array.Find(sounds, sound => sound.name == nameM);
        s.source.Play();
    }

    public void MusicControl()
    {
        foreach (var s in sounds)
        {
            s.source.mute = !s.source.mute;
        }
    }
    
}
