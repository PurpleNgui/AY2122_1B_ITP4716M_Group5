using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAttackSpeedScript : MonoBehaviour
{
    private float speed = 10f;

    public Transform target;

    void Start()
    {

    }

    void Update()
    {
        transform.LookAt(target);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

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
