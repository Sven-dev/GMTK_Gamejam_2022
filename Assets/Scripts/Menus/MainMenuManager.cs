using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject InstructionsPanel;
    [SerializeField] private GameObject OptionsPanel;
    [SerializeField] private GameObject CreditsPanel;

    public void StartGame()
    {
        LevelManager.Instance.LoadLevel(2, Transition.Crossfade);
        AudioManager.Instance.FadeOut("Music Menu", 2f);
        AudioManager.Instance.FadeIn("Music Game", 1f);
    }

    public void EnableInstructions()
    {
        InstructionsPanel.SetActive(true);
    }

    public void DisableInstructions()
    {
        print("test");
        InstructionsPanel.SetActive(false);
    }

    public void EnableOptions()
    {
        OptionsPanel.SetActive(true);
    }

    public void DisableOptions()
    {
        OptionsPanel.SetActive(false);
    }

    public void EnableCredits()
    {
        CreditsPanel.SetActive(true);
    }

    public void DisableCredits()
    {
        CreditsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
