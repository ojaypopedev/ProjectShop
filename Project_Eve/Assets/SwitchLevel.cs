using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchLevel : MonoBehaviour
{

    public GameObject gManager;

    // Start is called before the first frame update
    void Start()
    {
        gManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (gManager.GetComponent<RequestList>().testComplete == true)
        {
            if (col.gameObject.tag == "Trolley")
            {

                SceneManager.LoadScene(1);

            }
        }

    }
}
