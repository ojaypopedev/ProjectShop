using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompareOnCollision : MonoBehaviour
{

    ObjectComparer comparer;

    private void Start()
    {
        comparer = GetComponent<ObjectComparer>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<ShopObjectReference>())
        {
            collision.transform.SetParent(transform);

            ShopObjectReference reference = collision.gameObject.GetComponent<ShopObjectReference>();

            comparer.toCompareToRequest = reference;

            if(!comparer.allDone)
            comparer.Compare();
        }
    }


}
