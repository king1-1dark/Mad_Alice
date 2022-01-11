using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tall_Clock : MonoBehaviour
{
    
    [SerializeField] private float angle,x;

    void FixedUpdate()
    {

        transform.rotation = Quaternion.Euler(Mathf.PingPong(Time.time*x, angle),-90,0);
    }
}
