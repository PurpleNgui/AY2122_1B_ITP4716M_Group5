using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAttackSpeedScript : MonoBehaviour
{
    private float speed = 10f;

    private float time = 2f;

    //public Transform target;

    void Start()
    {

    }

    void Update()
    {
        //transform.LookAt(target);
        transform.Translate((-Vector3.forward) * speed * Time.deltaTime, Space.World);

        time -= Time.deltaTime;
        if (time <= 0)
        {
            TurnTheRope.setRopeSpeed(300);
            Destroy(this.gameObject);
            time = 2f;
        }

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            TurnTheRope.setRopeSpeed(300);
            Destroy(this.gameObject);
        }
    }

    private void OnMouseDown()
    {
        Destroy(this.gameObject);
    }
}
