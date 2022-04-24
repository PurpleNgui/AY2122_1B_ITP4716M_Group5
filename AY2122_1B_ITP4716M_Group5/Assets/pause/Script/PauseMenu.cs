using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseUI;

    [SerializeField]
    private bool IsPause;

    [SerializeField]
    private GameObject option;

    [SerializeField]
    private GameObject FPSController;

    [SerializeField]
    FirstPersonController fpc;

    // Start is called before the first frame update
    void Start()
    {
        pauseUI.SetActive(false);
        option.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPause)
            {
                Resume();
                option.SetActive(false);
                fpc.SetCursorLock(true);
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        IsPause = false;
        fpc.SetCursorLock(true);
        AudioListener.volume = 1;
    }

    public void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        IsPause = true;
        AudioListener.volume = 0;
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start menu");
        FPSController.SetActive(false);
    }
    public void Option()
    {
        option.SetActive(true);
        pauseUI.SetActive(false);
        fpc.SetCursorLock(false);
    }

    public void Back()
    {
        pauseUI.SetActive(true);
        option.SetActive(false);
    }
    public void Lobby()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
        FPSController.SetActive(false);
    }
    public void MuteOn()
    {
        AudioListener.volume = 1;
        fpc.SetCursorLock(false);
    }
    public void MuteOff()
    {
        AudioListener.volume = 0;
        fpc.SetCursorLock(false);
    }
}

