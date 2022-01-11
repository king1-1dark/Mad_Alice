using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chess : MonoBehaviour
{
    [SerializeField] private Transform player;
    void Update()
    {
        transform.LookAt(player,Vector3.up);
    }
}
