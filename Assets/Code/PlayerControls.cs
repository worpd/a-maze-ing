using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed = 10.0f;
    public float strafeSpeed = 10.0f;
    public float mouseSensitivity = 2.0f;

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float strafe = Input.GetAxis("Horizontal") * strafeSpeed * Time.deltaTime;
        
        transform.Translate(strafe, 0, translation);

        float h = Input.GetAxis("Mouse X") * mouseSensitivity;
        
        transform.Rotate(0, h, 0);
    }
}
