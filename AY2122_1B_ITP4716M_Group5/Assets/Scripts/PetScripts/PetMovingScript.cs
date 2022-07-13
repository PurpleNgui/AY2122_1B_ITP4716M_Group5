using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PetMovingScript : MonoBehaviour
{
    private GameObject player;
    private GameObject food;
    private NavMeshAgent nav;

    //public GameObject copyFood;

    bool haveFood = true;
    //bool haveCopyFood = false;

    Vector3 foodPos;
    //Vector3 copyFoodPos;
    private int eat = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        food = GameObject.Find("Food");
        nav = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //moving + lookAt
        if (Vector3.Distance(player.transform.position, transform.position) > 5f)
        {
            //Debug.Log("move");
            nav.SetDestination(player.transform.position);
            transform.LookAt(player.transform.position);
        }
        else //Debug.Log("stop");
        {
            //find food, no food>stop finding
            if (haveFood) 
            { 
                foodPos = food.transform.position;
            }
            else/* if(haveCopyFood)*/
            {
                //copyFood = GameObject.Find("Food(Clone)");
                //copyFoodPos = copyFood.transform.position;
                return;
            }
            //else if(haveFood == false || haveCopyFood== false)
            //{
            //    CreateFood();

            //}

               

            //lookAt food || player
            if (foodPos.y > 0.7f)
            {
                transform.LookAt(food.transform.position);

            }
            else/* if(foodPos.y <= 0.7f || ateFood==true)*/
            {
                transform.LookAt(player.transform.position);
            } 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name=="Food")
        {
            eat++;
            if(eat == 0)
            {
                this.gameObject.transform.localScale *= 1.25f;
                Destroy(collision.gameObject);

                haveFood = false;
                //haveCopyFood = false;
            }
            else
            {
                Destroy(collision.gameObject);

                haveFood = false;
                //haveCopyFood = false;
            }
        }
    }

    //void CreateFood()
    //{
    //    Instantiate(copyFood, new Vector3(-4.7f, 3.3f, -7.5f), Quaternion.identity);
    //    haveCopyFood = true;
    //}
}
