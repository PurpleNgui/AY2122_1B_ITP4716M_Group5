using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    float missTime = 3f;
    float successTime = 1f;
    float aasTime = 5f;
    float dasTime = 4f;
    float startTime = 3f;

    public Text startCountDown;

    public GameObject startCountDownText;
    public GameObject missText;
    public GameObject successText;
    public GameObject Birds;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreatBird", Random.Range(4, 9), Random.Range(5, 11));
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

        if (RulesScript.getIsStartGame())
        {
            startCountDownText.SetActive(true);
            if (startTime > 0)
            {
                startTime -= Time.deltaTime;
            }
            else
            {
                startCountDownText.SetActive(false);
            }
            startCountDown.text = "<color=red><b>" + Mathf.Ceil(startTime).ToString() + "</b></color>";
        }
    }

    public void CreatBird()
    {
        float y;
        y = Random.Range(1, 4);

        Instantiate(Birds, new Vector3(17f, y, 9.3f), Quaternion.identity);
    }
}
