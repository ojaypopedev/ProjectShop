using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headMove : MonoBehaviour
{

   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float x = 0;

        if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
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


        }
        else
        {
            x = Input.GetAxis("Mouse X") * 3f;
            transform.Rotate(0, x, 0);


        }

     
        

       

        //if(Mathf.Abs(transform.rotation.eulerAngles.y)> 0)
        //{
        //    transform.Rotate(0, -transform.rotation.eulerAngles.y/10, 0);
        //}
        


        

    }
}
