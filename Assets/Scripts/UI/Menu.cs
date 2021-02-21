using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    public void MusicControl()
    {
        foreach (var s in AudioManager.Instance.sounds)
        {
            s.source.enabled = !s.source.enabled;
        }
    }
  
}
