using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int Time = 0;
    public int Moves = 0;

    private IEnumerator Timer;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        Timer = _Timer();
    }

    public void StartTimer()
    {
        StartCoroutine(Timer);
    }

    public void StopTimer()
    {
        StopCoroutine(Timer);
    }

    public void ResetScore()
    {
        Time = 0;
        Moves = 0;
    }

    private IEnumerator _Timer()
    {
        while(true)
        {
            Time++;
            yield return new WaitForSeconds(1);
        }
    }
}
