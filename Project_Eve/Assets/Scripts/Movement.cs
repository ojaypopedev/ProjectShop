using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public Rigidbody rb;

    public float speed;

    public float maxSpeed;

    public GameObject trolley;
    public GameObject TrolleyContainer;
    public GameObject pCamera;

    public GameObject handContainer;
    GameObject handChoice;
    public TargetTransform[] targetTransforms;
    public GameObject RightHand;

    public List<GameObject> ItemsInTrolley = new List<GameObject>();

     Vector3 rightHandStartPoint;

    public GameObject LeftHand;
     Vector3 leftHandStartPoint;


  

    RaycastHit info = new RaycastHit();

    public Camera rayCam;


    public enum HandsOnTrolley { None, Left, Right, Both};
    public HandsOnTrolley handsOnTrolley = HandsOnTrolley.None;

    private GameObject trolleyModel;

    private GameObject currentShopItem;
    private GameObject currentFridge;

    public enum HandState {Nothing, Trolley, Item};
    public HandState state = HandState.Nothing;

    float waitTimer = 0.5f;

    public Transform dropPoint;
    public bool forward = true;

    bool holdingTrolley;
    bool picked;
    float delay;

    Vector3 weightOffset;


    // Start is called before the first frame update
    void Start()
    {
        Initialize();

        rightHandStartPoint = RightHand.transform.localPosition;
        leftHandStartPoint = LeftHand.transform.localPosition;
        weightOffset = pCamera.transform.forward;

    }

    
    void FixedUpdate()
    {


        print(state.ToString());

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

        if (info.collider)
        {

            print(info.collider.name);

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
                    if (state != HandState.Trolley)
                    {
                        trolleyModel = info.collider.gameObject;
                        trolleyModel.GetComponent<MaterialReference>().SetGlow(true);
                        holdingTrolley = false;
                    }

                }





            }


            else if (info.collider.tag == "ShopItem" && TrolleyCheck(info.collider.gameObject) == false)
            {

                currentShopItem = info.collider.gameObject;

                if (info.distance < 18)
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
                if (state == HandState.Trolley)
                    state = HandState.Nothing;
            }

            handContainer.GetComponent<Animator>().SetBool("OnTrolley", state == HandState.Trolley);

            if (state == HandState.Item)
            {

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




                if (Vector3.Distance(handChoice.transform.position, currentShopItem.transform.position) < 0.5f || picked == true)
                {
                    picked = true;


                    if (currentShopItem.GetComponent<Rigidbody>() == false)
                    {

                        currentShopItem.AddComponent<Rigidbody>();

                    }
                    else
                    {


                        currentShopItem.layer = 15;
                        currentShopItem.GetComponent<Collider>().enabled = false;
                        currentShopItem.GetComponent<Rigidbody>().useGravity = false;
                        currentShopItem.transform.SetParent(handChoice.transform);
                        handChoice.transform.position = Vector3.Lerp(handChoice.transform.position, dropPoint.position, 10 * Time.deltaTime);

                        if (Vector3.Distance(handChoice.transform.position, dropPoint.position) < 0.3f)
                        {
                            handChoice.transform.position = dropPoint.position;
                            currentShopItem.GetComponent<Collider>().enabled = true;
                            currentShopItem.GetComponent<Rigidbody>().useGravity = true;                                                     
                            ItemsInTrolley.Add(currentShopItem);
                            currentShopItem.transform.SetParent(TrolleyContainer.transform);
                            picked = false;
                            state = HandState.Nothing;

                        }
                    }

                }
                else if (picked == false)
                {



                    handChoice.transform.position = Vector3.Lerp(handChoice.transform.position, currentShopItem.transform.position, 10 * Time.deltaTime);

                }
            }
            else
            {


                RightHand.transform.localPosition = Vector3.Lerp(RightHand.transform.localPosition, rightHandStartPoint, 5 * Time.deltaTime);
                LeftHand.transform.localPosition = Vector3.Lerp(LeftHand.transform.localPosition, leftHandStartPoint, 5 * Time.deltaTime);
                handChoice = null;
            }

            //Fridge Door


            if (info.collider.tag == "Fridge")
            {



                currentFridge = info.collider.gameObject;


                if (info.distance < 18)
                {

                    currentFridge.GetComponent<MaterialReference>().SetGlow(true);



                    if (Input.GetMouseButtonDown(0))
                    {
                        if (currentFridge.GetComponent<FridgeDoorLeft>())
                        {
                            currentFridge.GetComponent<FridgeDoorLeft>().move = !currentFridge.GetComponent<FridgeDoorLeft>().move;
                        }


                        else if (currentFridge.GetComponent<FridgeDoorRight>())
                        {

                            currentFridge.GetComponent<FridgeDoorRight>().move = !currentFridge.GetComponent<FridgeDoorRight>().move;

                        }

                        
                    }
                }
                else
                {
                    if (currentFridge)
                        currentFridge.GetComponent<MaterialReference>().SetGlow(false);




                }
            }
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

       // handContainer.transform.position = Vector3.MoveTowards(handContainer.transform.position, targetTransforms[1].position, 0.5f);
       // handContainer.transform.rotation = Quaternion.Euler(Vector3.MoveTowards(handContainer.transform.rotation.eulerAngles, targetTransforms[1].rotation, 0.5f));

        if (waitTimer < 0.5f)
        {
            waitTimer += Time.deltaTime;
        }
        else
        {


            rb.velocity = (weightOffset * (speed) * (forward ? 1 : -1));
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);



            delay += 1 * Time.deltaTime;

            float delayTime = ItemsInTrolley.Count / 10;

            if(delayTime > 0.7f)
            {
                delayTime = 0.7f;
            }

            if (delay > delayTime)
            {
                weightOffset = pCamera.transform.forward;
                
                delay = 0;
            }
         

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


       // handContainer.transform.position = Vector3.MoveTowards(handContainer.transform.position, targetTransforms[0].position, 0.5f);
       // handContainer.transform.rotation = Quaternion.Euler(Vector3.MoveTowards(handContainer.transform.rotation.eulerAngles, targetTransforms[0].rotation, 0.5f));

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

    bool TrolleyCheck(GameObject itemToTest)
    {// bool same = false;

        if (ItemsInTrolley.Count > 0)
        {
            for (int i = 0; i < ItemsInTrolley.Count; i++)
            {

                if (ItemsInTrolley[i].gameObject ==  itemToTest.gameObject)
                {
                    print("true");
                    return true;
                   // same = true;
                }

            }
        }
        else
        {
            print("false");
            return false;
         //   same = false;

            

        }

        print("false");
        return false;

       // return same;

    }


    [System.Serializable]
    public struct TargetTransform
    {
        public Vector3 position;
        public Vector3 rotation;
        public Vector3 scale;
    }


}
