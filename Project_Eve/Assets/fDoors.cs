using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fDoors : MonoBehaviour
{

    public GameObject lDoor;
    public GameObject rDoor;

    Vector3 lDoorStart;
    Vector3 rDoorStart;

    public bool inDoor;

    // Start is called before the first frame update
    void Start()
    {

        lDoorStart = lDoor.transform.localPosition;
        rDoorStart = rDoor.transform.localPosition;

    }

    // Update is called once per frame
    void Update()
    {
        
        if(inDoor == true)
        {
            if(lDoor.transform.localPosition.x < 6.25f)
            {

                lDoor.transform.position += new Vector3(0.1f,0,0);

            }

            if(rDoor.transform.localPosition.x > -6.25f)
            {
                rDoor.transform.position -= new Vector3(0.1f, 0, 0);

            }

        }
        else
        {

            if (lDoor.transform.localPosition.x > 0)
            {

                lDoor.transform.position -= new Vector3(0.1f, 0, 0);

            }

            if (rDoor.transform.localPosition.x < 0)
            {
                rDoor.transform.position += new Vector3(0.1f, 0, 0);

            }


        }


    }

    void OnTriggerEnter(Collider col)
    {


        if(col.gameObject.tag == "Trolley")
        {

            inDoor = true;

        }

    }

    void OnTriggerExit(Collider col)
    {

        if (col.gameObject.tag == "Trolley")
        {

            inDoor = false;

        }

    }
}
