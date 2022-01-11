using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time_Score : MonoBehaviour
{
    [SerializeField] public float time;
    [SerializeField] public Text Timer;
    [SerializeField] private GameObject Restart;

    private void Start()
    {
        Timer.text = time.ToString();
    }

    private void Update()
    {
        //timer();

    }
    public void timer()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            Timer.text = Mathf.Round(time).ToString();
        }
        else
        {
            Time.timeScale = 0;
            Timer.text = "Time`s UP";
            Restart.SetActive(true);
        }
    }

}
