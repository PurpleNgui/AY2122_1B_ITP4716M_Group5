using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHPController : MonoBehaviour
{
    public Slider bossHP;

    public GameObject win;

    void Start()        //�]BossHPA�̤j�q = 1
    {
        bossHP.value = 1;
    }

    public void AttackBoss()        //���a����Boss(��q-20%)  ���]��÷���� = 0  ���]Boss�����ɶ�  ��q <= 0(Boss�MBossHP�|����, ���XWIN�H��)
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
        }
    }

}
