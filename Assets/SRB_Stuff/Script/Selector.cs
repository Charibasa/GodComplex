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

    Text descript;

    int objectNumber = 0;
    float selectPlace = 0;
    float yRotate = 0;
    bool stickIsNeutral = true;
    Vector3 objRotate = new Vector3(0,0,0);
    GameObject g;

    JY_Button status;

    // Start is called before the first frame update
    void Start()
    {
        Pointer = GameObject.Find("Pointer");
        SelectScreen = GameObject.Find("SelectScreen");

        image1 = GameObject.Find("Image1").GetComponent<Image>();
        image2 = GameObject.Find("Image2").GetComponent<Image>();
        image3 = GameObject.Find("Image3").GetComponent<Image>();
        select = GameObject.Find("Selected").GetComponent<RectTransform>();

        descript = GameObject.Find("descText").GetComponent<Text>();

        g = Instantiate(Objects[objectNumber], Pointer.transform.position, Pointer.transform.rotation)
                as GameObject;

        status = GetComponent<JY_Button>();

        updateDesc();
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

        float v = Input.GetAxis("Vertical");

        if(v == 0)
        {
            stickIsNeutral = true;
        }

        //if (v > .15)
        if ((Input.GetAxis("Vertical") > 0 && stickIsNeutral))
        {
            stickIsNeutral = false;
            if (objectNumber != Objects.Length - 1)
                objectNumber++;
            else if (objectNumber == Objects.Length - 1)
                objectNumber = 0;

            Destroy(g);

            if (!(objectNumber == 0 || objectNumber == 1 || objectNumber == Objects.Length - 1))
                g = Instantiate(Objects[objectNumber], Pointer.transform.position, Pointer.transform.rotation)
                    as GameObject;
            else
                g = Instantiate(Objects[objectNumber], Pointer.transform.position, g.transform.rotation)
                        as GameObject;

            if (selectPlace == 1)
            {
                cycleImage(1);
                updateDesc();
            }
            else if (selectPlace == 0)
            {
                selectPlace = 1;
                updateDesc();
            }
            else if (selectPlace == -1)
            {
                selectPlace = 0;
                updateDesc();
            }

            print(objectNumber);
            //print(Objects[objectNumber].name + ", " + Images[objectNumber].name);
        }

        //if (v < -.15)
        if ((Input.GetAxis("Vertical") < 0 && stickIsNeutral))
        {
            stickIsNeutral = false;
            if (objectNumber != 0)
                objectNumber--;
            else if (objectNumber == 0)
                objectNumber = Objects.Length - 1;

            Destroy(g);

            if(!(objectNumber == 0 || objectNumber == 1 || objectNumber == Objects.Length - 1))
                g = Instantiate(Objects[objectNumber], Pointer.transform.position, Pointer.transform.rotation)
                    as GameObject;
            else
                g = Instantiate(Objects[objectNumber], Pointer.transform.position, g.transform.rotation)
                        as GameObject;

            if (selectPlace == -1)
            {
                cycleImage(0);
                updateDesc();
            }
            else if (selectPlace == 0)
            {
                selectPlace = -1;
                updateDesc();
            }
            else if (selectPlace == 1)
            {
                selectPlace = 0;
                updateDesc();
            }

            print(objectNumber);
            //print(Objects[objectNumber].name + ", " + Images[objectNumber].name);
        }

        if (Input.GetKeyUp(KeyCode.Q) || OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))  //&& (objectNumber == 0 || objectNumber == 1 || objectNumber == 6))
        {
            objRotate = new Vector3(0, -45, 0);
            g.transform.Rotate(objRotate);
            print(yRotate);
        }

        if (Input.GetKeyUp(KeyCode.E) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger)) //&& (objectNumber == 0 || objectNumber == 1 || objectNumber == 6))
        {
            objRotate = new Vector3(0, 45, 0);
            g.transform.Rotate(objRotate);
            print(yRotate);
        }

        if (g != null)
        {
            if(g.GetComponent<JY_Structure>() != null)
            {
                g.GetComponent<JY_Structure>().collisionGeometry.SetActive(false);
            }

            if (Input.GetButtonDown("Jump") || OVRInput.GetDown(OVRInput.Button.One) && !status.moving)
            {
                if (g.GetComponent<JY_Structure>() != null)
                {
                    g.GetComponent<JY_Structure>().collisionGeometry.SetActive(true);
                }

                g = Instantiate(Objects[objectNumber], Pointer.transform.position, g.transform.rotation)
                                as GameObject;
            }
            else
            {
                if (g.GetComponent<JY_Structure>() != null)
                {
                    g.GetComponent<JY_Structure>().collisionGeometry.SetActive(false);
                }

                g.transform.position = Pointer.transform.position;
            }

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

    public void updateDesc()
    {
        if (objectNumber == 0)
            descript.text = "A Bridge. Can be placed anywhere, and will let tribes traverse gaps.";
        if (objectNumber == 1)
            descript.text = "A Longer Bridge. Ccan go bring tribes and even further distance.";
        if (objectNumber == 2)
            descript.text = "Sends a tribe in the direction it points!";
        if (objectNumber == 3)
            descript.text = "A Ramp. Use it to go to higher places!";
        if (objectNumber == 4)
            descript.text = "A Block. Use it however you like, maybe a base to build more.";
        if (objectNumber == 5)
            descript.text = "A Longer Block for Longer options.";
        if (objectNumber == 6)
            descript.text = "A Ramp";
    }
}
