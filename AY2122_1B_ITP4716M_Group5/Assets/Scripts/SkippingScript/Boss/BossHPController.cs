using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHPController : MonoBehaviour
{
    private float disappear = 3f;

    public Slider bossHP;

    public GameObject win;

    [SerializeField]
    private GameObject bgm;

    [SerializeField]
    private GameObject defeat;

    public Animator bossAnimator;

    //bool end = false;

    public AudioClip injredSound;

    GameObject bossAttackTime;
    GameObject scorer;

    void Start()        //設BossHPA最大量 = 1
    {
        bossHP.value = 1;
        bgm.SetActive(true);
        defeat.SetActive(false);
        bossAttackTime = GameObject.Find("BossATText");
        scorer = GameObject.Find("Scorer");


    }

    private void Update()
    {
        if (win.activeInHierarchy)
        {
            disappear -= Time.deltaTime;
            if (disappear <= 0)
            {
                GameObject boss = GameObject.FindGameObjectWithTag("Boss");
                Destroy(boss);
            }
        }
    }

    public void AttackBoss()        //玩家攻擊Boss(血量-20%)  重設跳繩次數 = 0  重設Boss攻擊時間  血量 <= 0(Boss和BossHP會消失, 跳出WIN信息)
    {
        if (bossHP.value > 0)
        {
            GameObject bat = GameObject.Find("BossATText");

            ScoreCount.ResetScore();
            bossHP.value -= 0.2f;
            bossAnimator.SetTrigger("isInjred 0");
            AudioSource.PlayClipAtPoint(injredSound, transform.position);

            bat.SendMessage("ResetAttackTime");
        }
        else    
        {
            //GameObject boss = GameObject.FindGameObjectWithTag("Boss");

            //end = true;
            bossAnimator.SetBool("isDead", true);
            AudioSource.PlayClipAtPoint(injredSound, transform.position);
            //Destroy(boss);
            //bossHP.enabled = false;

            bossAttackTime.SetActive(false);
            scorer.SetActive(false);

            win.SetActive(true);

            bgm.SetActive(false);
            defeat.SetActive(true);

            
        }
    }

    //public bool GetEnd()
    //{
    //    return end;
    //}

}
