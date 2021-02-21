using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

namespace Game
{
    public class SceneManagements : MonoBehaviour
    {
        private AsyncOperation _async;

        private void Start()
        {
            
            
            StartCoroutine(Load()); // Load scene in background
            Application.targetFrameRate = 60;
        }

        private IEnumerator Load()
        {
        
            _async = SceneManager.LoadSceneAsync("Scene 1");
            _async.allowSceneActivation = false;
            yield return _async;
        }
        public void Play()
        {
            // async.allowSceneActivation = true;
            SceneManager.LoadScene("Scene 1");
        }
    
        public void Quit()
        {
            Application.Quit();
        }
    }
}
