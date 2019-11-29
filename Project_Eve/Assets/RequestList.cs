using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shop;

public class RequestList : MonoBehaviour{
    public enum ModeSelect {teach,test,challenge}
    [SerializeField] ModeSelect modeSelect;

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
    public List<ShopObjectRequest> inLevel;
    public int index;
    public ShopObjectRequest current;

    public int RequestCount;
    [Header("Ref")]
    [SerializeField]public  messageController mController;





    private void Update(){

      
        if (modeSelect == ModeSelect.teach){
            if (Input.GetKeyDown(KeyCode.Space)){
                mController.AddMsg(tutorialList[tutCounter].isWife, tutorialList[tutCounter].msg);
                tutCounter++;
            }
        }
        if (modeSelect == ModeSelect.test){

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
