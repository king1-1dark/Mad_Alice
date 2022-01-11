using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Domino : MonoBehaviour
{
    [SerializeField] private Vector3 start;
    [SerializeField] private float offset, t, amp, freq;
    void Start()
    {
        start = transform.position;
    }

    void FixedUpdate()
    {
        t = t + Time.deltaTime;
        offset = amp * Mathf.Sin(t * freq);
        transform.position = start + new Vector3(offset, 0, 0);
    }
}
