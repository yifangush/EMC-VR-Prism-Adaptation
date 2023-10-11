using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Timer : MonoBehaviour
{
    static string dataPath = Directory.GetCurrentDirectory() + "/Assets/Data/";
    string logFile = dataPath + "Time" + ".csv";
    public static string log;
    float StartTime = 0;
    public KeyCode StartKey = KeyCode.Space;

    // Start is called before the first frame update
    void Start()
    {
        if (!Directory.Exists(dataPath))
        {
            Directory.CreateDirectory(dataPath);
        }
        if (!File.Exists(logFile))
        {
            File.WriteAllText(logFile, "Time\n");
        }

        double StartTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        StartTime = StartTime / (Math.Pow(10, 12));


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(StartKey))
        {
            double ThrowTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            ThrowTime = ThrowTime / (Math.Pow(10, 12));
            double ElapsedTime = ThrowTime - StartTime;
            log += ElapsedTime + "time, ";
            File.AppendAllText(logFile, log);
            Debug.Log(ThrowTime);

        }

    }
}
