using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player_Controller>(out var player))
        {
            
            player.timer.text = "YOU LOSE";
            player.Ragdoll();
            player.RestartGame();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player_Controller>(out var player))
        {
            player.timer.text = "YOU LOSE";
            player.Ragdoll();
            player.RestartGame();
        }

    }
}
