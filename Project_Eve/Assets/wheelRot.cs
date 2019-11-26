using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelRot : MonoBehaviour
{

    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float angle = Vector3.Angle(transform.position, target.transform.position);

       // transform.rotation = Quaternion.Euler(0, angle, 0);


    }
}
