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

    public GameObject handContainer;
    public GameObject RightHand;
     Vector3 rightHandStartPoint;

    public GameObject LeftHand;
     Vector3 leftHandStartPoint;


    GameObject handChoice;

    RaycastHit info = new RaycastHit();

    public Camera rayCam;


    public enum HandsOnTrolley { None, Left, Right, Both};
    public HandsOnTrolley handsOnTrolley = HandsOnTrolley.None;

    private GameObject trolleyModel;

    private GameObject currentShopItem;

    public enum HandState {Nothing, Trolley, Item};
    public HandState state = HandState.Nothing;

    float waitTimer = 0.5f;

    public Transform dropPoint;
    public bool forward = true;

    bool holdingTrolley;


    // Start is called before the first frame update
    void Start()
    {
        Initialize();

        rightHandStartPoint = RightHand.transform.localPosition;
        leftHandStartPoint = LeftHand.transform.localPosition;
    }

    
    void FixedUpdate()
    {

        GetInputs();
     
        MovementContainer();

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
        //int handsDownAsInt = 0;
        //if (Input.GetMouseButton(0)) handsDownAsInt += 1;
        //if (Input.GetMouseButton(1)) handsDownAsInt += 2;

        //handsOnTrolley = (HandsOnTrolley)handsDownAsInt;
 

        if (state == HandState.Nothing)
        {
          
            Ray ray = new Ray(rayCam.transform.position, rayCam.transform.forward);
            Physics.Raycast(ray, out info);

        }

        if(info.collider)
        if (info.collider.tag == "Trolley")
        {
            

            if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
            {
                    if (holdingTrolley == false)
                    {
                        state = HandState.Trolley;


                        waitTimer = 0f;



                        trolleyModel = info.collider.gameObject;
                        trolleyModel.GetComponent<MaterialReference>().SetGlow(false);

                        holdingTrolley = true;

                    }
                    

            }
            else
            {
                if (state != HandState.Trolley){
                    trolleyModel = info.collider.gameObject;
                    trolleyModel.GetComponent<MaterialReference>().SetGlow(true);
                    holdingTrolley = false;
                }
               
            }


            


        }    
      

       else  if(info.collider.tag == "ShopItem")
        {

                currentShopItem = info.collider.gameObject;

                if (info.distance < 9)
                {
                    
                    currentShopItem.GetComponent<MaterialReference>().SetGlow(true);

                   

                    if (Input.GetMouseButtonDown(0))
                    {


                        state = HandState.Item;

                        //currentShopItem.transform.position = dropPoint.transform.position;
                    }
                }
        }
        else
        {
            if (currentShopItem)
            {
                currentShopItem.GetComponent<MaterialReference>().SetGlow(false);
                currentShopItem = null;
            }
            if (trolleyModel)
            {

                trolleyModel.GetComponent<MaterialReference>().SetGlow(false);
            }

            state = HandState.Nothing;

        }


        if (!Input.GetMouseButton(0) || !Input.GetMouseButton(1))
        {
          if(state == HandState.Trolley)
            state = HandState.Nothing;
        }

        handContainer.GetComponent<Animator>().SetBool("OnTrolley", state == HandState.Trolley);

        if(state == HandState.Item)
        {
            print(123);


            if (!handChoice)
            {
                float dist = Vector3.Distance(currentShopItem.transform.position, LeftHand.transform.position);
                if (dist < Vector3.Distance(currentShopItem.transform.position, RightHand.transform.position))
                {
                    handChoice = LeftHand;
                }
                else
                {
                    handChoice = RightHand;
                }
            }

            if(Vector3.Distance(handChoice.transform.position, currentShopItem.transform.position)< 0.5f)
            {
                currentShopItem.GetComponent<Rigidbody>().useGravity = false;
                currentShopItem.transform.SetParent(handChoice.transform);
                handChoice.transform.position = Vector3.Lerp(handChoice.transform.position, dropPoint.position, 10*Time.deltaTime);

                if(Vector3.Distance(handChoice.transform.position, dropPoint.position) < 0.1f){
                    currentShopItem.GetComponent<Rigidbody>().useGravity = true;
                    currentShopItem.transform.SetParent(null);

                    state = HandState.Nothing;
                }

            }
            else
            {

                handChoice.transform.position = Vector3.Lerp(handChoice.transform.position, currentShopItem.transform.position, 10 * Time.deltaTime);
            }
        }
        else
        {
            RightHand.transform.localPosition = Vector3.Lerp(RightHand.transform.localPosition, rightHandStartPoint, 5*Time.deltaTime);
            LeftHand.transform.localPosition = Vector3.Lerp(LeftHand.transform.localPosition, leftHandStartPoint, 5 * Time.deltaTime);
            handChoice = null;
        }


    }



    #region Movement Methods

    void MovementContainer()
    {

        switch (state)
        {
            case HandState.Nothing:
                NoTrolleyMovement();
                break;
            case HandState.Trolley:
                NormalMovement();
                break;
            case HandState.Item:
                break;
            default:
                break;
        }

  
    }

    void NormalMovement()
    {
       if(waitTimer < 0.5f)
        {
            waitTimer += Time.deltaTime;
        }
        else
        {
            rb.velocity = pCamera.transform.forward * speed*(forward?1:-1);

            if (speed < maxSpeed)
            {

                speed += 0.5f;
            }
            else
            {

                speed = maxSpeed;
            }
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

        
    }

    void NoTrolleyMovement()
    {
        Vector3 temp = trolley.transform.forward;
        temp.y = 0;

        rb.velocity = temp * speed;
        if (speed > 0)
        {
            speed -= maxSpeed / 0.5f * Time.deltaTime;

        }

        if (speed < 0)
        {
            speed = 0;
        }

        
    }

    #endregion

    void Initialize()
    {
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;

        speed = 0;
    }



}
