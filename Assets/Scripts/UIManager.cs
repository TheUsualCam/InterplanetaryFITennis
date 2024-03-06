using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    ObstacleSpawner obstacleSpawner;
    BeatSpawner beatSpawner;
    SoundManager soundManager;

    public TMP_Text scoreText;
    public TMP_Text missesText;
    public TMP_Text songCompleteText;
    public TMP_Text finalScoreText;
    public TMP_Text songFailedText;

    GameObject[] blueBalls;
    GameObject[] redBalls;
    GameObject[] obstacles;

    int currentScore;
    int missesRemaining = 3;

    private void Start()
    {
        obstacleSpawner = GameObject.Find("ObstacleSpawner").GetComponent<ObstacleSpawner>();
        beatSpawner = GameObject.Find("BeatSpawner").GetComponent<BeatSpawner>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    private void FixedUpdate()
    {
        blueBalls = GameObject.FindGameObjectsWithTag("BlueBall");
        redBalls = GameObject.FindGameObjectsWithTag("RedBall");
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

        if (soundManager.SongIsFinished())
        {
            SongCompleted();
            StartCoroutine(LoadMainMenu());
        }
    }

    public void UpdateScore(int score)
    {
        currentScore += score;
        scoreText.text = currentScore.ToString();
    }

    public void UpdateMisses()
    {
        if(missesRemaining > 1)
        {
            missesRemaining--;
            missesText.text = "Misses: " + missesRemaining;
        }
        else
        {
            obstacleSpawner.StopSpawner();
            beatSpawner.StopSpawner();
            soundManager.StopPlaying();

            foreach(GameObject ball in blueBalls)
            {
                Destroy(ball);
            }
            foreach(GameObject ball in redBalls)
            {
                Destroy(ball);
            }
            foreach(GameObject obstacle in obstacles)
            {
                Destroy(obstacle);
            }

            missesRemaining--;
            missesText.text = "Misses: " + missesRemaining;
            songFailedText.enabled = true;
            scoreText.enabled = false;
            missesText.enabled = false;
            StartCoroutine(LoadMainMenu());
        }
    }

    public void SongCompleted()
    {
        obstacleSpawner.StopSpawner();
        beatSpawner.StopSpawner();

        foreach (GameObject ball in blueBalls)
        {
            Destroy(ball);
        }
        foreach(GameObject ball in redBalls)
        {
            Destroy(ball);
        }
        foreach (GameObject obstacle in obstacles)
        {
            Destroy(obstacle);
        }

        finalScoreText.text = "YOUR SCORE: " + currentScore;

        songCompleteText.enabled = true;
        finalScoreText.enabled = true;
        scoreText.enabled = false;
        missesText.enabled = false;
    }

    IEnumerator LoadMainMenu()
    {
        yield return new WaitForSeconds(10.0f);
        SceneManager.LoadSceneAsync(1);
    }
}
