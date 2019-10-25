using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_MouseTracker : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(r, out hitInfo, Mathf.Infinity, 1 << LayerMask.NameToLayer("Terrain")))
        {
            if (hitInfo.collider.tag == "Terrain")
            {
                transform.position = new Vector3(hitInfo.point.x, hitInfo.point.y, hitInfo.point.z);
            }
        }

        if(Input.GetMouseButtonDown(0))
        {
            var obj = transform.Find("Bridge(Clone)");

            if(obj != null)
            {
                obj.transform.parent = null;
            }
        }
    }
}