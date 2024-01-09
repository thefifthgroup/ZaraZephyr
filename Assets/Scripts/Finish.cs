using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private AudioSource finishSound;
    private ItemCollector levelComplete;
    private bool levelFinished = false; 
    private BGMController bgm;
    private Animator anim; 
  
    private void Start()
    {
        levelComplete = FindAnyObjectByType<ItemCollector>();
        bgm = FindObjectOfType<BGMController>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && levelComplete.LevelComplete() && !levelFinished)
        {
            levelFinished = true;
            //bgm.backgroundMusic.Stop();
            anim.SetTrigger("checkpointOn");
            IsComplete();
        }
    }

    private void IsComplete()
    {
        finishSound.Play();
        Invoke("CompleteLevel", 2f);
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
