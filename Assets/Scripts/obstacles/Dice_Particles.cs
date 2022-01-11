using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice_Particles : MonoBehaviour
{
    [SerializeField] private ParticleSystem puff;
    private void OnCollisionEnter(Collision collision)
    {
        puff.Play();
    }
}
