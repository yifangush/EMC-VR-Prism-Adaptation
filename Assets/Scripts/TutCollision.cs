using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;


public class TutCollision : MonoBehaviour
{
    private float reactionTimer = 0;
    public KeyCode StartKey = KeyCode.Space;
    static string dataPath = Directory.GetCurrentDirectory() + "/Assets/Data/";
    string logFile;
    public static string log; // new line of data
    public float StartTime = 0; // unused
    public static double totalScore = 0;
    public static bool detectCollision = true; // FIX

    void Start()
    {

    }

    public void OnTriggerEnter(Collider col)
    {
        log = "";
        if (col.gameObject.name == "Target") // removed "SceneManager.GetActiveScene().buildIndex != 8" condition. Tutorial round will now keep track of player accuracy.
        {
            double targetY = GameObject.Find("Target").transform.position.y;
            double targetZ = GameObject.Find("Target").transform.position.z;
            double bulletY = gameObject.transform.position.y;
            double bulletZ = gameObject.transform.position.z;
            double ypos = bulletY - targetY;
            double zpos = bulletZ - targetZ;
            Debug.Log("Target: " + targetZ + ", " + gameObject.transform.position.z);
            double distance = Math.Sqrt(ypos * ypos + zpos * zpos);
            double angle;
            double score = 0;
            // float time = gameObject.GetComponent<Gun>().time; // Fix this one!!
            // float time = GameObject.Find("Player").GetComponent<SteamVRObjects>();
            Debug.Log("Retrieved time: " + Gun.time);
            // ROUNDING

            // target position and bullet position used, independent of round:
            // positive direction is to the LEFT
            angle = Math.Atan(bulletZ / 30.0) - Math.Atan(targetZ / 30.0);

            // radian to degree
            angle *= 180.0 / Math.PI;

            Debug.Log("Target=" + targetZ + ": delta=" + zpos + ", bullet=" + bulletZ + ", angle=" + angle);


            ypos = Math.Round(ypos, 4);
            zpos = Math.Round(zpos, 4);
            distance = Math.Round(distance, 4);
            angle = Math.Round(angle, 4);

            if (distance <= 3.96)
            {
                score = Math.Round((3.96 - distance) / 3.96 * 100);
            }
            /*
            if (distance <= 0.3)
                score = 100;
            else if (distance <= 0.63)
                score = 90;
            else if (distance <= 1.35)
                score = 75;
            else if (distance <= 2.25)
                score = 50;
            else if (distance <= 3)
                score = 25;
            else if (distance <= 3.96) // updated from 3.91
                score = 10;
            */


            Debug.Log("Score: " + score);

            totalScore += score;

            Debug.Log("Total Score: " + totalScore);

        }
    }

}