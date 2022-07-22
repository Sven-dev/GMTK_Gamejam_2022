using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelResetter : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            //reload scene
            LevelManager.Instance.LoadLevel(2, Transition.None);
        }
    }
}
