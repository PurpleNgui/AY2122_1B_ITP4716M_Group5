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
    private GameObject MusicOn;

    [SerializeField]
    private GameObject MusicOff;

    void Start()
    {
        option.SetActive(false);
        SetSoundState();
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
    //public void Mute()
    //{
    //    if (PlayerPrefs.GetInt("Muted", 0) == 0)
    //    {
    //        PlayerPrefs.SetInt("Muted", 1);
    //    }
    //    else
    //    {
    //        PlayerPrefs.SetInt("Muted", 0);
    //    }

    //    SetSoundState();
    //}

    public void MuteOn()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            PlayerPrefs.SetInt("Muted", 1);
        }

        SetSoundState();
    }

    public void MuteOff()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 1)
        {
            PlayerPrefs.SetInt("Muted", 0);
        }

        SetSoundState();
    }

    public void SetSoundState()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            AudioListener.volume = 1;
            MusicOn.SetActive(true);
            MusicOff.SetActive(false);
        }
        else
        {
            AudioListener.volume = 0;
            MusicOn.SetActive(false);
            MusicOff.SetActive(true);
        }
    }
}
