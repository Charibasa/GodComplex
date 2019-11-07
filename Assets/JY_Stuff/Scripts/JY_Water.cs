using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_Water : MonoBehaviour
{
    public GameObject splash;
    ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        ps = splash.GetComponent<ParticleSystem>();
    }

    void OnTriggerEnter(Collider other)
    {
        splash.transform.position = other.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
        #pragma warning disable 618
        ps.startSpeed = other.GetComponent<Rigidbody>().velocity.magnitude / 3;
        ps.Play();
    }
}
