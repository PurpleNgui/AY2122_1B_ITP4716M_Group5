using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField]
    private GameObject cardFront;

    public void SetCardFrontMat(Material cardFrontMat)
    {
        cardFront.GetComponent<Renderer>().material = cardFrontMat;
    }

    public Material SetCardFrontTex(Texture2D cardFrontTex)
    {
        Renderer cardRenderer = cardFront.GetComponent<Renderer>();
        cardRenderer.material.mainTexture = cardFrontTex;
        return cardRenderer.material;
    }
}
