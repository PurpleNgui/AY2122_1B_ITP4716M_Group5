using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRotate : MonoBehaviour
{
    private float anglePerFrame = 2;

    private float targetRotY;
    private float fCurrentRotY;

    // Start is called before the first frame update
    void Start()
    {
        fCurrentRotY = transform.rotation.y;
    }

    // Update is called once per frame
    private void Update()
    {
        if (IsRotate())
        {
            transform.Rotate(Vector3.up * anglePerFrame);
            fCurrentRotY += anglePerFrame;
        }
    }

    bool IsRotate()
    {
        return targetRotY > fCurrentRotY;
    }

    void OnMouseDown()
    {
        if (!IsRotate())
        {
            targetRotY += 180;
        }
    }

    //public GameObject getSelectedCard()
    //{
    //    return
    //}
}
