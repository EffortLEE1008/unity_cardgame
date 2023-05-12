using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] card;
    public GameObject[] target;

    public Sprite[] my_sprite;
    SpriteRenderer[] card_info = new SpriteRenderer[8];


    bool isstart = true;
    bool isbatting = true;

    float timer = 0;

    public Text info_text;

    List<string> player0 = new List<string>();
    List<string> computer1 = new List<string>();
    List<string> computer2 = new List<string>();
    List<string> computer3 = new List<string>();

    public List<string> player_card_list = new List<string>();
    public List<int> player_value_list = new List<int>();

    void Start()
    {
        info_text.text = "°ÔÀÓ½ÃÀÛ";
        
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

            player0.Add(card_info[0].sprite.name);
            player0.Add(card_info[1].sprite.name);
            player0.Sort();

            player_card_list.Add(player0[0] + player0[1]); // bB

            if (jokbo.ContainsKey(player_card_list[0]))// true false
            {
                player_value_list.Add(jokbo[player_card_list[0]]);
            }
            else
            {
                player_value_list.Add((not_in_jokbo[player_card_list[0][0].ToString()] +
                                      not_in_jokbo[player_card_list[0][1].ToString()]) % 10);
            }

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

            if (jokbo_string.ContainsKey(player_card_list[0]))
            {
                info_text.text = jokbo_string[player_card_list[0]];

            }
            else
            {
                info_text.text = not_in_jokbo_string[player_value_list[0]];
                
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

            player_card_list.Add(computer1[0] + computer1[1]);
            player_card_list.Add(computer2[0] + computer2[1]);
            player_card_list.Add(computer3[0] + computer3[1]);

            for (int i = 1; i <player_card_list.Count; i++)
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

        int a = 10;

        int tmp = a;

        int c = tmp;

    }

    Dictionary<string, int> jokbo = new Dictionary<string, int>()
            {

                {"aA", 200 }, {"bB", 220 }, {"cC", 240 }, {"dD", 260 }, {"eE", 280 }, {"fF", 300 },
                {"gG", 320 }, {"hH", 340 }, {"iI", 360 }, {"jJ", 380 },

                {"df", 40 }, {"dF", 40 }, {"Df", 40 }, {"DF", 40 }, //¼¼·ú
                {"ai", 50 }, {"aI", 50 }, {"Ai", 50 }, {"AI", 50 }, //±¸»æ
                {"dj", 60 }, {"dJ", 60 }, {"Dj", 60 }, {"DJ", 60 }, //Àå»ç
                {"ad", 70 }, {"aD", 70 }, {"Ad", 70 }, {"AD", 70 }, //µ¶»ç
                {"aj", 80 }, {"aJ", 80 }, {"Aj", 80 }, {"AJ", 80 }, //Àå»æ
                {"ab", 90 }, {"aB", 90 }, {"Ab", 90 }, {"AB", 90 }, //¾Ë¸®

                {"AC", 1300 }, {"AH", 1300 }, {"CH", 3800 } //±¤¶¯

            };

    Dictionary<string, string> jokbo_string = new Dictionary<string, string>()
    {

            {"aA","ÀÏ¶¯" }, {"bB", "ÀÌ¶¯" }, {"cC", "»ï¶¯" }, {"dD", "»ç¶¯" }, {"eE", "¿À¶¯" }, {"fF", "À°¶¯" },
            {"gG", "Ä¥¶¯" }, {"hH", "ÆÈ¶¯" }, {"iI", "±¸¶¯" }, {"jJ", "½Ê¶¯" },

            {"df", "¼¼·ú" }, {"dF", "¼¼·ú" }, {"Df", "¼¼·ú" }, {"DF", "¼¼·ú" }, //¼¼·ú
            {"ai", "±¸»æ" }, {"aI", "±¸»æ" }, {"Ai", "±¸»æ" }, {"AI", "±¸»æ" }, //±¸»æ
            {"dj", "Àå»ç" }, {"dJ", "Àå»ç" }, {"Dj", "Àå»ç" }, {"DJ", "Àå»ç" }, //Àå»ç
            {"ad", "µ¶»ç" }, {"aD", "µ¶»ç" }, {"Ad", "µ¶»ç" }, {"AD", "µ¶»ç" }, //µ¶»ç
            {"aj", "Àå»æ" }, {"aJ", "Àå»æ" }, {"Aj", "Àå»æ" }, {"AJ", "Àå»æ" }, //Àå»æ
            {"ab", "¾Ë¸®" }, {"aB", "¾Ë¸®" }, {"Ab", "¾Ë¸®" }, {"AB", "¾Ë¸®" }, //¾Ë¸®

            {"AC", "ÀÏ»ï±¤¶¯" }, {"AH", "ÀÏÆÈ±¤¶¯" }, {"CH", "»ïÆÈ±¤¶¯" }, //±¤¶¯

            {"cg", "¶¯ÀâÀÌ or ¸ÁÅë" }, {"Cg", "¶¯ÀâÀÌ or ¸ÁÅë" }, {"cG", "¶¯ÀâÀÌ or ¸ÁÅë" },
            {"CG", "¶¯ÀâÀÌ or ¸ÁÅë" },

            {"DG", "¾ÏÇà¾î»ç or ÀÏ²ý" }

    };

    Dictionary<int, string> not_in_jokbo_string = new Dictionary<int, string>()
    {
        {0, "¸ÁÅë" }, {1, "ÀÏ²ý" }, {2, "µÎ²ý" }, {3, "¼¼²ý" }, {4, "³×²ý" }, {5, "´Ù¼¸²ý" },
        {6, "¿©¼¸²ý" }, {7, "ÀÏ°ö²ý" }, {8, "¿©´ü²ý" }, {9, "°©¿À" }

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
