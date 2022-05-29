using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowItmeScript : MonoBehaviour
{
    public GameObject abItem;
    public GameObject aasItem;
    public GameObject dasItem;

    private GameObject boss;

    public Transform target;

    private float times = 5f;

    private void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss");
    }

    // Update is called once per frame
    void Update()
    {
        if (RulesScript.GetStartGame() && TimerScript.GetEndGame() == false)
        {
            times -= Time.deltaTime;
            if (times <= 0)
            {
                GameObject obj = (GameObject)Instantiate(RandomItem());
                //AddBloodItemScript abItem = obj.GetComponent<AddBloodItemScript>();
                //AddAttackSpeedScript aasItem = obj.GetComponent<AddAttackSpeedScript>();
                //DownAttackSpeedScript dasItem = obj.GetComponent<DownAttackSpeedScript>();

                //abItem.target = target;
                //aasItem.target = target;
                //dasItem.target = target;

                int x = Random.Range(2, 6);
                int y = Random.Range(3, 6);
                //Debug.Log("x: " + x + ", y: " + y);

                obj.transform.position = new Vector3(x, y, 25);

                times = Random.Range(5, 10);
            }
        }
    }

    GameObject RandomItem()
    {

        float randomNum = Random.Range(0, 10);
        //Debug.Log("randomNum: " + randomNum);

        if (randomNum <= 1)
            return abItem;
        else if (randomNum > 1 && randomNum <= 3)
            return aasItem;
        else
            return dasItem;

    }
}
