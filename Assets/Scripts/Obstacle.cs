using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    UIManager uiManager;

    private void Start()
    {
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BlueBall" || collision.gameObject.tag == "RedBall")
        {
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "MainCamera" || collision.gameObject.tag == "Racket")
        {
            uiManager.UpdateMisses();
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
