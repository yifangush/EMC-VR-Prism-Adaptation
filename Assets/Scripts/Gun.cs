using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 5000f;
    public float gravityForce = 1;
    public GameObject hand;
    private float eccentricity = 0;
    private float timer;
    private float delay = 3f; // changed from 3 to 2 sec delay
    public static IEnumerator coroutine;
    public static float time = 0;
    public static int round = 0;
    public static int maxScore = 750; // 1000 -> 750 score to reach, 150 for debug testing
    public static int maxTime = 60; // 1 minutes per round maximum CHANGE THIS 
    public static bool rest = false;

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("Coroutine called");

        StartCoroutine(Fire());
    }

    IEnumerator Fire()
    {
        while (time < maxTime) // removed CollisionBullet.totalScore < maxScore &&
        {
            yield return new WaitForSeconds(delay);

            time += delay;
            Debug.Log("Time: " + time);

            bulletSpawnPoint.transform.rotation = hand.transform.rotation;
            // ROTATION ECCENTRICITY: 
            int ind = SceneManager.GetActiveScene().buildIndex;
            switch (ind)
            {
                case 0:
                    eccentricity = 0;
                    break;
                case 1:
                    eccentricity = 15;
                    break;
                case 2:
                    eccentricity = -15;
                    break;
                case 3:
                    eccentricity = 30;
                    break;
                case 4:
                    eccentricity = -30;
                    break;
            }
            Debug.Log("Bullet rotated to " + eccentricity);
            bulletSpawnPoint.transform.Rotate(new Vector3(10, eccentricity, 0));
            //Quaternion direction = Quaternion.Euler(90, 90, 90);
            //bulletSpawnPoint.transform.position = playerCamera.transform.position + playerCamera.transform.forward * Time.deltaTime * 500.0f;


            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
            // timer = delay;
        }
        Debug.Log("Finished firing");
    }


    void Start()
    {
        Debug.Log("Starting Round " + SceneManager.GetActiveScene().buildIndex);
        coroutine = Wait();
        StartCoroutine(coroutine);
    }

    void Update() //This probably needs to be changed because player is not destroyed
    {
        if (time >= maxTime) // remove CollisionBullet.totalScore >= maxScore || 
        {
            Destroy(GameObject.Find("Player"));
            time = 0;
            CollisionBullet.totalScore = 0;
            round += 1;
            if (round <= 4)
            {
                SceneManager.LoadScene(6); //break scene
            }
            else
            {
                SceneManager.LoadScene(7); //end scene
            }
        }

    }


   

}
