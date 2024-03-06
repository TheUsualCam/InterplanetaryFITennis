using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatSpawner : MonoBehaviour
{
    public GameObject[] cubes;

    public Transform[] spawnPoints;

    public SoundManager soundManager;

    float _nextBeatToSpawnNote = 0.0f;

    bool musicPlaying = false;

    // Update is called once per frame
    void Update()
    {
        if(soundManager.songPositionInBeats >= _nextBeatToSpawnNote && musicPlaying)
        {
            SpawnBeat();

            _nextBeatToSpawnNote += 4.0f;
        }
    }

    void SpawnBeat()
    {
        Instantiate(cubes[Random.Range(0, cubes.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)]);
    }

    public void StartSpawner()
    {
        musicPlaying = true;
    }

    public void StopSpawner()
    {
        musicPlaying = false;
    }
}
