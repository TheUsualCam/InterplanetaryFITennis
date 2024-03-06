using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2.0f;

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * transform.forward * _speed;
    }
}
