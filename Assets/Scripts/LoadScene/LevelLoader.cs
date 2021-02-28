using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace LoadScene
{
    public class LevelLoader : MonoBehaviour
    {
        public GameObject loadingScreen;
        public Slider slider;
        
        public void Load(int sceneIndex)
        {
            StartCoroutine(LoadAsynchronously(sceneIndex));
        }

        private IEnumerator LoadAsynchronously(int sceneIndex)
        {
            var operation = SceneManager.LoadSceneAsync(sceneIndex);
            loadingScreen.SetActive(true);
            while (!operation.isDone)
            {
                var progress = Mathf.Clamp01(operation.progress / .9f);

                slider.value = progress;

                yield return null;
            }
        }
    }
}
