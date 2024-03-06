using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestalTrigger : MonoBehaviour
{
    Animator anim;

    SoundManager soundManager;

    BeatSpawner beatSpawner;

    ObstacleSpawner obstacleSpawner;

    public GameObject redSword;

    public GameObject blueSword;

    public GameObject leftSword;

    public GameObject rightSword;

    public GameObject leftHand;

    public GameObject rightHand;

    bool musicPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.Find("Pedestal").GetComponent<Animator>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        beatSpawner = GameObject.Find("BeatSpawner").GetComponent<BeatSpawner>();
        obstacleSpawner = GameObject.Find("ObstacleSpawner").GetComponent<ObstacleSpawner>();
    }

    private void Update()
    {
        CheckIfMusicShouldPlay();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "RedRacket")
        {
            anim.SetBool("redIsActive", true);
            Destroy(redSword);
            rightSword.SetActive(true);
            rightHand.SetActive(false);
        }

        if(other.gameObject.name == "BlueRacket")
        {
            anim.SetBool("blueIsActive", true);
            Destroy(blueSword);
            leftSword.SetActive(true);
            leftHand.SetActive(false);
        }
    }

    void CheckIfMusicShouldPlay()
    {
        if (anim.GetBool("redIsActive") == true && anim.GetBool("blueIsActive") == true && musicPlayed != true)
        {
            soundManager.PlayMusicTrack();
            musicPlayed = true;
            beatSpawner.StartSpawner();
            obstacleSpawner.StartSpawner();
        }
    }
}
