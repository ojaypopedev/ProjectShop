﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InTrolleyCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerExit(Collider col)
    {


        if(col.gameObject.tag == "Trolley")
        {

            transform.SetParent(null);

        }

    }
}
