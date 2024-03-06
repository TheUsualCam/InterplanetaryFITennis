using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audiosource;

    public AudioClip musicTrack;

    [SerializeField]
    float _firstBeatOffset;

    public float songBpm;

    public float songPositionInBeats;

    float _secPerBeat;

    float _songPosition;

    float _dspSongTime;

    bool musicHasPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();

        _secPerBeat = 60f / songBpm;

        _dspSongTime = (float)AudioSettings.dspTime;
    }

    private void Update()
    {
        _songPosition = (float)(AudioSettings.dspTime - _dspSongTime - _firstBeatOffset);

        songPositionInBeats = _songPosition / _secPerBeat;
    }

    public void PlayMusicTrack()
    {
        audiosource.PlayOneShot(musicTrack);
        musicHasPlayed = true;
    }

    public bool SongIsFinished()
    {
        return !audiosource.isPlaying && musicHasPlayed;
    }

    public void StopPlaying()
    {
        musicHasPlayed = false;
        audiosource.Stop();
    }
}
