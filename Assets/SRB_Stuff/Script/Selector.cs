using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{

    GameObject Pointer;
    GameObject SelectScreen;
    public GameObject[] Objects;

    // Start is called before the first frame update
    void Start()
    {
        Pointer = GameObject.Find("Pointer");
        SelectScreen = GameObject.Find("SelectScreen");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Jump"))
        {
            GameObject g = Instantiate(Objects[0], Pointer.transform.position, Pointer.transform.rotation)
                as GameObject;
            //GameObject h = Instantiate(Objects[0], SelectScreen.transform.position, SelectScreen.transform.rotation)
                //as GameObject;
        }
    }
}
