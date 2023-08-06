using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;


public class CollisionBullet : MonoBehaviour
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
        int ind = SceneManager.GetActiveScene().buildIndex;
        switch (ind)
        {
            case 0:
                logFile = dataPath + "Data_0.csv";
                break;
            case 1:
                logFile = dataPath + "Data_15.csv";
                break;
            case 2:
                logFile = dataPath + "Data_-15.csv";
                break;
            case 3:
                logFile = dataPath + "Data_30.csv";
                break;
            case 4:
                logFile = dataPath + "Data_-30.csv";
                break;
        }
    
        

        if (!Directory.Exists(dataPath))
        {
            Directory.CreateDirectory(dataPath);
        }
        if (!File.Exists(logFile))
        {
            File.WriteAllText(logFile, "Time, TargetPos, Distance, Ypos, Zpos, Angle, Score, TotalScore" + Environment.NewLine);
        }
        
        

    }

    public void OnTriggerEnter(Collider col)
    {
        log = "";
        if (SceneManager.GetActiveScene().buildIndex != 8 && col.gameObject.name == "Target")
        {
            double targetY = GameObject.Find("Target").transform.position.y;
            double targetZ = GameObject.Find("Target").transform.position.z;
            double bulletY = gameObject.transform.position.y;
            double bulletZ = gameObject.transform.position.z;
            double ypos = bulletY - targetY;
            double zpos = bulletZ - targetZ;
            Debug.Log("Target: " + targetZ + ", " + gameObject.transform.position.z);
            double distance = Math.Sqrt(ypos * ypos + zpos * zpos);
            double angle = 0;
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


            Debug.Log("Score: " + score);

            totalScore += score;

            Debug.Log("Total Score: " + totalScore);

            if (true) // log only if valid score // changed from score != 0
            {
                log += Gun.time + "," + targetZ + "," + distance + "," + ypos + "," + zpos + "," + angle + "," + score + "," + totalScore;
                File.AppendAllText(logFile, log + Environment.NewLine);
                log = "";
            }
            detectCollision = true;
        }
    }

}