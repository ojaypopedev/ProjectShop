using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraScript : MonoBehaviour
{

    public Transform lookPoint;
    public float lookSpeed = 2f;


    public Movement moveRef;
    Vector2 rotatedAmount;

    public Transform leftHand;
    public Transform rightHand;
    public Transform handCont;

    public float MaxXRot = 25;

    Movement.HandState state;


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
    }

    void stateHandler()
    {
        if(state != moveRef.state)
        {
            inital = true;
            state = moveRef.state;

            if(state == Movement.HandState.Trolley)
            {
                MaxXRot = 25;
            }
            if(state == Movement.HandState.Nothing)
            {
                MaxXRot = 50;
            }
        }
    }

    void CameraLook()
    {

        if (state == Movement.HandState.Trolley || state == Movement.HandState.Nothing)
        {
         

            lookPoint.RotateAround(transform.position, Vector3.up, Input.GetAxis("Mouse X") * lookSpeed);
            rotatedAmount.x += Input.GetAxis("Mouse X");
            lookPoint.RotateAround(transform.position, transform.right, -Input.GetAxis("Mouse Y") * lookSpeed);
            rotatedAmount.y += Input.GetAxis("Mouse Y");
            Vector3 eulers = lookPoint.eulerAngles;


            if (Mathf.Abs(rotatedAmount.x) > MaxXRot)
            {
                lookPoint.RotateAround(transform.position, Vector3.up, -Input.GetAxis("Mouse X") * lookSpeed);
                rotatedAmount.x -= Input.GetAxis("Mouse X");
            }
            if (Mathf.Abs(rotatedAmount.y) > 30)
            {
                lookPoint.RotateAround(transform.position, transform.right, Input.GetAxis("Mouse Y") * lookSpeed);
                rotatedAmount.y -= Input.GetAxis("Mouse Y");
            }

        }



        transform.LookAt(lookPoint);
    }
}
