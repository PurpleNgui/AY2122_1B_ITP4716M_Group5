using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownTimer : MonoBehaviour
{
    public float timer = 10;

    [SerializeField]
    private float minute = 0;

    [SerializeField]
    private float second = 0;
    public bool isRunning = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        minute = Mathf.FloorToInt(timer / 60);
        if (minute < 0)
        {
            minute = 0;
        }

        second = Mathf.FloorToInt(timer % 60);
        if (second < 0)
        {
            second = 0;
        }

        if (timer > 0 && isRunning)
        {
            timer -= Time.deltaTime;
        }
        else if (timer > 0 && !isRunning)
        {
            Debug.Log("Pause");
        }
        else if (timer < 0 && isRunning)
        {
            isRunning = false;
            Debug.Log("Time's up");
        }
    }
}
