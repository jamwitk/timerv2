using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagements : MonoBehaviour
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
        //StartCoroutine(Load()); // Load scene in background
    }

    private IEnumerator Load()
    {
        
        async = SceneManager.LoadSceneAsync("Scene 1");
        async.allowSceneActivation = false;
        yield return async;
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
