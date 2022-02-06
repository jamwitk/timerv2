using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    }
}
