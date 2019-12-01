using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraScript : MonoBehaviour
{

    public Transform lookPoint;
    public float lookSpeed = 1000f;


    public Movement moveRef;
    Vector2 rotatedAmount;

    public Transform leftHand;
    public Transform rightHand;
    public Transform handCont;
    public Transform Trolley;
    public Transform camPos;

    public float MaxXRot = 25;

    Movement.HandState state;

    float offset= 1;


    bool inital = false;

    private void Start()
    {
        state = moveRef.state;
    }

    // Update is called once per frame
    void Update()
    {
        stateHandler();
        CameraLook();
        CameraTilt();
    }

    void stateHandler()
    {
        if(state != moveRef.state)
        {
            inital = true;
            state = moveRef.state;

            if(state == Movement.HandState.Trolley)
            {
                MaxXRot = 50;
            }
            if(state == Movement.HandState.Nothing)
            {
                MaxXRot = 80;
            }
        }
    }

    void CameraLook()
    {
        transform.position = new Vector3(camPos.position.x, 5f, camPos.position.z);

        if(state == Movement.HandState.Trolley)
        {
          
            lookSpeed = 2.3f;
            

        }


        if (state == Movement.HandState.Trolley || state == Movement.HandState.Nothing)
        {

            float xAxis = Mathf.Clamp(Input.GetAxis("Mouse X") * lookSpeed, -lookSpeed, lookSpeed);

            //print(xAxis);
           
            rotatedAmount.x += Input.GetAxis("Mouse X");
            lookPoint.RotateAround(transform.position, transform.right, -Input.GetAxis("Mouse Y") * lookSpeed);
            rotatedAmount.y += Input.GetAxis("Mouse Y");
            Vector3 eulers = lookPoint.eulerAngles;



            //90 is looking Straight

            float lookAngle = Vector3.Angle(transform.right, Trolley.right) - 90;

            

           



            if (lookAngle > MaxXRot || lookAngle < -MaxXRot)
            {
                if (lookAngle > MaxXRot)
                {
                    if (Input.GetAxis("Mouse X") < 0)
                    {
                        lookPoint.RotateAround(transform.position, Vector3.up, xAxis * lookSpeed);
                    }
                }

                if (lookAngle < MaxXRot)
                {
                    if (Input.GetAxis("Mouse X") > 0)
                    {
                        lookPoint.RotateAround(transform.position, Vector3.up, xAxis * lookSpeed);
                    }
                    
                }
            }
            else
            {
                lookPoint.RotateAround(transform.position, Vector3.up, xAxis * lookSpeed);

            }

            if (Mathf.Abs(rotatedAmount.y) > 30)
            {
                lookPoint.RotateAround(transform.position, transform.right, Input.GetAxis("Mouse Y") * lookSpeed);
               rotatedAmount.y -= Input.GetAxis("Mouse Y");
            }

            if (moveRef.rb.velocity.magnitude > 1)
            {
                GetComponent<Camera>().fieldOfView = 77 + moveRef.rb.velocity.magnitude/2;
            }

            if(GetComponent<Camera>().fieldOfView <= 77)
            {

                GetComponent<Camera>().fieldOfView = 77;

            }

        }



        transform.LookAt(lookPoint);
    }

    void CameraTilt()
    {


        Vector3 diff = transform.forward - Trolley.forward;

        float temp = 0;

        if (state == Movement.HandState.Trolley)
        { 

            //transform.Rotate(0, 0, diff.x * 5);

            temp = diff.x;

        }

        


    }
}
