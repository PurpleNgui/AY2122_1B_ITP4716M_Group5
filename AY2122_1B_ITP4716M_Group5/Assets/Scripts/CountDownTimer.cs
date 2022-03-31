using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public float timer = 10;

    [SerializeField]
    private float minute = 0;

    [SerializeField]
    private float second = 0;
    public bool isRunning = true;

    [SerializeField]
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        minute = Mathf.Floor(timer / 60);
        if (minute < 0)
        {
            minute = 0;
        }

        second = Mathf.Ceil(timer % 60);
        if (second < 0)
        {
            second = 0;
        }

        if (minute < 10 && second < 10)
        {
            text.text = "0" + minute.ToString() + " : " + "0" + second.ToString();
        }
        else if (minute < 10 && second >= 10)
        {
            text.text = "0" + minute.ToString() + " : " + second.ToString();
        }
        else if (minute >= 10 && second < 10)
        {
            text.text = minute.ToString() + " : " + "0" + second.ToString();
        }
        else
        {
            text.text = minute.ToString() + " : " + second.ToString();
        }

        //Debug.Log("text: "+text.gameObject.name);
        //Debug.Log();
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
