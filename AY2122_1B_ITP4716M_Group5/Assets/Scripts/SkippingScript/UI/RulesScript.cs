using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RulesScript : MonoBehaviour
{
    private float startCountDownTime = 3f;

    public Text startCountDownTimeText;

    public GameObject startCountDownTimeGO;
    public GameObject nextPageBtn;
    public GameObject lastPageBtn;
    public GameObject closeBtn;
    public GameObject startBtn;

    public GameObject page1;
    public GameObject page2;
    public GameObject page3;

    private int currentPage = 1;

    private bool IsStartGame = false;
    private static bool startGame = false;

    private void Update()
    {
        if (IsStartGame)
        {
            if (startCountDownTime >= 0)
            {
                startCountDownTimeGO.SetActive(true);
                startCountDownTime -= Time.deltaTime;
            }
            else
            {
                Destroy(startCountDownTimeGO, 1f);
                startGame = true;
            }
            startCountDownTimeText.text = Mathf.Ceil(startCountDownTime).ToString();
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
        startBtn.SetActive(false);
    }

    public static bool GetStartGame()
    {
        return startGame;
    }
}
