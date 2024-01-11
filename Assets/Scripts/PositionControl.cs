 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using System.IO;
using System;
using TMPro;

public class PositionControl : MonoBehaviour
{
    public static string[] pos = { "Position 0", "Position -15", "Position 15", "Position 30", "Position -30" };
    Random rnd = new Random();
    public static int i;
    private int change_time = 6; // 9 sec + 5 sec initial delay  // 7 sec sweet point for 4-sec bullet reload
    public float timer = 0;
    private int numTrials = 0;
    public bool timerStart = false;

    

    
    // Start is called before the first frame update
    void Start()
    {
        i = rnd.Next(0, pos.Length);
        Debug.Log("Starting pos: " + i);
        GameObject.Find("Target").transform.position = GameObject.Find(pos[i]).transform.position;
    }

    IEnumerator change()
    {
      int j = i;
        while (j == i)
        {
        i = rnd.Next(0, pos.Length);
        }
        // i = 0;
        // this is a radical change; you should decide on whether to adopt it

        Debug.Log("Changing to position #" + i + ": " + pos[i]); 
        GameObject.Find("Target").transform.position = GameObject.Find(pos[i]).transform.position;
        yield return new WaitForSecondsRealtime(0); 
    }

    // Update is called once per frame
    void Update()
    { 
        if (Time.timeSinceLevelLoad - timer > change_time) 
        {
            StartCoroutine(change());
            change_time = 3;
            timer = Time.timeSinceLevelLoad;
        }
        
    }
}
