using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFlyingScript : MonoBehaviour
{
    private float speed;

    private void Start()
    {
        if (TimerScript.GetStartGame())
        {
            speed = Random.Range(6, 11);
        }
    }


    // Update is called once per frame
    void Update()
    {
            transform.Translate(-(speed * Time.deltaTime), 0, 0);
            Destroy(this.gameObject, 5f);

    }


}
