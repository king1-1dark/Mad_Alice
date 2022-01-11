using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballistic : MonoBehaviour
{

    [SerializeField] private Transform SpawnTransform;
    [SerializeField] private Transform TargetTransform;
    [SerializeField] private float spawnTime;
    [SerializeField] private float ReloadTime;
    [SerializeField] private float AngleInDegrees;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private float y, z;
    float g = Physics.gravity.y;

    

    private void Start()
    {
        InvokeRepeating("Shot", spawnTime, ReloadTime);
    }
    void Update()
    {
        SpawnTransform.localEulerAngles = new Vector3(-AngleInDegrees, y, z);
    }

    public void Shot()
    {
        Vector3 fromTo = TargetTransform.position - transform.position;
        Vector3 fromToXZ = new Vector3(fromTo.x, 0f, fromTo.z);

        //transform.rotation = Quaternion.LookRotation(fromToXZ, Vector3.up);


        float x = fromToXZ.magnitude;
        float y = fromTo.y;

        float AngleInRadians = AngleInDegrees * Mathf.PI / 180;

        float v2 = (g * x * x) / (2 * (y - Mathf.Tan(AngleInRadians) * x) * Mathf.Pow(Mathf.Cos(AngleInRadians), 2));
        float v = Mathf.Sqrt(Mathf.Abs(v2));

        GameObject newBullet = Instantiate(Bullet, SpawnTransform.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().velocity = SpawnTransform.forward * v;
        Destroy(newBullet, 5);
    }
}
