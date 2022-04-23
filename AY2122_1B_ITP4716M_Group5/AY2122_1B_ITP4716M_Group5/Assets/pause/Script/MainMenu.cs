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
        SceneManager.LoadScene("Pause menu");
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
}
