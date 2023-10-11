using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class Gun1 : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 5000f;
    public float gravityForce = 1;
    public GameObject hand;
    public float eccentricity = 40;
    private float timer;
    private float delay = 2f; // changed from 3 to 2 sec delay
    public static float time1 = 0;
    IEnumerator Wait1()
    {
        yield return new WaitForSeconds(5f);
        Debug.Log("Coroutine called");

        StartCoroutine(Fire1());

    }

    IEnumerator Fire1()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);

            time1 += delay;
            Debug.Log("Time: " + time1);

            bulletSpawnPoint.transform.rotation = hand.transform.rotation;
            // ROTATION ECCENTRICITY: 
            bulletSpawnPoint.transform.Rotate(new Vector3(0, eccentricity, 0));
            Quaternion direction = Quaternion.Euler(90, 90, 90);
            //bulletSpawnPoint.transform.position = playerCamera.transform.position + playerCamera.transform.forward * Time.deltaTime * 500.0f;


            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
            // timer = delay;
        }

    }

    void Start()
    {
        StartCoroutine(Wait1());
    }


    void Update()
    {


    }


   

}
