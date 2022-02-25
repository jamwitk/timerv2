using System;
using UnityEngine;

namespace Audio
{
    public class AudioManager : Singleton<AudioManager>
    {
        public Sounds[] sounds;
       
        private void Start()
        { 
            foreach (var s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;

                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
                s.source.playOnAwake = s.PlayOnAwake;
            }
            Play("Track");
        }

        public void Play(string nameM)
        {
            var s = Array.Find(sounds, sound => sound.name == nameM);
            s.source.Play();
        }
    }
}
