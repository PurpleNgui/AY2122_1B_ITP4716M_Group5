using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject mainmenu;

    [SerializeField]
    private GameObject option;

    [SerializeField]
    private GameObject Camera;

    void Start()
    {
        option.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Mainmenu()
    {
        mainmenu.SetActive(false);
    }
    public void Option()
    {
        option.SetActive(true);
    }

    public void Back()
    {
        option.SetActive(false);
        mainmenu.SetActive(true);
    }
    public void MuteOn()
    {
        AudioListener.volume = 1;
    }
    public void MuteOff()
    {
        AudioListener.volume = 0;
    }
}
