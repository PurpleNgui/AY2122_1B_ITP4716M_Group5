using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RulesScript : MonoBehaviour
{
    float startTime = 3f;

    public Text startCountDown;

    public GameObject startCountDownText;

    public GameObject nextPageBtn;
    public GameObject lastPageBtn;
    public GameObject closeBtn;
    public GameObject startBtn;

    public GameObject page1;
    public GameObject page2;
    public GameObject page3;

    private int currentPage = 1;

    private static bool IsStartGame = false;


    void Update()
    {
        if (getIsStartGame())
        {
            startCountDownText.SetActive(true);
            if (startTime > 0)
            {
                startTime -= Time.deltaTime;
            }
            else
            {
                startCountDownText.SetActive(false);
                Destroy(this.gameObject);
            }
            startCountDown.text = "<color=red><b>" + Mathf.Ceil(startTime).ToString() + "</b></color>";
        }
    }

    public void NextPage()
    {
        if(currentPage == 1)
        {
            page1.SetActive(false);
            page2.SetActive(true);
            lastPageBtn.SetActive(true);
            currentPage++;
        }
        else if(currentPage == 2)
        {
            currentPage++;
            page2.SetActive(false);
            page3.SetActive(true);
            startBtn.SetActive(true);
            nextPageBtn.SetActive(false);
            
        }
    }

    public void LastPage()
    {
        if (currentPage == 2)
        {
            page2.SetActive(false);
            page1.SetActive(true);
            nextPageBtn.SetActive(true);
            startBtn.SetActive(false);
            currentPage--;
            lastPageBtn.SetActive(false);
        }
        else if(currentPage == 3)
        {
            page3.SetActive(false);
            page2.SetActive(true);
            nextPageBtn.SetActive(true);
            startBtn.SetActive(false);
            currentPage--;
        }
    }

    public void StartGame()
    {
        IsStartGame = true;


    }

    public static bool getIsStartGame()
    {
        return IsStartGame;
    }
}
