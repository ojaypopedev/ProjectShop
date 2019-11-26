using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class y_Look : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void YRotation()
    {

        float x = 0;


        x = Input.GetAxis("Mouse Y");


        transform.Rotate(0, 0, x);

    }
}
