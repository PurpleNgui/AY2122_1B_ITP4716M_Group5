using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFlyingScript : MonoBehaviour
{
    private float speed = 6f;
    private float times/* = Random.Range(1, 10)*/;

    public GameObject copy;



    // Update is called once per frame
    void Update()
    {
        times -= Time.deltaTime;
        if(times <= 0)
        {
            transform.Translate(-(speed * Time.deltaTime), 0, 0);  
        }

    }

    //void OnTriggerEnter(Collider col)
    //{
    //    if (col.CompareTag("Player"))
    //    {
    //        Instantiate(copy, new Vector3(17f, 1.5f, 9.3f), Quaternion.identity);

    //        Destroy(this);
    //    }
    //}


}
