using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shop;

public class ObjectComparer : MonoBehaviour
{

    [SerializeField] ShopObject[] allRequestsInOrder = new ShopObject[1];
    [SerializeField]  ShopObject CurrentRequest;
    private int index = 0;
    [SerializeField] ShopObjectReference toCompareToRequest;

    [SerializeField] bool doCompare = false;


    private void Start()
    {
        CurrentRequest = allRequestsInOrder[0];
    }
    private void Update()
    {

        if (doCompare && CurrentRequest)
        {
            doCompare = false;
            Compare();
            ShopObjectRequest requester = new ShopObjectRequest();
            requester.toCompare = CurrentRequest;

            if (requester.exactComparison(CurrentRequest)) index++;

            if(allRequestsInOrder.Length > index)
            {
                index++;
            }

            CurrentRequest = allRequestsInOrder[index];

        }
        else
        {
            if (!CurrentRequest) print("There are no objects to request");
        }
    }


    [ContextMenu("Compare")]
    public void Compare()
    {
          print(123);

        ShopObjectRequest requester = new ShopObjectRequest();
        requester.toCompare = CurrentRequest;

        float percentage = requester.percentageComparison(toCompareToRequest.shopTags);
        bool exact = requester.exactComparison(toCompareToRequest.shopTags);
        string objectName = toCompareToRequest.shopTags.Name;

        print(objectName + (exact ? (" is exactly matched") : ("is not an exact but is " + percentage.ToString() + "% match.")));

    }

}
