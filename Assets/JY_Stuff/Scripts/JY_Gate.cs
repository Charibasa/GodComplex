using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_Gate : MonoBehaviour
{
    bool opened;

    public GameObject door;
    public GameObject deco1;
    public GameObject deco2;

    void Start()
    {
        opened = false;
    }

    void Update()
    {
        if(opened)
        {
            door.transform.localPosition = Vector3.MoveTowards(door.transform.localPosition, new Vector3(door.transform.localPosition.x, -.995f, door.transform.localPosition.z), .5f * Time.deltaTime);
        }
    }

    public void setOpen()
    {
        opened = true;
    }

    public void reset()
    {
        opened = false;
        door.transform.localPosition = new Vector3(door.transform.localPosition.x, 0, door.transform.localPosition.z);
    }
}