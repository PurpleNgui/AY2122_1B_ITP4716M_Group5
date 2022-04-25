using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void triggerMenu(int i)
    {
        switch(i)
        {
            default:
            case(0):
                SceneManager.LoadScene("MemoryScene");
                break;
            case(1):
                Application.Quit();
                break;
        }
    }
}
