using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrolleyPos : MonoBehaviour
{

    public GameObject pos;
    public GameObject lookPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = pos.transform.position;

        //transform.LookAt(lookPos.transform);

        

    }
}
