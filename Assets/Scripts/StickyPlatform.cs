using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : Monobehaviour
{
  private void OnTriggerEnter2D(Collider2D collision)
  {
      if (collision.gameObject.name == "Player")
      {
          collision.gameObject.transform.SetParent(transform);
      }
  }

  private void OnTriggerExit2d(Collider2D collision)
  {
      if (collision.gameObject.name == "Player")
    {
      collision.gameObject.transform.SetParent(null);
    }
  }
}
