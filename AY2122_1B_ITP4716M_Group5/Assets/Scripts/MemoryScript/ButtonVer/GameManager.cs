using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Sprite[] cardFront;

    [SerializeField]
    private Sprite cardBack;

    [SerializeField]
    private GameObject[] cards;
    
    [SerializeField]
    private GameObject winText;

    [SerializeField]
    private GameObject returnButton;

    private bool _init = false;
    private int _matches = 10;

    void Update()
    {
        if (!_init)
            initializeCards();

        if (Input.GetMouseButtonUp(0))
            checkCards();
    }

    void initializeCards()
    {
        for (int id = 0; id < 2; id++)
        {
            for (int i = 1; i < 11; i++)
            {
                bool test = false;
                int choice = 0;
                while (!test)
                {
                    choice = Random.Range(0, cards.Length);
                    test = !(cards[choice].GetComponent<ButtonCard>().initialized);
                }
                cards[choice].GetComponent<ButtonCard>().cardValue = i;
                cards[choice].GetComponent<ButtonCard>().initialized = true;
            }
        }

        foreach (GameObject c in cards)
            c.GetComponent<ButtonCard>().setupGraphics();

        if (!_init)
            _init = true;
    }

    public Sprite getCardBack()
    {
        return cardBack;
    }

    public Sprite getCardFront(int i)
    {
        return cardFront[i - 1];
    }

    void checkCards()
    {
        List<int> c = new List<int>();

        for (int i = 0; i < cards.Length; i++)
        {
            if (cards[i].GetComponent<ButtonCard>().state == 1)
                c.Add(i);
        }

        if (c.Count == 2)
            cardComparison(c);
    }

    void cardComparison(List<int> c)
    {
        ButtonCard.DO_NOT = true;

        int x = 0;

        if (cards[c[0]].GetComponent<ButtonCard>().cardValue == cards[c[1]].GetComponent<ButtonCard>().cardValue)
        {
            x = 2;
            _matches--;
            if (_matches == 0)
            {
                winText.SetActive(true);
                returnButton.SetActive(true);
            }
        }

        for (int i = 0; i < c.Count; i++)
        {
            cards[c[i]].GetComponent<ButtonCard>().state = x;
            cards[c[i]].GetComponent<ButtonCard>().falseCheck();
        }
    }
}
