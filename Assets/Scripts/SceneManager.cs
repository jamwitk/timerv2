using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    private AsyncOperation async;
    public TextMeshProUGUI SpaceText;
    public TextMeshProUGUI WasdText;

    private void Awake()
    {
#if UNITY_ANDROID
        SpaceText.text = "Press button to crunch";
        WasdText.text = "Use joystick to Movement";
#endif
    }

    private void Start()
    {
        StartCoroutine(Load()); // Load scene in background
    }

    IEnumerator Load()
    {
        async = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Scene 1");
        async.allowSceneActivation = false;
        yield return async;
    }
    public void Play()
    {
        async.allowSceneActivation = true;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
