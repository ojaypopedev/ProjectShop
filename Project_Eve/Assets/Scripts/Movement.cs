using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody rb;

    public float speed;

    public float maxSpeed;

    public GameObject trolley;
    public GameObject pCamera;

    public GameObject leftH;
    public GameObject rightH;

    public Animator[] hands;


    public enum HandsOnTrolley { None, Left, Right, Both};
    public HandsOnTrolley handsOnTrolley = HandsOnTrolley.None;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    
    void FixedUpdate()
    {

        GetInputs();
     
        MovementContainer();

        DoAnimation();

        #region Old Code
        //if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
        //{


        //} else if (Input.GetMouseButton(0) == true){

        //    rb.velocity = trolley.transform.forward * speed;
        //    if (speed < maxSpeed)
        //    {

        //        speed += 0.5f;
        //    }
        //    else
        //    {

        //        speed = maxSpeed;
        //    }

        //    rightH.SetActive(true);


        //}
        //else if (Input.GetMouseButton(1) == true)
        //{
        //    rb.velocity = trolley.transform.forward * speed;
        //    if (speed < maxSpeed)
        //    {

        //        speed += 0.5f;
        //    }
        //    else
        //    {

        //        speed = maxSpeed;
        //    }

        //    leftH.SetActive(true);

        //}


        //else
        //{


        //}
        #endregion

    }

    void GetInputs()
    {
        int handsDownAsInt = 0;
        if (Input.GetMouseButton(0)) handsDownAsInt += 1;
        if (Input.GetMouseButton(1)) handsDownAsInt += 2;

        handsOnTrolley = (HandsOnTrolley)handsDownAsInt;

    }

    void DoAnimation()
    {
        hands[0].SetBool("Raise", (handsOnTrolley == HandsOnTrolley.Right) || (handsOnTrolley == HandsOnTrolley.None));
        hands[1].SetBool("Raise", (handsOnTrolley == HandsOnTrolley.Left) || (handsOnTrolley == HandsOnTrolley.None));
    }

    #region Movement Methods

    void MovementContainer()
    {

        switch (handsOnTrolley)
        {
            case HandsOnTrolley.None:
                NoTrolleyMovement();
                break;
            case HandsOnTrolley.Left:
                OneHandMovement(HandsOnTrolley.Left);
                break;
            case HandsOnTrolley.Right:
                OneHandMovement(HandsOnTrolley.Right);
                break;
            case HandsOnTrolley.Both:
                NormalMovement();
                break;
            default:
                break;
        }
    }

    void NormalMovement()
    {
        rightH.SetActive(false);
        leftH.SetActive(false);
        rb.velocity = pCamera.transform.forward * speed;

        if (speed < maxSpeed)
        {

            speed += 0.5f;
        }
        else
        {

            speed = maxSpeed;
        }
    }

    void OneHandMovement(HandsOnTrolley mode)
    {
        rb.velocity = trolley.transform.forward * speed;
        if (speed < maxSpeed)
        {

            speed += 0.5f;
        }
        else
        {

            speed = maxSpeed;
        }

        if (mode == HandsOnTrolley.Left)
        {
            rightH.SetActive(true);
        }
        else
        {
            leftH.SetActive(true);
        }
    }

    void NoTrolleyMovement()
    {
        rb.velocity = trolley.transform.forward * speed;
        if (speed > 0)
        {
            speed -= maxSpeed / 0.5f * Time.deltaTime;

        }

        if (speed < 0)
        {
            speed = 0;
        }

        rightH.SetActive(false);
        leftH.SetActive(false);
    }

    #endregion

    void Initialize()
    {
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;

        speed = 0;
    }



}
