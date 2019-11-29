using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameLoop : MonoBehaviour
{

    public RequestList.ModeSelect gameState = RequestList.ModeSelect.teach;
    float totalTime = 180;
    float timeLeft;


    [SerializeField] Text timer;
    float timerScaleOffset;
    Vector3 timerScaleOriginal;
    [SerializeField] Text itemsDone;

    RequestList list;

    private void Start()
    {
        timeLeft = totalTime;

        timerScaleOriginal = timer.GetComponent<RectTransform>().localScale;


        list = GetComponent<RequestList>();
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        timer.text= (timeInMinSec(timeLeft));
        itemsDone.text = list.index + "/5";
        
    }


    public void BumpScore()
    {
        itemsDone.GetComponent<Animator>().SetTrigger("Bump");
    }

    string timeInMinSec(float time)
    {
        int Mins = 0;
        while (time > 0)
        {
            Mins++;
            time -= 60;

        }

        Mins -= 1;
        time += 60;
        print(timerScaleOffset);
        
        time = Mathf.Floor(time);

        return Mins.ToString()+":"+time.ToString();

        
    }




}
