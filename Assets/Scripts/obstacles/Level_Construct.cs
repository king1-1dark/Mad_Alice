using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Construct : MonoBehaviour
{
    [SerializeField] private GameObject[] massObstacles;
    [SerializeField] private GameObject[] lvlObstacles;
    [SerializeField] private GameObject lvlFinish;
    public Transform startLevel;
    private Transform lastPlatform = null;
    private Vector3 pos;
    private void Start()
    {
        for (int i = 0; i < lvlObstacles.Length; i++)
        {
            lvlObstacles[i] = massObstacles[Random.Range(0, massObstacles.Length)];
            CreateLvLObstacles(i);
        }
         lvlObstacles[lvlObstacles.Length-1] = lvlFinish;
        Instantiate(lvlObstacles[lvlObstacles.Length - 1], pos, Quaternion.identity, lastPlatform);
    }
    private void CreateLvLObstacles(int i)
    {
        pos = (lastPlatform == null) ?
            startLevel.position :
            lastPlatform.GetComponent<Platform_Controller>().endPoint.position;
        GameObject res = Instantiate(lvlObstacles[i],pos,Quaternion.identity, startLevel);
        lastPlatform = res.transform;
        
    }

}
