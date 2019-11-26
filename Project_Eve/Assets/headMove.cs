using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headMove : MonoBehaviour
{

    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //transform.rotation = Quaternion.Lerp(transform.rotation, target.transform.rotation, 0.5f);

        transform.LookAt(target.transform);

    }
}
