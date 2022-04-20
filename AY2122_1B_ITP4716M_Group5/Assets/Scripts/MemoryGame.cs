using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryGame : MonoBehaviour
{
    int first;
    int second;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetCard(string[] card)
    {
        string temp;
        int first, second;

        for (int i = 0; i < 40; i++)
        {
            first = Random.Range(0, 20);
            second = Random.Range(0, 20);
            temp = card[first];
            card[first] = card[second];
            card[second] = temp;
        }
    }
}
