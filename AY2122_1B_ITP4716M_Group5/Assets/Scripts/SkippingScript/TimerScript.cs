using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    float missTime = 3f;
    float successTime = 1f;
    float aasTime = 5f;
    float dasTime = 4f;
    float stophitTime = 3f;

    public GameObject missText;
    public GameObject successText;
    public GameObject Birds;
    public GameObject earth;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreatBird", Random.Range(4, 9), Random.Range(5, 11));
    }

    // Update is called once per frame
    void Update()
    {
        if (earth.activeInHierarchy)
        {
            stophitTime -= Time.deltaTime;
            if (stophitTime <= 0)
            {
                earth.SetActive(false);
                stophitTime = 3;

            }
        }

            if (missText.activeInHierarchy)
        {
            missTime -= Time.deltaTime;
            if (missTime <= 0)
            {
                missText.SetActive(false);
                missTime = 3;
            }
        }

        if (successText.activeInHierarchy)
        {
            successTime -= Time.deltaTime;
            if (successTime <= 0)
            {
                successText.SetActive(false);
                successTime = 1;
            }
        }

        if(TurnTheRope.getRopeSpeed() >= 500)
        {
            aasTime -= Time.deltaTime;
            if (aasTime <= 0)
            {
                TurnTheRope.setRopeSpeed(-300); ;
                aasTime = 5f;
            }
        }
        
        if(TurnTheRope.getRopeSpeed() <= 100)
        {
            dasTime -= Time.deltaTime;
            if (dasTime <= 0)
            {
                TurnTheRope.setRopeSpeed(100); ;
                dasTime = 5f;
            }
        }
    }

    public void CreatBird()
    {
        float y;
        y = Random.Range(1, 4);

        Instantiate(Birds, new Vector3(17f, y, 10f), Quaternion.identity);
    }
}
