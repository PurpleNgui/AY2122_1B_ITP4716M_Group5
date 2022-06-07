using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnTheRope : MonoBehaviour
{
    private static float speed = 200f;

    public AudioClip skipsound;

    [SerializeField]
    private int invalidShipping = 0;

    private bool miss = false;

    public GameObject successText;
    public GameObject missText;


    // Update is called once per frame
    void Update()
    {
        if(TimerScript.GetStartGame() == true && TimerScript.GetEndGame() == false) {
            transform.Rotate(Vector3.right * speed * Time.deltaTime);
        }

    }

    public static void setRopeSpeed(int n)
    {
        speed += n;
    }

    public static float getRopeSpeed()
    {
        return speed;
    }

    void OnTriggerEnter(Collider col) 
    {
        //if (col.CompareTag("Player") && col.CompareTag("Scorer"))
        //{
        //    invalidShipping += 1;
        //    miss = true;
        //    missText.SetActive(true);

        //    if (invalidShipping >= 2)
        //    {
        //        ScoreCount.ResetScore();
        //        invalidShipping = 0;
        //    }
        //}

        if (col.CompareTag("Player"))
        {
            Debug.Log("touch");
            invalidShipping += 1;
            miss = true;
            missText.SetActive(true);

            if (invalidShipping >= 2)
            {
                ScoreCount.ResetScore();
                invalidShipping = 0;
            }
        }

        if (col.CompareTag("Scorer"))
        {
            if (!miss)
            {
                ScoreCount.UpdateScore(1);
                successText.SetActive(true);
            }
            else
                miss = false;
            AudioSource.PlayClipAtPoint(skipsound, transform.position);


            if (ScoreCount.score >= 5)
            {
                     GameObject boss = GameObject.FindGameObjectWithTag("Boss");
                    boss.SendMessage("AttackBoss");
            }
        }
    }

   
}
