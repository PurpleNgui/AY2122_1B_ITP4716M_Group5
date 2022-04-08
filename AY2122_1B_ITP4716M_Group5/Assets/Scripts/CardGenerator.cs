using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject CardPrefab;

    int row = 4;
    int column = 5;

    float hDistance = 0.2f;
    float vDistance = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        float cameraDistance = 0.8f;
        Vector3 center = Camera.main.transform.position + Vector3.forward * cameraDistance;

        float leftPos = -((column - 1) / 2f);
        float topPos = (row - 1) / 2f;

        float cardWidth = CardPrefab.transform.localScale.x;
        float cardHeight = CardPrefab.transform.localScale.y;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
