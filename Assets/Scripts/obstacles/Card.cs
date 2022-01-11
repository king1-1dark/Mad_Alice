using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private Vector3 start;
    [SerializeField] private float offset,t,amp,freq;
    [SerializeField] private Material[] materials;
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = materials[Random.Range(0,materials.Length)];
        start = transform.position;
        amp = Random.Range(1.0f, 2.0f);
        freq = Random.Range(1.0f, 2.5f);
    }

    void FixedUpdate()
    {
        t = t + Time.deltaTime;
        offset = amp * Mathf.Sin(t * freq);
        transform.position = start +new Vector3(0,offset,0);
    }


}
