using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMemory : MonoBehaviour
{

    [SerializeField]
    private GameObject FPSController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "FPSController")
        {
            //Debug.Log("Touch");
            SceneManager.LoadScene("MemoryGameScene");
            //FPSController.SetActive(false);
        }
    }
}
