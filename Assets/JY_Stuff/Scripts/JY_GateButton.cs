using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_GateButton : MonoBehaviour
{
    int peopleCount;
    bool pressed;

    public GameObject button;
    public GameObject linkedGate;
    public Color col;

    // Start is called before the first frame update
    void Start()
    {
        peopleCount = 0;
        pressed = false;
        button.GetComponent<Renderer>().material.color = col;

        linkedGate.GetComponent<JY_Gate>().deco1.GetComponent<Renderer>().material.color = col;
        linkedGate.GetComponent<JY_Gate>().deco2.GetComponent<Renderer>().material.color = col;


    }

    // Update is called once per frame
    void Update()
    {
        if(pressed)
        {
            GameObject gate = linkedGate.GetComponent<JY_Gate>().door;

            button.transform.localPosition = Vector3.MoveTowards(button.transform.localPosition, new Vector3(button.transform.localPosition.x, -.25f, button.transform.localPosition.z), 1 * Time.deltaTime);
            gate.transform.localPosition = Vector3.MoveTowards(gate.transform.localPosition, new Vector3(gate.transform.localPosition.x, -.995f, gate.transform.localPosition.z), .5f * Time.deltaTime);
        }
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
