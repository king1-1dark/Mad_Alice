using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Camera_cotrol : MonoBehaviour
{
    
    [SerializeField] private Transform player;
    [SerializeField] private float smooth;
    private Vector3 offset,targetPos;
    private void Start()
    {
        offset = transform.position - player.position;
    }
    private void FixedUpdate()
    {
        targetPos = player.position + offset;
        this.transform.position = Vector3.Lerp(this.transform.position, targetPos, smooth);
    }
}
