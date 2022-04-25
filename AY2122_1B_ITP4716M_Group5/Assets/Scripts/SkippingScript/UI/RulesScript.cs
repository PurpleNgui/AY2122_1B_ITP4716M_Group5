using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RulesScript : MonoBehaviour
{
    public GameObject nextPageBtn;
    public GameObject lastPageBtn;
    public GameObject closeBtn;
    public GameObject startBtn;

    public GameObject page1;
    public GameObject page2;
    public GameObject page3;

    private int currentPage = 1;

    private bool IsStartGame = false;

    // Start is called before the first frame update
    void Start()
    {
        //page1.SetActive(false);
    }

    public void NextPage()
    {
        Debug.Log("touched, now in page" + currentPage);
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
        if(currentPage == 2)
        {
            page2.SetActive(false);
            page1.SetActive(true);
            currentPage--;
            lastPageBtn.SetActive(false);
        }
        else if(currentPage == 3)
        {
            page3.SetActive(false);
            page2.SetActive(true);
            nextPageBtn.SetActive(true);
            currentPage--;
        }
    }


}
