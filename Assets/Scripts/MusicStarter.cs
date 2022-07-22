using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStarter : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Instance.SetVolume("Music Game", 0);
    }
}
