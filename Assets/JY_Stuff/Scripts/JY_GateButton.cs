using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_GateButton : MonoBehaviour
{
    int peopleCount;
    bool pressed;

    public GameObject button;
    public JY_Gate linkedGate;
    public Color col;

    // Start is called before the first frame update
    void Start()
    {
        peopleCount = 0;
        pressed = false;
        button.GetComponent<Renderer>().material.color = col;

        linkedGate.deco1.GetComponent<Renderer>().material.color = col;
        linkedGate.deco2.GetComponent<Renderer>().material.color = col;
    }

    // Update is called once per frame
    void Update()
    {
        if(pressed)
        {
            button.transform.localPosition = Vector3.MoveTowards(button.transform.localPosition, new Vector3(button.transform.localPosition.x, -.25f, button.transform.localPosition.z), 1 * Time.deltaTime);
            linkedGate.setOpen();
        }
    }

    public void reset()
    {
        pressed = false;
        button.transform.localPosition = new Vector3(button.transform.localPosition.x, 0.025f, button.transform.localPosition.z);
        linkedGate.reset();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Person")
        {
            peopleCount++;
        }

        if(peopleCount == 10)
        {
            pressed = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "Person")
        {
            peopleCount--;
        }
    }
}