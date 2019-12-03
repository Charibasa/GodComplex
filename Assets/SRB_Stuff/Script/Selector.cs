﻿using System.Collections;
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

        cycleImage(2);
    }

    // Update is called once per frame
    void Update()
    {
        if (selectPlace == 1)
            select.position = new Vector3(select.position.x, 7.8f,select.position.z);

        if (selectPlace == 0)
            select.position = new Vector3(select.position.x, 7, select.position.z);

        if (selectPlace == -1)
            select.position = new Vector3(select.position.x, 6.2f, select.position.z);

        //if (v > .15)
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            if (objectNumber != Objects.Length - 1)
                objectNumber++;
            else if (objectNumber == Objects.Length - 1)
                objectNumber = 0;

            if (selectPlace == 1)
                cycleImage(1);
            else if (selectPlace == 0)
                selectPlace = 1;
            else if (selectPlace == -1)
                selectPlace = 0;

            print(objectNumber);
            //print(Objects[objectNumber].name + ", " + Images[objectNumber].name);
        }

        //if (v < -.15)
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            if (objectNumber != 0)
                objectNumber--;
            else if (objectNumber == 0)
                objectNumber = Objects.Length - 1;

            if (selectPlace == -1)
                cycleImage(0);
            else if (selectPlace == 0)
                selectPlace = -1;
            else if (selectPlace == 1)
                selectPlace = 0;

            print(objectNumber);
            //print(Objects[objectNumber].name + ", " + Images[objectNumber].name);
        }

        if (Input.GetButtonUp("Jump"))
        {
            GameObject g = Instantiate(Objects[objectNumber], Pointer.transform.position, Pointer.transform.rotation)
                as GameObject;
            //GameObject h = Instantiate(Objects[0], SelectScreen.transform.position, SelectScreen.transform.rotation)
                //as GameObject;
        }
    }

    public void cycleImage(int cycle)
    {
        int imageNumber = objectNumber;

        if (cycle == 2)
        {
            image1.sprite = Images[1];
            image2.sprite = Images[0];
            image3.sprite = Images[Objects.Length - 1];
        }

        if (cycle == 1)
        {
            image1.sprite = Images[imageNumber];

            if (imageNumber == 0)
            {
                image3.sprite = Images[Objects.Length - 2];
                image2.sprite = Images[Objects.Length - 1];
            }
            else if (imageNumber == 1)
            {
                image3.sprite = Images[Objects.Length - 1];
                image2.sprite = Images[0];
            }
            else
            {
                image3.sprite = Images[imageNumber - 2];
                image2.sprite = Images[imageNumber - 1];
            }
        }
        else if(cycle == 0)
        {
            image3.sprite = Images[imageNumber];

            if (imageNumber == Objects.Length - 1)
            {
                image1.sprite = Images[1];
                image2.sprite = Images[0];
            }
            else if (imageNumber == Objects.Length - 2)
            {
                image1.sprite = Images[0];
                image2.sprite = Images[Objects.Length - 1];
            }
            else
            {
                image1.sprite = Images[imageNumber + 2];
                image2.sprite = Images[imageNumber + 1];
            }
        }

    }
}
