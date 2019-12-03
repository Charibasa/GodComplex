using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selector : MonoBehaviour
{

    GameObject Pointer;
    GameObject SelectScreen;
    public Sprite[] Images; 
    public GameObject[] Objects;


    Image image1;
    Image image2;
    Image image3;
    RectTransform select;

    int objectNumber = 0;
    float selectPlace = 0;

    // Start is called before the first frame update
    void Start()
    {
        Pointer = GameObject.Find("Pointer");
        SelectScreen = GameObject.Find("SelectScreen");

        image1 = GameObject.Find("Image1").GetComponent<Image>();
        image2 = GameObject.Find("Image2").GetComponent<Image>();
        image3 = GameObject.Find("Image3").GetComponent<Image>();
        select = GameObject.Find("Selected").GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (selectPlace == 1)
            select = .8f;

        //if (v > .15)
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            if (objectNumber != Objects.Length - 1)
                objectNumber++;

            if(selectPlace ==)

            print(Objects[objectNumber].name);
        }

        //if (v < -.15)
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            if (objectNumber != 0)
                objectNumber--;

            print(Objects[objectNumber].name);
        }

        if (Input.GetButtonUp("Jump"))
        {
            GameObject g = Instantiate(Objects[objectNumber], Pointer.transform.position, Pointer.transform.rotation)
                as GameObject;
            //GameObject h = Instantiate(Objects[0], SelectScreen.transform.position, SelectScreen.transform.rotation)
                //as GameObject;
        }
    }
}
