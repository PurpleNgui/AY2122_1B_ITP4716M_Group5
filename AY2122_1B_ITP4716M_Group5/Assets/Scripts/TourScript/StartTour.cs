using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTour : MonoBehaviour
{
    public GameObject rules;

    public void StartTheGame()
    {
        rules.SetActive(false);
    }
}
