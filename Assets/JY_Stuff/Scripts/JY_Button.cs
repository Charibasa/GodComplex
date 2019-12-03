using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JY_Button : MonoBehaviour
{
    public bool moving;
    GameObject[] tribesA;
    GameObject[] tribesE;
    GameObject[] gates;
    GameObject tracker;

    // Start is called before the first frame update
    void Start()
    {
        moving = false;
        tribesA = GameObject.FindGameObjectsWithTag("TribeAlly");
        tribesE = GameObject.FindGameObjectsWithTag("TribeEnemy");
        gates = GameObject.FindGameObjectsWithTag("Gate");
        tracker = GameObject.FindGameObjectWithTag("Tracker");
    }

    private void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.Three) && !moving)
        {
            moving = true;
            moveTribes();
        }

        if(OVRInput.GetDown(OVRInput.Button.Four) && moving)
        {
            moving = false;
            resetTribes();

            if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0)
            {
                removeStructures();
            } 
        }

        if (OVRInput.GetDown(OVRInput.Button.Two) && tracker.GetComponent<JY_TribeTracker>().gameOver)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void moveTribes()
    {
        foreach (GameObject tribe in tribesA)
        {
            tribe.GetComponent<JY_Tribe>().globalMoving = true;
            tribe.GetComponent<JY_Tribe>().moving = true;
        }

        foreach (GameObject tribe in tribesE)
        {
            tribe.GetComponent<JY_Tribe>().globalMoving = true;
            tribe.GetComponent<JY_Tribe>().moving = true;
        }
    }

    public void resetTribes()
    {
        foreach (GameObject tribe in tribesA)
        {
            tribe.GetComponent<JY_Tribe>().globalMoving = false;
            tribe.GetComponent<JY_Tribe>().moving = false;
            tribe.GetComponent<JY_Tribe>().reseting = true;
            tribe.GetComponent<JY_Tribe>().invokeReset();
        }

        foreach (GameObject tribe in tribesE)
        {
            tribe.GetComponent<JY_Tribe>().globalMoving = false;
            tribe.GetComponent<JY_Tribe>().moving = false;
            tribe.GetComponent<JY_Tribe>().reseting = true;
            tribe.GetComponent<JY_Tribe>().invokeReset();
        }

        foreach(GameObject gate in gates)
        {
            gate.GetComponent<JY_GateButton>().reset();
        }

        tracker.GetComponent<JY_TribeTracker>().Reset();
    }

    public void removeStructures()
    {
        GameObject[] placedStructures = GameObject.FindGameObjectsWithTag("Structure");

        foreach(GameObject str in placedStructures)
        {
            Destroy(str);
        }
    }
}
