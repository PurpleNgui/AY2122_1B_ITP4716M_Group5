using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnTheRope : MonoBehaviour
{
    private static float speed = 200f;

    [SerializeField]
    private int invalidShipping = 0;

    public GameObject successText;
    public GameObject missText;


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right * speed * Time.deltaTime);

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
        if(col.CompareTag("Player"))
        {
            invalidShipping += 1;
            missText.SetActive(true);
            
            if (invalidShipping >= 2)
            {
                ScoreCount.ResetScore();
                invalidShipping = 0;
            }
        }
        if(col.CompareTag("Scorer"))
        {
            ScoreCount.UpdateScore(1);
            successText.SetActive(true);
            
           
            if (ScoreCount.score == 5)
            {
                     GameObject boss = GameObject.FindGameObjectWithTag("Boss");
                    boss.SendMessage("AttackBoss");
            }
        }
    }

   
}
