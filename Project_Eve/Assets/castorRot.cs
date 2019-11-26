using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class castorRot : MonoBehaviour
{
    public GameObject masterRot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.rotation = masterRot.transform.rotation;

        //transform.localPosition = new Vector3(transform.localPosition.x, masterRot.transform.localPosition.y, transform.localPosition.z);

    }
}
