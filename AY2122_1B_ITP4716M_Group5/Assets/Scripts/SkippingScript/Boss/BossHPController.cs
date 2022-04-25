using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHPController : MonoBehaviour
{
    public Slider bossHP;

    public GameObject win;

    [SerializeField]
    private GameObject bgm;

    [SerializeField]
    private GameObject defeat;

    void Start()        //設BossHPA最大量 = 1
    {
        bossHP.value = 1;
        bgm.SetActive(true);
        defeat.SetActive(false);
    }

    public void AttackBoss()        //玩家攻擊Boss(血量-20%)  重設跳繩次數 = 0  重設Boss攻擊時間  血量 <= 0(Boss和BossHP會消失, 跳出WIN信息)
    {
        GameObject bat = GameObject.Find("BossATText");

        ScoreCount.ResetScore();
        bossHP.value -= 0.2f;

        bat.SendMessage("ResetAttackTime");

        if (bossHP.value <= 0)     
        {
            GameObject boss = GameObject.FindGameObjectWithTag("Boss");
            Destroy(boss);
            win.SetActive(true);
            bossHP.enabled = false;
            bgm.SetActive(false);
            defeat.SetActive(true);
        }
    }

}
