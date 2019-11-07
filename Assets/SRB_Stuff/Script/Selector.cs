using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{

    GameObject Pointer;
    public GameObject[] Objects;

    // Start is called before the first frame update
    void Start()
    {
        Pointer = GameObject.Find("Pointer");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            GameObject g = Instantiate(Objects[0], Pointer.transform.position, Pointer.transform.rotation)
                as GameObject;
        }
    }
}
