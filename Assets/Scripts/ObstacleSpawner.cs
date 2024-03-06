using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle;

    public Transform spawnPoint;

    public SoundManager soundManager;

    float _nextBeatToSpawnNote = 0.0f;

    bool musicPlaying = false;

    // Update is called once per frame
    void Update()
    {
        if (soundManager.songPositionInBeats >= _nextBeatToSpawnNote && musicPlaying && Random.Range(0, 512) == 361)
        {
            SpawnObstacle();

            _nextBeatToSpawnNote += 4.0f;
        }
    }

    void SpawnObstacle()
    {
        Instantiate(obstacle, spawnPoint);
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
