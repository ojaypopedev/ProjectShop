using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trolleyRot : MonoBehaviour
{

    public GameObject xRot;
    public GameObject moveVel;

    Transform temp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


       // if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
        
            if (moveVel.GetComponent<Rigidbody>().velocity.magnitude > 0.5f)
            {
                Quaternion temp = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(moveVel.GetComponent<Rigidbody>().velocity), 2f*Time.deltaTime);

                 transform.rotation = temp;

             
            }
           

            





    }
}
