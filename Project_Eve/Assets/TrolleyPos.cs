﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrolleyPos : MonoBehaviour
{

    public GameObject pos;
    public Movement moveRef;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float power = moveRef.rb.velocity.magnitude/5;


        float shake = 0;

        shake = Random.Range(-power, power);

        Vector3 shakeAdd = Vector3.Lerp(Vector3.zero, new Vector3(0, 0 + shake, 0), 0.1f * Time.deltaTime);

        transform.localPosition = pos.transform.position + shakeAdd;
        

    }
}
