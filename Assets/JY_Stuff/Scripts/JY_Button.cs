using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_Button : MonoBehaviour
{
    public GameObject pointer;

    GameObject[] tribesA;
    GameObject[] tribesE;
    GameObject[] gates;
    GameObject tracker;
    float offset;

    // Start is called before the first frame update
    void Start()
    {
        tribesA = GameObject.FindGameObjectsWithTag("TribeAlly");
        tribesE = GameObject.FindGameObjectsWithTag("TribeEnemy");
        gates = GameObject.FindGameObjectsWithTag("Gate");
        tracker = GameObject.FindGameObjectWithTag("Tracker");
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

    public void setOffset(float fl)
    {
        offset = fl;
    }

    public void addObject(GameObject obj)
    {
        var structure = Instantiate(obj, new Vector3(pointer.transform.position.x, pointer.transform.position.y, pointer.transform.position.z+offset), Quaternion.identity);

        structure.name = "HeldStructure";

        structure.GetComponent<JY_Structure>().collisionGeometry.SetActive(false);

        structure.transform.parent = pointer.transform;
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
