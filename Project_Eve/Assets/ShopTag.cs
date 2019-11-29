using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shop;

[CreateAssetMenu()]
public class ShopObject : ScriptableObject
{
    public string Name;    //Not used in code just for Identification.  
    public ShopTag[] Tags; //for comparison to shop requests.

}

