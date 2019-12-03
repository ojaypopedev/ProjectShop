using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchLevel : MonoBehaviour
{

    public GameObject gManager;
    public Image fade;
    bool screenFade;

    // Start is called before the first frame update
    void Start()
    {
        gManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    // Update is called once per frame
    void Update()
    {

        if(screenFade == true)
        {

            Color temp = fade.color;

            temp.a += 0.1f;

            fade.color = temp;

            if(temp.a >= 1)
            {
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene(1);
            }


        }
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (gManager.GetComponent<RequestList>().testComplete == true)
        {
            if (col.gameObject.tag == "Trolley")
            {
                screenFade = true;
                

            }
        }

    }
}
