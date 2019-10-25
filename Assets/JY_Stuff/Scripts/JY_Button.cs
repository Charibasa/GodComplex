using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_Button : MonoBehaviour
{
    public GameObject pointer;
    public GameObject obj;
    GameObject[] tribes;

    // Start is called before the first frame update
    void Start()
    {
        tribes = GameObject.FindGameObjectsWithTag("Tribe");
    }

    public void moveTribes()
    {
        for(int i = 0; i < tribes.Length; i++)
        {
            tribes[i].GetComponent<JY_Tribe>().moving = true;
        }
    }

    public void resetTribes()
    {
        for (int i = 0; i < tribes.Length; i++)
        {
            tribes[i].GetComponent<JY_Tribe>().moving = false;
            tribes[i].GetComponent<JY_Tribe>().reseting = true;
            tribes[i].GetComponent<JY_Tribe>().invokeReset();
        }
    }

    public void addObject()
    {
        var thing = Instantiate(obj, new Vector3(pointer.transform.position.x, pointer.transform.position.y, pointer.transform.position.z+1), Quaternion.identity);

        thing.transform.parent = pointer.transform;
    }
}
