using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreStarter : MonoBehaviour
{
    void Start()
    {
        ScoreManager.Instance.ResetScore();
        ScoreManager.Instance.StartTimer();
    }
}
