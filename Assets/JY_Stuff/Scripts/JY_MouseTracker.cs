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
            var structure = transform.Find("HeldStructure");

            if(structure != null)
            {
                structure.name = "PlacedStructure";

                if (structure.GetComponent<JY_Structure>() != null)
                {
                    structure.GetComponent<JY_Structure>().collisionGeometry.SetActive(true);
                }

                structure.transform.parent = null;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            var structure = transform.Find("HeldStructure");

            if (structure != null)
            {
                Destroy(structure.gameObject);
            }
        }

        if (Input.GetKeyDown(KeyCode.Period))
        {
            var structure = transform.Find("HeldStructure");

            if (structure != null && structure.GetComponent<JY_Structure>() != null)
            {
                structure.Rotate(new Vector3(0, 90, 0));
            }
        }

        if (Input.GetKeyDown(KeyCode.Comma))
        {
            var structure = transform.Find("HeldStructure");

            if (structure != null && structure.GetComponent<JY_Structure>() != null)
            {
                structure.Rotate(new Vector3(0, -90, 0));
            }
        }
    }
}