using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GameManager : MonoBehaviour
{
    public GameObject[] card;
    public GameObject[] target;

    public Sprite[] my_sprite;
    bool isstart=true;
    bool isbatting = true;

    SpriteRenderer[] card_info = new SpriteRenderer[8];

    float timer = 0;

    List<string> player0 = new List<string>();
    List<string> computer1 = new List<string>();
    List<string> computer2 = new List<string>();
    List<string> computer3 = new List<string>();

    public List<string> player_card_list = new List<string>();
    public List<int> player_value_list = new List<int>();

    void Start()
    {
        
        for (int i = 0; i < card_info.Length; i++)
        {
            card_info[i] = card[i].GetComponent<SpriteRenderer>();
        }

        card_info[0].sprite = my_sprite[11];
        card_info[1].sprite = my_sprite[1];

        card_info[2].sprite = my_sprite[2];
        card_info[3].sprite = my_sprite[6];

        card_info[4].sprite = my_sprite[13];
        card_info[5].sprite = my_sprite[16];

        card_info[6].sprite = my_sprite[12];
        card_info[7].sprite = my_sprite[10];

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameStart()
    {
        if (isstart)
        {
            
            isstart = false;
            for (int i = 0; i < card.Length; i++)
            {
                StartCoroutine(MoveCard(card[i], target[i]));

                if (i == 2 || i == 3)
                {
                    card[i].transform.Rotate(Vector3.back * 90);
                    //card[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
                }
                else if (i == 4 || i == 5)
                {
                    card[i].transform.Rotate(Vector3.back * 180);
                }
                else if (i == 6 || i == 7)
                {
                    card[i].transform.Rotate(Vector3.back * 270);
                }
            }
        }      
    }
    public void CardRotate() 
    {

        card[3].transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
        card[2].transform.Rotate(Vector3.back * 90);

    }

    public void Batting()
    {
        if (isbatting)
        {
            isbatting = false;

            player0.Add(card_info[0].sprite.name);
            player0.Add(card_info[1].sprite.name);
            player0.Sort();

            computer1.Add(card_info[2].sprite.name);
            computer1.Add(card_info[3].sprite.name);
            computer1.Sort();

            computer2.Add(card_info[4].sprite.name);
            computer2.Add(card_info[5].sprite.name);
            computer2.Sort();

            computer3.Add(card_info[6].sprite.name);
            computer3.Add(card_info[7].sprite.name);
            computer3.Sort();

            player_card_list.Add(player0[0] + player0[1]); // bB
            player_card_list.Add(computer1[0] + computer1[1]);
            player_card_list.Add(computer2[0] + computer2[1]);
            player_card_list.Add(computer3[0] + computer3[1]);

            for (int i = 0; i <player_card_list.Count; i++)
            {
                if (jokbo.ContainsKey(player_card_list[i]))// true false
                {
                    player_value_list.Add(jokbo[player_card_list[i]]);
                }
                else
                {
                    player_value_list.Add((not_in_jokbo[player_card_list[i][0].ToString()] +
                                          not_in_jokbo[player_card_list[i][1].ToString()]) % 10);              
                }

            }

            bool isDDang = false;
            for (int i = 0; i <player_card_list.Count; i++)
            {
                if (ddang_list.Contains(player_card_list[i]))
                {
                    isDDang = true;
                    break;
                }

            }

            if (isDDang)
            {
                for (int i = 0; i < player_card_list.Count; i++)
                {
                    if (ddangkiller_list.Contains(player_card_list[i]))
                    {
                        player_value_list[i] = 400;
                    }

                }
                
            }

            bool isGyangDDang = false;

            for (int i = 0; i < player_card_list.Count; i++)
            {
                if (gyangddang_list.Contains(player_card_list[i]))
                {
                    isGyangDDang = true;
                    break;
                }

            }

            if (isGyangDDang)
            {
                for (int i = 0; i < player_card_list.Count; i++)
                {
                    if (player_card_list[i] == "DG")
                    {
                        player_value_list[i] = 1800;
                    }

                }

            }






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

        Debug.Log("ÄÚ¸£Æ¾ Á¾·á");

    }

    Dictionary<string, int> jokbo = new Dictionary<string, int>()
            {

                {"aA",200 }, {"bB", 220 }, {"cC", 240 }, {"dD", 260 }, {"eE", 280 }, {"fF", 300 },
                {"gG", 320 }, {"hH", 340 }, {"iI", 360 }, {"jJ", 380 },

                {"df", 40 }, {"dF", 40 }, {"Df", 40 }, {"DF", 40 }, //¼¼·ú
                {"ai", 50 }, {"aI", 50 }, {"Ai", 50 }, {"AI", 50 }, //±¸»æ
                {"dj", 60 }, {"dJ", 60 }, {"Dj", 60 }, {"DJ", 60 }, //Àå»ç
                {"ad", 70 }, {"aD", 70 }, {"Ad", 70 }, {"AD", 70 }, //µ¶»ç
                {"aj", 80 }, {"aJ", 80 }, {"Aj", 80 }, {"AJ", 80 }, //Àå»æ
                {"ab", 90 }, {"aB", 90 }, {"Ab", 90 }, {"AB", 90 }, //¾Ë¸®

                {"AC", 1300 }, {"AH", 1300 }, {"CH", 3800 } //±¤¶¯

            };

    Dictionary<string, int> not_in_jokbo = new Dictionary<string, int>()
            {
                {"a", 1 }, {"b", 2 }, {"c", 3 }, {"d", 4 }, {"e", 5 }, {"f", 6 }
                , {"g", 7 }, {"h", 8 }, {"i", 9 }, {"j", 10 },
                {"A", 1 }, {"B", 2 }, {"C", 3 }, {"D", 4 }, {"E", 5 }, {"F", 6 }
                , {"G", 7 }, {"H", 8 }, {"I", 9 }, {"J", 10 }
            };
    List<string> ddang_list = new List<string>()
            {
                "aA", "bB", "cC", "dD", "eE", "fF", "gG", "hH", "iI", "jJ"
            };

    List<string> ddangkiller_list = new List<string>()
            {
                "cg", "Cg", "cG", "CG"
            };

    List<string> gyangddang_list = new List<string>()
            {
                "AC", "AH"
            };




}
