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
        print(collision.gameObject.name);

        if (collision.gameObject.GetComponent<ShopObjectReference>())
        {
            Destroy(collision.gameObject.GetComponent<Rigidbody>());
            Destroy(collision.gameObject.GetComponent<Collider>());

            collision.transform.SetParent(transform);

            ShopObjectReference reference = collision.gameObject.GetComponent<ShopObjectReference>();

            comparer.toCompareToRequest = reference;
            comparer.toCompGO = collision.gameObject;

            if(!comparer.allDone)
            comparer.Compare();
        }
    }


}
