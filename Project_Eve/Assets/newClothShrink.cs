using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newClothShrink : MonoBehaviour
{

    Vector3 StartScale;

    bool changed;

    // Start is called before the first frame update
    void Start()
    {
        StartScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent)
        {
            if (transform.parent.name == "Left Hand" || transform.parent.name == "Right Hand")
            {

               if(changed == false)
                {
                    transform.localScale = StartScale * 1.4f;
                    changed = true;
                }

            }
        }
    }
}
