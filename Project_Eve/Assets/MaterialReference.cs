using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MaterialReference : MonoBehaviour
{


    Material[] mats;
    Material[] glowMats;

    Renderer rend;
          
   
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();

        mats = rend.materials;

        glowMats = new Material[mats.Length];

        for (int i = 0; i < mats.Length; i++)
        {
            glowMats[i] = new Material(mats[i]);

            glowMats[i].color += Color.white / 2;
        }

    }

    public void SetGlow(bool val)
    {
        if (val)
        {
            rend.materials = glowMats;
        }
        else
        {
            rend.materials = mats;
        }
       

    }
    
}
