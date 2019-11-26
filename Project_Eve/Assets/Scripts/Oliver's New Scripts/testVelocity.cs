using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testVelocity : MonoBehaviour
{
    public float friend;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    void FixedUpdate()
    {
       
        GetComponent<Rigidbody>().velocity = Vector3.forward * friend;
    }
}
