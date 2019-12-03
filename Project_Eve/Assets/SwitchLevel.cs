using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchLevel : MonoBehaviour
{

    public GameObject gManager;
    public GameObject Fade;
    public Image fade;
    public Text winText;
    public Button button;
    bool screenFade;

    // Start is called before the first frame update
    void Start()
    {
        gManager = GameObject.FindGameObjectWithTag("GameManager");
        button.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(screenFade == true)
        {

            winText.text = "You Win";
            Color temp = fade.color;

            temp.a += 0.1f;

            fade.color = temp;

            if(temp.a >= 1)
            {
                Cursor.lockState = CursorLockMode.None;
                if (gManager.GetComponent<RequestList>().testComplete == true)
                {
                    SceneManager.LoadScene(1);
                }
                else
                {

                    button.enabled = true;
                    Fade.active = true;

                }
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

        if(gManager.GetComponent<RequestList>().win == true && gManager.GetComponent<RequestList>().modeSelect == RequestList.ModeSelect.challenge)
        {

            screenFade = true;

        }

    }
}
