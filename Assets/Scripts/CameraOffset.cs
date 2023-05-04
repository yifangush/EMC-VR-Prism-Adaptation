using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOffset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = modifyRot(GameObject.Find("VRCamera").transform.rotation, 300);
        // transform.position = GameObject.Find("VRCamera").transform.position;

    }


    Quaternion modifyRot(Quaternion rotation, int disparity)
    {
        Vector3 rV = rotation.ToEulerAngles();
        rV.y += disparity; // Angular Disparity value
        return Quaternion.Euler(10 * rV.x, 10 * rV.y, 10 * rV.z); 
    }
}
