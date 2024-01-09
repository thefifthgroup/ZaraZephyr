using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    public AudioSource backgroundMusic;
    private void Start()
    {
        backgroundMusic = GetComponent<AudioSource>();
    }
}
