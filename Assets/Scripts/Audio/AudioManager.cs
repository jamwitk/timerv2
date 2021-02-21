using System;
using Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private bool _isPlaying;
    public Sounds[] sounds;
    public static AudioManager Instance;
    private void Awake()
    {
        for(var index = 0; index < sounds.Length; index++)
        {
            var s = sounds[index];
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.PlayOnAwake;
        }
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
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
}
