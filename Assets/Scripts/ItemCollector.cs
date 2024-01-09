using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Text keysText;
    [SerializeField] private AudioSource collectionSoundEffect;
    [SerializeField] private AudioSource keysSoundEffect;
    private int keys = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If player collides with a collectible key, destroy it and 1 add to counter
        if (collision.gameObject.CompareTag("KeyCollectible"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            keys++;
            // Display counter in the GUI
            keysText.text = "Keys: " + keys + "/5";
            if (keys == 5)
            {
                keysSoundEffect.Play(); 
                keysText.fontStyle = FontStyle.Bold;
                keysText.color = Color.red;
                LevelComplete();
            }
        }
    }
    public bool LevelComplete()
    {
        return true;
    }
}
