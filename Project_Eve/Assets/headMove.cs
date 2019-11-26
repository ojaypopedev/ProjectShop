using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headMove : MonoBehaviour
{

    public Transform yLook;

    public Movement movementRef;

    // Start is called before the first frame update
    void Start()
    {
        //yLook = GetComponentInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = 0;

        if (movementRef.handsOnTrolley == Movement.HandsOnTrolley.Both)
        {

            x = Mathf.Clamp(Input.GetAxis("Mouse X"), -2f, 2f);


            if (transform.localRotation.y * Mathf.Rad2Deg < -15)
            {

                transform.Rotate(0, 0.05f, 0);

            }
            else if (transform.localRotation.y * Mathf.Rad2Deg > 18)
            {

                transform.Rotate(0, -0.05f, 0);

            }
            else
            {

                transform.Rotate(0, x, 0);

            }
            YRotation();

        }
        else if (movementRef.handsOnTrolley == Movement.HandsOnTrolley.None)
        {
            x = Input.GetAxis("Mouse X") * 3f;
            transform.Rotate(0, x, 0);
            YRotation();
        }
        else
        {
           // transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z));
          //  yLook.rotation = Quaternion.Euler(new Vector3(yLook.eulerAngles.x, yLook.eulerAngles.y, 0));
         

        }






    }


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








