using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownAttackSpeedScript : MonoBehaviour
{
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);

       
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
