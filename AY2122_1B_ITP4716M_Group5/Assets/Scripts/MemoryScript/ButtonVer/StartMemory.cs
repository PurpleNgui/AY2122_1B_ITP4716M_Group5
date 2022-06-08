using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMemory : MonoBehaviour
{
    public GameObject rules;
    public GameObject timer;

    public void StartTheGame()
    {
        rules.SetActive(false);
        timer.SetActive(true);
    }
}
