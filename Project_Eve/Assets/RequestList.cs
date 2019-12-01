using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shop;

public class RequestList : MonoBehaviour{
    public enum ModeSelect {teach,test,challenge}
    [SerializeField] public ModeSelect modeSelect;

    public GameObject phone;
    public GameObject msgs;
    public GameObject Velocity;

    [System.Serializable]
    public struct TutMessage{
        public string msg;
        public bool isWife;
    }



    [Header("Tutorial")]

    [SerializeField] List<TutMessage> tutorialList;
    int tutCounter;
    [Header("CoreLoop")]
    public List<ShopObjectRequest> itemRequestList;
    public List<ShopObjectRequest> testRequestList;
    public List<ShopObjectRequest> inLevel;
    public int index;
    public ShopObjectRequest current;

    public int RequestCount;
    [Header("Ref")]
    [SerializeField]public  messageController mController;


    bool phoneTeach;
    bool addedMoveMsg;
    bool moved;
    public bool TeachItemPick;
    bool teachPhone;
    bool teachComplete;
    bool done;
    float timer = 0;
    int addTest = 0;
    bool testComplete;


    private void Update(){

      
        if (modeSelect == ModeSelect.teach){
           
            if(phoneTeach == false)
            {

                phone.GetComponent<ShowPhone>().onScreen = true;
                

            }

            if(Velocity.GetComponent<Rigidbody>().velocity.magnitude == 0)
            {
                if(addedMoveMsg == false)
                {

                    msgs.GetComponent<messageController>().AddMsg(true, "look at the trolley, hold Left and Right mouse buttons to move");
                    addedMoveMsg = true;

                }


            }
            if(Velocity.GetComponent<Rigidbody>().velocity.magnitude > 1)
            {
                if(moved == false)
                {

                    msgs.GetComponent<messageController>().AddMsg(false, "Yes i am a Pro!");
                    msgs.GetComponent<messageController>().AddMsg(true, "Great!");
                    msgs.GetComponent<messageController>().AddMsg(true, "Now go to any item and left click it to put it in the trolley");
                    moved = true;

                }


            }

            if(TeachItemPick == true)
            {

                if (teachPhone == false)
                {
                    phoneTeach = true;
                    msgs.GetComponent<messageController>().AddMsg(false, "I've so got this!");
                    msgs.GetComponent<messageController>().AddMsg(true, "Perfect!");
                    msgs.GetComponent<messageController>().AddMsg(true, "now use the scroll wheel to hide and show the phone");
                    teachPhone = true;


                }



            }

            if (phone.GetComponent<ShowPhone>().onScreen == false)
            {

                teachComplete = true;

            }

            if(phone.GetComponent<ShowPhone>().onScreen == true && teachComplete == true)
            {
                if (done == false)
                {
                    msgs.GetComponent<messageController>().AddMsg(false, "Got it");
                    msgs.GetComponent<messageController>().AddMsg(true, "Okay thats it, now lets do some shopping!");
                    msgs.GetComponent<messageController>().AddMsg(true, "Also... try not to make a mess of it");
                    done = true;
                }

                

                timer += 1 * Time.deltaTime;

                print(timer);

                if(timer > 3)
                {

                    modeSelect = RequestList.ModeSelect.test;
                    GetComponent<GameLoop>().gameState = RequestList.ModeSelect.test;

                }
            }

            




        }
        if (modeSelect == ModeSelect.test){



            inLevel = testRequestList;
                

            if (index < 4)
            {
                if (current != inLevel[index])
                {
                    GetComponent<GameLoop>().BumpScore();
                    current = inLevel[index];
                    mController.AddMsg(true, current.RequestMessage);

                }


            }
            else
            {
                current = null;
                if (testComplete == false)
                {
                    msgs.GetComponent<messageController>().AddMsg(true, "head to the exit when you're ready!");
                    testComplete = true;
                }
                print("Win");
            }

        }
        if (modeSelect == ModeSelect.challenge){
            
            while(inLevel.Count < 5)
            {
                int toUse = Random.Range(0, itemRequestList.Count);

                inLevel.Add(itemRequestList[toUse]);
                itemRequestList.RemoveAt(toUse);

            }
           
            if(index < 5)
            {
                if(current != inLevel[index])
                {
                    GetComponent<GameLoop>().BumpScore();
                    current = inLevel[index];
                    mController.AddMsg(true, current.RequestMessage);

                }

               
            }
            else
            {
                current = null;
                print("Win");
            }



           // mController.AddMsg(itemRequestList[Random.Range(0, itemRequestList.Count)]);
            
        }
    }
}
