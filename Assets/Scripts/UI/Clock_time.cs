using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Clock_time : MonoBehaviour
{
    Vector3 end = new Vector3(11000, 11000, 11000);
    [SerializeField] private float time = 1, curtime = 1;
    [SerializeField] private Player_Controller pl;
    [SerializeField] private GameObject clock;

    private Vector3 scale;
    void FixedUpdate()
    {
        if(pl.startPanel.activeSelf == false)
        {
            clock.SetActive(true);
            if (pl.time > 10)
                PingPong();
            if (pl.time < 10 && pl.time > 0)
            {
                PingPong();
                time = 2;
            }
        }
        
    }

    void PingPong()
    {
        clock.transform.localScale = Mathf.PingPong(Time.time * time, curtime) * end;
        if (pl.time > 10)
            time = 1;
        if (pl.time < 10 && pl.time > 0)
        {
            time = 2;
        }
    }
}
