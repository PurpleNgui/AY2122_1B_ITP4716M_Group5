using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownAttackSpeedScript : MonoBehaviour
{
    private float speed = 10f;

    private float time = 5f;

    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        transform.Translate((-Vector3.forward) * speed * Time.deltaTime, Space.World);

     
         time -= Time.deltaTime;
        if (time <= 0)
        {
                     TurnTheRope.setRopeSpeed(-100);
                      Destroy(this.gameObject);
            time = 5f;
        }
  

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            TurnTheRope.setRopeSpeed(-100);
            Destroy(this.gameObject);
        }
    }

    private void OnMouseDown() 
    {
        Destroy(this.gameObject);
    }
}
