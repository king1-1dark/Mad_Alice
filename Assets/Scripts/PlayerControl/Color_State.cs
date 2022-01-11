using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Color_State : MonoBehaviour
{
    public enum ColorState
    {
        Red, Yellow, Green
    }
    [SerializeField] private Renderer lights;
    [SerializeField] private ColorState startState = ColorState.Green;

    [SerializeField] private float stopTime;
    [SerializeField] private float goTime;

    private void Start()
    {
        switch (startState)
        {
            case ColorState.Red:
                StartCoroutine(Red());
                break;
            case ColorState.Yellow:
                StartCoroutine(Yellow());
                break;
            case ColorState.Green:
                StartCoroutine(Green());
                break;
        }
    }
    IEnumerator Red()
    {
        lights.material.color = Color.red;
        stopTime = Random.Range(2, 10);
        yield return new WaitForSeconds(stopTime);
        StartCoroutine(Green());
    }

    IEnumerator Green()
    {
        lights.material.color = Color.green;
        goTime = Random.Range(5, 15);
        yield return new WaitForSeconds(goTime);
        StartCoroutine(Yellow());
    }

    IEnumerator Yellow()
    {
        lights.material.color = Color.yellow;
        yield return new WaitForSeconds(2);
        StartCoroutine(Red());
    }
}
