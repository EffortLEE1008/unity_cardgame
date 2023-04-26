using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_card : MonoBehaviour
{
    Rigidbody2D my_rigid;

    Vector3 my_position;
    Vector3 goal_position;
    Vector3 next_position;

    [SerializeField]
    GameObject goal;

    
    void Start()
    {
        my_rigid = GetComponent<Rigidbody2D>();
        my_position = transform.position;

        goal_position = goal.transform.position;

        next_position = goal_position - my_position;

        

        Debug.Log("my_position : " + my_position);
        Debug.Log("goal_position : " + goal_position);
        Debug.Log("changeposition : " + next_position);
        Debug.Log("next_position¿« normal : " + next_position.normalized);

    }

    // Update is called once per frame
    void Update()
    {

        next_position = goal_position - transform.position;
        //transform.position = transform.position + goal_position.normalized * Time.deltaTime;
        //transform.position = transform.position + next_position.normalized * Time.deltaTime;

        //my_rigid.MovePosition(transform.position + next_position.normalized *15* Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, goal_position, 3 * Time.deltaTime);

    }



}
