using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossAttackTime : MonoBehaviour
{
    private float bossAttackTime;
    [SerializeField]
    private float time = 10;



    Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        bossAttackTime = time;
    }

    // Update is called once per frame
    void Update()
    {
        if (RulesScript.GetStartGame())
        {
            GameObject playerHPText = GameObject.Find("PlayerHPText");


            if (bossAttackTime > 0)
            {
                bossAttackTime -= Time.deltaTime;
            }
            else
            {
                playerHPText.SendMessage("SetPlayerHP", 1);
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
