using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
        {
            transform.Translate(transform.right * Time.deltaTime * 10);
        }
        
      
    }
}
