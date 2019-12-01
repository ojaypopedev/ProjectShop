using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompareOnCollision : MonoBehaviour
{

    ObjectComparer comparer;
    GameObject gMananger;

    private void Start()
    {
        comparer = GetComponent<ObjectComparer>();
        gMananger = GameObject.FindGameObjectWithTag("GameManager");
    }


    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
      
            if (gMananger.GetComponent<RequestList>().modeSelect != RequestList.ModeSelect.teach)
            {

                if (collision.gameObject.GetComponent<ShopObjectReference>() && collision.transform.parent == gameObject.transform && collision.gameObject.tag == "ShopItem")
                {
                    Destroy(collision.gameObject.GetComponent<Rigidbody>());


                if (gMananger.GetComponent<RequestList>().win == false)
                {
                    ShopObjectReference reference = collision.gameObject.GetComponent<ShopObjectReference>();

                    comparer.toCompareToRequest = reference;
                    comparer.toCompGO = collision.gameObject;

                    if (!comparer.allDone)
                        comparer.Compare();
                    collision.gameObject.layer = 11;
                    collision.gameObject.tag = "Trolley";

                }
                    
                    //Destroy(collision.gameObject.GetComponent<Collider>());
                    collision.gameObject.layer = 11;
                    collision.gameObject.tag = "Trolley";

                //collision.transform.SetParent(transform.parent);
            }
            }

            if (gMananger.GetComponent<RequestList>().modeSelect == RequestList.ModeSelect.teach)
            {

                if (collision.gameObject.GetComponent<ShopObjectReference>() && collision.transform.parent == gameObject.transform && collision.gameObject.tag == "ShopItem")
                {

                    Destroy(collision.gameObject.GetComponent<Rigidbody>());
                    gMananger.GetComponent<RequestList>().TeachItemPick = true;

                    collision.gameObject.layer = 11;
                    collision.gameObject.tag = "Trolley";


                }


            }

        
    }
}
