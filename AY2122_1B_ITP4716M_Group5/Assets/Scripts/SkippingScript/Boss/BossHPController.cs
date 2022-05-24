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

    public Animator bossAnimator;

    void Start()        //�]BossHPA�̤j�q = 1
    {
        bossHP.value = 1;
        bgm.SetActive(true);
        defeat.SetActive(false);

    }

    public void AttackBoss()        //���a����Boss(��q-20%)  ���]��÷���� = 0  ���]Boss�����ɶ�  ��q <= 0(Boss�MBossHP�|����, ���XWIN�H��)
    {
        GameObject bat = GameObject.Find("BossATText");

        ScoreCount.ResetScore();
        bossHP.value -= 0.2f;
        bossAnimator.SetBool("isInjred", true);

        bat.SendMessage("ResetAttackTime");

        if (bossHP.value <= 0)     
        {
            GameObject boss = GameObject.FindGameObjectWithTag("Boss");

            bossAnimator.SetBool("isDead", true);
            //Destroy(boss);
            win.SetActive(true);
            bossHP.enabled = false;
            bgm.SetActive(false);
            defeat.SetActive(true);

            
        }
    }

}
