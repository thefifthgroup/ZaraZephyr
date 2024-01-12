using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCar : MonoBehaviour
{
    public Animator fallingCarAppear;
    public AudioSource fallingCarSFX;

    public void TriggerFallingCar()
    {
        fallingCarAppear.SetTrigger("appear");
        Invoke("TriggerFallingCarSFX", .5f); 
    }
    private void TriggerFallingCarSFX()
    {
        fallingCarSFX.Play();
    }
}
