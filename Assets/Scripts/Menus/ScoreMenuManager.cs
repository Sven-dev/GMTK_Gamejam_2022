using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMenuManager : MonoBehaviour
{
    [SerializeField] private Text MovesLabel;
    [SerializeField] private Text TimerLabel;

    // Start is called before the first frame update
    void Start()
    {
        ScoreManager scoreManager = ScoreManager.Instance;
        scoreManager.StopTimer();

        MovesLabel.text = scoreManager.Moves.ToString();
        var ts = TimeSpan.FromSeconds(scoreManager.Time);
        TimerLabel.text = string.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);

        AudioManager.Instance.Play("Applause");
    }

    public void ReturnToMainMenu()
    {
        LevelManager.Instance.LoadLevel(1, Transition.Crossfade);
    }
}
