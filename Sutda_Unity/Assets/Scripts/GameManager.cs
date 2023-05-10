using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GameManager : MonoBehaviour
{
    public GameObject[] card;
    public GameObject[] target;

    float timer = 0;

    void Start()
    {

        

        
    }

    // Update is called once per frame
    void Update()
    {





    }

    public void GameStart()
    {
        for (int i = 0; i < card.Length; i++)
        {
            StartCoroutine(MoveCard(card[i], target[i]));
        }
           
 
    }

    IEnumerator MoveCard(GameObject my_card, GameObject goal)//GameObject my_card, GameObject goal
    {

        while (timer <= 20)
        {
            timer = timer + Time.deltaTime;
            my_card.transform.position = Vector3.MoveTowards(my_card.transform.position, goal.transform.position,
                                                                   5*Time.deltaTime);

            yield return null;
        }

        Debug.Log("코르틴 종료");

    }

   



}
