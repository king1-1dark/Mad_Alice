using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice_Controller : MonoBehaviour
{
    [SerializeField] private Player_Controller targetPlayer;
    [SerializeField] private GameObject dice;
    [SerializeField] private bool isHas =false;
    Vector3 offset;
    private void Start()
    {
        offset = this.transform.position- targetPlayer.transform.position;
    }
    private void Update()
    {
        if (targetPlayer.isMoving == true&&isHas==false)
            StartCoroutine(Spawn());
        this.transform.position = targetPlayer.transform.position + offset;
    }
    private void Spawn1()
    {
        if(!isHas)
        {
            GameObject newdice = Instantiate(dice, this.transform.position, Quaternion.identity);
            isHas=true;
            Destroy(newdice, 7);
        }
    }
    IEnumerator Spawn()
    {
        Spawn1();
        yield return new WaitForSeconds(10);
        isHas = false;
        StopCoroutine(Spawn());
    }
}
