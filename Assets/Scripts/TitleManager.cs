using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public GameObject playButton;
    public GameObject exitButton;
    public GameObject song1Button;
    public GameObject song2Button;
    public GameObject backButton;

    public TMP_Text titleText;
    public TMP_Text songChoiceText;

    public void OpenSongChoiceMenu()
    {
        playButton.SetActive(false);
        exitButton.SetActive(false);
        titleText.enabled = false;
        song1Button.SetActive(true);
        song2Button.SetActive(true);
        backButton.SetActive(true);
        songChoiceText.enabled = true;
    }

    public void CloseSongChoiceMenu()
    {
        playButton.SetActive(true);
        exitButton.SetActive(true);
        titleText.enabled = true;
        song1Button.SetActive(false);
        song2Button.SetActive(false);
        backButton.SetActive(false);
        songChoiceText.enabled = false;
    }

    public void LoadSongOne()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void LoadSongTwo()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
