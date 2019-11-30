using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeDoorRight : MonoBehaviour
{

    public bool move;
    Vector3 startPos;
    Vector3 endPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        endPos = startPos + new Vector3(0, 0, -5.45f);
    }

    // Update is called once per frame
    void Update()
    {
        if (move == true)
        {

            if (transform.localPosition.z <= 6)
            {

                transform.localPosition += new Vector3(0, 0, 0.2f);

            }

        }
        else
        {

            if (transform.localPosition.z > 0)
            {

                transform.localPosition -= new Vector3(0, 0, 0.2f);
            }

        }


    }
}
