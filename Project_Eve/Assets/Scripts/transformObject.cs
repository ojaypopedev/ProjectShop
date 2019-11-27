using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transformObject : MonoBehaviour
{

    public Mesh newMesh;

    Mesh startMesh;

    bool picked;

    // Start is called before the first frame update
    void Start()
    {
        startMesh = GetComponent<MeshFilter>().mesh;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent)
        {
            if (transform.parent.name == "Left Hand" || transform.parent.name == "Right Hand")
            {
               
                GetComponent<MeshFilter>().mesh = newMesh;

                GetComponent<Animator>().SetBool("picked", true);
                
            }
        }


    }
}
