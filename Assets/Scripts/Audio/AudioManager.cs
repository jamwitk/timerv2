using System;
using Game;
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
            GameManager.Instance.OnFinishGame += OnFinishGame;
        }

        private void OnDestroy()
        {
            GameManager.Instance.OnFinishGame -= OnFinishGame;
        }

        public void Play(string audioName)
        {
            var s = Array.Find(sounds, sound => sound.name == audioName);
            s.source.Play();
        }

        private void OnFinishGame()
        {
            Play("Punch");
        }
    }
}
