using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float playerSpeed = 10.0f;
    public float sensitivity = 2.0f;
    public Camera playerCamera;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }


    void Update()
    {
        float playerHorizontalMovement = Input.GetAxis("Horizontal");
        float playerVerticalMovement = Input.GetAxis("Vertical");

        Vector3 forward = new Vector3(playerCamera.transform.forward.x, 0, playerCamera.transform.forward.z);
        Vector3 right = new Vector3(forward.z, 0, -forward.x);

        // Debug.Log(playerCamera.transform.forward);
        controller.Move(forward.normalized * Time.deltaTime * playerSpeed * playerVerticalMovement);
        controller.Move(right.normalized * Time.deltaTime * playerSpeed * playerHorizontalMovement);

        yaw += sensitivity * Input.GetAxis("Mouse X");
        pitch -= sensitivity * Input.GetAxis("Mouse Y");

        playerCamera.transform.localEulerAngles =  new Vector3(pitch, yaw, 0.0f);
        gameObject.transform.localEulerAngles = new Vector3(0.0f, yaw, 0.0f);
    }
}
