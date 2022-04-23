using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBloodItemScript : MonoBehaviour
{
    public Transform target;

    GameObject playerHPText;

    // Start is called before the first frame update
    void Start()
    {
        playerHPText = GameObject.Find("PlayerHPText");
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            playerHPText.SendMessage("SetPlayerHP", -1);
            Destroy(this.gameObject);
        }
    }
}
