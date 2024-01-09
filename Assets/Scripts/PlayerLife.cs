using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife: MonoBehaviour
{
    // References, initializiations, declarations
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private AudioSource lifeSoundEffect;
    //[SerializeField] private AudioSource backgroundMusic;
    private BGMController bgm;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        bgm = FindObjectOfType<BGMController>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Player death condition 
        if (collision.gameObject.CompareTag("Trap"))
        {
            bgm.backgroundMusic.Stop();
            Die();
        }
    }

    private void Die()
    {
        // Set rigidbody type from dynamic to static when player dies, therefore stopping player movement or player input 
        deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        // set paramater to true
        anim.SetTrigger("death");
    }

    private void RestartLevel()
    {
        // Restore scene/level
        lifeSoundEffect.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

