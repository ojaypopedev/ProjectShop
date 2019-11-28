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
    [Header("Ref")]
    [SerializeField] messageController mController;


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
            if (Input.GetKeyDown(KeyCode.Space)){
                mController.AddMsg(itemRequestList[Random.Range(0, itemRequestList.Count)]);
            }
        }
    }
}
