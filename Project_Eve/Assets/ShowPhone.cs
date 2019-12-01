using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPhone : MonoBehaviour
{


    [SerializeField] Vector3 onPos;
    [SerializeField] Vector3 offPos;

    public bool onScreen = false;

    void Update()
    {

        float mouseScroll = Input.mouseScrollDelta.y;

       
            if (mouseScroll > 1)
            {
                onScreen = true;
            }
            if (mouseScroll < -1)
            {
                onScreen = false;
            }
        
      

        transform.localPosition = Vector3.Lerp (transform.localPosition, onScreen ? (onPos) : (offPos), 4 * Time.deltaTime);
        
    }
}
