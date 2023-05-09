using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject card0;
    public GameObject target0;

    void Start()
    {
        
        //target±¸ÇÏ°í
        
        
    }

    // Update is called once per frame
    void Update()
    {
        card0.transform.position = Vector3.MoveTowards(card0.transform.position, 
                                        target0.transform.position, 3*Time.deltaTime);


    }
}
