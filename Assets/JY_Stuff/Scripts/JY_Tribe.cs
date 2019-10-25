using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_Tribe : MonoBehaviour
{
    Vector3 dir;
    BoxCollider bcol;
    CapsuleCollider ccol;
    bool dead;
    int facing;

    public Vector3 initLoc;
    public GameObject dirIcon;
    public GameObject raycasterStop;
    public GameObject raycasterDir;
    public GameObject components;
    public GameObject[] people;
    public bool moving;
    public float speed;
    public int initFacing;

    public bool reseting;

    // Start is called before the first frame update
    void Start()
    {
        initLoc = transform.position;
        moving = false;
        dead = false;
        facing = initFacing;
        bcol = GetComponent<BoxCollider>();
        ccol = GetComponent<CapsuleCollider>();
        components = transform.Find("Components").gameObject;

        reseting = false;
    }

    // Update is called once per frame
    void Update()
    {
        setArrowLocation();
        setColliderHeight();
        setDirColliderHeight();

        if (facing == 0)
        {
            dir = new Vector3(0, 0, 0.2f);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (facing == 1)
        {
            dir = new Vector3(0.2f, 0, 0);
            transform.eulerAngles = new Vector3(0, 90, 0);
        }
        else if (facing == 2)
        {
            dir = new Vector3(0, 0, -0.2f);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (facing == 3)
        {
            dir = new Vector3(-0.2f, 0, 0);
            transform.eulerAngles = new Vector3(0, 270, 0);
        }

        if(moving)
        {
            transform.position += dir * Time.deltaTime * speed;
        }

        if(dead)
        {
            moving = false;
            components.SetActive(false);
        }
    }

    void setArrowLocation()
    {
        float avg = 0;

        for(int i = 0; i < 10; i++)
        {
            avg += people[i].transform.position.y;
        }
        
        dirIcon.transform.position = new Vector3(dirIcon.transform.position.x, (avg/10), dirIcon.transform.position.z);

        if(avg/10 < 1)
        {
            dead = true;
        }
    }

    void setColliderHeight()
    {
        RaycastHit rch;

        if (Physics.Linecast(raycasterStop.transform.position, new Vector3(raycasterStop.transform.position.x, raycasterStop.transform.position.y - 10, raycasterStop.transform.position.z), out rch))
        {
            if(rch.collider.tag == "Terrain")
            {
                raycasterStop.transform.position = new Vector3(raycasterStop.transform.position.x, rch.point.y + 0.2f, raycasterStop.transform.position.z);
                bcol.center = new Vector3(bcol.center.x, rch.point.y + 0.2f - transform.position.y, bcol.center.z);
            }
        }
    }

    void setDirColliderHeight()
    {
        RaycastHit rch;

        if (Physics.Linecast(raycasterDir.transform.position, new Vector3(raycasterDir.transform.position.x, raycasterDir.transform.position.y - 10, raycasterDir.transform.position.z), out rch))
        {
            if (rch.collider.tag == "Terrain")
            {
                raycasterDir.transform.position = new Vector3(raycasterDir.transform.position.x, rch.point.y + 0.3f, raycasterDir.transform.position.z);
                ccol.center = new Vector3(ccol.center.x, rch.point.y + 0.3f - transform.position.y, ccol.center.z);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Terrain")
        {
            moving = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!reseting)
        {
            if (other.tag == "Terrain")
            {
                moving = true;
            }

            if (other.tag == "ChangeDirection")
            {
                facing = other.GetComponentInParent<JY_ChangeDirection>().newDirection;
            }
        }
    }

    public void invokeReset()
    {
        Invoke("reset", .1f);
        Invoke("setReset", .2f);
    }

    void reset()
    {
        dead = false;
        transform.position = initLoc;
        facing = initFacing;
        raycasterStop.transform.localPosition = new Vector3(0, .2f, .485f);
        raycasterDir.transform.localPosition = new Vector3(0, .3f, .0625f);
        moving = false;
        components.SetActive(true);

        for (int i = 0; i < 10; i++)
        {
            people[i].GetComponent<JY_Person>().reset();
        }
    }
    
    void setReset()
    {
        reseting = false;
    }
}
