using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;



public class CollisionBullet1 : MonoBehaviour
{
    private float reactionTimer = 0;
    public KeyCode StartKey = KeyCode.Space;
    static string dataPath = Directory.GetCurrentDirectory() + "/Assets/Data/";
    string logFile = dataPath + "Data" + ".csv";
    public static string log; // new line of data
    public float StartTime = 0; // unused
    public static double totalScore1 = 0;
    public static bool detectCollision = true; // FIX

    void Start()
    {
        if (!Directory.Exists(dataPath))
        {
            Directory.CreateDirectory(dataPath);
        }
        if (!File.Exists(logFile))
        {
            File.WriteAllText(logFile, "Time, Distance, Ypos, Zpos, Angle, Score, TotalScore" + Environment.NewLine);
        }
        
        

    }

    public void OnTriggerEnter(Collider col)
    {
        log = "";
        if (col.gameObject.name == "Target")
        {
           
            Vector3 offsetPosition = new Vector3(GameObject.Find("Target").transform.position.x - 15, GameObject.Find("Target").transform.position.y - 4, GameObject.Find("Target").transform.position.z);
            double ypos = gameObject.transform.position.y - GameObject.Find("Target").transform.position.y;
            double zpos = gameObject.transform.position.z - GameObject.Find("Target").transform.position.z;
            double distance = Math.Sqrt(ypos * ypos + zpos * zpos);
            double angle = Math.Atan(Math.Abs(zpos) / 15.0);
            double score = 0;
            // float time = gameObject.GetComponent<Gun1>().time; // Fix this one!!
            // float time = GameObject.Find("Player").GetComponent<SteamVRObjects>();
            Debug.Log("Retrieved time: " + Gun1.time1);
            // ROUNDING
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
            else if (distance <= 3.91)
                score = 10;


            Debug.Log("Score: " + score);

            totalScore1 += score;

            Debug.Log("Total Score: " + totalScore1);

            if (score != 0) // log only if valid score
            {
                log += Gun1.time1 + "," + distance + "," + ypos + "," + zpos + "," + angle + "," + score + "," + totalScore1;
                File.AppendAllText(logFile, log + Environment.NewLine);
                log = "";
            }
            detectCollision = true;
        }
    }

}