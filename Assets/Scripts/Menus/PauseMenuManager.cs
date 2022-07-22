using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject PausePanel;

    private bool Paused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                //Resume game
                Paused = false;
                Unpause();
            }
            else
            {
                //Pause
                Paused = true;
                Pause();
            }
        }
    }

    public void Pause()
    {
        Movement.Instance.Paused = true;
        PausePanel.SetActive(true);

        ScoreManager.Instance.StopTimer();
        AudioManager.Instance.SetVolume("Music Game", 0);
    }

    public void Unpause()
    {
        Movement.Instance.Paused = false;
        PausePanel.SetActive(false);

        ScoreManager.Instance.StartTimer();
        AudioManager.Instance.SetVolume("Music Game", 1);
    }

    public void ReturnToMainMenu()
    {
        AudioManager.Instance.FadeIn("Music Menu", 1f);
        LevelManager.Instance.LoadLevel(1, Transition.Crossfade);
    }
}