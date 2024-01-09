using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSplash : MonoBehaviour
{
    private AudioSource waterSplash;
    void Start()
    {
        waterSplash = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            waterSplash.Play(); 
        }
        else
        {
            waterSplash.Stop();
        }
    }
}
