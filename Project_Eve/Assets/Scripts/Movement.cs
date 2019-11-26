using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody rb;

    public float speed;

    public float maxSpeed;

    public Camera mCam;

    public GameObject testPos;

    public Vector2 direction;

    Vector2 mPos;

    Vector3 targetPos;

    Vector3 startPos;

    Vector2 ScreenCenter;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        startPos = transform.localPosition;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

      

        


        direction = (ScreenCenter - mPos);


        Vector3 targetPos = (new Vector3(20, -direction.y/1000, direction.x/1000));

        print(targetPos);

        testPos.transform.localPosition = targetPos;


        if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
        {
            if (rb.velocity.magnitude < maxSpeed)
            {

                rb.AddForce((new Vector3(targetPos.x, 0, targetPos.z) - transform.position) * speed);


                //GameObject.Find("Target").transform.position - transform.position).normalized* speed
            }
        }

        
            

        

    }
}
