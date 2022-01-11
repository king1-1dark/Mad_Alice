using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost_Engine : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player_Controller>(out var player))
        {
            
            player.SpeedUp(6, 2);
            Destroy(this.gameObject);
        }
    }
}
