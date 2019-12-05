using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_Detector : MonoBehaviour
{
    public bool opponentTouched;

    // Start is called before the first frame update
    void Start()
    {
        opponentTouched = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(tag == "AllyBounds" && other.tag == "EnemyBounds")
        {
            opponentTouched = true;
        }
    }
}
