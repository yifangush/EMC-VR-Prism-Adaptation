 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using System.IO;
using System;
using TMPro;


public class PositionControl : MonoBehaviour
{
    public string[] pos = { "Position 0", "Position -10", "Position 10", "Position -20", "Position 20" };
    Random rnd = new Random();
    private int i = 0;
    private int change_time = 6; // 9 sec + 5 sec initial delay  // 7 sec sweet point for 4-sec bullet reload
    public float timer = 0;
    private int numTrials = 0;
    public bool timerStart = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Target").transform.position = GameObject.Find(pos[0]).transform.position;
    }

    IEnumerator change()
    {
        int j = i;
        while (j == i)
        {
            i = rnd.Next(0, pos.Length);
        }

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
