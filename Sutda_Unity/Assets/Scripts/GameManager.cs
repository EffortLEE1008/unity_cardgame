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

        for (int i = 0; i < card.Length; i++)
        {
            card[i].transform.position = Vector3.MoveTowards(card[i].transform.position,
                                target[i].transform.position, 3 * Time.deltaTime);

        }



    }

    public void GameStart()
    {
        //to do 작성
        //StartCoroutine(MoveCard( ));       
 
    }

    IEnumerator MoveCard(GameObject my_card, GameObject goal)//GameObject my_card, GameObject goal
    {

        while (timer <= 5)
        {
            timer = timer + Time.deltaTime;
            my_card.transform.position = Vector3.MoveTowards(my_card.transform.position, goal.transform.position,
                                                                   5*Time.deltaTime);

            yield return null;
        }
        if (timer >= 5)
        {
            Debug.Log("timer가 5를 넘겼습니다.");
        }


    }

   



}
