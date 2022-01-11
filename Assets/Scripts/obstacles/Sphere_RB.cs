using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere_RB : MonoBehaviour
{
    [SerializeField] private GameObject cube;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player_Controller>(out var player))
        {
            Destroy(cube);
        }
    }
}
