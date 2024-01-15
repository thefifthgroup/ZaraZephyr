using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private AudioSource finishSound;
    private bool levelFinished = false; 
    private BGMController bgm;
    private Animator anim; 
    private LevelChanger levelChanger;
    private int keys = 0;
  
    private void Start()
    {
        bgm = FindObjectOfType<BGMController>();
        levelChanger = FindObjectOfType<LevelChanger>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelFinished)
        {
            if (keys == 5)
            {
                levelFinished = true;
                bgm.backgroundMusic.Stop();
                anim.SetTrigger("checkpointOn");
                IsComplete();
            }
        }
    }

    public void AllKeysCollected()
    {
        keys += 5;
    } 

    private void IsComplete()
    {
        finishSound.Play();
        Invoke("CompleteLevel", .5f);
    }

    private void CompleteLevel()
    {
        levelChanger.FadeToLevel(0);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
