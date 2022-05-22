using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField]
    private GameObject cardGenerator;

    [SerializeField]
    private GameObject timerText;

    [SerializeField]
    private GameObject titleText;

    [SerializeField]
    private GameObject startButton;

    public void StartTheGame()
    {
        titleText.SetActive(false);
        startButton.SetActive(false);
        cardGenerator.SetActive(true);
        timerText.SetActive(true);
    }

}
