using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncubationScript : MonoBehaviour
{
    public GameObject pet;

    private int time = 0;


    private void OnMouseDown()
    {
        Debug.Log(time + "touch");
        time++;

        if (time == 10)
        {
            //Vector3 x = transform.right;
            //Vector3 y = transform.forward;

            Instantiate(pet, this.transform.position, Quaternion.identity);

            //Destroy(GameObject.Find("Wall"));
            Destroy(this.gameObject, 1f);


        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Hammer") 
        { 
        Instantiate(pet, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject, 1f);
        }
    }
}
