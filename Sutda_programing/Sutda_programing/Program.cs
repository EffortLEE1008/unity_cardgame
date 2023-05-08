

using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;

/////////index num[0    1    2    3    4    5    6    7    8    9]
///////////////////1번  2번  3번  4번  5번  6번  7번  8번  9번   10번
string[] deck = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j",
                  "A", "B", "C", "D", "E", "F", "G", "H", "I", "J"};


Dictionary<string, int> jokbo = new Dictionary<string, int>()
{  
    {"aA", 200 }, {"bB", 220}, {"cC", 240}, {"dD", 260},
    {"eE", 280}, {"fF", 300}, {"gG", 320}, {"hH", 340 },
    {"iI", 360}, {"jJ",380}, //땡들

    {"ab", 80 }, {"aB", 80}, {"Ab", 80}, {"AB", 80}, //알리
    {"ad", 70 }, {"aD", 70}, {"Ad", 70}, {"AD", 70}, //독사
    {"ai", 60}, {"aI", 60}, {"Ai", 60}, {"AI", 60}, // 구삥
    {"aj", 50}, {"aJ", 50}, {"Aj", 50}, {"AJ", 50}, //장삥
    {"di", 40}, {"dI", 40}, {"Di", 40}, {"DI", 40}, //장사
    {"df", 30}, {"dF", 30}, {"Df", 30}, {"DF", 30}, //세륙 

    {"AC", 1300}, {"AH", 1300}, {"CH", 3800} //광땡

};


Dictionary<string, int> non_jokbo = new Dictionary<string, int>()
{
    {"a" , 1 }, {"A",1}, {"b",2}, {"B",2}, {"c", 3}, {"C", 3}, {"d", 4}, {"D", 4}, {"e", 5}, {"E", 5},
    {"f", 6}, {"F", 6}, {"g", 7}, {"G", 7}, {"h", 8}, {"H", 8}, {"i", 9}, {"I", 9}, {"j", 10}, {"J", 10}
};

List<string> ddang_list = new List<string>()
{
    "aA", "bB", "cC", "dD", "eE", "fF", "gG", "hH", "iI", "jJ"
};

List<string> ddang_killer = new List<string>()
{
    "cg", "cG", "Cg", "CG"
};

List<string> gang_list = new List<string>()
{
    "AH", "AC"
};

//List 사용해서 player0 만들고, 카드 2장 넣어보기.


List<string> player0 = new List<string>();
List<string> computer1 = new List<string>();
List<string> computer2 = new List<string>();
List<string> computer3 = new List<string>();

List<string> player_card_list= new List<string>();
List<int> player_value_list = new List<int>();

player0.Add(deck[1]);
player0.Add(deck[11]);                   

computer1.Add(deck[12]);
computer1.Add(deck[10]);

computer2.Add(deck[13]);
computer2.Add(deck[16]);

computer3.Add(deck[2]);
computer3.Add(deck[6]);


player0.Sort();
computer1.Sort();
computer2.Sort();
computer3.Sort();

string concat_player0 = player0[0] + player0[1];
string concat_computer1 = computer1[0] + computer1[1];
string concat_computer2 = computer2[0] + computer2[1];
string concat_computer3 = computer3[0] + computer3[1];

player_card_list.Add(concat_player0);
player_card_list.Add(concat_computer1);
player_card_list.Add(concat_computer2);
player_card_list.Add(concat_computer3);

//변경하기 플레이어card_list로 변경하기

for (int i = 0; i < player_card_list.Count; i++)
{
    if (jokbo.ContainsKey(player_card_list[i]))            //족보에 있는 지 없는지 비교
    {

        player_value_list.Add(jokbo[player_card_list[i]]);

        //Console.WriteLine(concat_player0+"존재합니다.")
    }
    else
    {
        player_value_list.Add((non_jokbo[player_card_list[i][0].ToString()] + non_jokbo[player_card_list[i][1].ToString()]) % 10);


    }


}

for (int i = 0; i < player_card_list.Count; i++)
{
    Console.WriteLine("player_value_list[" + i + "]는 " + player_value_list[i]);
    Console.WriteLine("player_card_list[" + i + "]는 " + player_card_list[i]);
    Console.WriteLine("");
}

Console.WriteLine("ㅡㅡㅡㅡㅡㅡㅡㅡㅡ값 재부여 ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");


bool isDDang = false;


for(int i=0; i<player_card_list.Count; i++)
{
    Console.WriteLine(i + "현재 위치입니다.");
    if (ddang_list.Contains(player_card_list[i]))
    {
        isDDang = true;
        Console.WriteLine("존재합니다.");
        break;
    }

}

//for (int i = 0; i < player_card_list.Count; i++)
//{
//    if (player_value_list[i]>=200 && player_value_list[i] <= 380)
//    {
//        isDDang = true;
//        Console.WriteLine("존재합니다.");
//        break;
//    }
//}

if (isDDang)
{
    for(int i=0; i < player_card_list.Count; i++)
    {
        if (ddang_killer.Contains(player_card_list[i]))
        {
            player_value_list[i] = 400;
        }

    }
}

bool isGang = false;

for(int i=0; i< player_card_list.Count; i++)
{
    if (gang_list.Contains(player_card_list[i]))
    {
        isGang= true;
        break;
    }

}

if (isGang)
{
    for(int i =0; i < player_card_list.Count; i++)
    {
        if (player_card_list[i] == "DG")
        {
            player_value_list[i] = 1500;
        }

    }
}




for (int i = 0; i < player_card_list.Count; i++)
{
    Console.WriteLine("player_value_list[" + i + "]는 " + player_value_list[i]);
    Console.WriteLine("player_card_list[" + i + "]는 " + player_card_list[i]);
    Console.WriteLine("");
}
int max_value = 0;
int max_index = 0;

for (int i = 0; i < player_value_list.Count; i++)
{
    if (max_value < player_value_list[i])
    {
        max_value = player_value_list[i];
        max_index = i;
    }


}
Console.WriteLine("");
Console.WriteLine("maxvalue는 " + max_value);
Console.WriteLine("maxindex는 " + max_index);
















