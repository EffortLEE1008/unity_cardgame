using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    


    public Text changeText;
    

    public Sprite[] my_sprites;

    bool isflush = false;
    bool ismount = false;
    bool isstraight = false;
    

    List<string> card_list = new List<string>();
    List<int> card_list_numonly = new List<int>();
    List<string> card_list_shapeonly = new List<string>();


    List<int> randnum_lst= new List<int>();

    [SerializeField]
    GameObject[] card_array;


    [SerializeField]
    SpriteRenderer[] sr_array;

    // Start is called before the first frame update
    void Start()
    {

        for(int i=0; i < card_array.Length;)
        {
            int randnum = UnityEngine.Random.Range(0, 32);

            if (!randnum_lst.Contains(randnum))
            {
                randnum_lst.Add(randnum);
                i++;
                
            }
            else
            {
                continue;
            }

        }





        changeText.text = "게임을 시작합니다.";




        //렌더러를 활용하여 sprite 변경
        for (int i = 0; i < card_array.Length; i++)
        {
            sr_array[i] = card_array[i].GetComponent<SpriteRenderer>();
            sr_array[i].sprite = my_sprites[randnum_lst[i]];
            Debug.Log(randnum_lst[i]);
            card_list.Add(sr_array[i].sprite.name);
            card_list_numonly.Add(int.Parse(sr_array[i].sprite.name.Substring(0, 2)));
            card_list_shapeonly.Add(sr_array[i].sprite.name.Substring(2, 1));
        }

        card_list_numonly.Sort();
        card_list_shapeonly.Sort();



        

        Debug.Log(card_list[0] + " " + card_list[1] + " " + card_list[2] + " "
            + card_list[3]+ " " + card_list[4]);


    }

    // Update is called once per frame
    void Update()
    {

    }


    public void ReStart()
    {
        SceneManager.LoadScene(0);
    }


    public void Batting()
    {
        int paircount = 0;
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
            changeText.text = "축하합니다. 로티플이에요";
        }
        else if (isflush && isstraight)
        {
            changeText.text = "축하합니다 스트레이트 플러쉬에요";

        }
        else if (paircount == 6)
        {
            changeText.text = "축하합니다 포카드입니다.";
        }
        else if (paircount == 4)
        {

            changeText.text = "축하합니다 풀하우스에요.";
        }
        else if (isflush)
        {
            changeText.text = "축하합니다 플러쉬에요";
        }
        else if (ismount)
        {
            changeText.text = "축하합니다 마운틴입니다.";
        }
        else if (isstraight)
        {
            changeText.text = "축하합니다 스트레이트입니다.";
        }
        else if (paircount == 3)
        {
            changeText.text = "축하합니다 트리플입니다.";
        }
        else if (paircount == 2)
        {
            changeText.text = "아쉽네요 투페어";
        }
        else if (paircount == 1)
        {
            changeText.text = "아쉽네요 원페어";
        }
        else
        {
            changeText.text = "아무것도 아닌 탑카드에요";
        }





    }




}
