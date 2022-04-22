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

    private Dictionary<int, Material> dicCardFrontMat = new Dictionary<int, Material>();
    
    // Start is called before the first frame update
    void Start()
    {
        
        Vector3[] cardPos = new Vector3[cardNum];

        cardDistance = CardPrefab.transform.localScale.x * 1.5f;
        FirstCardPos.x = -2f;
        FirstCardPos.y = 1.6f;

        GenerateCard(cardPos);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateCard(Vector3[] cardPos)
    {
        for (int row = 1; row <= 5; row++)
        {
            FirstCardPos.y = FirstCardPos.y  * row;

            for (int i = 0; i < cardNum / 5; i += 2)
            {
                GameObject card01 = Instantiate(CardPrefab, FirstCardPos + Vector3.right * (cardDistance * i), Quaternion.identity) as GameObject;

                cardPos[i] = card01.transform.position;
                card01.transform.Rotate(Vector3.up * 180);

                GameObject card02 = Instantiate(CardPrefab, FirstCardPos + Vector3.right * (cardDistance * (i + 1)), Quaternion.identity) as GameObject;

                cardPos[i + 1] = card02.transform.position;
                card02.transform.Rotate(Vector3.up * 180);

                //Mat Version
                //int RandomIndex = Random.Range(0, cardFrontMat.Count);
                //card01.GetComponent<Card>().SetCardFrontMat(cardFrontMat[RandomIndex]);
                //card02.GetComponent<Card>().SetCardFrontMat(cardFrontMat[RandomIndex]);

                int RandomIndex = Random.Range(0, cardFrontTex.Count);

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
                }
            }

            FirstCardPos.y = 1.6f;
        }
    }
}
