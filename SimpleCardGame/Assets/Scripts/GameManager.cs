using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    

    [SerializeField]
    GameObject[] card_array; 


    [SerializeField]
    SpriteRenderer[] sr_array;
    

    public Sprite[] my_sprites;

    bool isflush = false;
    bool ismount = false;
    bool isstraight = false;
    int paircount = 0;

    List<string> card_list = new List<string>();
    List<int> card_list_numonly = new List<int>();
    List<string> card_list_shapeonly = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        //렌더러를 활용하여 sprite 변경
        for (int i = 0; i < card_array.Length; i++)
        {
            sr_array[i] = card_array[i].GetComponent<SpriteRenderer>();
            sr_array[i].sprite = my_sprites[i];
            card_list.Add(sr_array[i].sprite.name);
            card_list_numonly.Add(int.Parse(sr_array[i].sprite.name.Substring(0, 2)));
            card_list_shapeonly.Add(sr_array[i].sprite.name.Substring(2, 1));
        }

        card_list_numonly.Sort();
        card_list_shapeonly.Sort();



        Batting();

        Debug.Log(card_list[0] + " " + card_list[1] + " " + card_list[2] + " "
            + card_list[3]+ " " + card_list[4]);


    }

    // Update is called once per frame
    void Update()
    {
        
    }




    void Batting()
    {
        if (card_list_shapeonly[0] == card_list_shapeonly[card_list_shapeonly.Count - 1])
        {
            isflush = true;
        }

        if ((card_list_numonly[0] == 6) && (card_list_numonly[1] == 10) && (card_list_numonly[2] == 11) &&
            (card_list_numonly[3] == 12) && (card_list_numonly[4] == 13))
        {
            ismount = true;

        }

        for (int i = 0; i < card_list_numonly.Count - 1; i++)
        {
            if (card_list_numonly[i + 1] - card_list_numonly[i] == 1)
            {
                isstraight = true;

            }
            else
            {
                isstraight = false;
                break;
            }

        }


        for (int i = 0; i < card_list_numonly.Count - 1; i++)
        {
            for (int j = i + 1; j < card_list_numonly.Count; j++)
            {


                if (card_list_numonly[i] == card_list_numonly[j])
                {
                    paircount++;

                }

            }

        }


        if (isflush && ismount)
        {
            Debug.Log("축하합니다. 로티플이에요");
        }
        else if (isflush && isstraight)
        {
            Debug.Log("축하합니다 스트레이트 플러쉬에요");
        }
        else if (paircount == 6)
        {
            Debug.Log("축하합니다 포카드입니다.");
        }
        else if (paircount == 4)
        {
            Debug.Log("축하합니다 풀하우스에요.");
        }
        else if (isflush)
        {
            Debug.Log("축하합니다 플러쉬에요");
        }
        else if (ismount)
        {
            Debug.Log("축하합니다 마운틴입니다.");
        }
        else if (isstraight)
        {
            Debug.Log("축하합니다 스트레이트입니다.");
        }
        else if (paircount == 3)
        {
            Debug.Log("축하합니다 트리플입니다.");
        }
        else if (paircount == 2)
        {
            Debug.Log("아쉽네요 투페어");
        }
        else if (paircount == 1)
        {
            Debug.Log("아쉽네요 원페어");
        }
        else
        {
            Debug.Log("아무것도 아닌 탑카드에요");
        }





    }
}
