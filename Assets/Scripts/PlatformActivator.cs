using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformActivator : MonoBehaviour
{
    private InvisiblePlatform platform;
    private GameObject invisiblePlatform;
    private bool isDone = false;
    private int keys = 0;

    private void Awake()
    {
        platform = FindObjectOfType<InvisiblePlatform>();
        invisiblePlatform = GameObject.Find("InvisiblePlatform");
    }
    void Start()
    {
        invisiblePlatform.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && isDone == false)
        {
            if (keys != 5)
            {
                invisiblePlatform.SetActive(true);
                platform.sfxPlatform.Play();
                platform.platformAppear.SetTrigger("appear");
                Debug.Log("Platform activated ");
                isDone = true;  
            }
        }
    }

    public void AllKeysCollected()
    {
        keys += 5;
    }

}
