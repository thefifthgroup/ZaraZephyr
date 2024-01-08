using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Text keysText;
    private int keys = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If player collides with a collectible key, destroy it and 1 add to counter
        if (collision.gameObject.CompareTag("KeyCollectible"))
        {
            Destroy(collision.gameObject);
            keys++;
            // Display counter in the GUI
            keysText.text = "Keys: " + keys + "/3";
        }
    }
}
