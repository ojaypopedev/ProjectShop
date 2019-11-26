using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headMove : MonoBehaviour
{

    public Transform yLook;

    public Movement movementRef;

    public Transform leftHand;
    public Transform rightHand;

    public Transform trolley;

    public Camera cam;
    Vector3 startRot;

    // Start is called before the first frame update
    void Start()
    {
        //yLook = GetComponentInChildren<Transform>();

         startRot = cam.transform.rotation.eulerAngles;
    }



    private void Update()
    {
        if(movementRef.handsOnTrolley == Movement.HandsOnTrolley.Both)
        {
            cam.transform.LookAt(trolley.position + Vector3.up*2);
        }

    }

    // Update is called once per frame
    //void Update()
    //{
    //    float x = 0;

    //    if (movementRef.handsOnTrolley == Movement.HandsOnTrolley.Both)
    //    {

    //        x = Mathf.Clamp(Input.GetAxis("Mouse X"), -2f, 2f);

    //        cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, Quaternion.Euler(startRot), Time.deltaTime*2);

    //        if (transform.localRotation.y * Mathf.Rad2Deg < -15)
    //        {

    //            transform.Rotate(0, 0.05f, 0);

    //        }
    //        else if (transform.localRotation.y * Mathf.Rad2Deg > 18)
    //        {

    //            transform.Rotate(0, -0.05f, 0);

    //        }
    //        else
    //        {

    //            transform.Rotate(0, x, 0);

    //        }
    //        YRotation();

    //    }
    //    else if (movementRef.handsOnTrolley == Movement.HandsOnTrolley.None)
    //    {
    //        x = Input.GetAxis("Mouse X") * 3f;
    //        transform.Rotate(0, x, 0);
    //        YRotation();

    //        cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, Quaternion.Euler(startRot), Time.deltaTime * 2);
    //    }
    //    else
    //    {
    //        if(movementRef.handsOnTrolley == Movement.HandsOnTrolley.Right)
    //        {


    //            cam.transform.LookAt(leftHand);


    //            print(213);
    //            leftHand.RotateAround(transform.position, Vector3.up, Input.GetAxis("Mouse X"));

    //        }

    //        if (movementRef.handsOnTrolley == Movement.HandsOnTrolley.Left)
    //        {


    //            cam.transform.LookAt(rightHand);


    //            print(213);
    //            rightHand.RotateAround(transform.position, Vector3.up, Input.GetAxis("Mouse X"));

    //        }






    //        // transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z));
    //        //  yLook.rotation = Quaternion.Euler(new Vector3(yLook.eulerAngles.x, yLook.eulerAngles.y, 0));


    //    }






    //}


    void YRotation()
    {

        float x = 0;


        x = Input.GetAxis("Mouse Y");


        yLook.Rotate(0, 0, x);

    }


}





//if(Mathf.Abs(transform.rotation.eulerAngles.y)> 0)
//{
//    transform.Rotate(0, -transform.rotation.eulerAngles.y/10, 0);
//}








