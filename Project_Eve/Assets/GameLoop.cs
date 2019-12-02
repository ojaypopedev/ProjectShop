﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameLoop : MonoBehaviour
{

    public RequestList.ModeSelect gameState = RequestList.ModeSelect.test;
    float totalTime = 200;
    float timeLeft;


    [SerializeField] Text timer;
    float timerScaleOffset;
    Vector3 timerScaleOriginal;
    [SerializeField] Text itemsDone;
    [SerializeField] Text itemsCol;

    public GameObject bingBong;

    bool[] warnings = { false, false, false, false, false };

    RequestList list;

    private void Start()
    {
        timeLeft = totalTime;

        timerScaleOriginal = timer.GetComponent<RectTransform>().localScale;


        list = GetComponent<RequestList>();
    }

    private void Update()
    {

        if (timeLeft < 180 && !warnings[0])
        {
            warnings[0] = true;
            GetComponent<SoundManager>().playSound(1);
        }
        if (timeLeft < 120 && !warnings[1])
        {
            warnings[1] = true;
            GetComponent<SoundManager>().playSound(2);
        }
        if (timeLeft < 60 && !warnings[2])
        {
            warnings[2] = true;
            GetComponent<SoundManager>().playSound(3);
        }
        if (timeLeft < 0 && !warnings[3])
        {
            warnings[3] = true;
            GetComponent<SoundManager>().playSound(4);
        }
        if(FindObjectOfType<Movement>().ItemsInTrolley.Contains(bingBong) && !warnings[4])
        {
            warnings[4] = true;
            GetComponent<SoundManager>().playSound(5);
        }

        if (gameState == RequestList.ModeSelect.test)
        {
            Color temp = itemsDone.color;
            Color temp2 = itemsCol.color;

            temp.a = 1;
            temp2.a = 1;

            itemsDone.color = temp;
            itemsCol.color = temp2;
            

            itemsDone.text = list.index + "/4";

        }
        else if (gameState == RequestList.ModeSelect.challenge)
        {


            timeLeft -= Time.deltaTime;
            timer.text = (timeInMinSec(timeLeft));
            itemsDone.text = list.index + "/5";
        }
        else
        {

            Color temp = itemsDone.color;
            Color temp2 = itemsCol.color;
            temp.a = 0;
            temp2.a = 0;
            itemsDone.color = temp;
            itemsCol.color = temp2;

        }
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
