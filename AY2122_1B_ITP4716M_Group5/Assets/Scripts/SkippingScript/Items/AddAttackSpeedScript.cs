using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAttackSpeedScript : MonoBehaviour
{
    //private float speed = 10f;

    public Transform target;

    void Start()
    {

    }

    void Update()
    {
        transform.LookAt(target);
        //Debug.DrawLine(transform.position, target.position, Color.green);
        //transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            TurnTheRope.setRopeSpeed(300);
            Destroy(this.gameObject);
        }
    }


}
