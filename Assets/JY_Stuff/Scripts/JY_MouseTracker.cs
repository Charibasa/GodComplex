using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_MouseTracker : MonoBehaviour
{
    Transform rightHand;

    void Start()
    {
        rightHand = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = Vector3.zero;

        RaycastHit hitInfo;

        if (Physics.Linecast(rightHand.position, new Vector3(rightHand.position.x, -100, rightHand.position.z), out hitInfo))
        {
            if (hitInfo.collider.tag == "Terrain")
            {
                if(hitInfo.point.y < 4)
                {
                    transform.position = new Vector3(rightHand.position.x, 4, rightHand.position.z);
                }
                else
                {
                    transform.position = new Vector3(rightHand.position.x, hitInfo.point.y, rightHand.position.z);
                }
            }
            else
            {
                transform.position = rightHand.position;
            }
        }
    }
}