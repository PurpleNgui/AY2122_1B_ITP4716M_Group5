using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGenerator : MonoBehaviour
{
    private Vector3 FirstCardPos = Vector3.zero;

    [SerializeField]
    private GameObject CardPrefab;

    private int cardNum = 20;

    private float cardDistance;

    [Header("Material")]
    [SerializeField]
    private List<Material> cardFrontMat;

    [Header("Texture")]
    [SerializeField]
    private List<Texture2D> cardFrontTex;

    //private Dictionary<int, Material> dicCardFrontMat = new Dictionary<int, Material>();
    
    void Start()
    {
        
        GameObject[] cardPos = new GameObject[cardNum];

        cardDistance = CardPrefab.transform.localScale.x * 1.5f;
        FirstCardPos.x = -2f;
        FirstCardPos.y = 1.6f;

        GenerateCard(cardPos);
    }

    void Update()
    {
        
    }

    void GenerateCard(GameObject[] cardPos)
    {
        int[] haveMat = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, };

        //int usedMat = 0;

        for (int row = 0; row < 5; row++)
        {
            FirstCardPos.y = FirstCardPos.y  * (row + 1);

            for (int i = 0; i < cardNum / 5; i += 2)
            {
                GameObject card01 = Instantiate(CardPrefab, FirstCardPos + Vector3.right * (cardDistance * i), Quaternion.identity) as GameObject;

                cardPos[i] = card01;
                card01.transform.Rotate(Vector3.up * 180);

                GameObject card02 = Instantiate(CardPrefab, FirstCardPos + Vector3.right * (cardDistance * (i + 1)), Quaternion.identity) as GameObject;

                cardPos[i + 1] = card02;
                card02.transform.Rotate(Vector3.up * 180);

                int RandomIndex = Random.Range(0, cardFrontMat.Count);
                while (haveMat[RandomIndex] == 2)
                {
                    RandomIndex = Random.Range(0, cardFrontMat.Count);
                }
                card01.GetComponent<Card>().SetCardFrontMat(cardFrontMat[RandomIndex]);
                haveMat[RandomIndex]++;

                RandomIndex = Random.Range(0, cardFrontMat.Count);
                while (haveMat[RandomIndex] == 2)
                {
                    RandomIndex = Random.Range(0, cardFrontMat.Count);
                }
                card02.GetComponent<Card>().SetCardFrontMat(cardFrontMat[RandomIndex]);
                haveMat[RandomIndex]++;

                //card01.GetComponent<Card>().SetCardFrontMat(cardFrontMat[usedMat]);
                //card02.GetComponent<Card>().SetCardFrontMat(cardFrontMat[usedMat]);
                //usedMat++;

                //Mat Version
                //int RandomIndex = Random.Range(0, cardFrontMat.Count);
                //card01.GetComponent<Card>().SetCardFrontMat(cardFrontMat[RandomIndex]);
                //card02.GetComponent<Card>().SetCardFrontMat(cardFrontMat[RandomIndex]);

                /*int RandomIndex = Random.Range(0, cardFrontTex.Count);

                //check is mat already generated
                if (dicCardFrontMat.ContainsKey(RandomIndex))
                {
                    Material oldCardFrontMat = dicCardFrontMat[RandomIndex];
                    card01.GetComponent<Card>().SetCardFrontMat(cardFrontMat[RandomIndex]);
                    card02.GetComponent<Card>().SetCardFrontMat(cardFrontMat[RandomIndex]);
                }
                else
                {
                    Material newCardFrontMat = card01.GetComponent<Card>().SetCardFrontTex(cardFrontTex[RandomIndex]);
                    card02.GetComponent<Card>().SetCardFrontMat(newCardFrontMat);

                    dicCardFrontMat.Add(RandomIndex, newCardFrontMat);
                }*/
            }

            FirstCardPos.y = 1.6f;
        }
        //ResetCard(cardPos);

        //Debug.Log("cardPos[1]: " + cardPos[1].name);
    }

    //public void ResetCard(GameObject[] card)
    //{
    //    GameObject gobjTemp;
    //    int first, second;

    //    for (int i = 0; i < 40; i++)
    //    {
    //        first = Random.Range(0, 20);
    //        second = Random.Range(0, 20);

    //        swapCard(card[first], card[second]);

    //        gobjTemp = card[first];
    //        card[first] = card[second];
    //        card[second] = gobjTemp;
    //    }

    //}

    //private void swapCard(GameObject card1, GameObject card2)
    //{
    //    Vector3 temp = new Vector3(card1.transform.position.x, 
    //                               card1.transform.position.y,
    //                               card1.transform.position.z);

    //    card1.transform.position = Vector3.MoveTowards(card2.transform.position, card1.transform.position, 1);
    //    card2.transform.position = Vector3.MoveTowards(temp, card2.transform.position, 1);
    //}
}
