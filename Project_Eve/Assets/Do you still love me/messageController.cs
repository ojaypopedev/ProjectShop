using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Shop;

public class messageController : MonoBehaviour{
    public GameObject wife_msg_prefab;
    public GameObject you_msg_prefab;

    [SerializeField] GameObject msgContainer;

    [SerializeField] Transform spawnPos;
    [SerializeField] List<GameObject> messages;
    [SerializeField] GameObject[] targetpos;

    [SerializeField] GameObject offScreenTarget;
    GameObject offScreenMsg;
    [SerializeField] float speed;

    int c;
    void Update(){
        //if (Input.GetKeyDown(KeyCode.Space)){
        //    c++;
        //    int x = c % 2;
        //    Debug.Log(x);
        //    bool isWife = x != 0;
        //    AddMsg("DO YOU STILL LOVE ME?", c, isWife);
        //}
        if (messages.Count >= 5){
            if (offScreenMsg){
                Destroy(offScreenMsg);
            }
            offScreenMsg = messages[0];
            messages.RemoveAt(0);
        }
        for (int i = 0; i < messages.Count; i++){
            messages[i].transform.position = Vector3.Lerp(messages[i].transform.position, targetpos[i].transform.position, speed * Time.deltaTime);
        }
        if (offScreenMsg){
            offScreenMsg.transform.position = Vector3.Lerp(offScreenMsg.transform.position, offScreenTarget.transform.position, speed * Time.deltaTime);
        }
    }

    void AddMsg(string inputText, int c, bool isWifesText){
        GameObject temp;
        if (isWifesText){
             temp = Instantiate(wife_msg_prefab, msgContainer.transform);
        }
        else{
            temp = Instantiate(you_msg_prefab, msgContainer.transform);
        }
        //temp.transform.parent = msgContainer.transform;
        temp.transform.position = spawnPos.position;
        temp.GetComponentInChildren<Text>().text = inputText + " " + c.ToString(); ;
        messages.Add(temp);
    }
    //WIFE
    public void AddMsg(ShopObjectRequest reqs){
        
         GameObject temp = Instantiate(wife_msg_prefab, msgContainer.transform);

        //temp.transform.parent = msgContainer.transform;
        temp.transform.position = spawnPos.position;
        temp.GetComponentInChildren<Text>().text = reqs.RequestMessage;
        messages.Add(temp);
    }

    public void AddMsg(bool isWifesText, string inputText){
        GameObject temp;
        if (isWifesText){
            temp = Instantiate(wife_msg_prefab, msgContainer.transform);
        }
        else{
            temp = Instantiate(you_msg_prefab, msgContainer.transform);
        }
        //temp.transform.parent = msgContainer.transform;
        temp.transform.position = spawnPos.position;
        temp.GetComponentInChildren<Text>().text = inputText;
        messages.Add(temp);
    }
}
