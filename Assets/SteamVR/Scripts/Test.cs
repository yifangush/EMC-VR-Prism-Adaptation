using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion vec = GameObject.Find("VRCamera").transform.rotation;
        Vector3 v = vec.ToEulerAngles();

        // Debug.Log(v.y);
    }
}
