using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    int playerHP = 3;

    Text playerHPText;

    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        playerHPText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        playerHPText.text = "Player HP: <color=red><b>" + playerHP.ToString() + "</b></color>";
    }

     public void SetPlayerHP(int n)
    {
        GameObject bossAttackTime = GameObject.Find("BossATText");
        GameObject scorer = GameObject.FindGameObjectWithTag("Scorer");

        if (playerHP > 0)
            playerHP -= n;
        else if(playerHP <= 0)
        {
            gameOver.SetActive(true);
            playerHPText.enabled = false;
            bossAttackTime.SetActive(false);
            scorer.SetActive(false);

        }
    }

}
