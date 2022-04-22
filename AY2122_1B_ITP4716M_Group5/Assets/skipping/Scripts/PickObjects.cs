using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickObjects : MonoBehaviour
{
    private Transform pickObj = null;
    RaycastHit hit;
    float dist;
    Vector3 newPos;
    Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.green);
            if (!pickObj)
            {
                if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Pickable")
                {
                    pickObj = hit.transform;
                    pickObj.GetComponent<Rigidbody>().isKinematic = true;
                    dist = hit.distance;
                    offset = pickObj.position - hit.point;
                }
            }
            else
            {
                newPos = ray.GetPoint(dist) + offset;
                pickObj.position = newPos;
            }
        }
        else
        {
            if (pickObj != null)
            {
                pickObj.GetComponent<Rigidbody>().isKinematic = false;
            }
            pickObj = null;
        }

    }

}
