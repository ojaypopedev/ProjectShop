using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody rb;

    public float speed;

    public float maxSpeed;

    public GameObject trolley;
    public GameObject pCamera;

    public GameObject leftH;
    public GameObject rightH;



    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();


        Cursor.lockState = CursorLockMode.Locked;

        speed = 0;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // rb.AddForce(trolley.transform.forward * speed);


       


        if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
        {
            rightH.SetActive(false);
            leftH.SetActive(false);
            rb.velocity = pCamera.transform.forward * speed;

            if (speed < maxSpeed)
            {

                speed += 0.5f;
            }
            else
            {

                speed = maxSpeed;
            }

        } else if (Input.GetMouseButton(0) == true && Input.GetMouseButton(1) == false){

            rb.velocity = trolley.transform.forward * speed;
            if (speed < maxSpeed)
            {

                speed += 0.5f;
            }
            else
            {

                speed = maxSpeed;
            }

            rightH.SetActive(true);


        }
        else if (Input.GetMouseButton(1) == true && Input.GetMouseButton(0) == false)
        {
            rb.velocity = trolley.transform.forward * speed;
            if (speed < maxSpeed)
            {

                speed += 0.5f;
            }
            else
            {

                speed = maxSpeed;
            }

            leftH.SetActive(true);

        }


        else
        {

            rb.velocity = trolley.transform.forward * speed;
            if (speed > 0) {
                speed -= maxSpeed/0.5f * Time.deltaTime;

            }

            if(speed < 0)
            {
                speed = 0;
            }

            rightH.SetActive(false);
            leftH.SetActive(false);
        }

    }
}
