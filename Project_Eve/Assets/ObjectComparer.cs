using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shop;

public class ObjectComparer : MonoBehaviour
{

    
    [SerializeField] ShopObjectRequest CurrentRequest;
    private int index = 0;
    public ShopObjectReference toCompareToRequest;
    public GameObject toCompGO;

    [SerializeField] bool doCompare = false;

    public bool allDone;

    float percentageRequired = 70;


    public RequestList list;

    int incorrect = 0;

    string[] incorrectMessages =
    {
        "No.", "Not Quite.", "Really...", "Not that.", "Wrong gift for the wrong person", "Hmmm... I dont think so", "Nope.", "Not That!", "You think you are funny dont you!",
        "No chance", "No", "No! You dont have much time", "I dont think they would like that", "Maybe for you, but they would never want that", "Just get what I tell you to get",
        "No, and quick, you dont have much time!"
    };

    private void Start()
    {
        list = FindObjectOfType<RequestList>();
    }

    #region OldCode
    //[ContextMenu("Compare")]
    //public void TestCompare()
    //{
    //      print(123);

    //    ShopObjectRequest requester = new ShopObjectRequest();
    //    requester.toCompare = CurrentRequest;

    //    float percentage = requester.percentageComparison(toCompareToRequest.shopTags);
    //    bool exact = requester.exactComparison(toCompareToRequest.shopTags);
    //    string objectName = toCompareToRequest.shopTags.Name;

    //    print(objectName + (exact ? (" is exactly matched") : ("is not an exact but is " + percentage.ToString() + "% match.")));

    //}
    #endregion

    public void Compare()
    {

        CurrentRequest = list.current;

        float percentage = CurrentRequest.percentageComparison(toCompareToRequest.shopObject);

        list.mController.AddMsg(false, "I got a " + toCompGO.name);


        if (percentage > percentageRequired)
        {
            print(toCompareToRequest.name + " was adequate.");

            list.index++;

            list.mController.AddMsg(true, CurrentRequest.ReplyMessage);

        }
        else
        {
            list.mController.AddMsg(true, incorrectMessages[Mathf.RoundToInt(Random.Range(0,incorrectMessages.Length-1))]); // add variations to this
            incorrect++;
            if(incorrect == 2)
            {
                incorrect = 0;
                list.mController.AddMsg(true, CurrentRequest.RequestMessage);
            }
        }

        if (percentage > percentageRequired) print("Object Reqs Met"); else print("Object Reqs Not Met");
    }


}
