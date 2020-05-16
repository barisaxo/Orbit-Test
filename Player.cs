using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GM gm;
    public float rotY, rotX, mouseSensitivityX, mouseSensitivityY, speed;
    Rigidbody rb;

    void Start()
    {
        mouseSensitivityX = 5f;
        mouseSensitivityY = 5f;
        rb = GetComponent<Rigidbody>();
        speed = 500f;
       // ParticleSystem ps = gameObject.AddComponent<ParticleSystem>();
        

    }

    void Update()
    { 
        rotX += Input.GetAxis("Mouse X") * mouseSensitivityX; //transform.localEulerAngles.y +
        rotY += Input.GetAxis("Mouse Y") * mouseSensitivityY;
       // rotY = Mathf.Clamp(rotY, -89.5f, 89.5f);
        transform.localEulerAngles = new Vector3(-rotY, -rotX, 0.0f);

        if(Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-transform.right * rb.mass * Time.deltaTime * speed, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-transform.forward * rb.mass * Time.deltaTime * speed, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(transform.right * rb.mass * Time.deltaTime * speed, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * rb.mass * Time.deltaTime * speed, ForceMode.Impulse);
        }

    }
}
