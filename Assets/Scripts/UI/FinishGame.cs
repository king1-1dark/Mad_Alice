using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    [SerializeField] private GameObject finish;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player_Controller>(out var player))
        {
            player.FinishGame();
            finish.SetActive(true);
        }
    }
}
