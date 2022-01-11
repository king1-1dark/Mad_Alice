using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogWheel : MonoBehaviour
{
    [SerializeField] private Vector3 start;
    [SerializeField] private float offset, t, amp , freq;
    void Start()
    {
        amp = 1;
        freq = Random.Range(1.0f, 3.0f);
        start = transform.position;
    }

    void FixedUpdate()
    {
        t = t + Time.deltaTime;
        offset = amp * Mathf.Sin(t * freq);
        transform.position = start + new Vector3(0, offset, 0);
    }
}
