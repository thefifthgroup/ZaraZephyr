using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfBite : MonoBehaviour
{
    private AudioSource wolfBite;
    void Start()
    {
        wolfBite = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            wolfBite.Play();
        }
        else
        {
            wolfBite.Stop();
        }
    }
}
