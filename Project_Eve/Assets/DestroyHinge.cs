﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHinge : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent)
        {
            if (transform.parent.name == "Left Hand" || transform.parent.name == "Right Hand")
            {

                Destroy(GetComponent<HingeJoint>());

            }
        }
    }
}
