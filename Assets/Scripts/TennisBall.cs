using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisBall : MonoBehaviour
{
    UIManager uiManager;

    public GameObject explosion;

    [SerializeField]
    int scoreValue = 100;

    private void Start()
    {
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if((collision.gameObject.name == "LeftRacket" && this.gameObject.tag == "BlueBall") || (collision.gameObject.name == "RightRacket" && this.gameObject.tag == "RedBall"))
        {
            GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity);
            this.gameObject.SetActive(false);
            uiManager.UpdateScore(scoreValue);
            Destroy(expl, 1);
            Destroy(this.gameObject, 2);
        }
        else if(collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "BlueBall" || collision.gameObject.tag == "RedBall")
        {
            Destroy(this.gameObject);
        }
        else
        {
            uiManager.UpdateMisses();
            Destroy(this.gameObject);
        }
    }
}
