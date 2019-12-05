using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_Person : MonoBehaviour
{
    Rigidbody rb;
    float interval;
    Vector3 initLoc;
    Vector3 currentLoc;

    // Start is called before the first frame update
    void Start()
    {
        initLoc = new Vector3(transform.localPosition.x, -0.05f, transform.localPosition.z);
        rb = GetComponent<Rigidbody>();
        interval = Random.Range(0.5f, 1.5f);
        jump();
        InvokeRepeating("jump", interval, .1f);
    }

    void Update()
    {
        float xVel = 0;
        float zVel = 0;
        currentLoc = new Vector3(transform.localPosition.x, -0.05f, transform.localPosition.z);

        if (initLoc.x == currentLoc.x)
        {
            xVel = 0;
        }
        else
        {
            xVel = initLoc.x - currentLoc.x;
        }
        
        if (initLoc.z == currentLoc.z)
        {
            zVel = 0;
        }
        else
        {
            zVel = initLoc.z - currentLoc.z;
        }
        
        currentLoc.x += xVel * Time.deltaTime;
        currentLoc.z += zVel * Time.deltaTime;

        transform.localPosition = new Vector3(currentLoc.x, transform.localPosition.y, currentLoc.z);
    }

    void jump()
    {
        rb.AddRelativeForce(0, Random.Range(0.075f, 0.1f), 0, ForceMode.Impulse);
    }

    public void reset()
    {
        transform.localPosition = initLoc;
        rb.velocity = new Vector3(0, 0, 0);
        rb.mass = 0.125f;
    }

    public void ascend()
    {
        rb.mass = 0.08f;
    }

    public void explode()
    {
        rb.AddRelativeForce(Random.Range(-3, 3), Random.Range(1, 4), Random.Range(-3, 3), ForceMode.Impulse);
    }
}
