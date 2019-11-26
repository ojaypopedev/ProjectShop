using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shop;

public class ObjectComparer : MonoBehaviour
{

    [SerializeField] ShopObject[] allRequestsInOrder = new ShopObject[1];
    [SerializeField]  ShopObject CurrentRequest;
    private int index = 0;
    public ShopObjectReference toCompareToRequest;

    [SerializeField] bool doCompare = false;

    public bool allDone;

    float percentageRequired = 70;

    private void Start()
    {
        CurrentRequest = allRequestsInOrder[0];
    }


    [ContextMenu("Compare")]
    public void TestCompare()
    {
          print(123);

        ShopObjectRequest requester = new ShopObjectRequest();
        requester.toCompare = CurrentRequest;

        float percentage = requester.percentageComparison(toCompareToRequest.shopTags);
        bool exact = requester.exactComparison(toCompareToRequest.shopTags);
        string objectName = toCompareToRequest.shopTags.Name;

        print(objectName + (exact ? (" is exactly matched") : ("is not an exact but is " + percentage.ToString() + "% match.")));

    }

    public void Compare()
    {
        ShopObjectRequest requester = new ShopObjectRequest();
        requester.toCompare = CurrentRequest;

        float percentage = requester.percentageComparison(toCompareToRequest.shopTags);

        if (percentage > percentageRequired)
        {
            print(toCompareToRequest.name + " was adequate.");

            index++;

            if(allRequestsInOrder.Length > index)
            {
                CurrentRequest = allRequestsInOrder[index];
            }
            else
            {
                CurrentRequest = null;
                print("All Objects Found");
                allDone = true;
            }
        }




            if (percentage > percentageRequired) print("Object Reqs Met"); else print("Object Reqs Not Met");
    }


}
