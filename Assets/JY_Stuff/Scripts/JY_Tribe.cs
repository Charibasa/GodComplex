using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_Tribe : MonoBehaviour
{
    Vector3 dir;
    BoxCollider bcol;
    CapsuleCollider ccol;
    JY_TribeTracker tracker;
    bool dead;
    bool exploded;
    bool ascended;
    float facing;

    public Vector3 initLoc;
    public GameObject dirIcon;
    public GameObject raycasterStop;
    public GameObject raycasterDir;
    public GameObject components;
    public GameObject detector;
    public GameObject[] people;
    public bool moving;
    public bool globalMoving;
    public float speed;
    public int initFacing;
    public bool reseting;
    public AudioClip[] sfx;

    // Start is called before the first frame update
    void Start()
    {
        initLoc = transform.position;
        moving = false;
        globalMoving = false;
        dead = false;
        exploded = false;
        facing = initFacing;
        bcol = GetComponent<BoxCollider>();
        ccol = GetComponent<CapsuleCollider>();
        tracker = GameObject.FindGameObjectWithTag("Tracker").GetComponent<JY_TribeTracker>();

        reseting = false;
    }

    // Update is called once per frame
    void Update()
    {
        setArrowLocation();
        setColliderHeight();
        setDirColliderHeight();

        if (facing == 0) //North
        {
            dir = new Vector3(0, 0, 0.2f);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (facing == 1) //East
        {
            dir = new Vector3(0.2f, 0, 0);
            transform.eulerAngles = new Vector3(0, 90, 0);
        }
        else if (facing == 2) // South
        {
            dir = new Vector3(0, 0, -0.2f);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (facing == 3) // West
        {
            dir = new Vector3(-0.2f, 0, 0);
            transform.eulerAngles = new Vector3(0, 270, 0);
        }
        else if (facing == 4) // NorthEast
        {
            dir = new Vector3(.2f, 0, 0.2f);
            transform.eulerAngles = new Vector3(0, 45, 0);
        }
        else if (facing == 5) // SouthEast
        {
            dir = new Vector3(0.2f, 0, -.2f);
            transform.eulerAngles = new Vector3(0, 135, 0);
        }
        else if (facing == 6) // SouthWest
        {
            dir = new Vector3(-.2f, 0, -0.2f);
            transform.eulerAngles = new Vector3(0, 225, 0);
        }
        else if (facing == 7) // NorthWest
        {
            dir = new Vector3(-0.2f, 0, 0.2f);
            transform.eulerAngles = new Vector3(0, 315, 0);
        }

        if (moving && globalMoving)
        {
            transform.position += dir * Time.deltaTime * speed;
        }

        if(detector.GetComponent<JY_Detector>().opponentTouched && !exploded)
        {
            exploded = true;
            explode();
        }

        if(dead)
        {
            moving = false;
            globalMoving = false;
            components.SetActive(false);
        }
    }

    void setArrowLocation()
    {
        float avg = 0;

        foreach(GameObject person in people)
        {
            avg += person.transform.position.y;
        }
        
        dirIcon.transform.position = new Vector3(dirIcon.transform.position.x, (avg/people.Length), dirIcon.transform.position.z);

        if(avg/people.Length < 1)
        {
            GetComponent<AudioSource>().PlayOneShot(sfx[0]);
            setDead();
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
        if(other.tag == "Terrain" || other.tag == "Boundary")
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

            if (other.tag == "Goal")
            {
                GetComponent<AudioSource>().PlayOneShot(sfx[1]);
                ascended = true;
                other.GetComponentInParent<JY_Goal>().speedUp();

                moving = false;
                foreach (GameObject person in people)
                {
                    person.GetComponent<JY_Person>().ascend();
                }
                Invoke("setDead", 7);
            }
        }
    }

    public void invokeReset()
    {
        CancelInvoke();

        Invoke("reset", .05f);
        Invoke("setReset", .15f);
    }

    void reset()
    {
        dead = false;
        ascended = false;
        transform.position = initLoc;
        facing = initFacing;
        raycasterStop.transform.localPosition = new Vector3(0, .2f, .485f);
        raycasterDir.transform.localPosition = new Vector3(0, .3f, .0625f);
        moving = false;
        globalMoving = false;
        components.SetActive(true);

        foreach (GameObject person in people)
        {
            person.GetComponent<JY_Person>().reset();
        }
    }

    void setReset()
    {
        reseting = false;
    }

    void setDead()
    {
        dead = true;
        transform.position += new Vector3(0, 50, 0);

        if(tag == "TribeAlly")
        {
            if (ascended)
            {
                tracker.ascendedAllies++;
            }

            tracker.allyCount--;
        }
        else if(tag == "TribeEnemy")
        {
            tracker.enemyCount--;
        }
    }

    void explode()
    {
        GetComponent<AudioSource>().PlayOneShot(sfx[0]);
        moving = false;
        foreach (GameObject person in people)
        {
            person.GetComponent<JY_Person>().explode();
        }
        Invoke("setDead", 5);
    }
}
