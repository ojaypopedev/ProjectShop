using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shop;

[RequireComponent(typeof(MaterialReference))]


[ExecuteInEditMode]
public class ShopObjectReference : MonoBehaviour
{


    //Editor Bits
    public ShopTag[] _toAdd;
    public int _editorTagLength;



    
    public ShopObject shopObject;


    
}
