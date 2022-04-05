using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryGame : MonoBehaviour
{
    CountDownTimer timer;
    float countDown;
    int first;
    int second;

    //[SerializeField]
    //private  TimerGameObject;

    // Start is called before the first frame update
    void Start()
    {
        //TimerGameObject = GameObject.Find("CountDownTimer");
        timer = GetComponent<CountDownTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        countDown = timer.GetTimer();
        Debug.Log("Time = " + countDown);
    }
}
