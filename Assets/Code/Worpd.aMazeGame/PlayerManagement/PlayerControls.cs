using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed = 30.0f;
    public float strafeSpeed = 30.0f;
    public float mouseSensitivity = 200.0f;

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float strafe = Input.GetAxis("Horizontal") * strafeSpeed * Time.deltaTime;
        float zoom = Input.GetAxis("Mouse ScrollWheel") * mouseSensitivity * Time.deltaTime;

        transform.Translate(strafe, translation, zoom);

//        float h = Input.GetAxis("Mouse X") * mouseSensitivity;
//
//        transform.Rotate(0, h, 0);
    }
}
