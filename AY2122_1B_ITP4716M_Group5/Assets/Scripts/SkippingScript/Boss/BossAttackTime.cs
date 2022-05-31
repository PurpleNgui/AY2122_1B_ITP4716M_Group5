using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossAttackTime : MonoBehaviour
{
    private float bossAttackTime;
    [SerializeField]
    private float time = 10;

    public Animator bossAnimation;

    public GameObject earth;
    

    Text text;

    public AudioSource player;
    public AudioClip palyerInjredSound;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        bossAttackTime = time;
      


    }

    // Update is called once per frame
    void Update()
    {
        if (TimerScript.GetStartGame() && TimerScript.GetEndGame() == false)
        {
            GameObject playerHPText = GameObject.Find("PlayerHPText");
            //GameObject bossATText = GameObject.Find("BossATText");


            if (bossAttackTime > 0)
            {
                bossAttackTime -= Time.deltaTime;
                bossAnimation.SetInteger("isAttack", 0);
    
            }
            else
            {
                bossAnimation.SetInteger("isAttack", 1);

                earth.SetActive(true);

                playerHPText.SendMessage("SetPlayerHP", 1);
                player.PlayOneShot(palyerInjredSound);
                ResetAttackTime();
            }
            text.text = "<color=red><b>" + Mathf.Ceil(bossAttackTime).ToString() + "</b></color>";
        }
    }

    public void ResetAttackTime()
    {
        bossAttackTime = time;
    }
}
