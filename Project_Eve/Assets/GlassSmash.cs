using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassSmash : MonoBehaviour
{


    public GameObject player;
    public GameObject smashedGlass;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == player)
        {
            smashedGlass.transform.position = transform.position;
           
            Instantiate(smashedGlass);
            Destroy(gameObject);
        }
    }


}


