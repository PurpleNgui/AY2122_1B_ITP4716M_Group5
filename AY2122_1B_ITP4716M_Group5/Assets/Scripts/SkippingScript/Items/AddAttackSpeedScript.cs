using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAttackSpeedScript : MonoBehaviour
{
    private float speed = 10f;

    private Transform Player;

    void Start()
    {
        Player = transform.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        transform.LookAt(Player);
        Debug.DrawLine(transform.position, Player.position, Color.green);
        //transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            TurnTheRope.setRopeSpeed(1);
            Destroy(this);
        }
    }
}
