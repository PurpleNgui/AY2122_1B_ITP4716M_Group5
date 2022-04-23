using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    float missTime = 3f;
    float successTime = 1f;

    public GameObject missText;
    public GameObject successText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

    }
}
