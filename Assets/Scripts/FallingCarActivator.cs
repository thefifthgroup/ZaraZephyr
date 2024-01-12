using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCarActivator : MonoBehaviour
{
    [SerializeField] private AudioSource fallingCarWarning;
    private FallingCar fallingCar;
    private GameObject fallingCarObject;
    private bool isDone = false;
    // Start is called before the first frame update

    private void Awake()
    {
        fallingCarObject = GameObject.Find("FallingCar");
        fallingCar = FindObjectOfType<FallingCar>();
    }
    void Start()
    {
        fallingCarObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && isDone == false)
        {
            fallingCarObject.SetActive(true);
            fallingCarWarning.Play();
            fallingCar.TriggerFallingCar();
            isDone = true;
        }
    }
}
